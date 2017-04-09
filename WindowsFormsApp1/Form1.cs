using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap("C:\\Users\\Onam\\Desktop\\ocr\\work\\hellosentence.jpg");
            bmp.SetResolution(90, 60);
            pictureBox1.Image = bmp;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap("C:\\Users\\Onam\\Desktop\\ocr\\work\\hellosentence.jpg");
            bmp.SetResolution(90, 60);
            int i = 0,x=0,p=0;
            int xval = bmp.Width;
            int yval = bmp.Height;
            int[] xaxis = new int[xval];

            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayimage = filter.Apply(bmp);
            Threshold th = new Threshold();
            th.ApplyInPlace(grayimage);

            for (x=1;x<xval;x++)
            {
                int f = 0;
                for(int y =1;y<yval;y++)
                {
                    if(grayimage.GetPixel(x,y).Name == "ff000000")
                    {
                        f = 1;
                    }
                    
                }
                if (f == 0)
                {
                    xaxis[p++] = x;
                }
            }
            for (p=0;p<xval;p++)
            {
                textBox1.Text += xaxis[p] + " ";
            }
            
        }
    }
}
