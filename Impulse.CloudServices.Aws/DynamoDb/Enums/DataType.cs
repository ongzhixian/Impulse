using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Impulse.CloudServices.Aws.DynamoDb
{

    /*
S       – String
N       – Number
B       – Binary
BOOL    – Boolean
NULL    – Null
M       – Map
L       – List
SS      – String Set
NS      – Number Set
BS      – Binary Set
         */

    public enum DataType
    {
        [Description("S")]
        String,

        [Description("N")]
        Number,

        [Description("B")]
        Binary,

        [Description("BOOL")]
        Boolean,

        [Description("NULL")]
        Null,

        [Description("M")]
        Map,

        [Description("L")]
        List,

        [Description("SS")]
        StringSet,

        [Description("NS")]
        NumberSet,

        [Description("BS")]
        BinarySet
    }
}
