using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Services
{
    public interface ICourierOrderService
    {
        Task<CourierOrderDto> GetAsync(Guid id);
        Task<CourierOrderDto> GetAsync(int courierOrderNumber);
        Task<CourierOrderDto> GetAsync(string companyName);
        Task<IEnumerable<CourierOrderDto>> BrowseAsync(string companyName = null);
        Task CreateAsync(Guid id, int courierOrderNumber, int numberOfPackages, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string description, 
            int weight, int height, int width, int length);
        Task UpdateAsync(Guid id, int courierOrderNumber, int numberOfPackages, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string description, 
            int weight, int height, int width, int length);
        Task DeleteAsync(Guid id);
    }
}