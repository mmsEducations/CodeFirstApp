// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");

/*
 */


public class Product
{

    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }

    public Tag Tag { get; set; }

    [ForeignKey(nameof(Category))]
    //[ForeignKey("Category")]
    public int CatId { get; set; }

    [ForeignKey(nameof(Tag))]
    public int TId { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public ICollection<Product> Product { get; set; }

}
public class Tag
{
    public int TagId { get; set; }

    public string Name { get; set; }

    public ICollection<Product> Product { get; set; }

}

public class AppDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }//Class to entity,Enitty to db tables 

    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Hangi database kullanılıyor ise onun provider'ı projeye eklenir 
        optionsBuilder.UseSqlServer("Server=.;Database=AppDbs;Integrated Security=true;Encrypt = False;");
    }

}