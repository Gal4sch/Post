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
        private static readonly ISet<Shipments> _shipments = new HashSet<Shipments>
        {
            new Shipments(Guid.NewGuid(), 1024 , "company 1", "name", "street", 11111, "city 1", "777", "test1@test.com", "company 2", 
                "name 2", "street 2", 11111, "City 2", "555",  "test2@test.com", "description")
        };

        public async Task<Shipments> GetAsync(Guid id)
            => await Task.FromResult(_shipments.SingleOrDefault(x => x.Id == id));

        public async Task<Shipments> GetAsync(int shipmentsNumber)
            => await Task.FromResult(_shipments.SingleOrDefault(x => x.ShipmentsNumber == shipmentsNumber));

        public async Task<Shipments> GetAsync(string companyName)
            => await Task.FromResult(_shipments.SingleOrDefault(x => x.SenderCompanyName.ToLowerInvariant() == companyName.ToLowerInvariant()));

        public async Task<IEnumerable<Shipments>> BrowseAsync(string companyName)
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