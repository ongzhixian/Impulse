using System;

namespace WkspIdl.Handcraft
{
    public interface IAccount
    {
        string IOwner { get; set; }

        decimal Cash {get;set;}
    }
}