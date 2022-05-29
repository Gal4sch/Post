using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Services
{
    public interface IShipmentsService
    {
        Task<ShipmentsDto> GetAsync(Guid id);
        Task<ShipmentsDto> GetAsync(int shipmentsNumber);
        Task<ShipmentsDto> GetAsync(string companyName);
        Task<IEnumerable<ShipmentsDto>> BrowseAsync(string companyName = null);
        Task CreateAsync(Guid id, int shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, int recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description);
        Task AddParcelsAsync(Guid id, int shipmentsNumber, int numberOfPackages, int weight, int height, int width, int length);
        Task UpdateAsync(Guid id, int shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, int recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description);
        Task DeleteAsync(Guid id);
    }
}