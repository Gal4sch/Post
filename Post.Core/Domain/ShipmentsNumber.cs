using System;

namespace Post.Core.Domain
{
    public class ShipmentsNumber : Shipments
    {
        public Guid ShipmentsId { get; protected set; }
        public Guid? UserId { get; protected set; }
        public string Username { get; protected set; }
        public bool Created => UserId.HasValue;

        protected ShipmentsNumber()
        {
        }
        public ShipmentsNumber(Shipments shipments, int shipmentsNumber, int weight, int height, int width, int length)
        {
            ShipmentsId = shipments.Id;
            ShipmentsNumber = shipmentsNumber;
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
        }
    }
}