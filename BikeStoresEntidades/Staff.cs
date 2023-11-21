using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[Table("staffs", Schema = "sales")]
[Index("Email", Name = "UQ__staffs__AB6E616410F6BE31", IsUnique = true)]
public partial class Staff : IDisposable
{
    bool disposed;

    [Key]
    [Column("staff_id")]
    public int StaffId { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("active")]
    public byte Active { get; set; }

    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("manager_id")]
    public int? ManagerId { get; set; }

    [Column("password_staff")]
    [StringLength(64)]
    public string PasswordStaff { get; set; } = null!;

    [Column("image_staff")]
    public byte[]? ImageStaff { get; set; }

    [InverseProperty("Manager")]
    public virtual ICollection<Staff> InverseManager { get; set; } = new List<Staff>();

    [ForeignKey("ManagerId")]
    [InverseProperty("InverseManager")]
    public virtual Staff? Manager { get; set; }

    [InverseProperty("Staff")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("StoreId")]
    [InverseProperty("Staff")]
    public virtual Store Store { get; set; } = null!;

    public Staff(int staffId, string firstName, string lastName, string email, string? phone, byte active, int storeId, int? managerId, string passwordStaff, byte[]? imageStaff,
       ICollection<Staff> inverseManager, Staff? manager, ICollection<Order> orders, Store store)
    {
        disposed = false;
        StaffId = staffId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Active = active;
        StoreId = storeId;
        ManagerId = managerId;
        PasswordStaff = passwordStaff;
        ImageStaff = imageStaff;
        InverseManager = inverseManager;
        Manager = manager;
        Orders = orders;
        Store = store;
    }

    public Staff(int staffId, string firstName, string lastName, string email, byte active, int storeId, string passwordStaff,
       ICollection<Staff> inverseManager, ICollection<Order> orders, Store store)
    {
        disposed = false;
        StaffId = staffId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Active = active;
        StoreId = storeId;
        PasswordStaff = passwordStaff;
        InverseManager = inverseManager;
        Orders = orders;
        Store = store;
    }

    public Staff()
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
        return $"{StaffId}#{FirstName}#{LastName}#{Email}#{Phone}#{Active}#{StoreId}#{ManagerId}#{PasswordStaff}#{ImageStaff?.Length}#{InverseManager.Count}#{Manager}#{Orders.Count}#{Store}";
    }
}
