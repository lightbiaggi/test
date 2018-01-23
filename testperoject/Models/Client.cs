using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace testperoject.Models
{
    public class Client
    {
        private XElement ClientRoot;

        public Client(XElement root)
        {
            ClientRoot = root;
        }

        public string FirstName
        {
            get
            {
                XElement firstname = ClientRoot.Element("fn");
                string fn = null;
                if (firstname != null)
                {
                    fn = firstname.Value;
                }
                else
                {
                    //to do throw exception  
                }
                return fn;

            }
        }

        public string LastName
        {
            get
            {
                XElement lasename = ClientRoot.Element("ln");
                string ln = null;
                if (lasename != null)
                {
                    ln = lasename.Value;
                }
                else
                {
                    //to do throw exception  
                }
                return ln;

            }

        }

        public int Account
        {
            get
            {
                XElement account = ClientRoot.Element("acc");
                int acc = 0;
                if (account == null || !int.TryParse(account.Value, out acc))
                {
                    // exception todo
                }
                return acc;

            }

        }

        public DateTime DOB
        {
            get
            {
                XElement xDob = ClientRoot.Element("dob");
                DateTime dob = DateTime.Now;
                if (xDob == null || !DateTime.TryParse(xDob.Value, out dob))
                {
                    //to do throw exception  
                }

                return dob;
            }
        }
    }
}