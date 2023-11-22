using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Providers.GetAllProviders;

public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, List<Provider>>
{
    private readonly IApplicationDbContext _context;

    public GetAllProvidersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Provider>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Providers.ToListAsync(cancellationToken);
    }
}