﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SL_WCF1
{
    public class Result
    {
        public bool Correct { get; set; }//true //false
        public string ErrorMessage { get; set; }
        public Exception Ex { get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; }
    }
}