using System;

namespace Post.Infrastructure.DTO
{
    public class ShipmentsDto
    {
        public Guid Id { get; set; }
        public int ShipmentsNumber { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int ParcelsCount { get; set; }
    }
}