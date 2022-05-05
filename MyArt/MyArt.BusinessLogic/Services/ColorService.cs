using Microsoft.AspNetCore.Http;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using System.Drawing;

namespace MyArt.BusinessLogic.Services
{
    public class ColorService : IColorService
    {
        public ColorsViewModel GetColorPalette(IFormFile img, int numberOfColors, int imageGranularity, int colorGranularity)
        {
            Image image = Image.FromStream(img.OpenReadStream(), true, true);

            Dictionary<Color, int> colors = new Dictionary<Color, int>();
            Dictionary<Color, int> brightness = new Dictionary<Color, int>();

            Bitmap thumbBmp = new Bitmap(image);

            for (int i = 1; i < thumbBmp.Size.Width; i += imageGranularity)
            {
                for (int j = 1; j < thumbBmp.Size.Height; j += imageGranularity)
                {
                    Color col = thumbBmp.GetPixel(i, j);

                    var red = (int)Math.Round(Math.Round(col.R / (double)colorGranularity) * colorGranularity);
                    var green = (int)Math.Round(Math.Round(col.G / (double)colorGranularity) * colorGranularity);
                    var blue = (int)Math.Round(Math.Round(col.B / (double)colorGranularity) * colorGranularity);

                    Color newCol = Color.FromArgb(red, green, blue);

                    if (colors.ContainsKey(newCol))
                        colors[newCol]++;
                    else
                        colors.Add(newCol, 1);
                }
            }

            List<KeyValuePair<Color, int>> countValueList = new List<KeyValuePair<Color, int>>(colors);

            countValueList.Sort(delegate (KeyValuePair<Color, int> firstPair, KeyValuePair<Color, int> nextPair)
            {
                return nextPair.Value.CompareTo(firstPair.Value);
            });

            foreach (var item in countValueList)
            {
                brightness[item.Key] = (int)(0.2126 * item.Key.R + 0.7152 * item.Key.G + 0.0722 * item.Key.B);
            }

            var brightColor = brightness.FirstOrDefault(x => x.Value > 220);
            var mutedColor = brightness.FirstOrDefault(x => x.Value > 130 && x.Value < 160);
            var darkColor = brightness.FirstOrDefault(x => x.Value < 60);

            var colorsVM = new ColorsViewModel()
            {
                BrightColor = ColorTranslator.ToHtml(brightColor.Key).ToString(),
                MutedColor = ColorTranslator.ToHtml(mutedColor.Key).ToString(),
                DarkColor = ColorTranslator.ToHtml(darkColor.Key).ToString()
            };

            return colorsVM;
        }
    }
}
