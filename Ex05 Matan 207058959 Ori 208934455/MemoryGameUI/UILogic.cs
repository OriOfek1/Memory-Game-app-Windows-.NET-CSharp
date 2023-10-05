using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryGameLogic;

namespace MemoryGameUI
{
    class UILogic
    {
        private SettingsForm m_SettingsForm;
        private eGameType m_GameType;
        private static Player m_Player1;
        private static Player m_Player2;
        private static eTurn m_Turn;
        private Move m_FirstMove;
        private Move m_SecondMove;
        private Dictionary<Move, char> m_MovesInMemory;
        private int numberOfMovesPlayed = 0;
        private static int m_NumberOfRows;
        private static int m_NumberOfColumns;
        private static GameBoard m_GameBoard;
        private GameForm m_GameForm;
        private eGameBoardSize m_GameBoardSize;
        private char m_TemporaryFirstMoveCharValue;
        private char m_MatchedCharValue;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static int alarmCounter = 1;
        static bool exitFlag = false;

        public static int NumberOfRows
        {
            get => m_NumberOfRows;
        }

        public static int NumberOfColumns
        {
            get => m_NumberOfColumns;
        }

        public static Player Player1
        {
            get => m_Player1;
        }

        public static Player Player2
        {
            get => m_Player2;
        }

        public static GameBoard GameBoard
        {
            get => m_GameBoard;
        }

        public static eTurn Turn
        {
            get => m_Turn;
        }

        public static bool isDuringTurn { get; set; }

        public void Run()
        {
            // TO:DO - create new logic instance
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            m_SettingsForm = new SettingsForm();
            m_GameForm = new GameForm();
            ChooseSettingsForm();
            StartNewGame();
        }

        public void ChooseSettingsForm()
        {
            //m_SettingsForm.ShowDialog();
            Application.Run(m_SettingsForm);
            m_GameType = setGameType();
            m_Player1 = new Player(m_SettingsForm.FirstPlayerName, ePlayerType.Human);
            m_Player2 = setSecondPlayer();
            m_GameBoardSize = m_SettingsForm.GameBoardSize;
            m_NumberOfRows = gameBoardSizeToRowInteger();
            m_NumberOfColumns = gameBoardSizeToColumnInteger();
        }

        public void StartNewGame()
        {
            m_GameBoard = new GameBoard(m_NumberOfRows, m_NumberOfColumns);
            m_MovesInMemory = new Dictionary<Move, char>();
            m_Player1.Score = 0;
            m_Player2.Score = 0;
            m_Turn = eTurn.Player1;
            m_GameForm.GameForm_Load();
            m_GameForm.Activated += playTurns;
            Application.Run(m_GameForm);
        }

        private void playTurns()
        {
            //if(numberOfMovesPlayed == 2)
            //{
            //    if(!isCardsMatch(m_FirstMove, m_SecondMove))
            //    {
            //        m_GameBoard.ClearLastTwoMoveFromBoard(m_FirstMove, m_SecondMove);
            //        //m_GameForm.Update();
            //        m_GameForm.CardButtons[m_FirstMove.Row, m_FirstMove.Column].BackgroundImage = null;
            //        m_GameForm.CardButtons[m_SecondMove.Row, m_SecondMove.Column].BackgroundImage = null;
            //        changeTurn();
            //    }
            //}

            switch (m_Turn)
            {
                case eTurn.Player1:
                    //isDuringTurn = true;
                    //m_CurrentPlayer = Player1;
                    playTurn(Player1);
                    //numberOfMovesPlayed++;

                    //m_GameForm.Activated += null;
                    //playSecondTurn(Player1);
                    //isDuringTurn = false;
                    //changeTurn();
                    //checkIfGameOver();
                    break;
                case eTurn.Player2:
                    playTurn(Player2);
                    //playTurn(Player2);
                    //changeTurn();
                    //checkIfGameOver();
                    break;
            }


        }

        private bool isCardsMatch(Move i_FirstMove, Move i_SecondMove)
        {
            bool isMatched = false;

            if (m_GameBoard.UIGameBoard[i_FirstMove.Row, i_FirstMove.Column]
                == m_GameBoard.UIGameBoard[i_SecondMove.Row, i_SecondMove.Column])
            {
                //m_MatchedCharValue = GameBoard.UiGameBoard[i_FirstMove.Row - 1, i_FirstMove.Column - 1];
                isMatched = true;
            }

            return isMatched;
        }

