using Infrastructure.Model;

namespace NorthwndApp.Model.Entities
{
    public class ProductPhoto : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string PhotoPath { get; set; }

        public virtual Product Product { get; set; }
    }
}
