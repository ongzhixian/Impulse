namespace Impulse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            return obj.ToDictionary<object>();
        }

        public static IDictionary<string, T> ToDictionary<T>(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            Dictionary<string, T> result = new Dictionary<string, T>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            {
                object value = property.GetValue(obj);

                if (value is T)
                {
                    result.Add(property.Name, (T)value);
                }
            }

            return result;
        }

        public static IDictionary<string, object> ToCompatDictionary(this object obj)
        {
            return obj.ToCompatDictionary<object>();
        }

        public static IDictionary<string, T> ToCompatDictionary<T>(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            Dictionary<string, T> result = new Dictionary<string, T>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            {
                if (property.PropertyType.IsValueType 
                    || property.PropertyType.IsArray
                    || (property.PropertyType.FullName == "System.String"))
                {
                    result.Add(property.Name, (T)property.GetValue(obj));
                    continue;
                }
                
                object value = property.GetValue(obj);

                result.Add(property.Name, (T)value.ToCompatDictionary());
            }

            return result;
        }

        public static IList<IDictionary<string, object>> ToCompatDictionaryList(this object obj)
        {
            return obj.ToCompatDictionaryList<object>();
        }

        public static IList<IDictionary<string, T>> ToCompatDictionaryList<T>(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            IList<IDictionary<string, T>> result = new List<IDictionary<string, T>>();

            //T[] a = (T[])obj;

            T[] objArray = obj as T[];

            foreach (T item in objArray)
            {
                result.Add((IDictionary<string, T>) item.ToCompatDictionary());
            }


            //Dictionary<string, T> result = new Dictionary<string, T>();

            //foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            //{
            //    if (property.PropertyType.IsValueType
            //        || property.PropertyType.IsArray
            //        || (property.PropertyType.FullName == "System.String"))
            //    {
            //        result.Add(property.Name, (T)property.GetValue(obj));
            //        continue;
            //    }

            //    object value = property.GetValue(obj);

            //    result.Add(property.Name, (T)value.ToCompatDictionary());
            //}

            return result;
        }

        // TODO: Need a variant that can convert to nested Dictionary of <string, object> type

        //Dictionary<string, object> doc = new Dictionary<string, object>
        //        {
        //            {   "student_id", 40001 },
        //            {   "class_id", 400 },
        //            {   "scores", new List<Dictionary<string, object>>
        //                {
        //                    new Dictionary<string, object>{ {   "type", "exam" }, {   "score", 50 } },
        //                    new Dictionary<string, object>{ {   "type", "quiz" }, {   "score", 50 } },
        //                    new Dictionary<string, object>{ {   "type", "assignment1" }, {   "score", 43 } },
        //                }
        //            }
        //        };

        // So that we can write something like this:
        //object x = new
        //{
        //    student_id = 30001,
        //    class_id = 300,
        //    scores = new[]
        //    {
        //                new { type = "exam", score = 94}
        //            }
        //};

        // And have it be an equivalent of this
        //var document = new BsonDocument
        //{
        //    { "student_id", 10000 },
        //    { "scores", new BsonArray
        //        {
        //        new BsonDocument{ {"type", "exam"}, {"score", 88.12334193287023 } },
        //        new BsonDocument{ {"type", "quiz"}, {"score", 74.92381029342834 } },
        //        new BsonDocument{ {"type", "homework"}, {"score", 89.97929384290324 } },
        //        new BsonDocument{ {"type", "homework"}, {"score", 82.12931030513218 } }
        //        }
        //    },
        //    { "class_id", 480}
        //};

        // Another test case

        //var a = new
        //{
        //    item = "canvas",
        //    qty = 100,
        //    tags = new[] { "cotton" },
        //    size = new { h = 28, w = 35.5, uom = "cm" }
        //};

        //Dictionary<string, object> doc = new Dictionary<string, object>
        //        {
        //            { "item", "canvas" },
        //            { "qty", 500 },
        //            { "scores", new List<Dictionary<string, object>>
        //                {
        //                    new Dictionary<string, object>{ {   "type", "exam" }, {   "score", 60 } },
        //                    new Dictionary<string, object>{ {   "type", "quiz" }, {   "score", 50 } },
        //                    new Dictionary<string, object>{ {   "type", "assignment1" }, {   "score", 43 } },
        //                }
        //            },
        //            { "size", new Dictionary<string,object>{ { "h", 28 }, { "w", 35.5 }, { "uom", "cm" } } },
        //            { "tags",  new List<string>{ "asd" , "asd"} }
        //        };



    }
}