        private void addMoveToComputerMemory(Move i_MoveToAdd)
        {
            if (!m_MovesInMemory.ContainsKey(i_MoveToAdd))
            {
                m_MovesInMemory.Add(i_MoveToAdd, m_GameBoard.LogicalGameBoard[i_MoveToAdd.Row, i_MoveToAdd.Column]);
            }
        }

        private void changeTurn()
        {
            m_Turn = m_Turn == eTurn.Player1 ? eTurn.Player2 : eTurn.Player1;
            numberOfMovesPlayed = 0;
            string playerName = m_Turn == eTurn.Player1 ? Player1.Name : Player2.Name;
            m_GameForm.UpdateCurrentPlayerLabel(playerName);
            Debug.WriteLine("Changing turns...");
        }

        private void checkIfGameOver()
        {
            if (isGameOver())
            {
                string winnerOrTieMsg = isGameTied() ? "Tie game!" : $"{getWinnerName()} is the winner!";
                string finalResultMsg = string.Format(
                    @"{0}
Final Result: {1}: {2}   {3}: {4}
Do you want to start a new game?",
                    winnerOrTieMsg,
                    Player1.Name,
                    Player1.Score,
                    Player2.Name,
                    Player2.Score);
                string gameOverMsg = "GAME OVER!";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(finalResultMsg, gameOverMsg, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    restartGame();
                }
                else
                {
                    m_GameForm.Close();
                }
            }

        }

        private void restartGame()
        {
            m_GameBoard = new GameBoard(m_NumberOfRows, m_NumberOfColumns);
            m_MovesInMemory = new Dictionary<Move, char>();
            m_MatchedCharValue = ' ';
            m_TemporaryFirstMoveCharValue = ' ';
            m_Player1.Score = 0;
            m_Player2.Score = 0;
            m_Turn = eTurn.Player1;
            m_GameForm.UpdateGameBoard();
        }

        private Move CreateMove(int i_Row, int i_Column)
        {
            Move playerMove = new Move(i_Row, i_Column);
            m_GameBoard.PlaceMoveOnUIBoard(playerMove);
            addMoveToComputerMemory(playerMove);

            return playerMove;
        }

        private void playTurn(Player i_CurrentPlayer)
        {
            switch (i_CurrentPlayer.PlayerType)
            {
                case ePlayerType.Human:
                    Debug.WriteLine(
                        "{0} pressed on: {1},{2}",
                        i_CurrentPlayer.Name,
                        m_GameForm.SelectedRow,
                        m_GameForm.SelectedColumn);
                    int moveRowInput = m_GameForm.SelectedRow;
                    int moveColumnInput = m_GameForm.SelectedColumn;

                    if (numberOfMovesPlayed == 0)
                    {
                        m_FirstMove = CreateMove(moveRowInput, moveColumnInput);
                        numberOfMovesPlayed++;
                    }
                    else
                    {
                        m_SecondMove = CreateMove(moveRowInput, moveColumnInput);
                        if (isCardsMatch(m_FirstMove, m_SecondMove))
                        {
                            numberOfMovesPlayed = 0;
                            playerMakesAHit(i_CurrentPlayer);
                            //m_GameBoard.PrintUiBoard(); // For Debugging
                            //printMemoryOfMoves(); // For Debugging
                            //m_GameBoard.PrintLogicalGameBoard();
                            checkIfGameOver();
                        }
                        else
                        {
                            numberOfMovesPlayed = 0;
                            m_GameForm.DisableAllBoard();
                            Thread.Sleep(2000);
                            //await Task.Delay(2000);
                            m_GameForm.EnableAllBoard();
                            cleanLastMove();
                            //m_GameBoard.PrintUiBoard(); // For Debugging
                            //printMemoryOfMoves(); // For Debugging
                            changeTurn();
                        }
                    }

                    break;

                case ePlayerType.Computer:
                    if (numberOfMovesPlayed == 0)
                    {
                        m_FirstMove = createComputerMove();
                        m_GameForm.CardSelected(m_GameForm.CardButtons[m_FirstMove.Row, m_FirstMove.Column]);
                        numberOfMovesPlayed++;
                        Thread.Sleep(2000);
                        m_GameForm.TimerGameForm.Start();

                    }
                    else
                    {
                        m_SecondMove = createComputerMove();
                        m_GameForm.CardSelected(m_GameForm.CardButtons[m_SecondMove.Row, m_SecondMove.Column]);
                        Thread.Sleep(2000);
                        if (isCardsMatch(m_FirstMove, m_SecondMove))
                        {
                            numberOfMovesPlayed = 0;
                            playerMakesAHit(i_CurrentPlayer);
                            //m_GameBoard.PrintUiBoard(); // For Debugging
                            //printMemoryOfMoves(); // For Debugging
                            //m_GameBoard.PrintLogicalGameBoard();
                            checkIfGameOver();
                        }
                        else
                        {
                            numberOfMovesPlayed = 0;
                            m_GameForm.DisableAllBoard();
                            m_GameForm.TimerGameForm.Start();
                            m_GameForm.EnableAllBoard();
                            cleanLastMove();
                            //m_GameBoard.PrintUiBoard(); // For Debugging
                            //printMemoryOfMoves(); // For Debugging
                            changeTurn();
                        }
                    }

                    break;
            }
        }

