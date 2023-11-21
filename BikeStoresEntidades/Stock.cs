using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[PrimaryKey("StoreId", "ProductId")]
[Table("stocks", Schema = "production")]
public partial class Stock : IDisposable
{
    bool disposed;

    [Key]
    [Column("store_id")]
    public int StoreId { get; set; }

    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Stocks")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("StoreId")]
    [InverseProperty("Stocks")]
    public virtual Store Store { get; set; } = null!;

    public Stock(int storeId, int productId, int? quantity, Product product, Store store)
    {
        disposed = false;
        StoreId = storeId;
        ProductId = productId;
        Quantity = quantity;
        Product = product;
        Store = store;
    }

    public Stock(int storeId, int productId, Product product, Store store)
    {
        disposed = false;
        StoreId = storeId;
        ProductId = productId;
        Product = product;
        Store = store;
    }

    public Stock()
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

        }

        disposed = true;
    }

    public override string ToString()
    {
        return $"{StoreId}#{ProductId}#{Quantity}#{Product}#{Store}";
    }
}
