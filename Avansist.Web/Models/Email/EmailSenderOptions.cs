using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Models.Email
{
    public class EmailSenderOptions
    {
        public string Server { set; get; }
        public int Port { set; get; }
        public string SenderName { set; get; }
        public string SenderEmail { set; get; }
        public string Password { set; get; }
    }
}
