using System.ComponentModel.DataAnnotations;

namespace BaiTapNho.Models;

public class User
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public virtual List<Order> Orders { get; set; }
}