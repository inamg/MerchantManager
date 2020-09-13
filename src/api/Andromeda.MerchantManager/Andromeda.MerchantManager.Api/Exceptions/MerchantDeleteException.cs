using System;

namespace Andromeda.MerchantManager.Api.Exceptions
{
    public class MerchantDeleteException : Exception
    {
        public MerchantDeleteException(string message) : base(message)
        {
            
        }
    }
}