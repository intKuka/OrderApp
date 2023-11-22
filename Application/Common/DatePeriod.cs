namespace Application.Common;

public class DatePeriod
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public DatePeriod()
    {
        DateFrom = DateTime.UtcNow.AddMonths(-1);
        DateTo = DateTime.UtcNow;
    }

    public DatePeriod(DateTime dateFrom, DateTime dateTo)
    {
        DateFrom =  dateFrom;
        DateTo =  dateTo;
    }
}