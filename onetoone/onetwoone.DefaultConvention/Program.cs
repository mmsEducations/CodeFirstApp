// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

/*
  EF İlişkiler 3 gruba ayrılır
  bire-bir ilişki
  bire-çok ilişki
  çoka-çok ilişki
  --- 
  EF 'te iliş kurmanın 3 farklı yöntemi var 
  1)Deafult Convention 
  2)Data Annotation-Attribue base 
  3)Fluent Api 

  EF 
  Database First  : proje başlarken varsa hazır bir db tercih edilir 
  Code First      : proje başlangıcında elimizde db yok ise tercih edilir 
   
  Entity : Database'deki tabloya karşılık gelir 
  Navigation Property

  Code First yönteminde C# ta yazdığımız entitilerin Database'de tabloya dönüştürme adımları
  1)add-migration name 
    script dosyası oluşturur 
   
  2)update-database 
   script dosyasının çalıştırılmasını sağlar
 */

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
    public int Id { get; set; }

    public string Address { get; set; }

    public Personel Personel { get; set; }

    public int PersonelId { get; set; }
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