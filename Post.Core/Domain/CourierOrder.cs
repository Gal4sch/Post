using System;
using System.Collections.Generic;

namespace Post.Core.Domain
{
    public class CourierOrder : AdressAndParameters
    {
        public DateTime StatusDate { get; protected set; }
        public int NumberOfPackages { get; protected set;}
    }
}