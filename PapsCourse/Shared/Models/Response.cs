using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PapsCourse.Shared.Models
{
    public class Response
    {
        public IReadOnlyList<string> Errors { get; set; }
        public bool IsSuccessfull => Errors.Count == 0;
        public string Data { get; set; }

        public T GetData<T>()
        {
            return JsonConvert.DeserializeObject<T>(Data);            
        }
    }
}
