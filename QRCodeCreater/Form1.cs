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

            //取得主目錄下的logo.png檔案
            string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "logo.png");

            if (!File.Exists(logoPath))
            {
                MessageBox.Show("找不到 logo.png 檔案");
                return;
            }

            Bitmap logo = new Bitmap(logoPath);
            string QRCodeSource = txtInput.Text;
            if (string.IsNullOrEmpty(QRCodeSource))
            {
                MessageBox.Show("尚未填入轉換資料來源");
                return;
            }


            try
            {
                // 設置 QR Code 參數
                var hint = new Dictionary<EncodeHintType, object>
                {
                    { EncodeHintType.CHARACTER_SET, "UTF-8" },
                    { EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H }
                };
                // 生成 QR Code
                MultiFormatWriter writer = new MultiFormatWriter();
                BitMatrix matrix = writer.encode(QRCodeSource, BarcodeFormat.QR_CODE, 300, 300, hint);
                BarcodeWriter barcodeWriter = new BarcodeWriter { Format = BarcodeFormat.QR_CODE };
                Bitmap qrCodeBitmap = barcodeWriter.Write(matrix);

                // 計算插入圖片位置和大小
                int[] rectangle = matrix.getEnclosingRectangle();
                int middleW = Math.Min(qrCodeBitmap.Width / 20, logo.Width); // 减小 logo 的比例
                int middleH = Math.Min(qrCodeBitmap.Height / 20, logo.Height);
                int middleL = (qrCodeBitmap.Width - middleW) / 2;
                int middleT = (qrCodeBitmap.Height - middleH) / 2;

                // 創建最終帶 logo 的 QR Code 圖片
                Bitmap finalImage = new Bitmap(qrCodeBitmap.Width, qrCodeBitmap.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(qrCodeBitmap, 0, 0);
                }

                using (Graphics myGraphic = Graphics.FromImage(finalImage))
                {
                    // 插入 logo 並設置白底
                    myGraphic.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
                    myGraphic.DrawImage(logo, middleL, middleT, middleW, middleH);
                }
                pictureBox1.Image = finalImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤：{ex.Message}");
            }
        }
    }
}
