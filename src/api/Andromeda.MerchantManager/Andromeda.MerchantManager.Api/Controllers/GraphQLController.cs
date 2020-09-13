﻿using System.Threading.Tasks;
using Andromeda.MerchantManager.Api.GraphQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace Andromeda.MerchantManager.Api.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : Controller
    {
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new MerchantQuery()
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}