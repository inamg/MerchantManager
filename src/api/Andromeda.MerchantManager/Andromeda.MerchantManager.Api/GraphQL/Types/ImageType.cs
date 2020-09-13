using Andromeda.MerchantManager.Api.Models;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace Andromeda.MerchantManager.Api.GraphQL.Types
{
    public class ImageType : ObjectGraphType<Image>
    {
        public ImageType()
        {
            Field(f => f.Id).Name("id");
            Field(f => f.Name).Name("filename");
            Field(f => f.MimeType).Name("mimetype");
            Field(f => f.Path).Name("path");
        }
    }

    public class ImageInputType : InputObjectGraphType<Image>
    {
        public ImageInputType()
        {
            Field(f => f.Id).Name("id");
            Field(f => f.Name).Name("filename");
            Field(f => f.MimeType).Name("mimetype");
            Field(f => f.Path).Name("path");
        }
    }
}