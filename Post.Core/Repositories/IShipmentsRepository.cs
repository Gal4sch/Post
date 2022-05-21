using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Post.Core.Domain;

namespace Post.Core.Repositories
{
    public interface IShipmentsRepository
    {
        Task<Shipments> GetAsync(Guid id);
        Task<Shipments> GetAsync(int shipmentsNumber);
        Task<Shipments> GetAsync(string companyName = "");
        Task<IEnumerable<Shipments>> BrowseAsync(int shipmentsNumber);
        Task AddAsync(Shipments shipments);
        Task UpdateAsync(Shipments shipments);
        Task DeleteAsync(Shipments shipments);
    }
}