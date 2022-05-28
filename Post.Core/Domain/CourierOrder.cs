using System;
using System.Collections.Generic;

namespace Post.Core.Domain
{
    public class CourierOrder : AdressAndParameters
    {
        public int CourierOrderNumber { get; protected set; }
        public int NumberOfPackages { get; protected set;}

        protected CourierOrder()
        {    
        }

        public CourierOrder(Guid courierOrderId, int courierOrderNumber, int numberOfPackages, 
            string senderCompanyName, string senderName, string senderStreet, int senderZipCode, 
            string senderCity, string senderPhoneNumber, string senderEmail, string description)
        {
            Id = courierOrderId;
            CourierOrderNumber = courierOrderNumber;
            NumberOfPackages = numberOfPackages;
            SenderCompanyName = senderCompanyName;
            SenderName = senderName;
            SenderStreet = senderStreet;
            SenderZipCode = senderZipCode;
            SenderCity = senderCity;
            SenderPhoneNumber = senderPhoneNumber;
            SenderEmail = senderEmail;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}