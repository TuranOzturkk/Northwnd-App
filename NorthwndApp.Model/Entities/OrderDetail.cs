using Infrastructure.Model;

namespace NorthwndApp.Model.Entities
{
    public class OrderDetail : IEntity
    {

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Product Product { get; set; }
    }
}
