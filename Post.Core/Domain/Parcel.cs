using System;

namespace Post.Core.Domain
{
    public class Parcel : Shipments
    {
        public Guid ShipmentsId { get; protected set; }
        public int NumberOfPackages { get; protected set; }
        public Guid? UserId { get; protected set; }
        public string Username { get; protected set; }
        public bool Created => UserId.HasValue;

        protected Parcel()
        {
        }
        public Parcel(Shipments shipments, int numberOfPackages, int weigh, int height, int width, int length)
        {
            ShipmentsId = shipments.Id;
            NumberOfPackages = numberOfPackages;
            Weigh = weigh;
            Height = height;
            Width = width;
            Length = length;
        }
    }
}