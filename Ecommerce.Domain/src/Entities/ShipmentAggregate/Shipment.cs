using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.AddressAggregate;
using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Domain.src.Entities.ShipmentAggregate
{
    public class Shipment : BaseEntity
    {
        public DateTime ShipmentDate { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Address? Address { get; set; }
    }
}