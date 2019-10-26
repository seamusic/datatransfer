using System;
using System.Collections;
using System.Reflection;
using Daan.DataTransfer.DataCommon;
using Daan.DataTransfer.Test.DataAccess;
using Daan.DataTransfer.Test.Domain;

namespace Daan.DataTransfer.Test.Query
{
    public class QueryDatabase
    {
        public void Exec(Action<IList> callback)
        {
            IList result;
            Assembly asm = Assembly.GetAssembly(typeof (DomainBase));

            result = ExecQuery(typeof(Initbasic));
            callback(result);

            result = ExecQuery(typeof(Initlocalsetting));
            callback(result);

            result = ExecQuery(typeof(Initsyssetting));
            callback(result);
            result = ExecQuery(typeof(Dictlibrary));
            callback(result);

            result = ExecQuery(typeof(Dictuser));
            callback(result);

            result = ExecQuery(typeof(Dictcheckcustomer));
            callback(result);

            result = ExecQuery(typeof(Dictcontroltestrule));
            callback(result);

            result = ExecQuery(typeof(Dictcontroltests));
            callback(result);

            result = ExecQuery(typeof(DictcustOdd));
            callback(result);
            result = ExecQuery(typeof(Dictlocation));
            callback(result);
            result = ExecQuery(typeof(Dictdoctor));
            callback(result);
            result = ExecQuery(typeof(Dictsaleman));
            callback(result);
            result = ExecQuery(typeof(Dictrouteassign));
            callback(result);
            result = ExecQuery(typeof(Dictcustomer));
            callback(result);
            result = ExecQuery(typeof(Dictcustomeruser));
            callback(result);
            result = ExecQuery(typeof(Dictcustomerdiscount));

            callback(result);
            result = ExecQuery(typeof(Dictcustomerexcelmap));
            callback(result);

            result = ExecQuery(typeof(Dictcustomergroup));
            callback(result);

            result = ExecQuery(typeof(Dictcustomergroupprice));

            callback(result);
            result = ExecQuery(typeof(Dictcustomerpriceactive));
            callback(result);

            result = ExecQuery(typeof(Dictcustomertestdiscount));
            callback(result);

            result = ExecQuery(typeof(Dictdiagnosis));
            callback(result);

            result = ExecQuery(typeof(Dictdoctorex));
            callback(result);

            result = ExecQuery(typeof(Dictdrawertype));
            callback(result);

            result = ExecQuery(typeof(Dictfastcomment));

            callback(result);
            result = ExecQuery(typeof(Dictgroupsecurity));
            callback(result);

            result = ExecQuery(typeof(Dicthost));
            callback(result);

            result = ExecQuery(typeof(Dictinputchoice));
            callback(result);

            result = ExecQuery(typeof(Dictinputtemplate));
            callback(result);

            result = ExecQuery(typeof(Dictinputtemplateitem));
            callback(result);

            result = ExecQuery(typeof(Dictinstrument));
            callback(result);

            result = ExecQuery(typeof(Dictinstrumentcenter));
            callback(result);

            result = ExecQuery(typeof(Dictinstrumenttest));

            callback(result);
            result = ExecQuery(typeof(Dictorganism));
            callback(result);

            result = ExecQuery(typeof(Dictorganismgroup));
            callback(result);

            result = ExecQuery(typeof(Dictpathologytype));

            callback(result);
            result = ExecQuery(typeof(Dictqccontrol));
            callback(result);

            result = ExecQuery(typeof(Dictqclot));

            callback(result);
            result = ExecQuery(typeof(Dictqclotcenter));

            callback(result);
            result = ExecQuery(typeof(Dictqclottest));
            callback(result);

            result = ExecQuery(typeof(Dictqcrule));
            callback(result);

            result = ExecQuery(typeof(Dictqctestrule));

            callback(result);
            result = ExecQuery(typeof(Dictreporttemplate));
            callback(result);

            result = ExecQuery(typeof(Dictresulttypedetail));
            callback(result);

            result = ExecQuery(typeof(Dictruleformular));
            callback(result);

            result = ExecQuery(typeof(Dictsecurityresource));
            callback(result);

            result = ExecQuery(typeof(Dictstatcolumns));

            callback(result);
            result = ExecQuery(typeof(Dictstatconditions));

            callback(result);
            result = ExecQuery(typeof(Dictstathead));
            callback(result);

            result = ExecQuery(typeof(Dicttableversion));
            callback(result);

            result = ExecQuery(typeof(Dicttestgroupdetail));
            callback(result);

            result = ExecQuery(typeof(Dicttestitem));
            callback(result);

            result = ExecQuery(typeof(Dicttestitemcenter));
            callback(result);

            result = ExecQuery(typeof(Dicttestitemmodel));

            callback(result);
            result = ExecQuery(typeof(Dicttestitemmodeldetail));
            callback(result);

            result = ExecQuery(typeof(Dicttestrefrange));
            callback(result);

            result = ExecQuery(typeof(Dicttuberack));

            callback(result);


            result = ExecQuery(typeof(Dictantibiotic));
            callback(result);

            result = ExecQuery(typeof(Dictantibioticgroup));
            callback(result);

            result = ExecQuery(typeof(Dictantibioticrefrange));

            callback(result);
            result = ExecQuery(typeof(Dictuserandgroup));
            callback(result);

            result = ExecQuery(typeof(Dictusergroup));

            callback(result);
            result = ExecQuery(typeof(Dictuserinstrument));
            callback(result);

            result = ExecQuery(typeof(Distributedetail));
            callback(result);

            result = ExecQuery(typeof(Distributehead));
            callback(result);

            result = ExecQuery(typeof(Instrumentpicture));
            callback(result);

            result = ExecQuery(typeof(Instrumentrawdata));
            callback(result);

            result = ExecQuery(typeof(Instrumentresult));
            callback(result);

            result = ExecQuery(typeof(Instrumentseq));
            callback(result);

            result = ExecQuery(typeof(Instrumenttempresult));

            callback(result);

//            result = ExecQuery(typeof(Maintenancelog));
//            callback(result);

            result = ExecQuery(typeof(Micantibioticresult));
            callback(result);

            result = ExecQuery(typeof(Micorganismresult));

            callback(result);
            result = ExecQuery(typeof(Micresult));

            callback(result);
            result = ExecQuery(typeof(Operationlog));
            callback(result);

            result = ExecQuery(typeof(Pathologypicture));

            callback(result);
            result = ExecQuery(typeof(Pathologyresult));
            callback(result);

            result = ExecQuery(typeof(Pathologyseq));
            callback(result);

            result = ExecQuery(typeof(Qcmonthlycomment));
            callback(result);

            result = ExecQuery(typeof(Qcprocesslog));
            callback(result);

            result = ExecQuery(typeof(Qcresult));

            callback(result);
            result = ExecQuery(typeof(Specialresult));
            callback(result);

            result = ExecQuery(typeof(Specimenexception));
            callback(result);

            result = ExecQuery(typeof(Specimengrouptest));

            callback(result);
            result = ExecQuery(typeof(Specimenhead));

            callback(result);
            result = ExecQuery(typeof(Specimenheaddetail));
            callback(result);

            result = ExecQuery(typeof(Specimenmanage));
            callback(result);

            result = ExecQuery(typeof(Specimenpatientname));
            callback(result);

            result = ExecQuery(typeof(Specimenreport));
            callback(result);

            result = ExecQuery(typeof(Specimenreportdetail));

            callback(result);
            result = ExecQuery(typeof(Specimenrequestinfo));

            callback(result);
            result = ExecQuery(typeof(Specimenresult));
            callback(result);

            result = ExecQuery(typeof(Specimentest));
            callback(result);

            result = ExecQuery(typeof(Specinstrmentdetail));
            callback(result);

            result = ExecQuery(typeof(Specinstrmenttest));
            callback(result);
        }


