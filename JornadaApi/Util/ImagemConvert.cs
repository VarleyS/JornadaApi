using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace JornadaApi.Util

{
    public class ImagemConvert
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImagemConvert(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string ConvertImagemParaString(IFormFile imagem)
        {
            try
            {
                if(imagem != null && imagem.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);

                    var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "TempImages", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imagem.CopyTo(stream);
                    }

                    var imageBytes = File.ReadAllBytes(filePath);
                    var base64String = Convert.ToBase64String(imageBytes);

                    File.Delete(filePath);

                    return base64String;
                }

                return null;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao converte imagem: ",ex.Message);
                return null;
            }
        }
    }
}
