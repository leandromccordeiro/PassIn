﻿namespace PassIn.Communication.Responses;
public class ResponseErrorJson
{
    public ResponseErrorJson(string message)
    {
        Message = message;
    }

    public string Message { get; set; } = string.Empty;
}
