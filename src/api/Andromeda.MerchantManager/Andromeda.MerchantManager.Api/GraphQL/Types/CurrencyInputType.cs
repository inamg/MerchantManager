using Andromeda.MerchantManager.Api.Models;
using GraphQL.Types;

namespace Andromeda.MerchantManager.Api.GraphQL.Types
{
    public class CurrencyInputType : InputObjectGraphType<Currency>
    {
        public CurrencyInputType()
        {
            Name = "CurrencyInput";

            Field(x => x.Code).Description("Currency Code.");
            Field(x => x.Name).Description("Currency Name");
        }
    }
}