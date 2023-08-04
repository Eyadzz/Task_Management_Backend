﻿using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace API.Controllers;

public class ErrorController : ControllerBase
{

    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, title) = exception switch
        {
            BaseException baseException => (baseException.StatusCode, baseException.Message),
            _ => (500, "Something went wrong!")
        };
        
        return Problem(
            statusCode: statusCode,
            title: title
        );
    }
}