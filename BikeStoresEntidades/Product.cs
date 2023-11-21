using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[Table("products", Schema = "production")]
public partial class Product : IComparable<Product>, IDisposable
{
    bool disposed;

    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string ProductName { get; set; } = null!;

    [Column("brand_id")]
    public int BrandId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("model_year")]
    public short ModelYear { get; set; }

    [Column("list_price", TypeName = "decimal(10, 2)")]
    public decimal ListPrice { get; set; }

    [Column("image_product")]
    public byte[]? ImageProduct { get; set; }

    [ForeignKey("BrandId")]
    [InverseProperty("Products")]
    public virtual Brand Brand { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Product")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    public Product(int productId, string productName, int brandId, int categoryId,
                  short modelYear, decimal listPrice, byte[]? imageProduct, Brand brand, Category category, ICollection<OrderItem> orderItems, ICollection<Stock> stocks)
    {
        disposed = false;
        ProductId = productId;
        ProductName = productName;
        BrandId = brandId;
        CategoryId = categoryId;
        ModelYear = modelYear;
        ListPrice = listPrice;
        ImageProduct = imageProduct;
        Brand = brand;
        Category = category;
        OrderItems = orderItems;
        Stocks = stocks;
    }
    public Product(int productId, string productName, int brandId, int categoryId,
                   short modelYear, decimal listPrice, Brand brand, Category category, ICollection<OrderItem> orderItems, ICollection<Stock> stocks)
    {
        disposed = false;
        ProductId = productId;
        ProductName = productName;
        BrandId = brandId;
        CategoryId = categoryId;
        ModelYear = modelYear;
        ListPrice = listPrice;
        Brand = brand;
        Category = category;
        OrderItems = orderItems;
        Stocks = stocks;
    }

    public Product()
    {
        disposed = false;
    }

    public int CompareTo(Product? product)
    {
        if (product == null)
        {
            return 1;
        }

        int categoryComparison = string.Compare(this.Category.CategoryName, product.Category.CategoryName);

        if (categoryComparison != 0)
        {
            return categoryComparison;
        }

        return string.Compare(this.ProductName, product.ProductName);
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
        return $"{ProductId}#{ProductName}#{BrandId}#{CategoryId}#{ModelYear}#{ListPrice}#{ImageProduct?.Length}#{Brand}#{Category}#{OrderItems.Count}#{Stocks.Count}";
    }
}
