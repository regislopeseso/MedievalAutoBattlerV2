﻿namespace MedievalAutoBattlerV2.Models.Dtos.Response
{
    public class Response<T>
    {
        public T? Content { get; set; }
        public string? Message { get; set; }
    }
}
