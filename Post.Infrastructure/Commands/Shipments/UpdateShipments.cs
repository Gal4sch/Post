using System;

namespace Post.Infrastructure.Commands.Shipments
{
    public class UpdateShipments
    {
        public Guid ShipmentsId { get; set; }
        public string SenderCompanyName { get; set; }
        public string SenderName { get; set; }
        public string SenderStreet { get; set; }
        public int SenderZipCode { get; set; }
        public string SenderCity { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SenderEmail { get; set; }
        public string RecipientCompanyName { get; set; }
        public string RecipientName { get; set; }
        public string RecipientStreet { get; set; }
        public int RecipientZipCode { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string RecipientEmail { get; set; }
        public string Description { get; set; }
        public int NumberOfPackages { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }
}