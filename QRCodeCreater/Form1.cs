using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;  //使用套件ZXing
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace QRCodeCreater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateQRCode_Click(object sender, EventArgs e)
        {

            //娶得主目錄下的logo.png檔案
            Bitmap logo = new Bitmap(Directory.GetCurrentDirectory()+@"\logo.png");
            var writer = new BarcodeWriter  
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions //設定QRCode大小
                {
                    Height = 300,
                    Width = 300,
                }
            };

            string QRCodeSource = txtInput.Text;
            if (string.IsNullOrEmpty(QRCodeSource))
            {
                MessageBox.Show("尚未填入轉換資料來源");
                return;
            }
            //產生QRcode

            #region 帶logo
            MultiFormatWriter Muwriter = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            BitMatrix bm = Muwriter.encode(QRCodeSource, BarcodeFormat.QR_CODE, 300, 300, hint);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);
            //得到QrCode實際尺寸
            int[] rectangle = bm.getEnclosingRectangle();
            //計算插入圖片之位置與大小
            int middleW = Math.Min((int)(rectangle[2] / 3.5), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3.5), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0);
            }
            //QRCode插入圖片
            Graphics myGraphic = Graphics.FromImage(bmpimg);
            //白底
            myGraphic.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
            myGraphic.DrawImage(logo, middleL, middleT, middleW, middleH);




            #endregion


            #region 不帶logo

            //var img = writer.Write(QRCodeSource);
            //string FileName = "ithome";
            //Bitmap bmpimg = new Bitmap(img);

            #endregion
            pictureBox1.Image = bmpimg;
        }
    }
}
