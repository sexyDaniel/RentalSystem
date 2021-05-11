using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PapsCourse.Shared.Models
{
    public class Response
    {
        public List<string> Errors { get; set; }
        public bool IsSuccessfull => Errors.Count == 0;
        public string Data { get; set; }

        public T GetData<T>()
        {
            return JsonSerializer.Deserialize<T>(Data);
        }
    }
}
