using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[Table("brands", Schema = "production")]
public partial class Brand : IDisposable
{
    bool disposed;

    [Key]
    [Column("brand_id")]
    public int BrandId { get; set; }

    [Column("brand_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string BrandName { get; set; } = null!;

    [InverseProperty("Brand")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public Brand(int brandoId, string brandName, ICollection<Product> products)
    {
        disposed = false;
        BrandId = brandoId;
        BrandName = brandName;
        Products = products;
    }

    public Brand()
    {
        disposed = false;
    }

    // Public implementation of Dispose pattern callable by consumers.
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
        return BrandId + "#" + BrandName + "#" + Products.Count;
    }

}
