using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class BllEntitiesMappers
    {
        public static Image ByteArrayToImage(this byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0) return null;
            using (MemoryStream mstream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mstream);
            }
        }
        public static byte[] ImageToByteArray(this Image imageIn)
        {
            if (imageIn == null) return null;
            byte[] t;
            using (var mstream = new MemoryStream())
            {
                imageIn.Save(mstream, ImageFormat.Png);
                t= mstream.ToArray();
            }
            return t;
        }
    }
}
