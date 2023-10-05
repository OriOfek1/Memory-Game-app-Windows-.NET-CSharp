using System;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MemoryGameLogic
{
    public class GameBoard
    {
        private const string k_ReversedCharset = "ZYXWVUTSRQPONMLKJI";
        private readonly int r_Rows = 0;
        private readonly int r_Columns = 0;
        private readonly int r_TotalNumOfPairs = 0;
        private readonly char[,] m_LogicalGameBoard;
        private char[,] m_UiGameBoard;
        private int m_NumberOfRevealedPairs = 0;

        public char[,] LogicalGameBoard
        {
            get => m_LogicalGameBoard;
        }

        public char[,] UIGameBoard
        {
            get => m_UiGameBoard;
        }

        public int TotalNumOfPairs
        {
            get => r_TotalNumOfPairs;
        }

        public int NumOfRevealedPairs
        {
            get => m_NumberOfRevealedPairs;
            set => m_NumberOfRevealedPairs = value;
        }

        public GameBoard(int i_Rows, int i_Columns)
        {
            r_Rows = i_Rows;
            r_Columns = i_Columns;
            r_TotalNumOfPairs = i_Rows * i_Columns / 2;
            Debug.WriteLine("Total Num Of Pairs: {0}", r_TotalNumOfPairs);
            m_LogicalGameBoard = new char[r_Rows, r_Columns];
            m_UiGameBoard = new char[r_Rows, r_Columns];
            fillGameBoard(r_Rows, r_Columns);
            PrintLogicalGameBoard(); // For Debugging
            initializeUiBoard();
            PrintUiBoard(); // For Debugging
        }

        private void fillGameBoard(int i_Rows, int i_Columns)
        {
            char[] pairsOfChars = new char[i_Rows * i_Columns];
            Random rnd = new Random();

            for (int i = 0; i < pairsOfChars.Length; i += 2)
            {
                char ch = k_ReversedCharset[i / 2];
                pairsOfChars[i] = ch;
                pairsOfChars[i + 1] = ch;
            }

            pairsOfChars = pairsOfChars.OrderBy(i_Char => rnd.Next()).ToArray();

            for (int i = 0, k = 0; i < i_Rows; i++)
            {
                for (int j = 0; j < i_Columns; j++)
                {
                    m_LogicalGameBoard[i, j] = pairsOfChars[k++];
                }
            }
        }

        private void initializeUiBoard()
        {
            for (int i = 0; i < r_Rows; i++)
            {
                for (int j = 0; j < r_Columns; j++)
                {
                    m_UiGameBoard[i, j] = ' ';
                }
            }
        }

        public void PlaceMoveOnUIBoard(Move i_Move)
        {
            m_UiGameBoard[i_Move.Row, i_Move.Column] = LogicalGameBoard[i_Move.Row, i_Move.Column];
        }

        public void ClearLastTwoMoveFromBoard(Move i_FirstMove, Move i_SecondMove)
        {
            m_UiGameBoard[i_FirstMove.Row, i_FirstMove.Column] = ' ';
            m_UiGameBoard[i_SecondMove.Row, i_SecondMove.Column] = ' ';
        }

        // Debugging Methods

        public void PrintUiBoard()
        {
            const string k_CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder gameBoardView = new StringBuilder();

            for (int k = 0; k < r_Columns; k++)
            {
                if (k == 0)
                {
                    string firstLineFirstColumnIndex = string.Format(@"     {0}", k_CharSet[k]);

                    gameBoardView.Append(firstLineFirstColumnIndex);
                }
                else
                {
                    string columnsIndexesLine = string.Format(@"   {0}", k_CharSet[k]);
                    gameBoardView.Append(columnsIndexesLine);
                }
            }

            gameBoardView.AppendLine();

            for (int i = 0; i < r_Rows; i++)
            {
                appendEqualSignMarksLine(gameBoardView, r_Columns);
                appendLineOfChars(gameBoardView, r_Columns, i, m_UiGameBoard);
            }

            Debug.WriteLine(gameBoardView);
        }

        public void PrintLogicalGameBoard()
        {
            const string k_CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder gameBoardView = new StringBuilder();

            for (int k = 0; k < r_Columns; k++)
            {
                if (k == 0)
                {
                    string firstLineFirstColumnIndex = string.Format(@"     {0}", k_CharSet[k]);

                    gameBoardView.Append(firstLineFirstColumnIndex);
                }
                else
                {
                    string columnsIndexesLine = string.Format(@"   {0}", k_CharSet[k]);
                    gameBoardView.Append(columnsIndexesLine);
                }
            }

            gameBoardView.AppendLine();

            for (int i = 0; i < r_Rows; i++)
            {
                appendEqualSignMarksLine(gameBoardView, r_Columns);
                appendLineOfChars(gameBoardView, r_Columns, i, m_LogicalGameBoard);
            }

            Debug.WriteLine(gameBoardView);
        }

        private static void appendEqualSignMarksLine(StringBuilder i_GameBoardView, int i_Columns)
        {
            i_GameBoardView.Append("  =");

            for (int k = 0; k < i_Columns; k++)
            {
                i_GameBoardView.Append("====");
            }

            i_GameBoardView.AppendLine();
        }

        private static void appendLineOfChars(StringBuilder i_GameBoardView, int i_Columns, int i_Row, char[,] i_LogicalGameBoard)
        {
            string rowStart = string.Format(@" {0} |", i_Row + 1);
            i_GameBoardView.AppendFormat(rowStart);
            for (int j = 0; j < i_Columns; j++)
            {
                string letterBox = string.Format(@" {0} |", i_LogicalGameBoard[i_Row, j]);
                i_GameBoardView.Append(letterBox);
            }

            i_GameBoardView.AppendLine();
        }
    }
}
