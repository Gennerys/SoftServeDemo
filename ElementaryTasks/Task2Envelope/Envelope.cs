using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{
    class Envelope
    {
        private double _height;
        private double _width;

        public double Height
        {
            get
            {
                return _height;

            }
            set
            {
                _height = value;
                SetBiggerSizeAsWidth();
            }

        }

        public double Width
        {
            get
            {
                return _width;

            }
            set
            {
                _width = value;
                SetBiggerSizeAsWidth();

            }
        }

        public Envelope(double height,double width)
        {
            Height = height;
            Width = width;
            SetBiggerSizeAsWidth();
        }

        private void SetBiggerSizeAsWidth()
        {
            if(Height < Width)
            {
                double temp;
                temp = Width;
                Width = Height;
                Height = temp;
            }
        }
    }
}
