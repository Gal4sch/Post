using System.Linq;
using AutoMapper;
using Post.Core.Domain;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Shipments, ShipmentsDto>()
                    .ForMember(x => x.NumberOfParcels, m => m.MapFrom(p => p.Parcel.Count()));
                cfg.CreateMap<CourierOrder, CourierOrderDto>();
                cfg.CreateMap<Shipments,ShipmentsDetailsDto>();
                cfg.CreateMap<ShipmentsNumber,ParcelDto>();
                cfg.CreateMap<User,AccountDto>();
            })
            .CreateMapper();
    }
}