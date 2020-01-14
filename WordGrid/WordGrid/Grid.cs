using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WordGrid
{
    class Grid
    {
        private static readonly List<Color> Colors = new List<Color>() { Color.Azure,Color.GreenYellow,Color.OrangeRed, Color.Cyan, Color.Gold,Color.HotPink };
        private int Size { get; }
        public List<GridCase> GridCases;
        public string Word;
        private readonly List<string> _wordParts = new List<string>();
        private readonly Random _alea = new Random(DateTime.Now.Millisecond);
        private readonly List<int> _emptyCases = new List<int>();
        public int CurrentLength = 1;
        public bool GridFull = false;


        public Grid(int size, string word)
        {
            this.Size = size;
            GridCases=new List<GridCase>(size);
            this.Word = word;
            ParseWord(word);
        }

        private void ParseWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                _wordParts.Add(word.Substring(0, i + 1));
            }
        }

        public void InitCases()
        {
            for (int i = 0; i < Word.Length;i++)
            {
                int indexCase = _alea.Next(0, Size - 1);
                GridCases[indexCase].Text = Word[i].ToString();
                GridCases[indexCase].BackColor = Color.GreenYellow;
            }
        }

        public void DisplayColors()
        {
            foreach (var gridCase in GridCases)
            {
                gridCase.BackColor = Colors[gridCase.Text.Length];
            }
        }
        public void NewLetter()
        {
            _emptyCases.Clear();
            for (int i = 0; i < Size; i++)
                if (GridCases[i].Text.Equals(string.Empty))
                    _emptyCases.Add(i);
            if (_emptyCases.Count == 0)
            {
                GridFull = true;
                return;
            }
                
            int newCase = _alea.Next(0, _emptyCases.Count - 1);
            if(CurrentLength+1==Word.Length)
                GridCases[_emptyCases[newCase]].Text= Word[CurrentLength].ToString();
            else
                GridCases[_emptyCases[newCase]].Text = Word[_alea.Next(CurrentLength-1,CurrentLength+1)].ToString();
        }

        public void Move(List<int> casesIndexes)
        {
            // on traite chaque ligne de 4 cases selon le sens bas, haut, droite ou gauche
            // On fusionne les cases dont les contenus se suivent
            for (int i = 0; i <= casesIndexes.Count - 1; i += 4)
                for (int j = 0; j <= 2; j++) // on ne fait rien pour la dernière case de la ligne ou colonne
                    if (!GridCases[casesIndexes[i + j]].Text.Equals(string.Empty))
                    {
                        int fusionLength = GridCases[casesIndexes[i + j]].Text.Length
                            + GridCases[casesIndexes[i + j + 1]].Text.Length;
                        // test si fusion possible avec la case qui suit
                        if (fusionLength <= Word.Length) { 
                            if ((GridCases[casesIndexes[i + j]].Text + 
                                 GridCases[casesIndexes[i + j + 1]].Text).Equals(_wordParts[fusionLength - 1]))
                            {
                                GridCases[casesIndexes[i + j]].Text = string.Empty; // on vide la case
                                GridCases[casesIndexes[i + j + 1]].Text = _wordParts[fusionLength-1]; // on fusionne les cases
                                if (CurrentLength < fusionLength)
                                {
                                    CurrentLength = fusionLength;
                                }
                                GridCases[casesIndexes[i + j]].Text = string.Empty;
                            }
                        }
                    }

            // On fait les décalages pour supprimer les cases vides
            for (int i = 0; i <= casesIndexes.Count - 1; i += 4)
            {
                List<string> values = new List<string>();
                for (int j = 0; j <= 3; j++)
                {
                    if (!GridCases[casesIndexes[i + j]].Text.Equals(string.Empty))
                        values.Add(GridCases[casesIndexes[i + j]].Text);
                    GridCases[casesIndexes[i + j]].Text = string.Empty;
                }
                if (values.Count != 0)
                {
                    while (values.Count < 4)
                        values.Insert(0, string.Empty);
                    for (int j = 0; j <= 3; j++)
                    {
                        if (!values[j].Equals(string.Empty))
                            GridCases[casesIndexes[i + j]].Text = values[j];
                    }
                }
            }

            
        }

        
    }
}
