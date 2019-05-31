using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Chess
{
    class FigureMoving
    {
        public Figure _figure { get; private set; }
        public Square _from { get; private set; }
        public Square _to { get; private set; }
        public Figure _promotion { get; private set; }

        public FigureMoving(FigureOnSquare fs, Square to, Figure promotion = Figure.none)
        {
            _figure = fs._figure;
            _from = fs._square;
            _to = to;
            _promotion = promotion;
        }

        public FigureMoving(string move)
        {
            _figure = (Figure)move[0];
            _from = new Square(move.Substring(1, 2));
            _to = new Square(move.Substring(3, 2));
            _promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }


    }
}
