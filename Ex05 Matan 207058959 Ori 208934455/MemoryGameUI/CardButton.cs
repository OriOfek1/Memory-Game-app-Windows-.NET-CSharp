using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGameUI
{
    public class CardButton : Button
    {
        private int m_Row;
        private int m_Column;
        private string m_ImageLocation;

        public string ImageLocation
        {
            get => m_ImageLocation;
        }

        public CardButton(int i_Row, int i_Column, string i_ImageLocation)
        {
            m_Row = i_Row;
            m_Column = i_Column;
            m_ImageLocation = i_ImageLocation;
        }
    }
}
