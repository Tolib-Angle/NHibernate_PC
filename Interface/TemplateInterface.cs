using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using PublishingCenter_v2.NHibernate;

namespace PublishingCenter_v2.PublishingCenter.Interface
{
    public class TemplateInterface<T>
    {
        private int FirtsId = 0;
        private int LasdId;
        private int PackageSize;
        private const string HqlTemplateNext = "from {0} e where {1} e.id > {2} order by e.id";
        private const string HqlTemplatePerv = "from {0} e where {1} e.id < {2} order by e.id DESC";
        private const string HqlTemplateGetByNumber = "from {0} order by id";
        public string Condition { get; set; }

        public TemplateInterface(int packageSize)
        {
            PackageSize = packageSize;
            LasdId = 0;
            FirtsId = 0;
            Condition = "";
        }

        public IList<T> NextPackage()
        {
            string hql = String.Format(
                HqlTemplateNext,
                typeof(T).Name,
                Condition.IsEmpty() ? "" : "(" + Condition + ") and ",
                FirtsId
            );
            var query = Repository.Instance.FindByCondition<T>(hql, PackageSize);
            var list = query.List<T>();
            return list;
        }

        public List<T> PrevPackage()
        {
            string hql = String.Format(
                HqlTemplatePerv,
                typeof(T).Name,
                Condition.IsEmpty() ? "" : "(" + Condition + ") and ",
                LasdId
            );
            var query = Repository.Instance.FindByCondition<T>(hql, PackageSize);
            List<T> list = (List<T>)query.List<T>();
            list.Reverse();
            return list;
        }
        public static T GetDataByNumber(int number)
        {
            string hql = String.Format(
                HqlTemplateGetByNumber,
                typeof(T).Name);
            var query = Repository.Instance.GetDataByNumber<T>(hql, number);
            return query.List<T>()[0];
        }
        public static List<T> SearchDataByText(string _hql, string data)
        {
            string hql = String.Format(
                _hql,
                typeof(T).Name,
                data);
            var query = Repository.Instance.SearchData<T>(hql);
            List<T> list = (List<T>)query.List<T>();
            return list;
        }
        public void Reset()
        {
            FirtsId = 0;
            LasdId = 0;
        }

        public void SetNewId(int first_id, int last_id)
        {
            FirtsId = last_id;
            LasdId = first_id;
        }
    }
}
