using System.ComponentModel;

namespace Impulse.CloudServices.Aws.DynamoDb
{
    public enum OperationState
    {
        [Description("Start")]
        Start,

        [Description("End")]
        End
    }
}