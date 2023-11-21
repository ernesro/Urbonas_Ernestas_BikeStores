﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

///<author> Ernestas Urbonas </author>
namespace BikeStoresEntidades;

[Table("customers", Schema = "sales")]
public partial class Customer : IDisposable
{
    bool disposed;

    [Key]
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("first_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("phone")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("street")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Street { get; set; }

    [Column("city")]
    [StringLength(50)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("state")]
    [StringLength(25)]
    [Unicode(false)]
    public string? State { get; set; }

    [Column("zip_code")]
    [StringLength(5)]
    [Unicode(false)]
    public string? ZipCode { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public Customer(int customerId, string firstName, string lastName, string? phone, string email, string? street, string? city, string? state, string? zipCode, ICollection<Order> orders)
    {
        disposed = false;
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Orders = orders;
    }

    public Customer(int customerId, string firstName, string lastName, string email, ICollection<Order> orders)
    {
        disposed = false;
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Orders = orders;
    }

    public Customer()
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
        return CustomerId + "#" + FirstName + "#" + LastName + "#" + Phone + "#" + Email + "#" + Street + "#" + City + "#" + State + "#" + ZipCode + "#" + Orders.Count;
    }
}
