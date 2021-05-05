﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filled_Julia_Set
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Bitmap bitmapImage = new Bitmap(pbNumberline.Width, pbNumberline.Height);   //Creates the bitmap used to draw on

            for (int x = 0; x < pbNumberline.Width; x++)
            {
                for (int y = 0; y < pbNumberline.Height; y++)
                {
                    double a = (double)(x - (pbNumberline.Width / 2)) / (double)(pbNumberline.Width / 4);
                    //Makes sure that a and b are in the range [-2,2]
                    double b = (double)(y - (pbNumberline.Height / 2)) / (double)(pbNumberline.Height / 4);

                    ComplexNumber c = new ComplexNumber(a, b);
                    ComplexNumber z = new ComplexNumber(0, 0);  //Looking at the behaviour of 0 under iteration

                    int iteration = 0;

                    while (iteration < 100)
                    {
                        iteration++;
                        z.square();
                        z.add(c);
                        if (z.magnitude() > 2.0)    //if magnitude is > 2.0 then the iterations will go to infinity
                        {
                            break;
                        }
                    }

                    if (iteration < 100)
                    {
                        bitmapImage.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        bitmapImage.SetPixel(x, y, Color.Blue);
                    }
                }
            }
            pbNumberline.Image = bitmapImage;
        }
    }
}
