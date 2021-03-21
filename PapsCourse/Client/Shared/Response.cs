using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PapsCourse.Shared
{
    public class Response
    {
        public IReadOnlyList<string> Errors { get; set; }
        public bool IsSuccessfull => Errors.Count == 0;
        public string Data { get; set; }

        public T GetData<T>()
        {
            return JsonSerializer.Deserialize<T>(Data);
        }
    }
}
