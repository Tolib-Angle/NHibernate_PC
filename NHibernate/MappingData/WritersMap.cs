using FluentNHibernate.Mapping;
using PublishingCenter_v2.NHibernate.Data;

namespace PublishingCenter_v2.NHibernate.MappingData
{
    public class WritersMap : ClassMap<Writers>
    {
        public WritersMap()
        {
            Id(x => x.id).Column("id").GeneratedBy.Increment();
            Map(x => x.passport_number).Column("passport_number");
            Map(x => x.surname).Column("surname");
            Map(x => x.name).Column("name");
            Map(x => x.middle_name).Column("middle_name");
            Map(x => x.address).Column("address");
            Map(x => x.phone).Column("phone");
            Table("writers");
        }
    }
}
