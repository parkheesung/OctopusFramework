using System;
using System.Collections.Generic;
using System.Text;

namespace Octopus.Basis
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EntityAttribute : Attribute
    {
        protected EntityObject entity { get; set; } = new EntityObject();

        public EntityAttribute(string name, string id, Entities.EntityType type, int size)
        {
            this.entity.LogicalName = name;
            this.entity.PhysicalName = id;
            this.entity.Size = size;
            this.entity.Type = type;
        }

        public EntityObject GetObject
        {
            get
            {
                return this.entity;
            }
        }

        public EntityAttribute(string name, Entities.EntityType type, int size) : this(name, name, type, size) { }

        public EntityAttribute(string name, string id, Entities.EntityType type) : this(name, id, type, -1) { }

        public EntityAttribute(string name, Entities.EntityType type) : this(name, name, type, -1) { }

        public EntityAttribute(string name, string id) : this(name, id, Entities.EntityType.String, -1) { }

        public EntityAttribute(string name) : this(name, name, Entities.EntityType.String, -1) { }
    }
}
