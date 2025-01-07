using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace B2B.Helper
{
    public class CaptchaHelper
    {
        public static string GenerateCaptchaText(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // Exclude confusing characters
            var random = new Random();
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result);
        }

        public static byte[] GenerateCaptchaImage(string captchaText)
        {
            using (var bitmap = new Bitmap(160, 50))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var random = new Random();
                graphics.Clear(Color.White);

                var font = new Font("Arial", 22, FontStyle.Bold);
                for (int i = 0; i < captchaText.Length; i++)
                {
                    //var brush = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                    var brush = new SolidBrush(ColorTranslator.FromHtml("#555555"));
                    var x = i * 30 + random.Next(5, 15);
                    var y = random.Next(5, 15);
                    graphics.DrawString(captchaText[i].ToString(), font, brush, x, y);
                }

                // Add noise
                for (int i = 0; i < 100; i++)
                {
                    var x = random.Next(bitmap.Width);
                    var y = random.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.Black);
                }

                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }

    }
}