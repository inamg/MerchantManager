using Andromeda.MerchantManager.Api.Models;
using GraphQL.Types;

namespace Andromeda.MerchantManager.Api.GraphQL.Types
{
    public class CurrencyType : ObjectGraphType<Currency>
    {
        public CurrencyType()
        {
            Name = "Currency";

            Field(x => x.Code).Description("Currency Code.");
            Field(x => x.Name).Description("Currency Name");
        }
    }
}