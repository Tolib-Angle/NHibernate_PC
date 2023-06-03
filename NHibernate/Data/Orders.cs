using System;

namespace PublishingCenter_v2.NHibernate.Data
{
    public class Orders
    {
        public virtual int id { get; set; }
        public virtual Customers customer { get; set; }
        public virtual int order_number { get; set; }
        public virtual DateTime date_of_receipt_order { get; set; }
        public virtual DateTime order_completion_date { get; set; }
        public virtual Books book { get; set; }
        public virtual int numbers_of_order { get; set; }
    }

}