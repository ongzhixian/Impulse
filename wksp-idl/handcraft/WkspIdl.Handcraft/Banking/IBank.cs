using System;

namespace WkspIdl.Handcraft
{

    public interface IBank
    {
        string Name { get; set; }

        IList<IOwner> CustomerList {get;set;}

        IList<IAccount> AccountList { get; set; }

        void RegisterAccountOwner(IOwner owner);

        void UpdateAccountOwner(IOwner owner);

        void RegisterBankAccount(IOwner owner);

        IList<IAccount> GetBankAccounts(IOwner owner);

        void UpdateBankAccount(IAccount account);

        void UpdateBankAccount(IAccount account);
    }

    public class AngMoKioBank : IBank
    {
        const string NAME = "ANG MO KIO BANK";

        public AngMoKioBank()
        {
            this.Name = Name;
            this.AccountList = new List<IAccount>();
        }

    }

}