using NorthwndApp.Model.Entities;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Models
{
    public class CategoryAddDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

       

        public byte[] Picture { get; set; }
        public string PicturePath { get; set; }
    }
}
