using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Impulse.DataStores.MongoDb.Extensions
{
    public static class BsonDocumentExtensions
    {
        public static IDictionary<string, object> ToDictionary(this BsonDocument document)
        {
            return document.ToDictionary<object>();
        }

        public static IDictionary<string, T> ToDictionary<T>(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            Dictionary<string, T> result = new Dictionary<string, T>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            {
                //if (property.PropertyType.IsValueType
                //    || property.PropertyType.IsArray
                //    || (property.PropertyType.FullName == "System.String"))
                //{
                //    result.Add(property.Name, (T)property.GetValue(obj));
                //    continue;
                //}

                object value = property.GetValue(obj);

                result.Add(property.Name, (T)value.ToCompatDictionary());
            }

            return result;
        }
    }
}
