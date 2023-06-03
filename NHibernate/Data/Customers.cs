using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingCenter_v2.NHibernate.Data
{
    public class Customers
    {
        public virtual int id { get; set; }
        public virtual string customer_name { get; set; }
        public virtual string address { get; set; }
        public virtual string phone { get; set; }
        public virtual string full_name_customers { get; set; }
    }
}
