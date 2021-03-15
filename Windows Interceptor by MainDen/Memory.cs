using MainDen.Windows.API;
using System;

namespace MainDen.Windows.Interceptor
{
    public class ProcessMemory
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

        public byte[] Read(IntPtr address, int count)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            return Read(pHandle, address, count);
        }

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

        public void Write(byte[] buffer, int offset = 0, int count = 0)
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

        public void Write(IntPtr address, byte[] buffer, int offset = 0, int count = 0)
        {
            IntPtr pHandle;
            lock (lSettings)
                pHandle = processHandle;
            Write(pHandle, address, buffer, offset, count);
        }

        public void Write(int baseAddressOffset, byte[] buffer, int offset = 0, int count = 0)
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

        public static byte[] Read(IntPtr pHandle, IntPtr address, int count)
        {
            if (pHandle == IntPtr.Zero)
                throw new ArgumentException("Invalid ProcessHandle.");
            if (address == IntPtr.Zero)
                throw new ArgumentException("Invalid Address.");
            if (count == 0)
                throw new ArgumentException("Invalid count.");
            byte[] buffer = new byte[count];
            IntPtr readCount;
            if (Proc.ReadProcessMemory(pHandle, address, buffer, count, out readCount))
                if (readCount == (IntPtr)count)
                    return buffer;
            throw new Exception($"ReadProcessMemory error ({Proc.GetLastError()}).");
        }

        public static void Write(IntPtr pHandle, IntPtr address, byte[] buffer, int offset = 0, int count = 0)
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
            IntPtr writeCount;
            if (Proc.WriteProcessMemory(pHandle, address, bufferPart, count, out writeCount))
                if (writeCount == (IntPtr)count)
                    return;
            throw new Exception($"WriteProcessMemory error ({Proc.GetLastError()}).");
        }
    }
}
