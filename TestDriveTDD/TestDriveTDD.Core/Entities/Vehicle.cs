using System;
using System.Collections.Generic;
using System.Text;
using TestDriveTDD.Core.Interfaces;

namespace TestDriveTDD.Core.Entities
{
    public class Vehicle : IAuditableEntity
    {
        public Guid ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Name { get; set; }

        public Guid DealerID { get; set; }
        public Dealer Dealer { get; set; }
    }
}
