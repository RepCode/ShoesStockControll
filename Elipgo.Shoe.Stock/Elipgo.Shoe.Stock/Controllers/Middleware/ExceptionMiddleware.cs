using Elipgo.ShoeStock.Api.Constants;
using Elipgo.ShoeStock.Api.Dtos.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Api.Controllers.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // logger.LogError($"Something went wrong: {contextFeature.Error}"); TODO

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse()
                        {
                            ErrorCode = (int)HttpStatusCode.InternalServerError,
                            ErrorMessage = MessageConstants.ServerErrorMessage
                        }));
                    }
                });
            });
        }
    }
}
