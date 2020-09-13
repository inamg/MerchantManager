using System;

namespace Andromeda.MerchantManager.Api.Exceptions
{
    public class MerchantUpdateException : Exception
    {
        public MerchantUpdateException(string message) : base(message)
        {
            
        }
    }
}