        private IList ExecQuery(Type type)
        {
            DateTime start = DateTime.Now;
            string message = string.Format("Select 开始获取类型：{0} 开始时间为：{1}", type, start);
            Console.WriteLine(message);
            LogHelper.Debug(GetType(), message);
            var dao = new SelectDaoBase(OracleMapper.GetInstance().GetMapper().CreateSqlMapSession());
            IList result = dao.QueryList(type);
            DateTime end = DateTime.Now;
            double diff = start.Subtract(end).TotalSeconds;
            message = string.Format("Select 获取类型：{0} 结束时间为：{1}，总耗时：{2}秒", type, end, diff);
            Console.WriteLine(message);
            LogHelper.Debug(GetType(), message);
            return result;
        }
        

        public void InsertObject( Type type , object data )
        {
            

            DateTime start = DateTime.Now;
            string message = string.Format("Insert 开始获取类型：{0} 开始时间为：{1}", type, start);
            Console.WriteLine(message);
            LogHelper.Debug(GetType(), message);
            var dao = new SelectDaoBase(OracleMapper.GetInstance().GetMapper().CreateSqlMapSession());
            dao.Insert(type , data );
            DateTime end = DateTime.Now;
            double diff = start.Subtract(end).TotalSeconds;
            message = string.Format("Insert 获取类型：{0} 结束时间为：{1}，总耗时：{2}秒", type, end, diff);
            Console.WriteLine(message);
            LogHelper.Debug(GetType(), message);
            
        }


    }
}