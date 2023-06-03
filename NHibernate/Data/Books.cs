using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingCenter_v2.NHibernate.Data
{
    public class Books
    {
        public virtual int id { get; set; }
        public virtual int cipher_of_the_book { get; set; }
        private IList<Writers> _writers;
        public virtual IList<Writers> writers
        {
            get
            {
                if (_writers == null)
                    _writers = new List<Writers>();
                return _writers;
            }
            set => _writers = value;
        }
        public virtual string name { get; set; }
        public virtual string title { get; set; }
        public virtual int circulation { get; set; }
        public virtual DateTime release_date { get; set; }
        public virtual float cost_price { get; set; }
        public virtual float sale_price { get; set; }
        public virtual float fee { get; set; }
    }
}
