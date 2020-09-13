using System;
using Andromeda.MerchantManager.Api.GraphQL.Types;
using Andromeda.MerchantManager.Api.Services;
using GraphQL.Types;

namespace Andromeda.MerchantManager.Api.GraphQL
{
    public class MerchantQuery : ObjectGraphType
    {
        public MerchantQuery(IMerchantService merchantService)
        {
            FieldAsync<MerchantType>(
                "GetMerchant",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id", Description = "The ID of the Merchant."}),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");

                    return await merchantService.GetMerchantAsync(id);
                });
            
            FieldAsync<ListGraphType<MerchantType>>(
                "GetMerchants",
                resolve: async context => await merchantService.GetAllMerchantsAsync());
        }
    }
}