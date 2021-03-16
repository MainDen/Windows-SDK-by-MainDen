using MainDen.Windows.API;
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace MainDen.Windows.Interceptor
{
    public class ProcessMemory : ICloneable
    {
        public ProcessMemory(IntPtr processHandle)
        {
            this.processHandle = processHandle;
            baseAddress = IntPtr.Zero;
        }

        public ProcessMemory(IntPtr processHandle, IntPtr baseAddress)
        {
            this.processHandle = processHandle;
            this.baseAddress = baseAddress;
        }

        public ProcessMemory(ProcessMemory processMemory)
        {
            lock (processMemory.lSettings)
            {
                processHandle = processMemory.processHandle;
                baseAddress = processMemory.baseAddress;
            }
        }

        private readonly object lSettings = new object();
        private IntPtr processHandle;
        public IntPtr ProcessHandle
        {
            get
            {
                lock (lSettings)
                    return processHandle;
            }
            set
            {
                lock (lSettings)
                    processHandle = value;
            }
        }
        private IntPtr baseAddress;
        public IntPtr BaseAddress
        {
            get
            {
                lock (lSettings)
                    return baseAddress;
            }
            set
            {
                lock (lSettings)
                    baseAddress = value;
            }
        }

        public byte[] Read(int count)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return Read(pHandle, address, count);
        }
        #region ReadType
        public Boolean ReadBoolean()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadBoolean(pHandle, address);
        }

        public Char ReadChar()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadChar(pHandle, address);
        }

        public Double ReadDouble()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadDouble(pHandle, address);
        }

        public Int16 ReadInt16()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadInt16(pHandle, address);
        }

        public Int32 ReadInt32()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadInt32(pHandle, address);
        }

        public Int64 ReadInt64()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadInt64(pHandle, address);
        }

        public IntPtr ReadIntPtr()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadIntPtr(pHandle, address);
        }

        public Single ReadSingle()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadSingle(pHandle, address);
        }

        public UInt16 ReadUInt16()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadUInt16(pHandle, address);
        }

        public UInt32 ReadUInt32()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadUInt32(pHandle, address);
        }

        public UInt64 ReadUInt64()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadUInt64(pHandle, address);
        }

        public UIntPtr ReadUIntPtr()
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            return ReadUIntPtr(pHandle, address);
        }
        #endregion
        public byte[] Read(IntPtr address, int count)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return Read(pHandle, address, count);
        }
        #region ReadType
        public Boolean ReadBoolean(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadBoolean(pHandle, address);
        }

        public Char ReadChar(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadChar(pHandle, address);
        }

        public Double ReadDouble(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadDouble(pHandle, address);
        }

        public Int16 ReadInt16(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadInt16(pHandle, address);
        }

        public Int32 ReadInt32(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadInt32(pHandle, address);
        }

        public Int64 ReadInt64(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadInt64(pHandle, address);
        }

        public IntPtr ReadIntPtr(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadIntPtr(pHandle, address);
        }

        public Single ReadSingle(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadSingle(pHandle, address);
        }

        public UInt16 ReadUInt16(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadUInt16(pHandle, address);
        }

        public UInt32 ReadUInt32(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadUInt32(pHandle, address);
        }

        public UInt64 ReadUInt64(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadUInt64(pHandle, address);
        }

        public UIntPtr ReadUIntPtr(IntPtr address)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return ReadUIntPtr(pHandle, address);
        }
        #endregion
        public byte[] Read(int baseAddressOffset, int count)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return Read(pHandle, address, count);
        }
        #region ReadType
        public Boolean ReadBoolean(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadBoolean(pHandle, address);
        }

        public Char ReadChar(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadChar(pHandle, address);
        }

        public Double ReadDouble(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadDouble(pHandle, address);
        }

        public Int16 ReadInt16(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadInt16(pHandle, address);
        }

        public Int32 ReadInt32(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadInt32(pHandle, address);
        }

        public Int64 ReadInt64(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadInt64(pHandle, address);
        }

        public IntPtr ReadIntPtr(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadIntPtr(pHandle, address);
        }

        public Single ReadSingle(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadSingle(pHandle, address);
        }

        public UInt16 ReadUInt16(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadUInt16(pHandle, address);
        }

        public UInt32 ReadUInt32(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadUInt32(pHandle, address);
        }

        public UInt64 ReadUInt64(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadUInt64(pHandle, address);
        }

        public UIntPtr ReadUIntPtr(int baseAddressOffset)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            return ReadUIntPtr(pHandle, address);
        }
        #endregion
        public void Write(byte[] buffer, int offset, int count)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, buffer, offset, count);
        }
        #region WriteType
        public void Write(Boolean value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(Char value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(Double value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(Int16 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(Int32 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(Int64 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(IntPtr value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(Single value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(UInt16 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(UInt32 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(UInt64 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }

        public void Write(UIntPtr value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress;
            }
            Write(pHandle, address, value);
        }
        #endregion
        public void Write(IntPtr address, byte[] buffer, int offset, int count)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, buffer, offset, count);
        }
        #region WriteType
        public void Write(IntPtr address, Boolean value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, Char value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, Double value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, Int16 value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, Int32 value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, Int64 value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, IntPtr value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, Single value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, UInt16 value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, UInt32 value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, UInt64 value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }

        public void Write(IntPtr address, UIntPtr value)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, value);
        }
        #endregion
        public void Write(int baseAddressOffset, byte[] buffer, int offset, int count)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, buffer, offset, count);
        }
        #region WriteType
        public void Write(int baseAddressOffset, Boolean value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, Char value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, Double value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, Int16 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, Int32 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, Int64 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, IntPtr value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, Single value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, UInt16 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, UInt32 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, UInt64 value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }

        public void Write(int baseAddressOffset, UIntPtr value)
        {
            IntPtr pHandle;
            IntPtr address;
            lock (lSettings)
            {
                pHandle = processHandle;
                address = baseAddress + baseAddressOffset;
            }
            Write(pHandle, address, value);
        }
        #endregion
        public static byte[] Read(IntPtr pHandle, IntPtr address, int count)
        {
            if (pHandle == IntPtr.Zero)
                throw new ArgumentException("Invalid ProcessHandle.");
            if (address == IntPtr.Zero)
                throw new ArgumentException("Invalid Address.");
            if (count < 0)
                throw new ArgumentException("Invalid count.");
            byte[] buffer = new byte[count];
            IntPtr readCount = IntPtr.Zero;
            if (Proc.ReadProcessMemory(pHandle, address, buffer, count, out readCount))
                if (readCount == (IntPtr)count)
                    return buffer;
            throw new Exception($"ReadProcessMemory error ({Proc.GetLastError()}).");
        }
        #region ReadType
        public static Boolean ReadBoolean(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToBoolean(Read(pHandle, address, sizeof(Boolean)));
        }

        public static Char ReadChar(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToChar(Read(pHandle, address, sizeof(Char)));
        }

        public static Double ReadDouble(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToDouble(Read(pHandle, address, sizeof(Double)));
        }

        public static Int16 ReadInt16(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToInt16(Read(pHandle, address, sizeof(Int16)));
        }

        public static Int32 ReadInt32(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToInt32(Read(pHandle, address, sizeof(Int32)));
        }

        public static Int64 ReadInt64(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToInt64(Read(pHandle, address, sizeof(Int64)));
        }

        public static IntPtr ReadIntPtr(IntPtr pHandle, IntPtr address)
        {
            return (IntPtr)ReadInt32(pHandle, address);
        }

        public static Single ReadSingle(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToSingle(Read(pHandle, address, sizeof(Single)));
        }

        public static UInt16 ReadUInt16(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToUInt16(Read(pHandle, address, sizeof(UInt16)));
        }

        public static UInt32 ReadUInt32(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToUInt32(Read(pHandle, address, sizeof(UInt32)));
        }

        public static UInt64 ReadUInt64(IntPtr pHandle, IntPtr address)
        {
            return BitConverter.ToUInt64(Read(pHandle, address, sizeof(UInt64)));
        }

        public static UIntPtr ReadUIntPtr(IntPtr pHandle, IntPtr address)
        {
            return (UIntPtr)ReadUInt32(pHandle, address);
        }
        #endregion
        public static void Write(IntPtr pHandle, IntPtr address, byte[] buffer, int offset, int count)
        {
            if (pHandle == IntPtr.Zero)
                throw new ArgumentException("Invalid ProcessHandle.");
            if (address == IntPtr.Zero)
                throw new ArgumentException("Invalid Address.");
            if (buffer is null)
                throw new ArgumentNullException(nameof(buffer));
            int maxCount = buffer.Length - offset;
            if (offset < 0 || maxCount < 0)
                throw new ArgumentException("Invalid offset.");
            if (count < 0 || maxCount < count)
                throw new ArgumentException("Invalid count.");
            byte[] bufferPart;
            if (offset == 0 && count == maxCount)
                bufferPart = buffer;
            else
            {
                bufferPart = new byte[count];
                Buffer.BlockCopy(buffer, offset, bufferPart, 0, count);
            }
            IntPtr writeCount = IntPtr.Zero;
            if (Proc.WriteProcessMemory(pHandle, address, bufferPart, count, out writeCount))
                if (writeCount == (IntPtr)count)
                    return;
            throw new Exception($"WriteProcessMemory error ({Proc.GetLastError()}).");
        }
        #region WriteType
        public static void Write(IntPtr pHandle, IntPtr address, Boolean value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(Boolean));
        }

        public static void Write(IntPtr pHandle, IntPtr address, Char value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(Char));
        }

        public static void Write(IntPtr pHandle, IntPtr address, Double value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(Double));
        }

        public static void Write(IntPtr pHandle, IntPtr address, Int16 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(Int16));
        }

        public static void Write(IntPtr pHandle, IntPtr address, Int32 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(Int32));
        }

        public static void Write(IntPtr pHandle, IntPtr address, Int64 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(Int64));
        }

        public static void Write(IntPtr pHandle, IntPtr address, IntPtr value)
        {
            Write(pHandle, address, (Int32)value);
        }

        public static void Write(IntPtr pHandle, IntPtr address, Single value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(Single));
        }

        public static void Write(IntPtr pHandle, IntPtr address, UInt16 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(UInt16));
        }

        public static void Write(IntPtr pHandle, IntPtr address, UInt32 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(UInt32));
        }

        public static void Write(IntPtr pHandle, IntPtr address, UInt64 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(pHandle, address, buffer, 0, sizeof(UInt64));
        }

        public static void Write(IntPtr pHandle, IntPtr address, UIntPtr value)
        {
            Write(pHandle, address, (UInt32)value);
        }
        #endregion
        public object Clone()
        {
            return new ProcessMemory(this);
        }
    }
}
