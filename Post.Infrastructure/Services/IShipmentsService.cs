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
        Task CreateAsync(Guid id, string shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, string recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description, int weight, int height, int width, int length);
        Task AddParcelsAsync(Guid id, int shipmentsNumber, int numberOfPackages, int weight, int height, int width, int length);
        Task UpdateAsync(Guid id, string shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, string recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description, int weight, int height, int width, int length);
        Task DeleteAsync(Guid id);
    }
}