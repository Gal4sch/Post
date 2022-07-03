using System;

namespace Post.Infrastructure.DTO
{
    public class ShipmentsDto
    {
        public Guid Id { get; set; }
        public int ShipmentsNumber { get; set; }
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
        public int NumberOfParcels { get; set; }
    }
}