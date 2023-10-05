namespace MemoryGameLogic
{
    public readonly struct Move
    {
        private readonly int r_Row;
        private readonly int r_Column;

        public int Row
        {
            get => r_Row;
        }

        public int Column
        {
            get => r_Column;
        }

        public Move(int i_Row, int i_Column)
        {
            r_Row = i_Row;
            r_Column = i_Column;
        }
    }
}
