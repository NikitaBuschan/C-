using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Data
    {
        public Command Command { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }


        public Data()
        {
            Command = Command.Null;
            Name = null;
            Message = null;
        }

        public Data(byte[] data)
        {
            Command = (Command)BitConverter.ToInt32(data, 0);
            int nameLen = BitConverter.ToInt32(data, 4);
            int messageLen = BitConverter.ToInt32(data, 8);
            int nameSize = nameLen * sizeof(char);

            Name = nameLen > 0 ? Encoding.Unicode.GetString(data, 12, nameSize) : null;

            int messageSize = messageLen * sizeof(char);
            Message = messageLen > 0 ? Encoding.Unicode.GetString(data, 12 + nameSize, messageSize) : null;
        }

        public byte[] ToBytes()
        {
            var result = new List<byte>();

            result.AddRange(BitConverter.GetBytes((int)Command));
            result.AddRange(Name != null ? BitConverter.GetBytes(Name.Length) : BitConverter.GetBytes(0));

            if (Name != null)
                result.AddRange(Encoding.Unicode.GetBytes(Name));
            if (Message != null)
                result.AddRange(Encoding.Unicode.GetBytes(Message));

            return result.ToArray();
        }
    }
}
