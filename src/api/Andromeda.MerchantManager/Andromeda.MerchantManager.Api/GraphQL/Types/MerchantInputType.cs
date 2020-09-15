using Andromeda.MerchantManager.Api.Models;
using GraphQL.Types;
using GraphQL.Upload.AspNetCore;

namespace Andromeda.MerchantManager.Api.GraphQL.Types
{
    public class MerchantInputType : InputObjectGraphType<Merchant>
    {
        public MerchantInputType()
        {
            Name = "MerchantInput";
            Field(x => x.Name).Description("The name of the Merchant");
            Field(x => x.Description);
            Field(name: "File", type: typeof(UploadGraphType));
            Field(x => x.Status, type: typeof(StatusType)).Description("Status Merchant.");
            Field(x => x.Currency, type: typeof(CurrencyInputType)).Description("Currency of the merchant");
            Field(x => x.Url);
        }
    }
}