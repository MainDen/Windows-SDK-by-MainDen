using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Interception
{
    public class MemoryContext
    {
        public IntPtr ProcessHandle { get; set; }

        public IntPtr BaseAddress { get; set; }

        public byte[] Read(int count)
        {
            return Read(ProcessHandle, BaseAddress, count);
        }
        #region ReadType
        public Boolean ReadBoolean()
        {
            return ReadBoolean(ProcessHandle, BaseAddress);
        }

        public Byte ReadByte()
        {
            return ReadByte(ProcessHandle, BaseAddress);
        }

        public Char ReadChar()
        {
            return ReadChar(ProcessHandle, BaseAddress);
        }

        public Double ReadDouble()
        {
            return ReadDouble(ProcessHandle, BaseAddress);
        }

        public Int16 ReadInt16()
        {
            return ReadInt16(ProcessHandle, BaseAddress);
        }

        public Int32 ReadInt32()
        {
            return ReadInt32(ProcessHandle, BaseAddress);
        }

        public Int64 ReadInt64()
        {
            return ReadInt64(ProcessHandle, BaseAddress);
        }

        public IntPtr ReadIntPtr()
        {
            return ReadIntPtr(ProcessHandle, BaseAddress);
        }

        public Single ReadSingle()
        {
            return ReadSingle(ProcessHandle, BaseAddress);
        }

        public UInt16 ReadUInt16()
        {
            return ReadUInt16(ProcessHandle, BaseAddress);
        }

        public UInt32 ReadUInt32()
        {
            return ReadUInt32(ProcessHandle, BaseAddress);
        }

        public UInt64 ReadUInt64()
        {
            return ReadUInt64(ProcessHandle, BaseAddress);
        }

        public UIntPtr ReadUIntPtr()
        {
            return ReadUIntPtr(ProcessHandle, BaseAddress);
        }
        #endregion
        public byte[] Read(IntPtr address, int count)
        {
            return Read(ProcessHandle, address, count);
        }
        #region ReadType
        public Boolean ReadBoolean(IntPtr address)
        {
            return ReadBoolean(ProcessHandle, address);
        }

        public Byte ReadByte(IntPtr address)
        {
            return ReadByte(ProcessHandle, address);
        }

        public Char ReadChar(IntPtr address)
        {
            return ReadChar(ProcessHandle, address);
        }

        public Double ReadDouble(IntPtr address)
        {
            return ReadDouble(ProcessHandle, address);
        }

        public Int16 ReadInt16(IntPtr address)
        {
            return ReadInt16(ProcessHandle, address);
        }

        public Int32 ReadInt32(IntPtr address)
        {
            return ReadInt32(ProcessHandle, address);
        }

        public Int64 ReadInt64(IntPtr address)
        {
            return ReadInt64(ProcessHandle, address);
        }

        public IntPtr ReadIntPtr(IntPtr address)
        {
            return ReadIntPtr(ProcessHandle, address);
        }

        public Single ReadSingle(IntPtr address)
        {
            return ReadSingle(ProcessHandle, address);
        }

        public UInt16 ReadUInt16(IntPtr address)
        {
            return ReadUInt16(ProcessHandle, address);
        }

        public UInt32 ReadUInt32(IntPtr address)
        {
            return ReadUInt32(ProcessHandle, address);
        }

        public UInt64 ReadUInt64(IntPtr address)
        {
            return ReadUInt64(ProcessHandle, address);
        }

        public UIntPtr ReadUIntPtr(IntPtr address)
        {
            return ReadUIntPtr(ProcessHandle, address);
        }
        #endregion
        public byte[] Read(int baseAddressOffset, int count)
        {
            return Read(ProcessHandle, BaseAddress + baseAddressOffset, count);
        }
        #region ReadType
        public Boolean ReadBoolean(int baseAddressOffset)
        {
            return ReadBoolean(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public Byte ReadByte(int baseAddressOffset)
        {
            return ReadByte(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public Char ReadChar(int baseAddressOffset)
        {
            return ReadChar(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public Double ReadDouble(int baseAddressOffset)
        {
            return ReadDouble(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public Int16 ReadInt16(int baseAddressOffset)
        {
            return ReadInt16(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public Int32 ReadInt32(int baseAddressOffset)
        {
            return ReadInt32(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public Int64 ReadInt64(int baseAddressOffset)
        {
            return ReadInt64(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public IntPtr ReadIntPtr(int baseAddressOffset)
        {
            return ReadIntPtr(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public Single ReadSingle(int baseAddressOffset)
        {
            return ReadSingle(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public UInt16 ReadUInt16(int baseAddressOffset)
        {
            return ReadUInt16(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public UInt32 ReadUInt32(int baseAddressOffset)
        {
            return ReadUInt32(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public UInt64 ReadUInt64(int baseAddressOffset)
        {
            return ReadUInt64(ProcessHandle, BaseAddress + baseAddressOffset);
        }

        public UIntPtr ReadUIntPtr(int baseAddressOffset)
        {
            return ReadUIntPtr(ProcessHandle, BaseAddress + baseAddressOffset);
        }
        #endregion
        public void Write(byte[] buffer, int offset, int count)
        {
            Write(ProcessHandle, BaseAddress, buffer, offset, count);
        }
        #region WriteType
        public void Write(Boolean value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(Byte value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(Char value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(Double value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(Int16 value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(Int32 value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(Int64 value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(IntPtr value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(Single value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(UInt16 value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(UInt32 value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(UInt64 value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }

        public void Write(UIntPtr value)
        {
            Write(ProcessHandle, BaseAddress, value);
        }
        #endregion
        public void Write(IntPtr address, byte[] buffer, int offset, int count)
        {
            Write(ProcessHandle, address, buffer, offset, count);
        }
        #region WriteType
        public void Write(IntPtr address, Boolean value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, Byte value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, Char value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, Double value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, Int16 value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, Int32 value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, Int64 value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, IntPtr value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, Single value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, UInt16 value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, UInt32 value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, UInt64 value)
        {
            Write(ProcessHandle, address, value);
        }

        public void Write(IntPtr address, UIntPtr value)
        {
            Write(ProcessHandle, address, value);
        }
        #endregion
        public void Write(int baseAddressOffset, byte[] buffer, int offset, int count)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, buffer, offset, count);
        }
        #region WriteType
        public void Write(int baseAddressOffset, Boolean value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, Byte value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, Char value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, Double value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, Int16 value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, Int32 value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, Int64 value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, IntPtr value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, Single value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, UInt16 value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, UInt32 value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, UInt64 value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }

        public void Write(int baseAddressOffset, UIntPtr value)
        {
            Write(ProcessHandle, BaseAddress + baseAddressOffset, value);
        }
        #endregion
        public static byte[] Read(IntPtr processHandle, IntPtr address, int count)
        {
            if (processHandle == IntPtr.Zero)
                throw new ArgumentException($"Invalid {nameof(processHandle)}.");
            if (address == IntPtr.Zero)
                throw new ArgumentException($"Invalid {nameof(address)}.");
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            byte[] block = new byte[count];
            if (Process.ReadProcessMemory(processHandle, address, block, count, out var readCount))
                if (readCount == (IntPtr)count)
                    return block;
            throw new Exception($"ReadProcessMemory error ({Process.GetLastError()}).");
        }
        #region ReadType
        public static Boolean ReadBoolean(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToBoolean(Read(processHandle, address, sizeof(Boolean)));
        }

        public static Byte ReadByte(IntPtr processHandle, IntPtr address)
        {
            return Read(processHandle, address, sizeof(Byte))[0];
        }

        public static Char ReadChar(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToChar(Read(processHandle, address, sizeof(Char)));
        }

        public static Double ReadDouble(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToDouble(Read(processHandle, address, sizeof(Double)));
        }

        public static Int16 ReadInt16(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToInt16(Read(processHandle, address, sizeof(Int16)));
        }

        public static Int32 ReadInt32(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToInt32(Read(processHandle, address, sizeof(Int32)));
        }

        public static Int64 ReadInt64(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToInt64(Read(processHandle, address, sizeof(Int64)));
        }

        public static IntPtr ReadIntPtr(IntPtr processHandle, IntPtr address)
        {
            if (IntPtr.Size == 4)
                return (IntPtr)ReadInt32(processHandle, address);
            else if (IntPtr.Size == 8)
                return (IntPtr)ReadInt64(processHandle, address);
            else
                throw new MethodAccessException($"Unexpected size of {nameof(IntPtr)}.");
        }

        public static Single ReadSingle(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToSingle(Read(processHandle, address, sizeof(Single)));
        }

        public static UInt16 ReadUInt16(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToUInt16(Read(processHandle, address, sizeof(UInt16)));
        }

        public static UInt32 ReadUInt32(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToUInt32(Read(processHandle, address, sizeof(UInt32)));
        }

        public static UInt64 ReadUInt64(IntPtr processHandle, IntPtr address)
        {
            return BitConverter.ToUInt64(Read(processHandle, address, sizeof(UInt64)));
        }

        public static UIntPtr ReadUIntPtr(IntPtr processHandle, IntPtr address)
        {
            if (UIntPtr.Size == 4)
                return (UIntPtr)ReadUInt32(processHandle, address);
            else if (UIntPtr.Size == 8)
                return (UIntPtr)ReadUInt64(processHandle, address);
            else
                throw new MethodAccessException($"Unexpected size of {nameof(UIntPtr)}.");
        }
        #endregion
        public static void Write(IntPtr processHandle, IntPtr address, byte[] buffer, int offset, int count)
        {
            if (processHandle == IntPtr.Zero)
                throw new ArgumentException($"Invalid {nameof(processHandle)}.");
            if (address == IntPtr.Zero)
                throw new ArgumentException($"Invalid {nameof(address)}.");
            if (buffer is null)
                throw new ArgumentNullException(nameof(buffer));
            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            int maxCount = buffer.Length - offset;
            if (maxCount < count)
                throw new ArgumentException($"The number of bytes in {nameof(buffer)} is less than {nameof(offset)} plus {nameof(count)}.");
            byte[] block = new byte[count];
            Buffer.BlockCopy(buffer, offset, block, 0, count);
            if (Process.WriteProcessMemory(processHandle, address, block, count, out var writeCount))
                if (writeCount == (IntPtr)count)
                    return;
            throw new Exception($"WriteProcessMemory error ({Process.GetLastError()}).");
        }
        #region WriteType
        public static void Write(IntPtr processHandle, IntPtr address, Boolean value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(Boolean));
        }

        public static void Write(IntPtr processHandle, IntPtr address, Byte value)
        {
            byte[] buffer = new byte[] { value };
            Write(processHandle, address, buffer, 0, sizeof(Byte));
        }

        public static void Write(IntPtr processHandle, IntPtr address, Char value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(Char));
        }

        public static void Write(IntPtr processHandle, IntPtr address, Double value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(Double));
        }

        public static void Write(IntPtr processHandle, IntPtr address, Int16 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(Int16));
        }

        public static void Write(IntPtr processHandle, IntPtr address, Int32 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(Int32));
        }

        public static void Write(IntPtr processHandle, IntPtr address, Int64 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(Int64));
        }

        public static void Write(IntPtr processHandle, IntPtr address, IntPtr value)
        {
            if (IntPtr.Size == 4)
                Write(processHandle, address, (Int32)value);
            else if (IntPtr.Size == 8)
                Write(processHandle, address, (Int64)value);
            else
                throw new MethodAccessException($"Unexpected size of {nameof(IntPtr)}.");
        }

        public static void Write(IntPtr processHandle, IntPtr address, Single value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(Single));
        }

        public static void Write(IntPtr processHandle, IntPtr address, UInt16 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(UInt16));
        }

        public static void Write(IntPtr processHandle, IntPtr address, UInt32 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(UInt32));
        }

        public static void Write(IntPtr processHandle, IntPtr address, UInt64 value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            Write(processHandle, address, buffer, 0, sizeof(UInt64));
        }

        public static void Write(IntPtr processHandle, IntPtr address, UIntPtr value)
        {
            if (UIntPtr.Size == 4)
                Write(processHandle, address, (UInt32)value);
            else if (UIntPtr.Size == 8)
                Write(processHandle, address, (UInt64)value);
            else
                throw new MethodAccessException($"Unexpected size of {nameof(UIntPtr)}.");
        }
        #endregion
    }
}
