using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Octopus.Basis
{
    public class EntityHelper
    {
    }

    public static class ExtendEntityHelper
    {
        public static EntityObject GetEntity<T>(this T target) where T : struct
        {
            EntityObject result = null;
            Type type = target.GetType();
            FieldInfo fi = type.GetField(target.ToString());
            EntityAttribute[] attrs = fi.GetCustomAttributes(typeof(EntityAttribute), false) as EntityAttribute[];
            if (attrs != null && attrs.Length > 0)
            {
                result = ((EntityAttribute)attrs[0]).GetObject;
            }
            return result;
        }


        public static EntityObject GetEntity(this PropertyInfo property)
        {
            EntityObject result = null;

            EntityAttribute temp;
            foreach (var attr in property.GetCustomAttributes())
            {
                temp = attr as EntityAttribute;
                if (temp != null)
                {
                    result = temp.GetObject;
                    break;
                }
            }

            return result;
        }

        public static EntityObject FindEntity<T>(this T target, string entityName) where T : IEntity
        {
            EntityObject result = null;

            Type type = typeof(T);

            var members = type.GetMembers();
            EntityAttribute temp;
            foreach (var member in members)
            {
                foreach (var attr in member.GetCustomAttributes())
                {
                    try
                    {
                        temp = attr as EntityAttribute;
                        if (temp != null)
                        {
                            if (temp.GetObject.PhysicalName.Equals(entityName, StringComparison.OrdinalIgnoreCase))
                            {
                                result = temp.GetObject;
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (result != null) break;
            }

            return result;
        }

        public static List<EntityObject> GetEntities<T>(this T target) where T : IEntity
        {
            List<EntityObject> result = new List<EntityObject>();

            Type type = typeof(T);

            var members = type.GetMembers();
            EntityAttribute temp;
            foreach (var member in members)
            {
                foreach (var attr in member.GetCustomAttributes())
                {
                    try
                    {
                        temp = attr as EntityAttribute;
                        if (temp != null)
                        {
                            result.Add(temp.GetObject);
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return result;
        }

        public static object GetValue<T>(this T entity, string physicalName) where T : IEntity
        {
            object result = null;

            Type type = entity.GetType();
            var properties = type.GetProperties();
            EntityObject temp = null;

            foreach (PropertyInfo property in properties)
            {
                temp = property.GetEntity();
                if (temp != null && temp.PhysicalName.Equals(physicalName, StringComparison.OrdinalIgnoreCase))
                {
                    result = property.GetValue(entity);
                    break;
                }
            }

            return result;
        }

    }
}
