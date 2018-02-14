using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Accord.Video.FFMPEG;
using Accord.Math;
using Accord.Math.Geometry;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Vision.Tracking;
namespace Day8_TrackTheMario
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pbThreshold.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMasked.SizeMode = PictureBoxSizeMode.StretchImage;
            var path = $@"{Application.StartupPath}\Mario.mp4";
            var videoSource = new VideoFileSource(path);
            vspMain.VideoSource = videoSource;
            vspMain.Start();
        }
        BlobCounter blobCounter = new BlobCounter();
        ColorFiltering colorFiltering = new ColorFiltering();
        Dilation dilation = new Dilation();
        GrayscaleBT709 grayscaleBT709 = new GrayscaleBT709();
        Threshold threshold = new Threshold(50);
        Rectangle lastRect = new Rectangle(0,0,50,100);
        int cntFrame = 0;
        int missFrame = 0;
        List<int> lstHeight = new List<int>();
        Camshift camshift = new Camshift
        {
            Conservative = false,
            Smooth = true,
            Mode = CamshiftMode.Mixed
        };

        private void vspMain_NewFrame(object sender, ref Bitmap image)
        {
            cntFrame++;
            if (cntFrame < 80)
            {
                return;
            }
            colorFiltering.Red = new Accord.IntRange(230,245);
            colorFiltering.Green = new Accord.IntRange(200,220);
            colorFiltering.Blue = new Accord.IntRange(150,180);
            
            var filteringFrame = colorFiltering.Apply(image);
            var  afterGray = grayscaleBT709.Apply(filteringFrame);
            
            var thersholdedFrame = threshold.Apply(afterGray);
            pbThreshold.Image = afterGray;

            var dilatedFrame = dilation.Apply(thersholdedFrame);

            ApplyMask applyMask = new ApplyMask(dilatedFrame);
            var maskedFrame = applyMask.Apply(image);
            var blobFrame = maskedFrame.Clone() as Bitmap;
            pbMasked.Image = maskedFrame;

            blobCounter.ProcessImage(blobFrame);
            var info = blobCounter.GetObjectsInformation();
            var rectangles = info.Where(w => w.Area >=200).Select(s=>s.Rectangle).ToList();
            //var rectangles = blobCounter.GetObjectsRectangles();
            if (rectangles.Count ==0 )
            {
                missFrame++;
                return;
            }
            var rectangle = rectangles[0];
            lstHeight.Add(rectangle.Y);

            if (lstHeight.Count >= 2)
            {
                lstHeight.Remove(0);
            }
            
            //if(cntFrame >=130)
            //    lastRect = rectangle;
            //rectangle = rectangles.Where(w => Math.Abs(lastRect.X - w.X) < 20).FirstOrDefault();
            if (rectangle == null)
            {
                return;
            }
            Graphics g = Graphics.FromImage(image);
            rectangle.Width = 50;
            rectangle.Height = 100;
            //rectangle.Y = lstHeight.Sum(s => s) / lstHeight.Count;
            g.DrawRectangle(new Pen(Color.Yellow, 3), rectangle);

            var img = UnmanagedImage.FromManagedImage(blobFrame);
            camshift.SearchWindow = rectangle;
            camshift.ProcessFrame(img);
            var trackRect = camshift.TrackingObject.Rectangle;
            if (trackRect == null)
            {
                return;
            }
            trackRect.Inflate(30,30);
            g.DrawRectangle(new Pen(Color.Aqua, 3), trackRect);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vspMain.Stop();
            vspMain.Start();
        }
    }
}
