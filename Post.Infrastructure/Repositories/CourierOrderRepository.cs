using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Core.Repositories;

namespace Post.Infrastructure.Repositories
{
    public class CourierOrderRepository : ICourierOrderRepository
    {
        private static readonly ISet<CourierOrder> _courierOrder = new HashSet<CourierOrder>
        {
            new CourierOrder(Guid.NewGuid(), 20220528, "company 1", "name 1", "street 1", 02274 , "city 1",
                "777", "test@test.com", "description", 1)
        };

        public async Task<CourierOrder> GetAsync(Guid id)
            => await Task.FromResult(_courierOrder.SingleOrDefault(x => x.Id == id));

        public async Task<CourierOrder> GetAsync(int courierOrderNumber)
            => await Task.FromResult(_courierOrder.SingleOrDefault(x => x.CourierOrderNumber == courierOrderNumber));

        public async Task<CourierOrder> GetAsync(string companyName = "")
            => await Task.FromResult(_courierOrder.SingleOrDefault(x => x.SenderCompanyName.ToLowerInvariant() == companyName.ToLowerInvariant()));

        public async Task<IEnumerable<CourierOrder>> BrowseAsync(string companyName)
            => await Task.FromResult(_courierOrder);

        public async Task AddAsync(CourierOrder courierOrderNumber)
        {
            _courierOrder.Add(courierOrderNumber);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(CourierOrder courierOrderNumber)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(CourierOrder courierOrderNumber)
        {
            _courierOrder.Remove(courierOrderNumber);
            await Task.CompletedTask;
        }
    }
}