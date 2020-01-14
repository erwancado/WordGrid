using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGrid
{
    public partial class Display : Form
    {
        private Grid _grid;
        private readonly int gridSize = 16;
        private readonly List<int> _downList = new List<int>() { 0, 4, 8, 12, 1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15 };
        private readonly List<int> _upList = new List<int>() { 12, 8, 4, 0, 13, 9, 5, 1, 14, 10, 6, 2, 15, 11, 7, 3 };
        private readonly List<int> _rightList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        private readonly List<int> _leftList = new List<int>() { 3, 2, 1, 0, 7, 6, 5, 4, 11, 10, 9, 8, 15, 14, 13, 12 };
        private readonly List<string> _fourLettersWords=new List<string>();
        private readonly List<string> _fiveLettersWords=new List<string>();
        private readonly List<string> _sixLettersWords = new List<string>();
        private int _nbRound;
        private int _nbWords;
        private bool _endOfGame;
        private bool _wordFound;
        private int _score;

        public Display()
        {
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
           startGame();
        }

        private void LoadDictionary()
        {
            
            string[] dictionary = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "/dico_fr.txt",Encoding.GetEncoding(1252));
            foreach (var word in dictionary)
            {
                if(word.Length==4)
                    _fourLettersWords.Add(word);
                if(word.Length==5)
                    _fiveLettersWords.Add(word);
                if(word.Length==6)
                    _sixLettersWords.Add(word);
            }
        }

        private string WordSelection()
        {
            if (_nbWords <= 3)
            {
                int wIndex = new Random(DateTime.Now.Millisecond).Next(_fourLettersWords.Count-1);
                return _fourLettersWords[wIndex];
            }
            else if (_nbWords <= 6)
            {
                int wIndex = new Random(DateTime.Now.Millisecond).Next(_fiveLettersWords.Count - 1);
                return _fiveLettersWords[wIndex];
            }
            else
            {
                int wIndex = new Random(DateTime.Now.Millisecond).Next(_sixLettersWords.Count - 1);
                return _sixLettersWords[wIndex];
            }
        }
        private void InitGame()
        {
            _wordFound = false;
            _grid = new Grid(gridSize, WordSelection());
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
            Score_Write(_score.ToString());
        }

        private void startGame()
        {
            LoadDictionary();
            _nbWords = 0;
            _score = 0;
            InitGame();
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
            if(_wordFound)
                InitGame();
            else
            {
                _grid.NewLetter();
                _grid.DisplayColors();
            }
        }

        private void endGameTest()
        {
            
            if (_grid.CurrentLength == _grid.Word.Length)
            {
                _score += _grid.Word.Length * 1000 - _nbRound * 100;
                _wordFound = true;
                _nbWords++;
                string message = "Vous avez trouvé "+_grid.Word+" !!\nScore : " + _score+"\nUn nouveau mot va arriver !";
                MessageBox.Show(message, "WordGrid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ScoreMax_Write(_score.ToString());
            }
            else
            {
                if (_grid.GridFull)
                {
                    _endOfGame = true;
                    string message = "Vous êtes bloqué : Game Over.\nScore final : "+_score;
                    MessageBox.Show(message, "WordGrid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void Score_Write(string w)
        {
            Score.Text = w;
        }

        private void ScoreMax_Write(string w)
        {
            ScoreMax.Text = w;
        }
    }
}
