using System.ComponentModel.DataAnnotations;

namespace BaiTapNho.Models;

public class OrderDetail
{
    [Key]
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
}