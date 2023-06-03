using FluentNHibernate.Mapping;
using PublishingCenter_v2.NHibernate.Data;

namespace PublishingCenter_v2.NHibernate.MappingData
{
    public class OrdersMap : ClassMap<Orders>
    {
        public OrdersMap()
        {
            Id(x => x.id).Column("id").GeneratedBy.Increment();
            References(x => x.customer).Column("id_customer");
            Map(x => x.order_number).Column("order_number");
            Map(x => x.date_of_receipt_order).Column("date_of_receipt_order");
            Map(x => x.order_completion_date).Column("order_completion_date");
            References(x => x.book).Column("id_book");
            Map(x => x.numbers_of_order).Column("numbers_of_order");
            Table("orders");
        }
    }
}
