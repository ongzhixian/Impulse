namespace Impulse.CloudServices.Aws.DynamoDb
{
    using System;

    public static class DataTypeExtensions
    {
        public static (string name, string dataType, object dataValue) AttributeValue(this DataType dataType, string key, object value)
        {
            switch (dataType)
            {
                case DataType.Binary: return (key, "B", value);
                case DataType.Boolean: return (key, "BOOL", value);
                case DataType.BinarySet: return (key, "BS", value);
                case DataType.List: return (key, "L", value);
                case DataType.Map: return (key, "M", value);
                case DataType.Number: return (key, "N", value);
                case DataType.NumberSet: return (key, "NS", value);
                case DataType.Null: return (key, "NULL", value);
                case DataType.String: return (key, "S", value);
                case DataType.StringSet: return (key, "SS", value);
                default: throw new ArgumentOutOfRangeException(nameof(dataType));
            }
        } // (string name, string dataType, object dataValue) AttributeValue(this DataType dataType, string key, object value)
    } // class DataTypeExtensions
} // namespace Impulse.CloudServices.Aws.DynamoDb
