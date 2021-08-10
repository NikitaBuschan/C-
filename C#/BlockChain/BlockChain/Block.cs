using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain
{
    public class Block
    {
        public int Id { get; private set; }
        public string Data { get; private set; }
        public DateTime Created { get; private set; }
        public string Hash { get; private set; }
        public string PreviousHash { get; private set; }
        public string User { get; private set; }

        /// <summary>
        /// Конструктор генезис блока
        /// </summary>
        public Block()
        {
            Id = 1;
            Data = "Hello, World!";
            Created = DateTime.Parse("01.09.2018 00:00:00.000");
            PreviousHash = "111111";
            User = "Admin";

            var data = GetData();
            Hash = GetHash(data);
        }

        public Block(string data, string user, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException("Empty argument data", nameof(data));
            }

            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException("Empty argument data", nameof(user));
            }

            if (block == null)
            {
                throw new ArgumentNullException("Empty argument block", nameof(block));
            }

            Id = block.Id + 1;
            Data = data;
            Created = DateTime.UtcNow;
            PreviousHash = block.Hash;
            User = user;

            var blockData = GetData();
            Hash = GetHash(blockData);
        }

        private string GetData()
        {
            string result = "";

            result += Id.ToString();
            result += Data;
            result += Created.ToString("dd.MM.yyyy HH:mm:ss.fff");
            result += PreviousHash;
            result += User;

            return result;
        }

        private string GetHash(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            var hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

    }
}
