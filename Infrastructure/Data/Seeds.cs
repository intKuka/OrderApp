using Domain.Models;

namespace Infrastructure.Data
{
    public static class Seeds
    {
        public static List<Provider> ProviderSeed = new()
        {
            new Provider { ProviderId = 1, Name = "eBay" },
            new Provider { ProviderId = 2, Name = "Amazon"},
            new Provider { ProviderId = 3, Name = "Wildberries"},
            new Provider { ProviderId = 4, Name = "Yandex.Market"},
            new Provider { ProviderId = 5, Name = "Ozon"}
        };
    }
}
