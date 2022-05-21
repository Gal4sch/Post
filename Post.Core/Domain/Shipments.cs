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

        public Shipments(Guid shipmentId, string senderCompanyName, string senderName, int senderZipCode, string senderCity,
            string senderPhoneNumber, string senderEmail, string recipientCompanyName, string recipientName, int recipientZipCode,
            string recipientCity, string recipientPhoneNumber, string recipientEmail, string description)
        {
            Id = shipmentId;
            CompanyName = senderCompanyName;
            Name = senderName;
            ZipCode = senderZipCode;
            City = senderCity;
            PhoneNumber = senderPhoneNumber;
            Email = senderEmail;
            CompanyName = recipientCompanyName;
            Name = recipientName;
            ZipCode = recipientZipCode;
            City = recipientCity;
            PhoneNumber = recipientPhoneNumber;
            Email = recipientEmail;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public void AddParcels(int amount, int weigh, int height, int width, int length)
        {
            var numberOfPackages = _parcel.Count + 1;
            for (var i = 0; i < amount; i++)
            {
                _parcel.Add(new Parcel(this, numberOfPackages, weigh, height, width, length));
                numberOfPackages++;
            }
        }

    }
}