using System.Net;
using Newtonsoft.Json;
using ToToAirline.BaseResponses;
using ToToAirline.MiddleWare.Exceptions;

namespace ToToAirline.MiddleWare
{
    public class ExceptionHanddle
    {
        private readonly RequestDelegate _next;

        public ExceptionHanddle(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (MaxLanghtException ex)
            {
                await HaddleExceptionAsync(context, "400", ex.Message);
            }
            catch (NotFoundException ex)
            {
                await HaddleExceptionAsync(context, "404", ex.Message);
            }
            catch (PresicionException ex)
            {
                await HaddleExceptionAsync(context, "400", ex.Message);
            }
            catch (Exception ex)
            {
                await HaddleExceptionAsync(context, "500", ex.Message);
            }
        }
        private static Task HaddleExceptionAsync(HttpContext context, string code, string message)
        {
            context.Response.ContentType = "appication/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new BaseResponse(code: code, msg: message, status: false);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));

        }

    }
}