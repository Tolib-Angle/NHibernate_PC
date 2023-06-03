using NHibernate;
using NHibernate.Criterion;

namespace PublishingCenter_v2.NHibernate
{
    public class Repository
    {
        private readonly ISession Session;

        private static Repository _instance = null;

        private Repository()
        {
            Session = NHibernateHelper.OpenSession();
        }

        public static Repository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Repository();
                }

                return _instance;
            }
        }
        public IQuery FindByCondition<T>(string expression)
        {
            return Session.CreateQuery(expression);
        }

        public IQuery FindByCondition<T>(string expression, int count)
        {
            return Session.CreateQuery(expression).SetMaxResults(count);
        }
        public IQuery GetDataByNumber<T>(string expression, int number)
        {
            return Session.CreateQuery(expression).SetFirstResult(number).SetMaxResults(1);
        }
        public int GetCount<T>() where T : class
        {
            return Session.QueryOver<T>().Select(Projections.RowCount()).SingleOrDefault<int>();
        }
        public IQuery SearchData<T>(string expression)
        {
            return Session.CreateQuery(expression);
        }
        public void Create<T>(T entity)
        {
            Session.Save(entity);
            Session.Flush();
        }

        public void Update<T>(T entity)
        {
            Session.Update(entity);
            Session.Flush();
        }

        public void Delete<T>(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }

        public T Find<T>(int id)
        {
            return Session.Get<T>(id);
        }

        public void Refresh<T>(T entity)
        {
            Session.Refresh(entity);
        }
    }
}
