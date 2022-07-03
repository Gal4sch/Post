using System;
using System.Collections.Generic;

namespace Post.Core.Domain
{
    public class Shipments : AdressAndParameters
    {
        private ISet<ShipmentsNumber> _parcel = new HashSet<ShipmentsNumber>();
        public int ShipmentsNumber { get; protected set; }
        public IEnumerable<ShipmentsNumber> Parcel => _parcel;
        protected Shipments()
        {
        }

        public Shipments(Guid shipmentId, int shipmentsNumber, string senderCompanyName, string senderName, string senderStreet, int senderZipCode,
            string senderCity, string senderPhoneNumber, string senderEmail, string recipientCompanyName, string recipientName, string recipientStreet,
            int recipientZipCode, string recipientCity, string recipientPhoneNumber, string recipientEmail, string description, int numberOfParcels)
        {
            Id = shipmentId;
            GenerateShipmentsNumber(shipmentsNumber, numberOfParcels);
            SetCompanyName(senderCompanyName, recipientCompanyName);
            SetName(senderName, recipientName);
            SetStreet(senderStreet, recipientStreet);
            SetZipCode(senderZipCode, recipientZipCode);
            SenderCity = senderCity;
            SenderPhoneNumber = senderPhoneNumber;
            SenderEmail = senderEmail;
            RecipientZipCode = recipientZipCode;
            RecipientCity = recipientCity;
            RecipientPhoneNumber = recipientPhoneNumber;
            RecipientEmail = recipientEmail;
            Description = description;
            NumberOfParcels = numberOfParcels;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void GenerateShipmentsNumber(int shipmentsNumber, int numberOfParcels)
        {
            Random shipmentsNumber2 = new Random();
            shipmentsNumber = shipmentsNumber2.Next();
            
            for (var i = 0; i < (numberOfParcels); i++)
            {
                shipmentsNumber++;
            }
            ShipmentsNumber = shipmentsNumber;
            NumberOfParcels = numberOfParcels;
            UpdatedAt = DateTime.Now;
        }

        public void SetCompanyName(string senderCompanyName, string recipientCompanyName)
        {
            if (string.IsNullOrWhiteSpace(senderCompanyName))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty sender company name.");
            }
            if (string.IsNullOrWhiteSpace(recipientCompanyName))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty recipient company name.");
            }
            SenderCompanyName = senderCompanyName;
            RecipientCompanyName = recipientCompanyName;
            UpdatedAt = DateTime.Now;
        }
        public void SetName(string senderName, string recipientName)
        {
            if (string.IsNullOrWhiteSpace(senderName))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty sender name.");
            }
            if (string.IsNullOrWhiteSpace(recipientName))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty recipient name.");
            }
            SenderName = senderName;
            RecipientName = recipientName;
            UpdatedAt = DateTime.Now;
        }
        public void SetStreet(string senderStreet, string recipientStreet)
        {
            if (string.IsNullOrWhiteSpace(senderStreet))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty sender street.");
            }
            if (string.IsNullOrWhiteSpace(recipientStreet))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty recipient street.");
            }
            SenderStreet = senderStreet;
            RecipientStreet = recipientStreet;
            UpdatedAt = DateTime.Now;
        }
        public void SetZipCode(int senderZipCode, int recipientZipCode)
        {
            string senderZipCode2 = senderZipCode.ToString();
            string recipientZipCode2 = recipientZipCode.ToString();
            if (string.IsNullOrWhiteSpace(senderZipCode2) || string.IsNullOrWhiteSpace(recipientZipCode2))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty sender or recipient zip code.");
            }
            SenderZipCode = senderZipCode;
            RecipientZipCode = recipientZipCode;
            UpdatedAt = DateTime.Now;
        }
        public void SetCity(string senderCity, string recipientCity)
        {
            if (string.IsNullOrWhiteSpace(senderCity) || string.IsNullOrWhiteSpace(recipientCity))
            {
                throw new Exception($"Shipments with id: '{Id}' can not have an empty sender or recipient zip code.");
            }
            SenderCity = senderCity;
            RecipientCity = recipientCity;
            UpdatedAt = DateTime.Now;
        }

        public void ChangeAmountOfParcels(int numberOfParcels)
        {
            string numberOfParcels2 = numberOfParcels.ToString();
            if (string.IsNullOrWhiteSpace(numberOfParcels.ToString()))
            {
                throw new Exception($"Shipment with id: '{Id}' must have minimum one parcel.");
            }

            NumberOfParcels = numberOfParcels;
            UpdatedAt = DateTime.Now;
        }

        public void AddParcels(int numberOfParcels, int shipmentsNumber, int weight, int height, int width, int length)
        {
            var parcelNumber = _parcel.Count + 1;
            for (var i = 0; i < numberOfParcels; i++)
            {
                _parcel.Add(new ShipmentsNumber(this, parcelNumber, weight, height, width, length));
                parcelNumber++;
            }
        }
    }
}