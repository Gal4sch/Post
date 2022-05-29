using System;

namespace Post.Infrastructure.Commands.CourierOrder
{
    public class UpdateCourierOrder
    {
        public Guid CourierOrderId { get; set; }
        public string SenderCompanyName { get; set; }
        public string SenderName { get; set; }
        public string SenderStreet { get; set; }
        public int SenderZipCode { get; set; }
        public string SenderCity { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SenderEmail { get; set; }
        public string Description { get; set; }
        public int NumberOfPackages { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }
}