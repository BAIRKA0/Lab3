using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class HSV
    {
        private float h,s,v;
        public HSV()
        {
            h = 0;
            s = 100;
            v = 100;
        }
        public HSV(float _h,float _s,float _v)
        {
            if (_h >= 0 && _h <= 359 && _s >= 0 && _s <= 100 && _v >= 0 && _v <= 100)
            {
                h = _h; s = _s; v = _v;
            }
            else
            {
                h = 0; s= 100; v = 100;
            }
        }

        public RGB toRGB()
        {
            RGB _rgb = new RGB();
            float C = (s/100) * (v/100);
            float X = C * (1 - Math.Abs((h / 60)%2-1));
            float M = (v/100) - C;
            if (h >= 0 && h < 60)
            {
                _rgb = new RGB((C+M)*255,(X+M)*255,M *255);
            }else if (h >= 60 &&  h < 120)
            {
                _rgb = new RGB( (X + M) * 255,  (C + M) * 255,  M * 255);
            }else if (h >= 120 && h < 180)
            {
                _rgb = new RGB( M * 255,  (C + M) * 255,  (X + M) * 255);
            }else if (h >= 180 && h < 240)
            {
                _rgb = new RGB( M * 255,  (X + M) * 255,  (C+M) * 255);
            }else if (h >= 240 && h < 300)
            {
                _rgb = new RGB( (X + M) * 255,  M * 255,  (C+M) * 255);
            }else if (h >= 300 && h < 360)
            {
                _rgb = new RGB( (C + M) * 255,  M * 255,  (X+M) * 255);
            }

            return _rgb;
        }
        public float H
        {
            set
            {
                if(value >= 0 && value <= 359)
                {
                    h = value;
                }
            }
            get
            {
                return h;
            }
        }
        public float S
        {
            set
            {
                if (value >= 0 && value <= 100)
                {
                    s = value;
                }
            }
            get
            {
                return s;
            }
        }
        public float V
        {
            set
            {
                if (value >= 0 && value <= 100)
                {
                    v = value;
                }
            }
            get
            {
                return v;
            }
        }
    }
}
