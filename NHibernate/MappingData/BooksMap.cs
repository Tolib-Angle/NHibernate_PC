using FluentNHibernate.Mapping;
using PublishingCenter_v2.NHibernate.Data;

namespace PublishingCenter_v2.NHibernate.MappingData
{
    public class BooksMap : ClassMap<Books>
    {
        public BooksMap()
        {
            Id(x => x.id).Column("id").GeneratedBy.Increment();
            Map(x => x.cipher_of_the_book).Column("cipher_of_the_book");
            HasManyToMany(x => x.writers).Cascade.SaveUpdate().Table("writers_books");
            Map(x => x.name).Column("name");
            Map(x => x.title).Column("title");
            Map(x => x.circulation).Column("circulation");
            Map(x => x.release_date).Column("release_date");
            Map(x => x.cost_price).Column("cost_price");
            Map(x => x.sale_price).Column("sale_price");
            Map(x => x.fee).Column("fee");
            Table("books");
        }
    }
}
