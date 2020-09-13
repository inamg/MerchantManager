using System;

namespace Andromeda.MerchantManager.Api.Exceptions
{
    public class MerchantGetException : Exception
    {
        public MerchantGetException(string message) : base(message)
        {
            
        }
    }
}