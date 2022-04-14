using AutoMapper;
using MyArt.API.Infrastructure.Models;
using MyArt.BusinessLogic.Models;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace MyArt.API.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMapper _mapper;

        public ErrorHandlerMiddleware(RequestDelegate next, IMapper mapper)
        {
            _next = next;
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                int statusCode;
                var response = new ErrorResponse(error.Message);

                switch (error)
                {
                    case FluentValidation.ValidationException e:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        response.ValidationFailures = _mapper.Map<IEnumerable<FluentFailure>>(e.Errors);
                        break;
                    case ApplicationException e:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var result = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
