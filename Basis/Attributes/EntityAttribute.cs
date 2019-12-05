using System;
using System.Data;

namespace Octopus.Basis
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EntityAttribute : Attribute
    {
        protected EntityObject entity { get; set; } = new EntityObject();

        public EntityAttribute(string name, string id, Entities.EntityType type, SqlDbType dbType, int size)
        {
            this.entity.LogicalName = name;
            this.entity.PhysicalName = id;
            this.entity.Size = size;
            this.entity.Type = type;
            this.entity.DbType = dbType;
        }

        public EntityObject GetObject
        {
            get
            {
                return this.entity;
            }
        }

        public EntityAttribute(string name, Entities.EntityType type, SqlDbType dbtype, int size) : this(name, name, type, dbtype, size) { }

        public EntityAttribute(string name, string id, Entities.EntityType type, SqlDbType dbtype) : this(name, id, type, dbtype , - 1) { }

        public EntityAttribute(string name, Entities.EntityType type, SqlDbType dbtype) : this(name, name, type, dbtype , - 1) { }

        public EntityAttribute(string name, string id) : this(name, id, Entities.EntityType.None, SqlDbType.NVarChar, -1) { }

        public EntityAttribute(string name) : this(name, name, Entities.EntityType.None, SqlDbType.NVarChar, -1) { }

        public EntityAttribute(string name, SqlDbType dbtype, int size) : this(name, name, Entities.EntityType.None, dbtype, size) { }

        public EntityAttribute(string name, string id, SqlDbType dbtype) : this(name, id, Entities.EntityType.None, dbtype, -1) { }

        public EntityAttribute(string name, SqlDbType dbtype) : this(name, name, Entities.EntityType.None, dbtype, -1) { }

        public EntityAttribute(string name, string id, SqlDbType dbtype, int size) : this(name, id, Entities.EntityType.None, dbtype, size) { }
    }
}