        private Move createComputerMove()
        {
            Move computerMove = computerRandomMoveGenerator();

            if (numberOfMovesPlayed == 0)
            {
                if (isExistsMatchingPairOfMovesInMemory())
                {
                    computerMove = m_MovesInMemory.GroupBy(i_SquareVal => i_SquareVal.Value)
                        .SelectMany(i_SquareVal => i_SquareVal.Reverse().Skip(1)).Select(i_Move => i_Move.Key).First();
                    m_MovesInMemory.TryGetValue(computerMove, out m_TemporaryFirstMoveCharValue);
                }
                else
                {
                    m_TemporaryFirstMoveCharValue = ' ';
                }
            }
            else
            {
                if (m_TemporaryFirstMoveCharValue != ' ')
                {
                    computerMove = m_MovesInMemory.Where(i_SquareVal => i_SquareVal.Value == m_TemporaryFirstMoveCharValue)
                        .Select(i_SquareVal => i_SquareVal.Key).Last();
                    m_MatchedCharValue = m_TemporaryFirstMoveCharValue;
                }

                m_TemporaryFirstMoveCharValue = ' ';
            }

            m_GameBoard.PlaceMoveOnUIBoard(computerMove);
            addMoveToComputerMemory(computerMove);
            return computerMove;
        }

        private bool isExistsMatchingPairOfMovesInMemory()
        {
            return m_MovesInMemory.GroupBy(i_Move => i_Move.Value).Any(i_Move => i_Move.Count() > 1);
        }

        private Move computerRandomMoveGenerator()
        {
            Random random = new Random();
            int randomColumn;
            int randomRow;

            do
            {
                randomColumn = random.Next(0, NumberOfColumns);
                randomRow = random.Next(0, NumberOfRows);
            }
            while (!isCardAlreadyRevealed(randomRow, randomColumn));

            Move computerGeneratedMove = new Move(randomRow, randomColumn);

            return computerGeneratedMove;
        }

        private bool isCardAlreadyRevealed(int i_Row, int i_Column)
        {
            return GameBoard.UIGameBoard[i_Row, i_Column] == ' ';
        }

        private void playerMakesAHit(Player io_CurrentPlayer)
        {
            m_GameBoard.NumOfRevealedPairs++;
            io_CurrentPlayer.Score++;
            m_GameForm.UpdateCurrentPlayerScore(io_CurrentPlayer.Name, io_CurrentPlayer.Score);
            removeMatchedMovesFromMemory();
        }

        private bool isGameOver()
        {
            return m_GameBoard.NumOfRevealedPairs == m_GameBoard.TotalNumOfPairs;
        }

        private void removeMatchedMovesFromMemory()
        {
            m_MovesInMemory.Remove(m_FirstMove);
            m_MovesInMemory.Remove(m_SecondMove);
        }

        private void cleanLastMove()
        {
            m_GameBoard.UIGameBoard[m_FirstMove.Row, m_FirstMove.Column] = ' ';
            m_GameBoard.UIGameBoard[m_SecondMove.Row, m_SecondMove.Column] = ' ';

            m_GameForm.CardButtons[m_FirstMove.Row, m_FirstMove.Column].BackgroundImage = null;
            m_GameForm.CardButtons[m_FirstMove.Row, m_FirstMove.Column].Enabled = true;

            m_GameForm.CardButtons[m_SecondMove.Row, m_SecondMove.Column].BackgroundImage = null;
            m_GameForm.CardButtons[m_SecondMove.Row, m_SecondMove.Column].Enabled = true;
        }

