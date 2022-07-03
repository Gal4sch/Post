using System;

namespace Post.Infrastructure.DTO
{
    public class ParcelDto
    {
        public Guid ShipmentsId { get; set; }
        public int ShipmentsNumber { get; set; }
        public int NumberOfParcels { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public Guid? UserId { get; set; }
        public string Username { get; set; }
        public bool Created { get; set; }
    }
}