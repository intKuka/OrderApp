using Application.Common;
using Application.ViewModels.Orders;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.CQRS.Orders.Queries.GetOrderListView;

public class GetOrderListViewQueryHandler : IRequestHandler<GetOrderListViewQuery, OrderListViewModel>
{
    private readonly IApplicationDbContext _context;

    public GetOrderListViewQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderListViewModel> Handle(GetOrderListViewQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Order> orders = _context.Orders
            .Include(p => p.Provider)
            .Include(p => p.OrderItems);
        request.Filter.Date ??= new DatePeriod(DateTime.MinValue, DateTime.MinValue);
        orders = orders.Where(order => order.Date >= request.Filter.Date.DateFrom && order.Date <= request.Filter.Date.DateTo);

        if (request.Filter.OrderNumbers.Any())
        {
            orders = orders.Where(order => 
                request.Filter.OrderNumbers.Any(number => 
                    order.Number == number));
        }

        if (request.Filter.ItemNames.Any())
        {
            orders = orders.Where(order =>
                order.OrderItems.Any(item =>
                    request.Filter.ItemNames.Any(name =>
                        item.Name == name)));
        }

        if (request.Filter.ItemUnits.Any())
        {
            orders = orders.Where(order =>
                order.OrderItems.Any(item =>
                    request.Filter.ItemUnits.Any(unit =>
                        item.Unit == unit)));
        }

        if (request.Filter.Providers.Any())
        {
            orders = orders.Where(order =>
                request.Filter.Providers.Any(provider =>
                    order.ProviderId == provider.ProviderId));
        }

        var filter = new OrderListFilter
        {
            Date = request.Filter.Date,
            SelectedOrderNumbers = request.Filter.SelectedOrderNumbers,
            SelectedItemNames = request.Filter.SelectedItemNames,
            SelectedItemUnits = request.Filter.SelectedItemUnits,
            SelectedProviderIds = request.Filter.SelectedProviderIds,
            OrderNumbers = await _context.Orders.Select(o => o.Number).Distinct().ToListAsync(cancellationToken),
            ItemNames = await _context.OrderItems.Select(i => i.Name).Distinct().ToListAsync(cancellationToken),
            ItemUnits = await _context.OrderItems.Select(i => i.Unit).Distinct().ToListAsync(cancellationToken),
            Providers = await _context.Providers.ToListAsync(cancellationToken)
        };
        var viewModel = new OrderListViewModel
        {
            Orders = await orders.ToListAsync(cancellationToken),
            Filter = filter
        };

        return viewModel;
    }
}