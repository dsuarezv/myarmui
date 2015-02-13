using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyArmClient
{


    public class Client: IDisposable
    {

        public event AnglesDelegate AnglesReceived;


        public AxesCalibration CalibrationData
        {
            get { return mCalibrationData; }
        }


        public Client(string comPort)
        {
            mComPortName = comPort;
        }

        public void Dispose()
        {
            // Dave: terminate reading thread

            lock (mWriteLock)
            {
                if (mPort == null) return;

                mPort.Dispose();
                mPort = null;
                mPortWriter = null;
            }
        }


        public void Attach()
        {
            if (mPort != null) Detach();

            mPort = new SerialPort(mComPortName, 115200);
            mPort.Open();
            mPortWriter = new BinaryWriter(mPort.BaseStream);
            LaunchReadingThread();
        }

        public void Detach()
        {
            Dispose();
        }


        // __ Public commands _________________________________________________


        public void SaveConfiguration(string fileName)
        {
            mCalibrationData.Save(fileName);
        }

        public void LoadConfiguration(string fileName)
        {
            mCalibrationData = AxesCalibration.Load(fileName);
        }

        public void Engage()
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.Engage);
                WriteCrc(null);
            }
        }

        public void Disengage()
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.Disengage);
                WriteCrc(null);
            }
        }

        public void Ping()
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.Ping);
                WriteCrc(null);
            }
        }

        public void SetAngles(double a1, double a2, double rotation, double gripperRotation)
        {
            if (!IsConnected()) return;

            if (double.IsNaN(a1) || double.IsNaN(a2) || double.IsNaN(rotation) || double.IsNaN(gripperRotation)) return;

            SetPulses(
                mCalibrationData.Right.GetPulsesForAngle(a1),
                mCalibrationData.Left.GetPulsesForAngle(a2),
                mCalibrationData.Rotation.GetPulsesForAngle(rotation),
                mCalibrationData.Gripper.GetPulsesForAngle(gripperRotation));
        }

        public void SetPulses(Int16 a1, Int16 a2, Int16 rotation, Int16 gripperRotation)
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.SetAngles);
                mPortWriter.Write(a1);
                mPortWriter.Write(a2);
                mPortWriter.Write(rotation);
                mPortWriter.Write(gripperRotation);

                WriteCrc(null);
            }
        }

        public void ReadAngles()
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.GetAngles);
                WriteCrc(null);
            }
        }


        // _ Write helpers ____________________________________________________


        private void WriteHeader(PacketType type)
        {
            if (mPortWriter == null) return;

            mPortWriter.Write(HeaderMagic);
            mPortWriter.Write((byte)type);
        }

        private void Flush()
        {
            if (mPortWriter == null) return;

            mPortWriter.Flush();
        }

        private void WriteCrc(byte[] data)
        {
            // TBD

            Flush();
        }

        private bool CheckCrc(byte[] data)
        {
            return true;
        }


        // __ Response handlers _______________________________________________


        private void ProcessAnglesResponse(BinaryReader r)
        {
            var a1 = r.ReadInt16();
            var a2 = r.ReadInt16();
            var rotation = r.ReadInt16();
            var gripperRotation = r.ReadInt16();

            if (!CheckCrc(null)) return;

            if (AnglesReceived != null) AnglesReceived(a1, a2, rotation, gripperRotation);
        }


        private void ProcessPingResponse(BinaryReader r)
        {
            // Notify ping response received
        }


        // __ Serial port management __________________________________________


        private bool IsConnected()
        {
            return (mPortWriter != null);
        }

        private void LaunchReadingThread()
        {
            Thread t = new Thread(new ThreadStart(ReadWorker));
            t.Name = "SerialPort read";
            t.IsBackground = true;
            t.Start();
        }

        private void ReadWorker()
        {
            try
            {
                using (BinaryReader r = new BinaryReader(mPort.BaseStream))
                {
                    while (true)
                    {
                        ProcessPacket(r);
                    }
                }
            }
            catch
            {
                Dispose();
            }
        }

        private void ProcessPacket(BinaryReader r)
        {
            byte b = r.ReadByte();
            if (b != HeaderMagic) return;

            var typeByte = r.ReadByte();
            PacketType type = (PacketType)typeByte;
            
            switch (type)
            {
                case PacketType.AnglesResponse:
                    ProcessAnglesResponse(r);
                    break;

                case PacketType.PingResponse:
                    ProcessPingResponse(r);
                    break;

                default:
                    // discard unknown packet
                    break;
            }
        }




       
        private const byte HeaderMagic = 255;

        private enum PacketType
        {
            GetAngles = 254,
            SetAngles = 253,
            Engage = 252,
            Disengage = 251,
            AnglesResponse = 250,
            Ping = 249,
            PingResponse = 248
        }

        private AxesCalibration mCalibrationData = new AxesCalibration();
        private string mComPortName;
        private SerialPort mPort;
        private BinaryWriter mPortWriter;
        private object mWriteLock = new Object();
    }


    public delegate void AnglesDelegate(Int16 a1, Int16 a2, Int16 rot, Int16 gripRot);
}
