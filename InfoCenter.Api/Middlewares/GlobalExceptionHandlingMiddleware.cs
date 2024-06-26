﻿using System.Net;
using System.Text.Json;

using InfoCenter.Api.Exceptions;

using Microsoft.AspNetCore.Mvc;

namespace InfoCenter.Api.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (HttpResponseException e)
        {
            context.Response.StatusCode = e.StatusCode;

            string title;

            switch (e.StatusCode)
            {
                case 400:
                    title = "Bad Request";
                    break;
                case 404:
                    title = "Not Found";
                    break;
                default:
                    title = "Something went wrong";
                    break;
            }

            ProblemDetails problem =
                new()
                {
                    Type = "Request error",
                    Title = title,
                    Status = e.StatusCode,
                    Detail = e.Message
                };

            string json = JsonSerializer.Serialize(problem);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem =
                new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server error",
                    Title = "Server error",
                    Detail = "An internal server error has occurred"
                };

            string json = JsonSerializer.Serialize(problem);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}