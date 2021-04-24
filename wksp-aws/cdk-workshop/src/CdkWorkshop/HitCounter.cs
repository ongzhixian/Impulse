using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;

namespace CdkWorkshop
{
    public class HitCounterProps
    {
        // The function for which we want to count url hits
        public IFunction Downstream { get; set; }
    }

    public class HitCounter : Construct
    {
        public HitCounter(Construct scope, string id, HitCounterProps props) : base(scope, id)
        {
            // TODO
        }
    }
}