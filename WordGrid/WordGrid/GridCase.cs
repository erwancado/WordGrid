using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGrid
{
    /// <summary>
    /// Représente une case de la grille du jeu
    /// </summary>
    class GridCase : Label
    {
        private static int caseSize = 130;

        public GridCase(int index, int caseLeft, int caseTop)
        {
            Name = "Case" + (index).ToString();
            Size = new Size(caseSize, caseSize);
            Location = new Point(caseLeft, caseTop);
            BorderStyle = BorderStyle.FixedSingle;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Tahoma", 18, FontStyle.Bold);
            Text = "";
            BackColor = Color.Azure;
        }
    }
}
