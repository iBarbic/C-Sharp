using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Labs
{
    class FormStats
    {
        public int _Width { get; set; }
        public int _Height { get; set; }
        public Point _Location { get; set; }

        public FormStats(int width, int height, Point point)
        {
            _Width = width;
            _Height = height;
            _Location = point;
        }
        
        public FormStats()
        {

        }

    }
}
