using System;
using System.Windows.Forms;

namespace MemoryGameUI
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UILogic uiLogic = new UILogic();
            uiLogic.Run();
        }
    }
}
