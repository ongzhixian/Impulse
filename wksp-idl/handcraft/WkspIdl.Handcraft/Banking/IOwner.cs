namespace WkspIdl.Handcraft
{
    using System;

    public interface IOwner
    {
        string Id { get; set; }

        string IIdentityInformation {get;set;}
    }

    public class AccountOwner : IOwner
    {
        
    }

} // namespace WkspIdl.Handcraft