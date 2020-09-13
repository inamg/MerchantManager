using System;

namespace Andromeda.MerchantManager.Api.Exceptions
{
    public class MerchantSaveException : Exception
    {
        public MerchantSaveException(string message) : base(message)
        {
            
        }
    }
}