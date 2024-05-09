// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

/*
     Fluent Api : OnModelCreating metodu override edilerek yazılır ,ilişkiler c# kodu yazılarak belirtilir
     HasOne,WithOne
     HasMany,WithMany 
 */


public class Personel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? LastName { get; set; }
    public PersonelAddress PersonelAddress { get; set; }
}

public class PersonelAddress
{
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

    //Fluent Api 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonelAddress>()
                    .HasKey(x => x.Id);

        //bir personel PersonelAddress ile bire bir bir ilişkiye sahiptir , Aynı zamanda PersonelAddress 'te personel ile 
        //birebir bir ilişkiye sahiptir
        modelBuilder.Entity<Personel>()
                    .HasOne(x => x.PersonelAddress)
                    .WithOne(x => x.Personel)
                    .HasForeignKey<PersonelAddress>(x => x.Id);
    }
}