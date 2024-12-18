using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapNho.Models;

public class Order
{
    [Key]
    public long Id { get; set; }
    public DateTime OrderDate { get; set; }
    public long UserId { get; set; }
    
    public virtual User User { get; set; }
    public virtual List<OrderDetail> OrderDetails { get; set; }
}