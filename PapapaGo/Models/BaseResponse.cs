using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapapaGo.Models
{
    public class BaseResponse
    {
        public class Railway
        {
            public string code { get; set; }
        }

        public class From
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class To
        {
            public string code { get; set; }
            public string name { get; set; }
        }


        public class Price
        {
            public string currency { get; set; }
            public int cents { get; set; }
        }

        public class From2
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class To2
        {
            public string code { get; set; }
            public string name { get; set; }
        }

    }
}