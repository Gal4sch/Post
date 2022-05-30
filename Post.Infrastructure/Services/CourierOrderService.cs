using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Post.Core.Domain;
using Post.Core.Repositories;
using Post.Infrastructure.DTO;
using Post.Infrastructure.Extensions;

namespace Post.Infrastructure.Services
{
    public class CourierOrderService : ICourierOrderService
    {
        private readonly ICourierOrderRepository _courierOrderRepository;
        private readonly IMapper _mapper;

        public CourierOrderService(ICourierOrderRepository courierOrderRepository, IMapper mapper)
        {
            _courierOrderRepository = courierOrderRepository;
            _mapper = mapper;
        }

        public async Task<CourierOrderDto> GetAsync(Guid id)
        {
            var courierOrder = await _courierOrderRepository.GetAsync(id);

            return _mapper.Map<CourierOrderDto>(courierOrder);
        }

        public async Task<CourierOrderDto> GetAsync(int courierOrderNumber)
        {
            var courierOrder = await _courierOrderRepository.GetAsync(courierOrderNumber);

            return _mapper.Map<CourierOrderDto>(courierOrderNumber);
        }

        public async Task<CourierOrderDto> GetAsync(string companyName)
        {
            var courierOrder = await _courierOrderRepository.GetAsync(companyName);

            return _mapper.Map<CourierOrderDto>(courierOrder);
        }

        public async Task<IEnumerable<CourierOrderDto>> BrowseAsync(string companyName = null)
        {
            var courierOrder = await _courierOrderRepository.BrowseAsync(companyName);

            return _mapper.Map<IEnumerable<CourierOrderDto>>(courierOrder);
        }

        public async Task CreateAsync(Guid id, int courierOrderNumber, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string description, int numberOfPackages,
            int weight, int height, int width, int length)
        {
            var courierOrder = await _courierOrderRepository.GetAsync(courierOrderNumber);
            if (courierOrder != null)
            {
                throw new Exception($"Courier order with number: '{courierOrder}' already exists.");
            }
            courierOrder = new CourierOrder(id, courierOrderNumber, senderCompanyName, senderName, senderStreet, senderZipCode,
                senderCity, senderPhoneNumber, senderEmail, description, numberOfPackages, weight, height, width, length);
            await _courierOrderRepository.AddAsync(courierOrder);
        }

        public async Task UpdateAsync(Guid id, int courierOrderNumber, string senderCompanyName, string senderName, string senderStreet,
            int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail, string description, int numberOfPackages,
            int weight, int height, int width, int length)
        {
            var courierOrder = await _courierOrderRepository.GetOrFailCourierOrderAsync(id);
            courierOrder.SetCompanyName(senderCompanyName);
            await _courierOrderRepository.UpdateAsync(courierOrder);
        }

        public async Task DeleteAsync(Guid id)
        {
            var courierOrder = await _courierOrderRepository.GetOrFailCourierOrderAsync(id);
            await _courierOrderRepository.DeleteAsync(courierOrder);
        }
    }
}