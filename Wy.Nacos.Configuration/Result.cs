using System;
using System.Collections.Generic;
using System.Text;

namespace Wy.Nacos.Configuration
{
   public class Result<T>
    {
        public Result(System.Net.HttpStatusCode code,string error)
        {
            StatusCode = code;
            ErrorMsg = error;
        }

        public Result(T data)
        {
            StatusCode = System.Net.HttpStatusCode.OK;
            Data = data;
        }

        public System.Net.HttpStatusCode StatusCode { set; get; }

        public string ErrorMsg { set; get; } = string.Empty;

        public T Data { set; get; } = default(T);

    }
}
