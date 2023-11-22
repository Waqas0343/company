using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Models.ViewModel
{
    public class Response<T>
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }

        public string? Message { get; set; }
        public bool? Status { get; set; }

        public T? Data { get; set; }

        public List<T>? List { get; set; }
    }
}
