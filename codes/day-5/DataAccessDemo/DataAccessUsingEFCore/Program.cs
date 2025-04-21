using DataAccessUsingEFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.Configuration.AddJsonFile(@"appsettings.json", false, true);
//version-1 and 2
string? str = builder.Configuration.GetConnectionString("UnisysDbConStr");

//version-2:
//this delegate will be used to configure DbContextOptionsBuilder with a connection string to connect to a database (Sql server). later this builder will be used to produce DbContextOptions<T> object carrying the sql server connection string and will be dependency injected into the dependent instance of ProductDbContext class
Action<DbContextOptionsBuilder> options = optionsBuilder => optionsBuilder.UseSqlServer(str);
builder.Services.AddDbContext<ProductDbContext>(options, ServiceLifetime.Scoped);

IHost host = builder.Build();

//version-1:
//if (str != null)
//{
//    var db = new ProductDbContext(str);
//    var products = db.Products;
//    products.ToList().ForEach(p => Console.WriteLine(p.Name));
//}

//version-2:
var container = host.Services;
var scope = container.CreateScope();

var provider = scope.ServiceProvider;
var db = provider.GetRequiredService<ProductDbContext>();
var products = db.Products;

//adition
//products.Add(new Product { Name = "lenovo thinkpad", Make = "Lenovo", Year = "2018", Description = "new laptop from lenovo", Price = 130000M });
//int result = db.SaveChanges();
//Console.WriteLine(result > 0 ? "Added" : "not added");

//updation
//if (products.Any(p => p.Id == 102))
//{
//    var found = products.Where(p => p.Id == 102).First();
//    found.Name = "Lenovo ThinkPad 13";
//    found.Price = 135000M;

//    products.Update(found);
//    int result = db.SaveChanges();

//    Console.WriteLine(result > 0 ? "Upadated" : "not updated");
//}

//deletion
//if (products.Any(p => p.Id == 102))
//{
//    var found = products.Where(p => p.Id == 102).First();
   
//    products.Remove(found);
//    int result = db.SaveChanges();

//    Console.WriteLine(result > 0 ? "deleted" : "not deleted");
//}

//selection
products.ToList().ForEach(p => Console.WriteLine(p.Name));

scope.Dispose();

host.Run();
host.Dispose();


