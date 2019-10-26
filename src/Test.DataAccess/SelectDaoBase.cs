using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;

namespace Daan.DataTransfer.Test.DataAccess
{
    public class SelectDaoBase
    {
        private readonly ISqlMapSession _session;
        public SelectDaoBase( ISqlMapSession  session)
        {

            _session = session; 

        }

        public IList QueryList( Type type  )
        {
            //select * from t_order limit 5,10; #返回第6-15行数据


            var name = string.Format("Select{0}", type.Name);
            Console.WriteLine("执行：" + name);
            return _session.SqlMapper.QueryForList(name, null);
        }
        public void Insert ( Type type , object data )
        {
            var name = string.Format("Insert{0}", type.Name);
            _session.SqlMapper.Insert(name, data);
        }
    }
}