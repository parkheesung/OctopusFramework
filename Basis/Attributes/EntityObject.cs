using System;
using System.Collections.Generic;
using System.Text;

namespace Octopus.Basis
{
    public class EntityObject
    {
        public string LogicalName { get; set; } = string.Empty;
        public string PhysicalName { get; set; } = string.Empty;
        public int Size { get; set; } = 0;

        public Entities.EntityType Type { get; set; }

        public EntityObject()
        {
        }
    }

    public class Entities
    {
        public enum EntityType
        {
            String = 10,
            Code = 11,
            Numeric = 12,
            Date = 13,
            Time = 14,
            Number = 20,
            Double = 21,
            Identity = 22,
            DateTime = 30,
            Boolean = 40,
            Object = 99
        }

        public enum Method
        {
            Select = 1,
            Insert = 2,
            Update = 3,
            Delete = 4,
            Count = 5,
            GroupBy = 6,
            List = 9
        }

    }
}
