using System.ComponentModel;

namespace Impulse.CloudServices.Aws.DynamoDb
{
    public enum Operation
    {
        [Description("Create")]
        Create,

        [Description("Check if exist")]
        CheckIfExist,

        [Description("Delete")]
        Delete,

        [Description("Create item")]
        CreateItem

        //[Description("Update")]
        //Update,


    }
}
