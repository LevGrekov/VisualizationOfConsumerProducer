using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizationOfConsumerProducer2try
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace VisualizationOfConsumeAndProduce
    {
        public class Square
        {
            private Color color;
            public int color_valueR { get; set; }
            public int color_valueG { get; set; }
            public int color_valueB  { get; set; }


            public Square(Color color)
            {
                this.color = color;

            }
            public Square()
            {

            }
            public Square(int R,int G,int B)
            {
                if (R > 255 || R < 0) throw new ArgumentException();
                if (G > 255 || G < 0) throw new ArgumentException();
                if (B > 255 || B < 0) throw new ArgumentException();
                this.color_valueR = R;
                this.color_valueG = G;
                this.color_valueB = B;
                this.Color = Color.FromArgb(R, G, B);
            }

            public Color Color
            {
                get { return color; }
                set { color = value; }
            }
        }
    }

}
