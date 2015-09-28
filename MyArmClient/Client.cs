using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MyArmClient
{


    public class Client: IDisposable
    {

        public event AnglesDelegate AnglesReceived;
        public event Action<object, byte> OutOfBandDataReceived;


        public ConcurrentQueue<byte> OutOfBandData
        {
            get { return mOutOfBandBytes; }
        }


        public AxesCalibration CalibrationData
        {
            get { return mCalibrationData; }
            set { mCalibrationData = value; }
        }

        public RobotAngles CurrentAngles
        {
            get { return mCurrentAngles; }
        }


        
        public static string[] GetComPorts()
        {
            return SerialPort.GetPortNames();
        }

        
        public Client()
        {
            
        }

        public void Dispose()
        {
            // Dave: terminate reading thread. Careful with the Dispose call in the trycatch (would deadlock)

            lock (mWriteLock)
            {
                if (mPort == null) return;

                mPort.Dispose();
                mPort = null;
                mPortWriter = null;
            }
        }


        public void Attach(string comPort)
        {
            if (mPort != null) return;

            mComPortName = comPort;
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

        public void GetVersion()
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.GetVersion);
                WriteCrc(null);
            }
        }

        public void SetAngles(RobotAngles angles, short timeInMs = DefaultMovementTime)
        {
            mCurrentAngles = angles;

            if (!IsConnected()) return;

            if (angles.IsNaN()) return;

            SetPulses(
                mCalibrationData.Right.GetPulsesForAngle(angles.A2),
                mCalibrationData.Left.GetPulsesForAngle(angles.A3),
                mCalibrationData.Rotation.GetPulsesForAngle(angles.A1),
                mCalibrationData.Gripper.GetPulsesForAngle(angles.A4), 
                0, 0, timeInMs);
        }

        public void SetPulses(Int16 a2, Int16 a3, Int16 a1, Int16 a4, Int16 a5, Int16 a6, int timeInMs)
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.SetAngles);
                mPortWriter.Write(a1);
                mPortWriter.Write(a2);
                mPortWriter.Write(a3);
                mPortWriter.Write(a4);
                mPortWriter.Write(a5);
                mPortWriter.Write(a6);
                mPortWriter.Write((Int16)timeInMs);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="speed">0 = full speed, 1-255 slower to faster</param>
        public void SetSpeed(int speed)
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(PacketType.SetSpeed);
                mPortWriter.Write((byte)speed);
                WriteCrc(null);
            }
            
        }


        public void PlayPath(Path path)
        {
            path.Play(this);
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
            mPortWriter.Write((byte)0);

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


        private void ProcessGetVersionResponse(BinaryReader r)
        {
            var version = r.ReadByte();
            if (!CheckCrc(new byte[] { version })) return;

            var robotType = version >> 5;
            var firmwareVersion = version & 0x1F;  // 1F = 00011111
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
            if (b != HeaderMagic)
            {
                ProcessOutOfBandByte(b);
                return;
            }

            var typeByte = r.ReadByte();
            PacketType type = (PacketType)typeByte;
            
            switch (type)
            {
                case PacketType.AnglesResponse:
                    ProcessAnglesResponse(r);
                    break;

                case PacketType.GetVersionResponse:
                    ProcessGetVersionResponse(r);
                    break;

                default:
                    // discard unknown packet
                    ProcessOutOfBandByte(b);
                    ProcessOutOfBandByte(typeByte);
                    break;
            }
        }

        private void ProcessOutOfBandByte(byte b)
        {
            mOutOfBandBytes.Enqueue(b);

            if (OutOfBandDataReceived != null) OutOfBandDataReceived(this, b);
        }



        private ConcurrentQueue<byte> mOutOfBandBytes = new ConcurrentQueue<byte>();
        private const byte HeaderMagic = 255;
        private const int DefaultMovementTime = 1000;

        private enum PacketType
        {
            GetAngles = 254,
            SetAngles = 253,
            Engage = 252,
            Disengage = 251,
            AnglesResponse = 250,
            GetVersion = 249,
            GetVersionResponse = 248,
            SetSpeed = 247
        }

        private AxesCalibration mCalibrationData = new AxesCalibration();
        private string mComPortName;
        private SerialPort mPort;
        private BinaryWriter mPortWriter;
        private object mWriteLock = new Object();
        private RobotAngles mCurrentAngles;
    }


    public delegate void AnglesDelegate(Int16 a1, Int16 a2, Int16 rot, Int16 gripRot);
}
