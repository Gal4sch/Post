using System;
using System.Collections.Generic;

namespace Post.Core.Domain
{
    public class CourierOrder : AdressAndParameters
    {
        public int CourierOrderNumber { get; protected set; }
        public int NumberOfPackages { get; protected set; }

        protected CourierOrder()
        {
        }

        public CourierOrder(Guid courierOrderId, int courierOrderNumber, string senderCompanyName, string senderName,
            string senderStreet, int senderZipCode, string senderCity, string senderPhoneNumber, string senderEmail,
            string description, int numberOfPackages)
        {
            Id = courierOrderId;
            CourierOrderNumber = courierOrderNumber;
            SenderCompanyName = senderCompanyName;
            SenderName = senderName;
            SenderStreet = senderStreet;
            SenderZipCode = senderZipCode;
            SenderCity = senderCity;
            SenderPhoneNumber = senderPhoneNumber;
            SenderEmail = senderEmail;
            Description = description;
            NumberOfPackages = numberOfPackages;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}