        private void playSecondTurn(Player i_CurrentPlayer)
        {
            Debug.WriteLine("{0} pressed on: {1},{2}", i_CurrentPlayer.Name, m_GameForm.SelectedRow, m_GameForm.SelectedColumn);
            int secondMoveRowInput = m_GameForm.SelectedRow;
            int secondMoveColumnInput = m_GameForm.SelectedColumn;
            Move secondMove = CreateMove(secondMoveRowInput, secondMoveColumnInput);
        }

        private eGameType setGameType()
        {
            return m_SettingsForm.SecondPlayerNameTextBox.Enabled ? eGameType.VsPlayer : eGameType.VsComputer;
        }

        private Player setSecondPlayer()
        {
            return m_GameType == eGameType.VsPlayer
                       ? new Player(m_SettingsForm.SecondPlayerName, ePlayerType.Human)
                       : new Player("Computer", ePlayerType.Computer);
        }

        private void printMemoryOfMoves()
        {
            StringBuilder movesInMemory = new StringBuilder();

            foreach (var move in m_MovesInMemory)
            {
                //Debug.WriteLine();`
                string moveString = string.Format(
                    @"Position: [{0},{1}], Value: {2}
",
                    move.Key.Row,
                    move.Key.Column,
                    move.Value);
                movesInMemory.Append(moveString);
            }

            Debug.WriteLine(movesInMemory);
        }

        private int gameBoardSizeToRowInteger()
        {
            int numOfRows;
            switch (m_GameBoardSize)
            {
                case eGameBoardSize.fourOnFour:
                case eGameBoardSize.fourOnFive:
                case eGameBoardSize.fourOnSix:
                    numOfRows = 4;
                    break;
                case eGameBoardSize.fiveOnFour:
                case eGameBoardSize.fiveOnSix:
                    numOfRows = 5;
                    break;
                case eGameBoardSize.sixOnFour:
                case eGameBoardSize.sixOnFive:
                case eGameBoardSize.sixOnSix:
                    numOfRows = 6;
                    break;
                default:
                    numOfRows = 4;
                    break;
            }

            return numOfRows;
        }

        private string getWinnerName()
        {
            string winnerName = string.Empty;
            if (Player1.Score > Player2.Score)
            {
                winnerName = Player1.Name;
            }
            else if (Player2.Score > Player1.Score)
            {
                winnerName = Player2.Name;
            }

            return winnerName;
        }

        private bool isGameTied()
        {
            return Player1.Score == Player2.Score;
        }

        private static void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            myTimer.Stop();

            // Displays a message box asking whether to continue running the timer.
            if (MessageBox.Show("Continue running?", "Count is: " + alarmCounter,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Restarts the timer and increments the counter.
                alarmCounter += 1;
                myTimer.Enabled = true;
            }
            else
            {
                // Stops the timer.
                exitFlag = true;
            }
        }

        private int gameBoardSizeToColumnInteger()
        {
            int numOfColumns;
            switch (m_GameBoardSize)
            {
                case eGameBoardSize.fourOnFour:
                case eGameBoardSize.fiveOnFour:
                case eGameBoardSize.sixOnFour:
                    numOfColumns = 4;
                    break;
                case eGameBoardSize.fourOnFive:
                case eGameBoardSize.sixOnFive:
                    numOfColumns = 5;
                    break;
                case eGameBoardSize.fourOnSix:
                case eGameBoardSize.fiveOnSix:
                case eGameBoardSize.sixOnSix:
                    numOfColumns = 6;
                    break;
                default:
                    numOfColumns = 4;
                    break;
            }

            return numOfColumns;
        }
    }

    public enum eGameType
    {
        VsPlayer,
        VsComputer,
    }

    public enum eGameBoardSize
    {
        [Description("4 x 4")]
        fourOnFour,
        [Description("4 x 5")]
        fourOnFive,
        [Description("4 x 6")]
        fourOnSix,
        [Description("5 x 4")]
        fiveOnFour,
        [Description("5 x 6")]
        fiveOnSix,
        [Description("6 x 4")]
        sixOnFour,
        [Description("6 x 5")]
        sixOnFive,
        [Description("6 x 6")]
        sixOnSix,
    }

    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }

    }
}
