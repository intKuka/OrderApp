using System.ComponentModel;
using Domain.Abstractions;

namespace Domain.Models
{
    public class Order : IOrder
    {
        [DisplayName("Order ID")]
        public int OrderId { get; set; }

        public string Number { get; set; } = null!;

        public DateTime Date { get; set; }

        [DisplayName("Provider")]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; } = null!;

        public IList<OrderItem> OrderItems { get; set; } = null!;
    }
}

//-Id(int)
//- Number(nvarchar(max)) * редактируется * используется для фильтрации
//- Date (datetime2(7)) *редактируется * используется для фильтрации 
//- ProviderId (int) *редактируется * используется для фильтрации

