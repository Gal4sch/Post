using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Post.Core.Domain;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Services
{
    public class CourierOrderService : ICourierOrderService
    {
        private readonly ICourierOrderService _courierOrderRepository;
        private readonly IMapper _mapper;

        public CourierOrderService(ICourierOrderService courierOrderRepository, IMapper mapper)
        {
            _courierOrderRepository = courierOrderRepository;
            _mapper = mapper;
        }

        public async Task<CourierOrderDto> GetAsync(Guid id)
        {
            var shipments = await _courierOrderRepository.GetAsync(id);

            return _mapper.Map<CourierOrderDto>(shipments);
        }

        public async Task<CourierOrderDto> GetAsync(int shipmentsNumber)
        {
            var shipments = await _courierOrderRepository.GetAsync(shipmentsNumber);

            return _mapper.Map<CourierOrderDto>(shipments);
        }

        public async Task<CourierOrderDto> GetAsync(string companyName)
        {
            var shipments = await _courierOrderRepository.GetAsync(companyName);

            return _mapper.Map<CourierOrderDto>(shipments);
        }

        public async Task<IEnumerable<CourierOrderDto>> BrowseAsync(string companyName = null)
        {
            var shipments = await _courierOrderRepository.BrowseAsync(companyName);

            return _mapper.Map<IEnumerable<CourierOrderDto>>(shipments);
        }

        public async Task CreateAsync(Guid id, int courierOrderNumber, int numberOfPackages, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string description, 
            int weight, int height, int width, int length)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, int courierOrderNumber, int numberOfPackages, string senderCompanyName, string senderName, string senderStreet,
            string senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string description, 
            int weight, int height, int width, int length)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}