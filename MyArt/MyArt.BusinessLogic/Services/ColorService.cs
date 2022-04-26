using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace MyArt.BusinessLogic.Services
{
    public class ColorService
    {
        public async Task<string> GetColorPaletteAsync(IFormFile img, CancellationToken cancellationToken)
        {
            Image image = Image.FromStream(img.OpenReadStream(), true, true);

            int thumbSize = 500;
            Dictionary<Color, int> colors = new Dictionary<Color, int>();

            Bitmap thumbBmp = new Bitmap(image);

            for (int i = 0; i < thumbSize; i++)
            {
                for (int j = 0; j < thumbSize; j++)
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

            string top10Colors = "";
            for (int i = 0; i < 10; i++)
            {
                top10Colors += string.Format("\n {0}. {1} > {2}", i, keyValueList[i].Key.ToString(), keyValueList[i].Value);
            }

            return top10Colors;
        }
    }
}
