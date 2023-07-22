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
        public static string ConvertImagemParaString(string imagemPara)
        {
            try
            {
                byte[] imagemByte = File.ReadAllBytes(imagemPara);
                string base64String = Convert.ToBase64String(imagemByte);
                return base64String;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao converte imagem: ",ex.Message);
                return null;
            }
        }
    }
}
