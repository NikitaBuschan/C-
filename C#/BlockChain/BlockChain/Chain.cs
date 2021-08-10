using System.Collections.Generic;

namespace BlockChain
{
    public class Chain
    {
        public List<Block> Blocks { get; private set; }
        public Block Last { get; private set; }

        public Chain()
        {
            Blocks = new List<Block>();
            var genesisBlock = new Block();
            //Blocks
        }
    }
}
