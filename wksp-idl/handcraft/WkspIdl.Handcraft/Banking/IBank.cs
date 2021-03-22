using System;
using System.Collections.Generic;

namespace WkspIdl.Handcraft
{

    public interface IBank
    {
        string Name { get; set; }

        System.Collections.Generic.IList<IOwner> CustomerList {get;set;}

        // IList<IAccount> AccountList { get; set; }

        void RegisterAccountOwner(IOwner owner);

        // void UpdateAccountOwner(IOwner owner);

        // void RegisterBankAccount(IOwner owner);

        // IList<IAccount> GetBankAccounts(IOwner owner);

        // void UpdateBankAccount(IAccount account);

        // void UpdateBankAccount(IAccount account);
    }

    public class AngMoKioBank : IBank
    {
        const string NAME = "ANG MO KIO BANK";

        public string Name { get; set; }
        public IList<IOwner> CustomerList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AngMoKioBank()
        {
            //System.Collections.Generic.IList
            this.Name = NAME;
            //this.AccountList = new List<IAccount>();
        }

        public void RegisterAccountOwner(IOwner owner)
        {
            throw new NotImplementedException();
        }
    }

}