using System;

namespace WkspIdl.Handcraft
{
    public interface ICash
    {
        ICurrency Currency {get;set;}
        decimal Amount {get;set;}
    }
}