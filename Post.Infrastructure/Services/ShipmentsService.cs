using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Post.Core.Domain;
using Post.Core.Repositories;
using Post.Infrastructure.DTO;
using Post.Infrastructure.Extensions;

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

        public async Task<ShipmentsDetailsDto> GetAsync(Guid id)
        {
            var shipments = await _shipmentsRepository.GetAsync(id);

            return _mapper.Map<ShipmentsDetailsDto>(shipments);
        }

        public async Task<ShipmentsDetailsDto> GetAsync(int shipmentsNumber)
        {
            var shipments = await _shipmentsRepository.GetAsync(shipmentsNumber);

            return _mapper.Map<ShipmentsDetailsDto>(shipments);
        }

        public async Task<ShipmentsDetailsDto> GetAsync(string companyName)
        {
            var shipments = await _shipmentsRepository.GetAsync(companyName);

            return _mapper.Map<ShipmentsDetailsDto>(shipments);
        }

        public async Task<IEnumerable<ShipmentsDto>> BrowseAsync(string companyName = null)
        {
            var shipments = await _shipmentsRepository.BrowseAsync(companyName);

            return _mapper.Map<IEnumerable<ShipmentsDto>>(shipments);
        }

        public async Task CreateAsync(Guid id, int shipmentsNumber, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, int recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description)
        {
            var shipments = await _shipmentsRepository.GetAsync(shipmentsNumber);
            if (shipments != null)
            {
                throw new Exception($"Shipments with number: '{shipmentsNumber}' already exists.");
            }
            shipments = new Shipments(id, shipmentsNumber, senderCompanyName, senderName, senderStreet, senderZipCode,
                senderCity, senderPhoneNumber, senderEmail, recipientCompanyName, recipientName, recipientStreet, recipientZipCode,
                recipientCity, recipientPhoneNumber, recipientEmail, description);
            await _shipmentsRepository.AddAsync(shipments);
        }

        public async Task AddParcelsAsync(Guid shipmentsId, int amount, int weight, int height, int width, int length)
        {
            var shipments = await _shipmentsRepository.GetOrFailShipmentsAsync(shipmentsId);
            shipments.AddParcels(amount, weight, height, width, length);
            await _shipmentsRepository.UpdateAsync(shipments);
        }

        public async Task UpdateAsync(Guid id, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName,
            string recipientName, string recipientStreet, int recipientZipCode, string recipientCity, string recipientPhoneNumber,
            string recipientEmail, string description)
        {
            var shipments = await _shipmentsRepository.GetOrFailShipmentsAsync(id);      
            shipments.SetCompanyName(senderCompanyName, recipientCompanyName);
            await _shipmentsRepository.UpdateAsync(shipments);
        }

        public async Task DeleteAsync(Guid id)
        {
            var shipments = await _shipmentsRepository.GetOrFailShipmentsAsync(id); 
            await _shipmentsRepository.DeleteAsync(shipments);
        }
    }
}