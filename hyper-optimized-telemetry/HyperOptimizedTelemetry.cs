using System;
using System.Collections.Generic;

public static class TelemetryBuffer
{
    private const byte LongPrefix = 256 - 8;
    private const byte IntPrefix = 256 - 4;
    private const byte ShortPrefix = 256 - 2;
    private const byte UIntPrefix = 4;
    private const byte UShortPrefix = 2;
    
    public static byte[] ToBuffer(long reading)
    {
        List<byte> buffer = new(9);
        Span<byte> bytes = new Span<byte>(new byte[8]);
        buffer.Add(0);
        
        if (reading >= 0)
        {
            if (reading > uint.MaxValue)
            {
                buffer[0] = LongPrefix;
                BitConverter.TryWriteBytes(bytes, (long)reading);
            }
            else if (reading > int.MaxValue)
            {
                buffer[0] = UIntPrefix;
                BitConverter.TryWriteBytes(bytes, (uint)reading);
            }
            else if (reading > ushort.MaxValue)
            {
                buffer[0] = IntPrefix;
                BitConverter.TryWriteBytes(bytes, (int)reading);
            }
            else
            {
                buffer[0] = UShortPrefix;
                BitConverter.TryWriteBytes(bytes, (ushort)reading);
            }
        }
        else
        {
            if (reading < int.MinValue)
            {
                buffer[0] = LongPrefix;
                BitConverter.TryWriteBytes(bytes, (long)reading);
            }
            else if (reading < short.MinValue)
            {
                buffer[0] = IntPrefix;
                BitConverter.TryWriteBytes(bytes, (int)reading);
            }
            else
            {
                buffer[0] = ShortPrefix;
                BitConverter.TryWriteBytes(bytes, (short)reading);
            }
        }
       
        buffer.AddRange(bytes.ToArray());
        return buffer.ToArray();
    }

    public static long FromBuffer(byte[] buffer)
    {
        return (sbyte) buffer[0] switch
        {
            -8 => BitConverter.ToInt64(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            -4 => BitConverter.ToInt32(buffer, 1),
            2 => BitConverter.ToUInt16(buffer, 1),
            -2 => BitConverter.ToInt16(buffer, 1),
            _ => 0
        };
    }
}
