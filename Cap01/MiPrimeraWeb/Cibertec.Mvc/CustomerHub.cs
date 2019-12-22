using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Cibertec.Mvc
{
    public class CustomerHub : Hub
    {
        static List<int> CustomerIds = new List<int>();

        public void AddCustomer(int id)
        {
            if (!CustomerIds.Contains(id))
                CustomerIds.Add(id);
            Clients.All.customerStatus(CustomerIds);
        }

        public void RemoveCustomer(int id)
        {
            if (CustomerIds.Contains(id))
                CustomerIds.Remove(id);
            Clients.All.customerStatus(CustomerIds);
        }

        public override Task OnConnected()
        {
            return Clients.All.customerStatus(CustomerIds);
        }

        public void Message(string message)
        {
            Clients.All.getMessage(message);
        }
    }
}