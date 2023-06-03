namespace PublishingCenter_v2.NHibernate.Data
{
    public class Writers
    {
        public virtual int id { get; set; }
        public virtual int passport_number { get; set; }
        public virtual string surname { get; set; }
        public virtual string name { get; set; }
        public virtual string middle_name { get; set; }
        public virtual string address { get; set; }
        public virtual string phone { get; set; }
    }
}
