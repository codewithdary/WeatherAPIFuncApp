using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;
using WeatherAPI.Logic;

namespace WeatherAPI.Data
{
    public class ImagingService
    {

        public static async Task<Stream> GenerateImage(Image image, StationMeasurement sm)
        {

            var newimage = image.Clone(img =>
            {

                string text = $"Station Name: {sm.Stationname}\r\nTemperature: {sm.Temperature}";


                var font = SystemFonts.CreateFont("Verdana", 20);
                var textsize = TextMeasurer.MeasureSize(text, new TextOptions(font));

                img.DrawText(text, font, Color.Magenta, new PointF(textsize.X, textsize.Y));


            }
               );

            var watermarkedStream = new MemoryStream();
            await newimage.SaveAsPngAsync(watermarkedStream);
            newimage.Dispose();
            return watermarkedStream;
        }
    }
}