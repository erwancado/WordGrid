using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGrid
{
    class Grid
    {
        private int size { get; }
        private List<GridCase> gridCases;
        private string word { get; }
        private List<string> wordParts = new List<string>();

        public Grid(int size, string word)
        {
            this.size = size;
            gridCases=new List<GridCase>(size);
            this.word = word;
            parseWord(word);
        }

        private void parseWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                wordParts.Add(word.Substring(0, i + 1));
            }
        }

        private void initCases()
        {
            //@TODO
        }

        public void Move(List<int> casesIndexes, List<GridCase> cases)
        {
            // on traite chaque ligne de 4 cases selon le sens bas, haut, droite ou gauche
            // On fusionne les cases dont les contenus se suivent
            for (int i = 0; i <= casesIndexes.Count - 1; i += 4)
                for (int j = 0; j <= 2; j++) // on ne fait rien pour la dernière case de la ligne ou colonne
                    if (!cases[casesIndexes[i + j]].Text.Equals(String.Empty))
                    {
                        int caseLength = cases[casesIndexes[i + j]].Text.Length;
                        // test si fusion possible avec la case qui suit
                        if ((cases[casesIndexes[i + j]].Text + cases[casesIndexes[i + j + 1]].Text).Equals(wordParts[caseLength]))
                        {
                            cases[casesIndexes[i + j]].Text = string.Empty; // on vide la case
                            cases[casesIndexes[i + j + 1]].Text = wordParts[caseLength]; // on double la case suivante selon la direction
                            cases[casesIndexes[i + j + 1]].Text = cases[casesIndexes[i + j]].Text;
                            cases[casesIndexes[i + j]].Text = string.Empty;
                        }
                    }

            // On fait les décalages pour supprimer les cases vides
            for (int i = 0; i <= casesIndexes.Count - 1; i += 4)
            {
                List<string> values = new List<string>();
                for (int j = 0; j <= 3; j++)
                {
                    cases[casesIndexes[i + j]].Text = string.Empty;
                    if (!cases[casesIndexes[i + j]].Text.Equals(string.Empty))
                        values.Add(cases[casesIndexes[i + j]].Text);
                }
                if (values.Count != 0)
                {
                    while (values.Count < 4)
                        values.Insert(0, String.Empty);
                    for (int j = 0; j <= 3; j++)
                    {
                        cases[casesIndexes[i + j]].Text.Equals(values[j]);
                        if (!cases[casesIndexes[i + j]].Text.Equals(string.Empty))
                            cases[casesIndexes[i + j]].Text = values[j];
                    }
                }
            }
        }
    }
}
