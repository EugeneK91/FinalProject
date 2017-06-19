using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using DAL.DTO;
using MvcPL.Models.AccountModel;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        public static Byte[] ImageToByteArray(this Image imageIn)
        {
            if (imageIn != null)
            {
                using (var ms = new MemoryStream())
                {
                    imageIn.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            return null;
        }

        public static Byte[] HttpPostedFileBasePhotoToByteArray(this HttpPostedFileBase file)
        {

            Image image = file.HttpPostedFileBaseToImage();
            if (image != null)
            {
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            return null;
        }

        public static Image HttpPostedFileBaseToImage(this HttpPostedFileBase file)
        {
            return file != null ? Image.FromStream(file.InputStream) : null;
        }

        public static Byte[] HttpPostedFileBaseMusicToByteArray(this HttpPostedFileBase file)
        {
            byte[] byteArray = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            byteArray = rdr.ReadBytes(file.ContentLength);
            return byteArray;
        }


        public static UserEntity ToBllUser(this RegisterViewModel userViewModel)
        {
            return new UserEntity()
            {
                Name = userViewModel.Name,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                Photo = userViewModel.Photo?.HttpPostedFileBasePhotoToByteArray(),
                RoleId = userViewModel.RoleId
            };
        }
    }
}