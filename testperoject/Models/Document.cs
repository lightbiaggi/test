using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace testperoject.Models
{
    public class Document
    {
        private XDocument document = new XDocument();
        private List<Client> clients;

        public Document(string path)
        {
          document  =   XDocument.Load(path);
            clients = new List<Client>();
        }

        

        public List<Client> Clients
        {
            get
            {
                return (from x in document.Root.Elements("person")
                        select new Client(x)).ToList();
            }

        }
    }
}