using Domain.Models;
using MediatR;

namespace Application.CQRS.Providers.GetAllProviders;

public record GetAllProvidersQuery : IRequest<List<Provider>>;