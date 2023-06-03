using FluentNHibernate.Mapping;
using PublishingCenter_v2.NHibernate.Data;

namespace PublishingCenter_v2.NHibernate.MappingData
{
    public class ContractsMap : ClassMap<Contracts>
    {
        public ContractsMap()
        {
            Id(x => x.id).Column("id").GeneratedBy.Increment();
            References(x => x.writer).Column("id_writer");
            Map(x => x.contract_number).Column("contract_number");
            Map(x => x.date_of_cons_contract).Column("date_of_cons_contract");
            Map(x => x.term_of_the_contract).Column("term_of_the_contract");
            Map(x => x.validy_of_the_contract).Column("validy_of_the_contract");
            Map(x => x.date_of_terminition_contract).Column("date_of_terminition_contract");
            Table("contracts");
        }
    }
}
