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
        public byte[] imageParaByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }

        //public byte[] byteArrayParaImage(byte[] byteArray)
        //{
        //    MemoryStream ms = new MemoryStream(byteArray);
        //    Image retornaImagem = Image.FromStream(ms);
        //    return retornaImagem;

        //}

    }
}
