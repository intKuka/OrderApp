namespace Domain.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Quantity { get; set; }

        public string Unit { get; set; } = null!;

        public Order? Order { get; set; } 
    }
}

//-Id(int)
//- OrderId(int)
//- Name(nvarchar(max)) * редактируется * используется для фильтрации
//- Quantity decimal(18, 3) *редактируется
//- Unit(nvarchar(max)) * редактируется * используется для фильтрации
