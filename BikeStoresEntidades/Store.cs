using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[Table("stores", Schema = "sales")]
public partial class Store : IDisposable
{
    bool disposed;

    [Key]
    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("store_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string StoreName { get; set; } = null!;

    [Column("phone")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("street")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Street { get; set; }

    [Column("city")]
    [StringLength(255)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("state")]
    [StringLength(10)]
    [Unicode(false)]
    public string? State { get; set; }

    [Column("zip_code")]
    [StringLength(5)]
    [Unicode(false)]
    public string? ZipCode { get; set; }

    [InverseProperty("Store")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Store")]
    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    [InverseProperty("Store")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public Store(int storeId, string storeName, string? phone, string? email, string? street, string? city, string? state, string? zipCode,
             ICollection<Order> orders, ICollection<Staff> staff, ICollection<Stock> stocks)
    {
        disposed = false;
        StoreId = storeId;
        StoreName = storeName;
        Phone = phone;
        Email = email;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Orders = orders;
        Staff = staff;
        Stocks = stocks;
    }

    public Store(int storeId, string storeName, ICollection<Order> orders, ICollection<Staff> staff, ICollection<Stock> stocks)
    {
        disposed = false;
        StoreId = storeId;
        StoreName = storeName;
        Orders = orders;
        Staff = staff;
        Stocks = stocks;
    }

    public Store()
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
        return $"{StoreId}#{StoreName}#{Phone}#{Email}#{Street}#{City}#{State}#{ZipCode}#{Orders.Count}#{Staff.Count}#{Stocks.Count}";
    }
}
