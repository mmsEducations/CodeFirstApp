// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");



AppDbContext dbContext = new AppDbContext();


public class Personel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? LastName { get; set; }
    public PersonelAddress PersonelAddress { get; set; } //Navigaiton property
}

public class PersonelAddress
{
    [Key, ForeignKey(nameof(Personel))]//Data Annotation
    public int Id { get; set; }

    public string Address { get; set; }

    public Personel Personel { get; set; }

}

public class AppDbContext : DbContext
{

    public DbSet<Personel> Personels { get; set; }//Class to entity,Enitty to db tables 

    public DbSet<PersonelAddress> PersonelAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Hangi database kullanılıyor ise onun provider'ı projeye eklenir 
        optionsBuilder.UseSqlServer("Server=.;Database=AppDbs;Integrated Security=true;Encrypt = False;");
    }
}