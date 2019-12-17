using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGrid
{
    class GridCase : Label
    {
        private static int caseSize = 130;

        public GridCase(int index, int caseLeft, int caseTop, string word)
        {
            Name = "Case" + (index).ToString();
            Size = new Size(130, 130);
            Location = new Point(caseLeft, caseTop);
            BorderStyle = BorderStyle.FixedSingle;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Tahoma", 18, FontStyle.Bold);
            Text = String.Empty;
        }
    }
}
