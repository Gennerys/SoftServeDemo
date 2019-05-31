using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Chess
{
    //Контейнер для хранения фигур

    class FigureOnSquare
    {
        public Figure _figure { get; private set; }
        public Square _square { get; private set; }

        public FigureOnSquare(Figure figure, Square square)
        {
            _figure = figure;
            _square = square; 
        }
    }
}
