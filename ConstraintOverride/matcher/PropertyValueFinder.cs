using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.matcher
{
    public static class PropertyValueFinder
    {

        public static List<Object> GetPropertyValues(string path, string propertyName, object obj)
        {
            List<Object> objects = null;
                
                       
            foreach (String part in path.Split('.'))
            {
                if (obj == null)
                {
                    break;
                }

                if (obj.IsNonStringEnumerable())
                {
                    var toEnumerable = (IEnumerable)obj;
                    var iterator = toEnumerable.GetEnumerator();
                    while (iterator.MoveNext())
                    {
                        obj = GetPartPropertyValue(part, iterator.Current);
                        path = path.Substring(path.IndexOf(".") + 1);
                        if (objects == null) objects = new List<object>();
                        objects.AddRange( GetPropertyValues(path.Substring(path.IndexOf(".") + 1), propertyName, obj));                       
                    }
                }

                obj = GetPartPropertyValue(part, obj);
                if (obj != null && part.Equals(propertyName))
                {
                    if (objects == null) objects = new List<object>();
                    objects.Add(obj);
                }
            }

            return objects;
        }

        private static Object GetPartPropertyValue(string part, object obj)
        {
            Type type = obj.GetType();
            PropertyInfo info = type.GetProperty(part);
            if (info == null)
            {
                return null;
            }

            obj = info.GetValue(obj, null);

            return obj;
        }

        public static Object GetPropertyValue(string name, object obj)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null)
                {
                    return null;
                }

                if (obj.IsNonStringEnumerable())
                {
                    var toEnumerable = (IEnumerable)obj;
                    var iterator = toEnumerable.GetEnumerator();
                    if (!iterator.MoveNext())
                    {
                        return null;
                    }
                    obj = iterator.Current;
                }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null)
                {
                    return null;
                }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static bool IsNonStringEnumerable(this PropertyInfo pi)
        {
            return pi != null && pi.PropertyType.IsNonStringEnumerable();
        }

        public static bool IsNonStringEnumerable(this object instance)
        {
            return instance != null && instance.GetType().IsNonStringEnumerable();
        }

        public static bool IsNonStringEnumerable(this Type type)
        {
            if (type == null || type == typeof(string))
                return false;
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}
