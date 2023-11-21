using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[Table("orders", Schema = "sales")]
public partial class Order : IDisposable {
    bool disposed;

    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("customer_id")]
    public int? CustomerId { get; set; }

    [Column("order_status")]
    public byte OrderStatus { get; set; }

    [Column("order_date", TypeName = "date")]
    public DateTime OrderDate { get; set; }

    [Column("required_date", TypeName = "date")]
    public DateTime RequiredDate { get; set; }

    [Column("shipped_date", TypeName = "date")]
    public DateTime? ShippedDate { get; set; }

    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("staff_id")]
    public int StaffId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


    [ForeignKey("StaffId")]
    [InverseProperty("Orders")]
    public virtual Staff Staff { get; set; } = null!;

    [ForeignKey("StoreId")]
    [InverseProperty("Orders")]
    public virtual Store Store { get; set; } = null!;

    public Order(int orderId, int? customerId, byte orderStatus, DateTime orderDate, DateTime requiredDate,
            DateTime? shippedDate, int storeId, int staffId, ICollection<OrderItem> orderItems) {
        disposed = false;
        OrderId = orderId;
        CustomerId = customerId;
        OrderStatus = orderStatus;
        OrderDate = orderDate;
        RequiredDate = requiredDate;
        ShippedDate = shippedDate;
        StoreId = storeId;
        StaffId = staffId;
        OrderItems = orderItems;
    }

    public Order(int orderId, byte orderStatus, DateTime orderDate, DateTime requiredDate, int storeId, int staffId
            , ICollection<OrderItem> orderItems) {
        disposed = false;
        OrderId = orderId;
        OrderStatus = orderStatus;
        OrderDate = orderDate;
        RequiredDate = requiredDate;
        StoreId = storeId;
        StaffId = staffId;
        OrderItems = orderItems;
    }

    public Order(Order copia) {
        disposed = false;
        OrderId = copia.OrderId;
        CustomerId = copia.CustomerId;
        OrderStatus = copia.OrderStatus;
        OrderDate = copia.OrderDate;
        RequiredDate = copia.RequiredDate;
        ShippedDate = copia.ShippedDate;
        StoreId = copia.StoreId;
        StaffId = copia.StaffId;
        OrderItems = copia.OrderItems;
    }

    public Order() {
        disposed = false;
    }

    public void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing) {
        if (disposed)
            return;

        if (disposing) {
            // Free any other managed objects here.
            //Liberar recursos no manejados como ficheros, conexiones a bd, etc.
        }

        disposed = true;
    }

    public override string ToString() {
        return $"{OrderId}#{CustomerId}#{OrderStatus}#{OrderDate}#{RequiredDate}#{ShippedDate}#{StoreId}#{StaffId}#Customer#{OrderItems.Count}#Staff#Store";
    }
}
