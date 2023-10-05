namespace MemoryGameLogic
{
    public class Player
    {
        private readonly string r_Name;
        private ePlayerType m_PlayerType;
        private int m_Score = 0;

        public string Name
        {
            get => r_Name;
        }

        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }

        public ePlayerType PlayerType
        {
            get => m_PlayerType;
        }

        public Player(string i_Name, ePlayerType i_PlayerType)
        {
            r_Name = i_Name;
            m_PlayerType = i_PlayerType;
        }
    }
}
