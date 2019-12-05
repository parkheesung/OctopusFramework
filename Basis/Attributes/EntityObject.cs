using System.Data;

namespace Octopus.Basis
{
    public class EntityObject
    {
        public string LogicalName { get; set; } = string.Empty;
        public string PhysicalName { get; set; } = string.Empty;
        public int Size { get; set; } = 0;

        public Entities.EntityType Type { get; set; }

        public SqlDbType DbType { get; set; }

        public EntityObject()
        {
        }
    }

    public class Entities
    {
        public enum EntityType
        {
            None = 0,
            Key = 1,
            ReadOnly = 2,
            Identity = 3,
            Hide = 4
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
