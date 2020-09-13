using System;
using Andromeda.MerchantManager.Api.GraphQL.Types;
using Andromeda.MerchantManager.Api.Models;
using Andromeda.MerchantManager.Api.Services;
using GraphQL.Types;

namespace Andromeda.MerchantManager.Api.GraphQL
{
    public class MerchantMutation : ObjectGraphType
    {
        public MerchantMutation(IMerchantService merchantService)
        {
            FieldAsync<MerchantType>(
                "CreateMerchant",
                arguments: new QueryArguments(
                    new QueryArgument<MerchantInputType> {Name = "merchant", Description = "updated merchant"}),
                resolve: async context =>
                {
                    var merchant = context.GetArgument<Merchant>("merchant");
                    return await merchantService.CreateMerchantAsync(merchant);
                }
            );

            FieldAsync<BooleanGraphType>(
                "DeleteMerchant",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id", Description = "The ID of the Merchant."}),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return await merchantService.DeleteMerchantAsync(id);
                }
            );

            FieldAsync<MerchantType>(
                "UpdateMerchant",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id", Description = "id of the merchant"},
                    new QueryArgument<MerchantInputType> {Name = "merchant", Description = "updated merchant"}),
                resolve: async context =>
                {
                    var merchant = context.GetArgument<Merchant>("merchant");
                    var id = context.GetArgument<Guid>("id");
                    return await merchantService.UpdateMerchantAsync(id, merchant);
                }
            );
        }
    }
}