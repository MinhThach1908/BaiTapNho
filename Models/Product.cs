using System.ComponentModel.DataAnnotations;

namespace BaiTapNho.Models;

public class Product
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public virtual List<OrderDetail> OrderDetails { get; set; }
}