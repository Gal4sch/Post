using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Post.Core.Domain;

namespace Post.Core.Repositories
{
    public interface ICourierOrderRepository
    {
        Task<CourierOrder> GetAsync(Guid id);
        Task<CourierOrder> GetAsync(int courierOrderNumber);
        Task<CourierOrder> GetAsync(string companyName = "");
        Task<IEnumerable<CourierOrder>> BrowseAsync(string companyName);
        Task AddAsync(CourierOrder courierOrderNumber);
        Task UpdateAsync(CourierOrder courierOrderNumber);
        Task DeleteAsync(CourierOrder courierOrderNumber);
    }
}