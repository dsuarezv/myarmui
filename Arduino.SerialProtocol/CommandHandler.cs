using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arduino.SerialProtocol
{
    public class CommandHandler: IDisposable
    {
        public event PacketReceivedDelegate PacketReceived;
        public event Action<object, byte[]> OutOfBandDataReceived;
        
        
        
        public static string[] GetComPorts()
        {
            return SerialPort.GetPortNames();
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

        public void WritePacket(Packet p)
        {
            if (!IsConnected()) return;

            lock (mWriteLock)
            {
                WriteHeader(p.PacketType);

                if (p.Data != null)
                {
                    mPortWriter.Write(p.Data);
                }

                WriteCrc(p.Data);
            }
        }


        // _ Write helpers ____________________________________________________


        private void WriteHeader(byte type)
        {
            if (mPortWriter == null) return;

            mPortWriter.Write(HeaderMagic1);
            mPortWriter.Write(type);
        }

        private void Flush()
        {
            if (mPortWriter == null) return;

            mPortWriter.Flush();
        }

        private void WriteCrc(byte[] data)
        {
            //mPortWriter.Write(Crc8.ComputeChecksum(data));
            mPortWriter.Write((byte)0);

            Flush();
        }

        private bool CheckCrc(byte[] data, byte checksum)
        {
            //return (Crc8.ComputeChecksum(data) == checksum);

            return true;
        }



        // __ Impl ____________________________________________________________


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
            if (b != HeaderMagic1)
            {
                ProcessOutOfBandBytes(b);
                return;
            }

            var type = r.ReadByte();
            var payloadLen = r.ReadByte();
            var data = r.ReadBytes(payloadLen);
            var checksum = r.ReadByte();

            if (CheckCrc(data, checksum))
            {
                PacketReceived(this, new Packet() { PacketType = type, Data = data });
            }
            else
            {
                ProcessOutOfBandBytes(type, payloadLen);
                ProcessOutOfBandBytes(data);
                ProcessOutOfBandBytes(checksum);
            }
        }

        private void ProcessOutOfBandBytes(params byte[] bytes)
        {
            foreach (var b in bytes) mOutOfBandBytes.Enqueue(b);

            if (OutOfBandDataReceived != null) OutOfBandDataReceived(this, bytes);
        }



        private ConcurrentQueue<byte> mOutOfBandBytes = new ConcurrentQueue<byte>();
        private const byte HeaderMagic1 = 255;
        private const int DefaultMovementTime = 1000;



        private string mComPortName;
        private SerialPort mPort;
        private BinaryWriter mPortWriter;
        private object mWriteLock = new Object();
    }


    public class Packet
    { 
        public byte PacketType;
        public byte[] Data;
    }

    public delegate bool PacketReceivedDelegate(object sender, Packet packet);
}
