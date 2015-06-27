using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rnwood.SmtpServer;

namespace Dummy.SmtpServer
{
    class SavedMessage
    {
        private IMessage message;

        public IMessage Message
        {
            get { return message; }
            set { message = value; }
        }


        private String path;        

        public SavedMessage(IMessage msg, string path)
        {            
            this.message = msg;
            this.path = path;
        }

        public String Path
        {
            get { return path; }
            set { path = value; }
        }        
        
    }
}
