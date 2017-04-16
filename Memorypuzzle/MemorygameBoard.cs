using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorypuzzle
{
    public class MemorygameBoard
    {
        private Tuple<string, Color>[,] board;
        private bool[,] revealedBoxes;
        private Tuple<int, int> firstSelection;

        public int Boardwidth { get; private set; }
        public int Boardheight { get; private set; }
        public int Boxsize { get; private set; }
        public int Gapsize { get; private set; }
        public int Xmargin { get; private set; }
        public int Ymargin { get; private set; }

        public List<Color> AllColors { get; private set; }
        public List<string> AllShapes { get; private set; }

        public MemorygameBoard(int windowwidth, int windowheight, int boardwidth, int boardheight, int boxsize, int gapsize)
        {
            Boardwidth = boardwidth;
            Boardheight = boardheight;
            Boxsize = boxsize;
            Gapsize = gapsize;

            if ((Boardwidth * Boardheight) % 2 > 0)
            {
                throw new ArgumentOutOfRangeException("Board needs to have an even number of boxes for pairs of matches.");
            }

            Xmargin = (windowwidth - (boardwidth * (boxsize + gapsize))) / 2;
            Ymargin = (windowheight - (boardheight * (boxsize + gapsize))) / 2;

            InitBoardState();
            GenerateRandomizeBoard();
            GenerateRevealedBoxesData(false);
            firstSelection = null;
        }

        private void InitBoardState()
        {
            // Init the AllColors List
            AllColors = new List<Color>();
            AllColors.Add(Color.Red);
            AllColors.Add(Color.Green);
            AllColors.Add(Color.Blue);
            AllColors.Add(Color.Yellow);
            AllColors.Add(Color.Orange);
            AllColors.Add(Color.Purple);
            AllColors.Add(Color.Cyan);

            // Init the AllShapes List
            AllShapes = new List<string>();
            AllShapes.Add("Donut");
            AllShapes.Add("Square");
            AllShapes.Add("Diamond");
            AllShapes.Add("Lines");
            AllShapes.Add("Oval");

            if ((AllColors.Count * AllShapes.Count) * 2 < (Boardwidth * Boardheight))
            {
                throw new ArgumentOutOfRangeException("Board is too big for the number of shapes/colors defined.");
            }
        }

        private void GenerateRandomizeBoard()
        {
            var icons = new List<Tuple<string, Color>>();

            //Get a list of every possible shape in every possible color.
            foreach (var color in AllColors)
            {
                foreach (var shape in AllShapes)
                {
                    icons.Add(new Tuple<string, Color>(shape, color));
                }
            }

            //TODO: Randomize funktioniert noch nicht !?
            icons.Randomize();
            var numIconsUsed = ((Boardwidth * Boardheight) / 2); //calculate how many icons are needed
            icons = icons.GetRange(0, numIconsUsed);
            icons.AddRange(icons);
            icons.Randomize();

            board = new Tuple<string, Color>[Boardwidth, Boardheight];

            for (var i = 0; i<Boardwidth; i++)
            {
                for (var j = 0; j < Boardheight; j++)
                {
                    board[i, j] = icons[0];
                    icons.RemoveAt(0);
                }
            }
        }

        private void GenerateRevealedBoxesData(bool value)
        {
            revealedBoxes = new bool[Boardwidth, Boardheight];

            for (var i = 0; i < Boardwidth; i++)
            {
                for (var j = 0; j < Boardheight; j++)
                {
                    revealedBoxes[i, j] = value;                    
                }
            }
        }

        public void StartGameAnimation()
        {
        }
    }
}
