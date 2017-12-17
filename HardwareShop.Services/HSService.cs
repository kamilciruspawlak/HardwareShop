using HardwareShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HardwareShop.Database;

namespace HardwareShop.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class HSService : IHSService, IDisposable
    {
        private readonly HSDbContext _ctx = new HSDbContext();

        public List<Product> GetProducts()
        {
            return _ctx.Products.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return _ctx.Customers.ToList();
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SubmitOrder(Order order)
        {
            _ctx.Orders.Add(order);
            order.OrderItems.ForEach(o => _ctx.OrderItems.Add(o));
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
