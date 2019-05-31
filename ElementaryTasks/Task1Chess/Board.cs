using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Chess
{
    class Board
    {
        //public int height;
        public string Fen { get; private set; }
        Figure[,] figures;
        public Color moveColor { get; private set; }
        public int moveNumber { get; private set; }

        public Board (string fen)
        {
            Fen = fen;
            figures = new Figure[8, 8];
            Init();
        }

        void Init()
        {
            SetFigureAt(new Square("a1"), Figure.whiteKing);
            SetFigureAt(new Square("h8"), Figure.blackKing);
            moveColor = Color.white;
        }
        public Figure GetFigureAt(Square square)
        {
            if(square.OnBoard())
            {
                return figures[square.X, square.Y];
            }
            else
            {
                return Figure.none;
            }

        }

        void SetFigureAt(Square square, Figure figure)
        {
            if(square.OnBoard())
            {
                figures[square.X, square.Y] = figure;
            }
        }

        public Board Move(FigureMoving fm)
        {
            Board next = new Board(Fen);
            next.SetFigureAt(fm._from, Figure.none);
            next.SetFigureAt(fm._to, fm._promotion == Figure.none ? fm._figure : fm._promotion);
            if(moveColor == Color.black)
            {
                next.moveNumber++;
            }
            next.moveColor = moveColor.FlipColor();
            return next;

        }


    }
}
