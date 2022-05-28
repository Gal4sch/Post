using System;

namespace Post.Infrastructure.DTO
{
    public class CourierOrderDto
    {
        public Guid Id { get; set; }
        public int CourierOrderNumber { get; set; }
        public int NumberOfPackages { get; set; }
        public string SenderCompanyName { get; set; }
        public string SenderName { get; set; }
        public string SenderStreet { get; set; }
        public int SenderZipCode { get; set; }
        public string SenderCity { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SenderEmail { get; set; }
        public string Description { get; set; }
    }
}