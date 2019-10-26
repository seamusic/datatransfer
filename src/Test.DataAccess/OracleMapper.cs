using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper.Configuration;
using System.Reflection;
using System.IO;
using IBatisNet.DataMapper.SessionStore;

namespace Daan.DataTransfer.Test.DataAccess
{
    public class OracleMapper
    {
       private static volatile ISqlMapper _mapper;

        private const string Path = "SqlMap.config";

        private static volatile OracleMapper _daansqlmapper; 

        /// <summary>
        /// 锁定构造
        /// </summary>
        private OracleMapper()
        {
            
        }

        /// <summary>
        /// 初始化DaanSQLMapper
        /// </summary>
        /// <returns></returns>
        public static OracleMapper GetInstance()
        {
            if ( _daansqlmapper == null )
            {
                lock (typeof(OracleMapper))
                {
                    if (_daansqlmapper == null)
                    {
                        _daansqlmapper = new OracleMapper();
                        InitialMapper(); 
                    }
                }
            }
            return _daansqlmapper; 
        }

        /// <summary>
        /// 初始化ISqlMapper
        /// </summary>
        private static void InitialMapper()
        {
            if (_mapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (_mapper == null)
                    {
                        BuildingMapper();
                    }
                }
            }

        }

        private static void BuildingMapper()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            _mapper = builder.ConfigureAndWatch(Path, handler);
            CallContextSessionStore ss = new CallContextSessionStore(_mapper.Id);
            _mapper.SessionStore = ss;
        }

        /// <summary>
        /// 获取ISqlMapper
        /// </summary>
        /// <returns></returns>
        public ISqlMapper GetMapper()
        {
            try
            {
               // if (!_mapper.IsSessionStarted)
                //{
                   
               // }
              
                
                return _mapper;

                
            }
            catch (Exception)
            {
                //_mapper = null;
                //InitialMapper();
                return _mapper;
            }
        }

        protected static void Configure(object obj)
        {
            _mapper = null;

        }
    }
}
