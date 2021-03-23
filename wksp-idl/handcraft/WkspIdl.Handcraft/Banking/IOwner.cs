namespace WkspIdl.Handcraft
{
    using System;

    public interface IOwner
    {
        string Id { get; set; }

        IIdentityInformation IdentityInformation {get;set;}
    }

    // public class AccountOwner : IOwner
    // {
    //     public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //     public string IIdentityInformation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    // }

} // namespace WkspIdl.Handcraft