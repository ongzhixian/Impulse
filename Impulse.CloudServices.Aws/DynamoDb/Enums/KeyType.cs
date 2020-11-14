using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Impulse.CloudServices.Aws.DynamoDb
{
    public enum KeyType
    {
        /// <summary>
        /// partition key
        /// </summary>
        /// 
        [Description("HASH")]
        Hash,

        /// <summary>
        /// sort key
        /// </summary>
        [Description("RANGE")]
        Range

    }
    
}
