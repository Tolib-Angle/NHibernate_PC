using System;

namespace PublishingCenter_v2.NHibernate.Data
{
    public class Contracts
    {
        public virtual int id { get; set; }
        public virtual Writers writer { get; set; }
        public virtual int contract_number { get; set; }
        public virtual DateTime date_of_cons_contract { get; set; }
        public virtual int term_of_the_contract { get; set; }
        public virtual bool validy_of_the_contract { get; set; }
        public virtual DateTime date_of_terminition_contract { get; set; }
    }
}
