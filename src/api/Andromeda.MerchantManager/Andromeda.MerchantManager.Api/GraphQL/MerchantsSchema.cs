using GraphQL.Types;
using GraphQL;
using GraphQL.Upload.AspNetCore;
using Microsoft.AspNetCore.Cors;

namespace Andromeda.MerchantManager.Api.GraphQL
{
    [EnableCors("AllowOrigin")]
    public class MerchantsSchema : Schema
    {
        public MerchantsSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MerchantQuery>();
            Mutation = resolver.Resolve<MerchantMutation>();
            RegisterValueConverter(new FormFileConverter());
        }
    }
}