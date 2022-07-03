using System;

namespace Post.Core.Domain
{
    public class AdressAndParameters : User
    {
        public string SenderCompanyName { get; protected set; }
        public string SenderName { get; protected set; }
        public string SenderStreet { get; protected set; }
        public int SenderZipCode { get; protected set; }
        public string SenderCity { get; protected set; }
        public string SenderPhoneNumber { get; protected set; }
        public string SenderEmail { get; protected set; }
        public string RecipientCompanyName { get; protected set; }
        public string RecipientName { get; protected set; }
        public string RecipientStreet { get; protected set; }
        public int RecipientZipCode { get; protected set; }
        public string RecipientCity { get; protected set; }
        public string RecipientPhoneNumber { get; protected set; }
        public string RecipientEmail { get; protected set; }
        public string Description { get; protected set; }
        public int NumberOfParcels { get; protected set; }
        public int Weight { get; protected set; }
        public int Height { get; protected set; }
        public int Width { get; protected set; }
        public int Length { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}