using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[PrimaryKey("OrderId", "ItemId")]
[Table("order_items", Schema = "sales")]
public partial class OrderItem : IDisposable
{
    bool disposed;

    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("list_price", TypeName = "decimal(10, 2)")]
    public decimal ListPrice { get; set; }

    [Column("discount", TypeName = "decimal(4, 2)")]
    public decimal Discount { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = new Order();

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product Product { get; set; } = null!;

    public OrderItem(int orderId, int itemId, int productId, int quantity, decimal listPrice, decimal discount, Order order, Product product)
    {
        disposed = false;
        OrderId = orderId;
        ItemId = itemId;
        ProductId = productId;
        Quantity = quantity;
        ListPrice = listPrice;
        Discount = discount;
        Order = order;
        Product = product;
    }

    public OrderItem()
    {
        disposed = false;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            // Free any other managed objects here.
            //Liberar recursos no manejados como ficheros, conexiones a bd, etc.
        }

        disposed = true;
    }

    public override string ToString()
    {
        return $"{OrderId}#{ItemId}#{ProductId}#{Quantity}#{ListPrice}#{Discount}#{Order}#{Product}";
    }
}
