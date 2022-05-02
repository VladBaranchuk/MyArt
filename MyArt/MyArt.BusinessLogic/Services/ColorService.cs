using Microsoft.AspNetCore.Http;
using MyArt.BusinessLogic.Contracts;
using System.Drawing;

namespace MyArt.BusinessLogic.Services
{
    public class ColorService : IColorService
    {
        public string[] GetColorPalette(IFormFile img)
        {
            Image image = Image.FromStream(img.OpenReadStream(), true, true);

            int thumbSize = 500;

            Dictionary<Color, int> colors = new Dictionary<Color, int>();

            Bitmap thumbBmp = new Bitmap(image);
            

            for (int i = 1; i < thumbBmp.Size.Width; i++)
            {
                for (int j = 1; j < thumbBmp.Size.Height; j++)
                {
                    Color col = thumbBmp.GetPixel(i, j);
                    if (colors.ContainsKey(col))
                        colors[col]++;
                    else
                        colors.Add(col, 1);
                }
            }

            List<KeyValuePair<Color, int>> keyValueList = new List<KeyValuePair<Color, int>>(colors);

            keyValueList.Sort(delegate (KeyValuePair<Color, int> firstPair,KeyValuePair<Color, int> nextPair)
            {
                return nextPair.Value.CompareTo(firstPair.Value);
            });

            var topColors = new string[3];
            for (int i = 0; i < 3; i++)
            {
                topColors[i] = ColorTranslator.ToHtml(keyValueList[i].Key).ToString();
            }

            return topColors;
        }
    }
}
