using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Core.Repositories;

namespace Post.Infrastructure.Repositories
{
    public class ShipmentsRepository : IShipmentsRepository
    {
        private static readonly ISet<Shipments> _shipments = new HashSet<Shipments>();

        public async Task<Shipments> GetAsync(Guid id)
            => await Task.FromResult(_shipments.SingleOrDefault(x => x.Id == id));

        public async Task<Shipments> GetAsync(int shipmentsNumber)
            => await Task.FromResult(_shipments.SingleOrDefault(x => x.ShipmentsNumber == shipmentsNumber));

        public async Task<Shipments> GetAsync(string companyName = "")
            => await Task.FromResult(_shipments.SingleOrDefault(x => x.CompanyName.ToLowerInvariant() == companyName.ToLowerInvariant()));

        public async Task<IEnumerable<Shipments>> BrowseAsync(int shipmentsNumber)
            => await Task.FromResult(_shipments);
        public async Task AddAsync(Shipments shipments)
        {
            _shipments.Add(shipments);
            await Task.CompletedTask;
        }


        public async Task UpdateAsync(Shipments shipments)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Shipments shipments)
        {
            _shipments.Remove(shipments);
            await Task.CompletedTask;
        }
    }
}