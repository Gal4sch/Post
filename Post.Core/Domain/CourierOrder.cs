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
            string description, int numberOfPackages, int weight, int height, int width, int length)
        {
            Id = courierOrderId;
            CourierOrderNumber = courierOrderNumber;
            SetCompanyName(senderCompanyName);
            SenderName = senderName;
            SenderStreet = senderStreet;
            SenderZipCode = senderZipCode;
            SenderCity = senderCity;
            SenderPhoneNumber = senderPhoneNumber;
            SenderEmail = senderEmail;
            Description = description;
            NumberOfPackages = numberOfPackages;
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void SetCompanyName(string senderCompanyName)
        {
            if(string.IsNullOrWhiteSpace(senderCompanyName))
            {
                throw new Exception($"Courier order with id: '{Id}' can not have an empty sender company name.");
            }
            SenderCompanyName = senderCompanyName;
            UpdatedAt = DateTime.Now;
        }
    }
}