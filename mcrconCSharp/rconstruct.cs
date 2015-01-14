using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mcrconCSharp
{
    enum PacketType
    {
        CommandResponse = 0,
        Command = 2,
        Login = 3
    }

    struct rconstruct
    {
        public int length
        {
            get
            { return 10 + payload.Length; }
        }
        public int requestId;
        public PacketType type;
        public string payload;
    }

    static class RconStruct
    { //http://wiki.vg/Rcon
        static Encoding encoder = ASCIIEncoding.GetEncoding("us-ascii",
                            new EncoderReplacementFallback(string.Empty),
                            new DecoderExceptionFallback());
        public static byte[] ToBytes(rconstruct input)
        {
            if (input.length > 1460)
                throw new InvalidOperationException("Too long command! Length of command must not be more than 1446 chars but we have " + input.length);

            byte[] buff = new byte[sizeof(int) + input.length];

            byte[] lengthBuff = BitConverter.GetBytes(input.length);
            byte[] requestIdBuff = BitConverter.GetBytes(input.requestId);
            byte[] typeBuff = BitConverter.GetBytes((int)input.type);
            byte[] payloadBuff = encoder.GetBytes(input.payload);


            Array.Copy(lengthBuff, 0, buff, 0, sizeof(int));
            Array.Copy(requestIdBuff, 0, buff, sizeof(int), sizeof(int));
            Array.Copy(typeBuff, 0, buff, sizeof(int) * 2, sizeof(int));
            Array.Copy(payloadBuff, 0, buff, sizeof(int) * 3, payloadBuff.Length);
            buff[buff.Length - 1] = buff[buff.Length - 2] = 0x00;

            return buff;
        }



        public static rconstruct FromBytes(byte[] input)
        {
            int length = BitConverter.ToInt32(input, 0);
            int rId = BitConverter.ToInt32(input, sizeof(int));
            PacketType tp = (PacketType)BitConverter.ToInt32(input, sizeof(int) * 2);
            string pld = encoder.GetString(input, sizeof(int) * 3, length - 10);

            rconstruct a = new rconstruct()
            {
                requestId = rId,
                type = tp,
                payload = pld
            };

            return a;
        }
    }
}
