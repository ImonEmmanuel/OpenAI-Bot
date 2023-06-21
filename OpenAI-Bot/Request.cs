using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI_Bot
{
    public class Request
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }
    }

}
