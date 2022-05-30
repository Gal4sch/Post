using System;
using System.Collections.Generic;

namespace Post.Core.Domain
{
    public class Shipments : AdressAndParameters
    {
        private ISet<Parcel> _parcel = new HashSet<Parcel>();
        public int ShipmentsNumber { get; protected set; }
        public IEnumerable<Parcel> Parcel => _parcel;
        protected Shipments()
        {
        }

        public Shipments(Guid shipmentId, int shipmentsNumber, string senderCompanyName, string senderName, string senderStreet, int senderZipCode, 
            string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName, string recipientName, string recipientStreet,
            int recipientZipCode, string recipientCity, string recipientPhoneNumber, string recipientEmail, string description)
        {
            Id = shipmentId;
            ShipmentsNumber = shipmentsNumber;
            SetCompanyName(senderCompanyName, recipientCompanyName);
            SenderName = senderName;
            SenderStreet = senderStreet;
            SenderZipCode = senderZipCode;
            SenderCity = senderCity;
            SenderPhoneNumber = senderPhoneNumber;
            SenderEmail = senderEmail;
            RecipientName = recipientName;
            RecipientStreet = recipientStreet;
            RecipientZipCode = recipientZipCode;
            RecipientCity = recipientCity;
            RecipientPhoneNumber = recipientPhoneNumber;
            RecipientEmail = recipientEmail;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void SetCompanyName(string senderCompanyName, string recipientCompanyName)
        {
            if(string.IsNullOrWhiteSpace(senderCompanyName))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty sender company name.");
            }
            if(string.IsNullOrWhiteSpace(recipientCompanyName))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty recipient company name.");
            }
            SenderCompanyName = senderCompanyName;
            RecipientCompanyName = recipientCompanyName;
            UpdatedAt = DateTime.Now;
        }
        public void AddParcels(int amount, int weight, int height, int width, int length)
        {
            var numberOfPackages = _parcel.Count + 1;
            for (var i = 0; i < amount; i++)
            {
                _parcel.Add(new Parcel(this, numberOfPackages, weight, height, width, length));
                numberOfPackages++;
            }
        }
    }
}