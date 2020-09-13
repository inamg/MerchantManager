using Andromeda.MerchantManager.Api.Models;
using GraphQL.Types;

namespace Andromeda.MerchantManager.Api.GraphQL.Types
{
    public class MerchantType : ObjectGraphType<Merchant>
    {
        public MerchantType()
        {
            Name = "Merchant";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Merchant.");
            Field(x => x.Name).Description("The name of the Merchant");
            Field(x => x.Description);
            Field(x => x.Image).Description("Image");
            Field(x => x.Status, type: typeof(StatusType)).Description("Status Merchant.");
            Field(x => x.Currency, type: typeof(CurrencyType)).Description("Currency of the merchant");
        }
    }
}