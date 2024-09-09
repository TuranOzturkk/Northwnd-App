using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace NorthwndApp.Model.Entities
{
    public class Category:IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
            
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string PicturePath { get; set; }
        

        [NotMapped]
        public string Base64String
        {
            get
            {
                string base64Str = string.Empty;
                if (CategoryId <= 8)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int offset = 78;
                        ms.Write(Picture, offset, Picture.Length - offset);
                        Bitmap bmp = new Bitmap(ms);
                        using (MemoryStream jpegms = new MemoryStream())
                        {
                            bmp.Save(jpegms, ImageFormat.Jpeg);
                            base64Str = Convert.ToBase64String(jpegms.ToArray());
                        }
                    }
                    return base64Str;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(Picture);
                    Bitmap bmp = new Bitmap(ms);
                    using (MemoryStream jpegms = new MemoryStream())
                    {
                        bmp.Save(jpegms, ImageFormat.Jpeg);
                        base64Str = Convert.ToBase64String(jpegms.ToArray());
                    }
                }
                return base64Str;

            }
        }

        public virtual ICollection<Product> Products { get; set; }
       
    }
}
