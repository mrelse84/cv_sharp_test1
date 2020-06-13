using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv_sharp_test1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        VideoCapture capture;
        Mat frame = new Mat();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Mat bond = Cv2.ImRead("d:/images/halcon_images/die/die_03.png", ImreadModes.Grayscale);
            image = BitmapConverter.ToBitmap(bond);
            pictureBox1.Image = image;
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            //타이머 설정
            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capture.Read(frame);
            if (frame.Empty())
                return;

            image = BitmapConverter.ToBitmap(frame);
            pictureBox1.Image = image;
        }
    }
}
