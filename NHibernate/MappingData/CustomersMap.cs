using FluentNHibernate.Mapping;
using PublishingCenter_v2.NHibernate.Data;

namespace PublishingCenter_v2.NHibernate.MappingData
{
    public class CustomersMap : ClassMap<Customers>
    {
        public CustomersMap()
        {
            Id(x => x.id).Column("id").GeneratedBy.Increment();
            Map(x => x.customer_name).Column("customer_name");
            Map(x => x.address).Column("address");
            Map(x => x.phone).Column("phone");
            Map(x => x.full_name_customers).Column("full_name_customer");
            Table("customers");
        }
    }
}
