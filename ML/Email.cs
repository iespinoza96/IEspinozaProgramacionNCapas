using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Email
    {
        public string From;
        public string FromDisplayName { get; set; }
        /// <remarks/>
        public string To;
        /// <remarks/>
        public string Subject;
        /// <remarks/>
        public string Body;
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

    }
}
