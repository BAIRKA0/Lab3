using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Dictionary<TextBox, TrackBar> tb;
        private List<TextBox> textBoxes;
        public Form1()
        {
            InitializeComponent();
            tb = new Dictionary<TextBox, TrackBar>()
            {
                {textBox1, trackBar1 },
                {textBox2, trackBar2 },
                {textBox3, trackBar3 },
                {textBox4, trackBar4 },
                {textBox5, trackBar5 },
                {textBox6, trackBar6 },
            };
            textBoxes = new List<TextBox>()
            {
                textBox1, textBox2, textBox3, textBox4, textBox5, textBox6
            };
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            textBox1.Text = Convert.ToString(trackBar1.Value);
            textBox2.Text = Convert.ToString(trackBar2.Value);
            textBox3.Text = Convert.ToString(trackBar3.Value);
            RGB rgb = new RGB((float)Convert.ToInt32(textBox1.Text), (float)Convert.ToInt32(textBox2.Text), (float)Convert.ToInt32(textBox3.Text));
            HSV hsv = rgb.toHSV();
            this.textBox4.Text = Convert.ToString((int)Math.Round(hsv.H));
            this.textBox5.Text = Convert.ToString((int)Math.Round(hsv.S));
            this.textBox6.Text = Convert.ToString((int)Math.Round(hsv.V));
            int r, g, b;
            r = Convert.ToInt32(textBox1.Text);
            g = Convert.ToInt32(textBox2.Text);
            b = Convert.ToInt32(textBox3.Text);


            trackBar4.Value = (int)Math.Round(hsv.H);
            trackBar5.Value = (int)Math.Round(hsv.S);
            trackBar6.Value = (int)Math.Round(hsv.V);

            pictureBox1.BackColor = Color.FromArgb(r, g, b);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(trackBar5.Value);
            textBox4.Text = Convert.ToString(trackBar4.Value);
            textBox6.Text = Convert.ToString(trackBar6.Value);
            HSV hsv = new HSV((float)Convert.ToInt32(textBox4.Text), (float)Convert.ToInt32(textBox5.Text), (float)Convert.ToInt32(textBox6.Text));
            RGB rgb = hsv.toRGB();
            this.textBox1.Text = Convert.ToString((int)Math.Round(rgb.R));
            this.textBox2.Text = Convert.ToString((int)Math.Round(rgb.G));
            this.textBox3.Text = Convert.ToString((int)Math.Round(rgb.B));

            trackBar1.Value = (int)Math.Round(rgb.R);
            trackBar2.Value = (int)Math.Round(rgb.G);
            trackBar3.Value = (int)Math.Round(rgb.B);

            pictureBox1.BackColor = Color.FromArgb((int)Math.Round(rgb.R), (int)Math.Round(rgb.G), (int)Math.Round(rgb.B));
        }


        private void SwitchEvents(bool status)
        {

            foreach(var textbox in textBoxes)
            {
                if(status)
                    textbox.TextChanged += textBox1_TextChanged;
                else
                    textbox.TextChanged -= textBox1_TextChanged;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SwitchEvents(false);
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                tb[textBox].Value = 0;
            }
            else
            {
                try
                {
                    tb[textBox].Value = Convert.ToInt32(textBox.Text);
                    if (textBox.Tag is "RGB")
                    {
                        trackBar1_Scroll(null, null);
                    }
                    else
                    {
                        trackBar4_Scroll(null, null);
                    }
                }
                catch
                {

                }
                

            }

            SwitchEvents(true);
        }


        
    }
}
