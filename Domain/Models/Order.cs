namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;

        public DateTimeOffset Date { get; set; }

        public int ProviderId { get; set; }
    }
}

//-Id(int)
//- Number(nvarchar(max)) * редактируется * используется для фильтрации
//- Date (datetime2(7)) *редактируется * используется для фильтрации 
//- ProviderId (int) *редактируется * используется для фильтрации

