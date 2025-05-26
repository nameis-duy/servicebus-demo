using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class OrderCreated
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public string ArticleNumber { get; set; }
        public CustomerCreated Customer { get; set; }
    }
}
