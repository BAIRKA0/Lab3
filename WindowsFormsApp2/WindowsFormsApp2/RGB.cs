using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class RGB
    {
        private float r, g, b;
        public RGB()
        {
            r = 0;
            g = 0;
            b = 0;
        }
        public RGB(float r,float g,float b)
        {
            if(r>=0&&r<=255&& g >= 0 && g <= 255 && b >= 0 && b <= 255)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
        }

        public HSV toHSV()
        {
            
            float h=0, s;
            float[] _rgb = new float[] { (r / 255), (g / 255), (b / 255) };
            float Cmax = 0, Cmin = _rgb[0];
            for (int i = 0; i < _rgb.Length; i++)
            {
                if (_rgb[i] > Cmax)
                {
                    Cmax = _rgb[i];
                }
                if (_rgb[i] < Cmin)
                {
                    Cmin = _rgb[i];
                }
            }
            float d = Cmax - Cmin;
            if (d == 0)
            {
                h = 0;
            }else if(Cmax == _rgb[0]){
                h = 60 * (((_rgb[1] - _rgb[2]) / d) % 6);
            }else if(Cmax == _rgb[1]){
                h = 60* (((_rgb[2] - _rgb[0]) / d) +2);
            }else if(Cmax == _rgb[2]){
                h= 60* (((_rgb[0] - _rgb[1]) / d) + 4);
            }
            if (Cmax == 0)
            {
                s = 0;
            }
            else { s = d / Cmax; }
            HSV _hsv = new HSV(h, s*100,Cmax*100);
            return _hsv;
        }
        public float R
        {
            set
            {
                if (value >= 0 && value <= 255)
                {
                    r = value;
                }
            }
            get
            {
                return r;
            }
        }
        public float G
        {
            set
            {
                if (value >= 0 && value <= 255)
                {
                    g = value;
                }
            }
            get
            {
                return g;
            }
        }
        public float B
        {
            set
            {
                if (value >= 0 && value <= 255)
                {
                    b = value;
                }
            }
            get
            {
                return b;
            }
        }
    }
}
