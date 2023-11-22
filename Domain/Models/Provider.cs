using System.ComponentModel;

namespace Domain.Models;

public class Provider
{
    [DisplayName("Provider ID")]
    public int ProviderId { get; set; }
    public string Name { get; set; } = null!;


    public IList<Order> Orders { get; set; } = null!;
}