using System.Collections.Generic;

namespace Post.Infrastructure.DTO
{
    public class ShipmentsDetailsDto : ShipmentsDto
    {
        public IEnumerable<ParcelDto> Parcels { get; set; }
    }
}