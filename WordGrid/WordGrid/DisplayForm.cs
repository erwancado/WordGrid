using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGrid
{
    public partial class Display : Form
    {
        private Grid _grid;
        private readonly List<int> _downList = new List<int>() { 0, 4, 8, 12, 1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15 };
        private readonly List<int> _upList = new List<int>() { 12, 8, 4, 0, 13, 9, 5, 1, 14, 10, 6, 2, 15, 11, 7, 3 };
        private readonly List<int> _rightList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        private readonly List<int> _leftList = new List<int>() { 3, 2, 1, 0, 7, 6, 5, 4, 11, 10, 9, 8, 15, 14, 13, 12 };
        private int _nbRound;
        private bool _endOfGame;

        public Display()
        {
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
           initGame();
        }

        private void initGame()
        {
            _grid = new Grid(16, "chat");
            gridPanel.Controls.Clear();
            _endOfGame = false;
            _nbRound = 0;
            GridCase gridCase = null;
            int index = 0;
            var casetop = 4;
            for (int row = 0; row <= 3; row++)
            {
                var iLeft = 4;
                for (int col = 0; col <= 3; col++)
                {
                    gridCase = new GridCase(index, iLeft, casetop);
                    _grid.GridCases.Add(gridCase);
                    gridPanel.Controls.Add(gridCase);
                    iLeft += gridCase.Width;
                    index += 1;
                }
                casetop += gridCase.Height;
            }
            _grid.InitCases();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(_endOfGame)
                return;
            switch (e.KeyCode)
            {
                case Keys.Down:
                    _grid.Move(_downList);
                    break;
                case Keys.Up:
                    _grid.Move(_upList);
                    break;
                case Keys.Left:
                    _grid.Move(_leftList);
                    break;
                case Keys.Right:
                    _grid.Move(_rightList);
                    break;
            }
            _nbRound++;
            endGameTest();
            _grid.NewLetter();
            _grid.DisplayColors();
            
        }

        private void endGameTest()
        {
            if (_grid.CurrentLength == _grid.Word.Length)
            {
                _endOfGame = true;
                string message = "Vous avez gagné !!!!!!!!\nScore : " + _nbRound + " coups";
                MessageBox.Show(message, "WordGrid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_grid.GridFull)
                {
                    _endOfGame = true;
                    string message = "Vous êtes bloqué : Game Over.";
                    MessageBox.Show(message, "WordGrid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            initGame();
        }
    }
}
