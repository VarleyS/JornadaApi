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
    public class Imagem
    {
        public byte[] imageParaByteArray(Image image = Image.FromFile(Path))
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] imageBytes = ms.ToArray();

            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public byte[] byteArrayParaImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image retornaImagem = Image.FromStream(ms);
            return retornaImagem;

        }

    }
}
