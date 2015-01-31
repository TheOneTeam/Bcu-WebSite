using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.DataProvider
{
    public class Result
    {
        public Result()
        {
            this.Flag = true;
        }

        public Result(bool result, string msg)
        {
            this.Flag = result;
            this.Msg = msg;
        }

        public bool Flag { get; set; }
        public string Msg { get; set; }
    }
}