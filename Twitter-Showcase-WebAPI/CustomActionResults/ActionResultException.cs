using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter_Showcase_WebAPI.CustomActionResults
{
    public class ActionResultException : ActionResult
    {
        private readonly Exception _exception;

        public ActionResultException(Exception exception)
        {
            _exception = exception;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var httpResponse = context.HttpContext.Response;

            httpResponse.Headers.Add("Exception-Type", _exception.GetType().Name); // add name of exception in response headers

            if (_exception is NullReferenceException)
            {
                httpResponse.StatusCode = MapExceptionToStatusCode(_exception);
                context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "User not found";
            }

            if (_exception is ArgumentNullException)
            {
                httpResponse.StatusCode = MapExceptionToStatusCode(_exception);
                context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "User has no tweets";
            }

            await httpResponse.WriteAsync(_exception.Message);
        }


        public static int MapExceptionToStatusCode(Exception exception)
        {
            if (exception is NullReferenceException)
            {
                return 404;
            }

            if (exception is ArgumentNullException)
            {
                return 400;
            }

            return 500;
        }
    }
}


// 28:12