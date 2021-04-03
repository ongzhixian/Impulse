namespace WkspAzure.FrmWrk.CryptographicFunctions.Tests.Stubs
{
    using Microsoft.Azure.WebJobs.Host;
    using System.Diagnostics;

    public class TraceWriterStub : TraceWriter
    {
        public TraceWriterStub(TraceLevel level) : base(level)
        {
        }

        public override void Trace(TraceEvent traceEvent)
        {
        }
    } // class TraceWriterStub : TraceWriter
} // namespace WkspAzure.FrmWrk.CryptographicFunctions.Tests.Stubs
