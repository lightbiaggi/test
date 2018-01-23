using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testperoject.Models
{
    public class Results
    {
        private List<Client> updatedClients = new List<Client>();
        private List<Client> addedClients = new List<Client>();
        public List<Client> UpdatedClients
        {
            get
            {
                return updatedClients;
            }

            set
            {
                updatedClients = value;
            }
        }
        public List<Client> AddedClients
        {
            get
            {
                return addedClients;
            }

            set
            {
                addedClients = value;
            }
        }
    }
}