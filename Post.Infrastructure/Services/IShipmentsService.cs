using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Services
{
    public interface IShipmentsService
    {
        Task<ShipmentsDetailsDto> GetAsync(Guid id);
        Task<ShipmentsDetailsDto> GetAsync(int shipmentsNumber);
        Task<ShipmentsDetailsDto> GetAsync(string companyName);
        Task<IEnumerable<ShipmentsDto>> BrowseAsync(string companyName = null);
        Task CreateAsync(Guid id, int shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, int recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description);
        Task AddParcelsAsync(Guid id, int numberOfPackages, int weight, int height, int width, int length);
        Task UpdateAsync(Guid id, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, int recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description);
        Task DeleteAsync(Guid id);
    }
}