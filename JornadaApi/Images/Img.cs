using JornadaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Drawing;
using System.Drawing.Imaging;

namespace JornadaApi.Images
{
    public class Img
    {
        private readonly string _filePath;

        public Img()
        {
            _filePath = "C:\\Users\\Cliente\\Source\\Repos\\VarleyS\\JornadaApi\\JornadaApi\\Images\\ImagensSalvas\\";
        }

        public string Save(string imageBase64)
        {
            var fileExt = imageBase64.Substring(imageBase64.IndexOf("/") + 1, imageBase64.IndexOf(";") - imageBase64.IndexOf("/") - 1);

            var base64Code = imageBase64.Substring(imageBase64.IndexOf(",") + 1);

            var imgByte = Convert.FromBase64String(base64Code);

            var fileName = Guid.NewGuid().ToString() + "." + fileExt;

            using (var imageFile = new FileStream(_filePath + "/" + fileName, FileMode.Create))
            {
                imageFile.Write(imgByte, 0, imgByte.Length);
                imageFile.Flush();
            }
            return _filePath + "/" + fileName;
        }

        public byte[] ConvertBase64ToImage(string imageBase64)
        {
            var base64Code = imageBase64.Substring(imageBase64.IndexOf(",") + 1);

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64Code)))
            {
                using(Bitmap bmp = new Bitmap(ms))
                {
                    using(MemoryStream msOutput = new MemoryStream())
                    {
                        bmp.Save(msOutput, ImageFormat.Jpeg);
                        return msOutput.ToArray();
                    }
                }
            }
        }
    }
}
