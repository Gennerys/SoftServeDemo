using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Chess
{
    //fen - позволяет задать любую позицую шахмат

    public class Chess
    {
        Board _board;

        public string Fen { get; private set; }

        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            Fen = fen;
            _board = new Board(Fen);
        }
        Chess (Board board)
        {
            _board = board;
        }

        public Chess Move(string move)
        {
            FigureMoving fm = new FigureMoving(move);
            Board nextBoard = _board.Move(fm); 
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt(int x, int y)
        {
            Square square = new Square(x, y);
            Figure f = _board.GetFigureAt(square);
            return f == Figure.none ? '.' : (char)f;
        }
    }
}
