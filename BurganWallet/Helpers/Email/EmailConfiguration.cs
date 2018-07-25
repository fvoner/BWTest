using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurganWallet.Helpers.Email
{
    public class EmailConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }
}