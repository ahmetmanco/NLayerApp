﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nlayer.Core.DTOs
{
    //public class NoContentDto
    //{
    //    public List<String> Errors { get; set; }
    //}
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public List<String> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResponseDto<T> Success(int statusCode,T data)
        {
            return new CustomResponseDto<T>{ Data = data, StatusCode= statusCode};
        }

        public static CustomResponseDto<T> Succes(int statusCode)
        {
            return new CustomResponseDto<T>{StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomResponseDto<T>{ Errors = errors, StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(string error, int statusCode)
        {
            return new CustomResponseDto<T> { Errors = new List<string> { error}, StatusCode = statusCode };
        }
    }
}
