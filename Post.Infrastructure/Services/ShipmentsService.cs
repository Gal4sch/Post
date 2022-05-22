using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Post.Core.Domain;
using Post.Core.Repositories;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Services
{
    public class ShipmentsService : IShipmentsService
    {
        private readonly IShipmentsRepository _shipmentsRepository;
        private readonly IMapper _mapper;

        public ShipmentsService(IShipmentsRepository shipmentsRepository, IMapper mapper)
        {
            _shipmentsRepository = shipmentsRepository;
            _mapper = mapper;
        }

        public async Task<ShipmentsDto> GetAsync(Guid id)
        {
            var shipments = await _shipmentsRepository.GetAsync(id);

            return _mapper.Map<ShipmentsDto>(shipments);
        }

        public async Task<ShipmentsDto> GetAsync(int shipmentsNumber)
        {
            var shipments = await _shipmentsRepository.GetAsync(shipmentsNumber);

            return _mapper.Map<ShipmentsDto>(shipments);
        }

        public async Task<ShipmentsDto> GetAsync(string companyName)
        {
            var shipments = await _shipmentsRepository.GetAsync(companyName);
            
            return _mapper.Map<ShipmentsDto>(shipments);
        }

        public async Task<IEnumerable<ShipmentsDto>> BrowseAsync(string companyName = null)
        {
            var shipments = await _shipmentsRepository.BrowseAsync(companyName);

            return _mapper.Map<IEnumerable<ShipmentsDto>>(shipments);
        }

        public async Task CreateAsync(Guid id, string shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName, 
            string recipientName, string recipientStreet, string recipientZipCode, string recipientCity, string recipientPhoneNumber, 
            string recipientEmail, string description, int weight, int height, int width, int length)
        {
            throw new NotImplementedException();
        }

        public async Task AddParcelsAsync(Guid id, int shipmentsNumber, int numberOfPackages, 
            int weight, int height, int width, int length)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, string shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName, 
            string recipientName, string recipientStreet, string recipientZipCode, string recipientCity, string recipientPhoneNumber, 
            string recipientEmail, string description, int weight, int height, int width, int length)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}