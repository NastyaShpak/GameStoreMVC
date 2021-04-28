using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GameStore.Client.Ulits.Helpers
{
    public static class CustomImageConverter
    {
        public static Bitmap ConvertImage(Image oldImage, int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height);

            using(Graphics context = Graphics.FromImage(newImage))
            {
                context.DrawImage(oldImage, 0, 0, width, height);
            }
            return new Bitmap(newImage);
        }
    }
}