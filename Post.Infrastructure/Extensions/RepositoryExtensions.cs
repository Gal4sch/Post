using System;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Core.Repositories;

namespace Post.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Shipments> GetOrFailShipmentsAsync(this IShipmentsRepository shipmentsRepository, Guid id)
        {
            var shipments = await shipmentsRepository.GetAsync(id);
            if (shipments == null)
            {
                throw new Exception($"Shipments with id: '{id}' does not exists.");
            }

            return shipments;
        }

        public static async Task<CourierOrder> GetOrFailCourierOrderAsync(this ICourierOrderRepository courierOrderRepository, Guid id)
        {
            var courierOrder = await courierOrderRepository.GetAsync(id);
            if (courierOrder == null)
            {
                throw new Exception($"Courier order with id: '{id}' does not exists.");
            }

            return courierOrder;
        }

        public static async Task<User> GetOrFailUserAsync(this IUserRepository userRepository, Guid id)
        {
            var user = await userRepository.GetAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id: '{id}' does not exists.");
            }

            return user;
        }
    }
}