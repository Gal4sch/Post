using System;

namespace Post.Core.Domain
{
    public class AdressAndParameters : User
    {
        public string CompanyName { get; protected set; }
        public string Name { get; protected set; }
        public string Street { get; protected set; }
        public int ZipCode { get; protected set; }
        public string City { get; protected set; }
        public string Description { get; protected set; }
        public int Weigh { get; protected set; }
        public int Height { get; protected set; }
        public int Width { get; protected set; }
        public int Length { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}