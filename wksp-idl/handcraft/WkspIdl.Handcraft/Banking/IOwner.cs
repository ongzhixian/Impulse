using System;

namespace WkspIdl.Handcraft
{

    public interface IOwner
    {
        string Id { get; set; }

        string IName {get;set;}
    }

    public class AccountOwner : IOwner
    {
        
    }


}