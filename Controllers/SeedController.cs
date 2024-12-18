using BaiTapNho.Data;
using BaiTapNho.Models;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapNho.Controllers;

public class SeedController : Controller
{
    private BaiTapNhoDbContext _baiTapNhoDbContext;
    
    public SeedController(BaiTapNhoDbContext baiTapNhoDbContext)
    {
        _baiTapNhoDbContext = baiTapNhoDbContext;
    }
    
    [Obsolete("Obsolete")]
    public IActionResult GenerateSeed()
    {
        var faker = new Faker();
        var fakerVi = new Faker("vi");
        var users = Enumerable.Range(1, 3).Select(i => new User()
        {
            Name = faker.Name.FullName(),
            Email = faker.Internet.Email(),
        }).ToList();
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
        }
        _baiTapNhoDbContext.Users.AddRange(users);
        var products = Enumerable.Range(1, 30).Select(i => new Product()
        {
            Name = faker.Commerce.ProductName(),
            Price = faker.Random.Int(10, 1000)
        }).ToList();
        foreach (var p in products)
        {
            Console.WriteLine($"Name: {p.Name}, Email: {p.Price}");
        }
        _baiTapNhoDbContext.Products.AddRange(products);
        var orders = Enumerable.Range(1, 10).Select(i => new Order()
        {
            User = users[faker.Random.Int(0, users.Count - 1)], 
            UserId = users[faker.Random.Int(0, users.Count - 1)].Id, 
            OrderDetails = Enumerable.Range(1, faker.Random.Int(2, 4)) 
                .Select(od => new OrderDetail()
                {
                    ProductId = faker.Random.Int(1, products.Count), 
                    Product = products[faker.Random.Int(0, products.Count - 1)], 
                    Quantity = faker.Random.Int(1, 5),
                    UnitPrice = decimal.Parse(faker.Commerce.Price()) 
                }).ToList()
        }).ToList();
        _baiTapNhoDbContext.Orders.AddRange(orders);
        _baiTapNhoDbContext.SaveChanges();
        return Ok("Ok");
    }
    
    public IActionResult LazyLoad(long id)
    {
        var o = _baiTapNhoDbContext.Orders
            .FirstOrDefault(o => o.Id == id);
        Console.WriteLine("---------------" + o.UserId);
        return Json(o);
    }
}