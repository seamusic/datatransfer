/*
insert license info here
*/
using System;

namespace Daan.DataTransfer.Test.Domain
{
	/// <summary>
	///	Generated by MyGeneration using the IBatis Object Mapping template
	/// </summary>
	[Serializable]
    public sealed class Dicttestitem : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dicttestitemid; 
		private string _fastcode; 
		private string _testcode; 
		private string _engname; 
		private string _testname; 
		private float _precision; 
		private float _displayorder; 
		private float _price; 
		private string _billable; 
		private string _active; 
		private string _caculatetest; 
		private float _timecycle; 
		private string _report; 
		private string _tubegroup; 
		private float _dicttesttypeid; 
		private float _dictcontainerid; 
		private float _dictspecimentypeid; 
		private float _testmethodid; 
		private float _dictlibraryid; 
		private float _limithigh; 
		private float _limitlow; 
		private string _forsex; 
		private string _refmethod; 
		private string _privacy; 
		private string _clinicalremark; 
		private string _operationremark; 
		private float _reagentcost; 
		private float _deltacheck; 
		private string _deltatype; 
		private string _defaultresult; 
		private string _sendouttest; 
		private float _specimenvolumn; 
		private string _specialhandle; 
		private float _specimenstoretime; 
		private float _resultlow; 
		private string _resulttips; 
		private string _resultlowprint; 
		private float _resulthigh; 
		private string _resulthighprint; 
		private string _unit; 
		private string _remark; 
		private string _testtype; 
		private float _dictlabdeptid; 
		private string _vitalsample; 
		private float _dictreporttemplateid; 
		private float _reportrow; 
		private string _showtips; 
		private string _coldstore; 
		private string _englongname; 
		private string _requestformtips; 
		private string _uniqueid; 
		private float _caculatecount; 
		private string _isimportant; 
		private string _iscanorder; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dicttestitem()
		{
			_dicttestitemid = 0; 
			_fastcode = null; 
			_testcode = null; 
			_engname = null; 
			_testname = null; 
			_precision = 0; 
			_displayorder = 0; 
			_price = 0; 
			_billable = null; 
			_active = null; 
			_caculatetest = null; 
			_timecycle = 0; 
			_report = null; 
			_tubegroup = null; 
			_dicttesttypeid = 0; 
			_dictcontainerid = 0; 
			_dictspecimentypeid = 0; 
			_testmethodid = 0; 
			_dictlibraryid = 0; 
			_limithigh = 0; 
			_limitlow = 0; 
			_forsex = null; 
			_refmethod = null; 
			_privacy = null; 
			_clinicalremark = null; 
			_operationremark = null; 
			_reagentcost = 0; 
			_deltacheck = 0; 
			_deltatype = null; 
			_defaultresult = null; 
			_sendouttest = null; 
			_specimenvolumn = 0; 
			_specialhandle = null; 
			_specimenstoretime = 0; 
			_resultlow = 0; 
			_resulttips = null; 
			_resultlowprint = null; 
			_resulthigh = 0; 
			_resulthighprint = null; 
			_unit = null; 
			_remark = null; 
			_testtype = null; 
			_dictlabdeptid = 0; 
			_vitalsample = null; 
			_dictreporttemplateid = 0; 
			_reportrow = 0; 
			_showtips = null; 
			_coldstore = null; 
			_englongname = null; 
			_requestformtips = null; 
			_uniqueid = null; 
			_caculatecount = 0; 
			_isimportant = null; 
			_iscanorder = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 测试项主键
		/// </summary>		
		public float Dicttestitemid
		{
			get { return _dicttestitemid; }
			set { _isChanged |= (_dicttestitemid != value); _dicttestitemid = value; }
		}
			
		/// <summary>
		/// 快捷录入码
		/// </summary>		
		public string Fastcode
		{
			get { return _fastcode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Fastcode", value, value.ToString());
				
				_isChanged |= (_fastcode != value); _fastcode = value;
			}
		}
			
		/// <summary>
		/// 测试代码
		/// </summary>		
		public string Testcode
		{
			get { return _testcode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Testcode", value, value.ToString());
				
				_isChanged |= (_testcode != value); _testcode = value;
			}
		}
			
		/// <summary>
		/// 英文名
		/// </summary>		
		public string Engname
		{
			get { return _engname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Engname", value, value.ToString());
				
				_isChanged |= (_engname != value); _engname = value;
			}
		}
			
		/// <summary>
		/// 测试项中文名字
		/// </summary>		
		public string Testname
		{
			get { return _testname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Testname", value, value.ToString());
				
				_isChanged |= (_testname != value); _testname = value;
			}
		}
			
		/// <summary>
		/// 精度，通常指小数位
		/// </summary>		
		public float Precision
		{
			get { return _precision; }
			set { _isChanged |= (_precision != value); _precision = value; }
		}
			
		/// <summary>
		/// 打印报告顺序
		/// </summary>		
		public float Displayorder
		{
			get { return _displayorder; }
			set { _isChanged |= (_displayorder != value); _displayorder = value; }
		}
			
		/// <summary>
		/// 价钱
		/// </summary>		
		public float Price
		{
			get { return _price; }
			set { _isChanged |= (_price != value); _price = value; }
		}
			
		/// <summary>
		/// 是否需要计账0-NO 1-YES
		/// </summary>		
		public string Billable
		{
			get { return _billable; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Billable", value, value.ToString());
				
				_isChanged |= (_billable != value); _billable = value;
			}
		}
			
		/// <summary>
		/// 是否可用 0-否  1-是
		/// </summary>		
		public string Active
		{
			get { return _active; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Active", value, value.ToString());
				
				_isChanged |= (_active != value); _active = value;
			}
		}
			
		/// <summary>
		/// 0-非计算值  1-计算值
		/// </summary>		
		public string Caculatetest
		{
			get { return _caculatetest; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Caculatetest", value, value.ToString());
				
				_isChanged |= (_caculatetest != value); _caculatetest = value;
			}
		}
			
		/// <summary>
		/// 需完成此测试项的时间设置(单位：小时）
		/// </summary>		
		public float Timecycle
		{
			get { return _timecycle; }
			set { _isChanged |= (_timecycle != value); _timecycle = value; }
		}
			
		/// <summary>
		/// 是否打印报告
		/// </summary>		
		public string Report
		{
			get { return _report; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Report", value, value.ToString());
				
				_isChanged |= (_report != value); _report = value;
			}
		}
			
		/// <summary>
		/// 分管原则
		/// </summary>		
		public string Tubegroup
		{
			get { return _tubegroup; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Tubegroup", value, value.ToString());
				
				_isChanged |= (_tubegroup != value); _tubegroup = value;
			}
		}
			
		/// <summary>
		/// 医学专业组分组ID，对应表DictLibrary
		/// </summary>		
		public float Dicttesttypeid
		{
			get { return _dicttesttypeid; }
			set { _isChanged |= (_dicttesttypeid != value); _dicttesttypeid = value; }
		}
			
		/// <summary>
		/// 试管类型
		/// </summary>		
		public float Dictcontainerid
		{
			get { return _dictcontainerid; }
			set { _isChanged |= (_dictcontainerid != value); _dictcontainerid = value; }
		}
			
		/// <summary>
		/// 标本类型
		/// </summary>		
		public float Dictspecimentypeid
		{
			get { return _dictspecimentypeid; }
			set { _isChanged |= (_dictspecimentypeid != value); _dictspecimentypeid = value; }
		}
			
		/// <summary>
		/// 检验方法
		/// </summary>		
		public float Testmethodid
		{
			get { return _testmethodid; }
			set { _isChanged |= (_testmethodid != value); _testmethodid = value; }
		}
			
		/// <summary>
		/// 结果类型ID，对应表DictLibrary
		/// </summary>		
		public float Dictlibraryid
		{
			get { return _dictlibraryid; }
			set { _isChanged |= (_dictlibraryid != value); _dictlibraryid = value; }
		}
			
		/// <summary>
		/// 限制高值
		/// </summary>		
		public float Limithigh
		{
			get { return _limithigh; }
			set { _isChanged |= (_limithigh != value); _limithigh = value; }
		}
			
		/// <summary>
		/// 限制低值
		/// </summary>		
		public float Limitlow
		{
			get { return _limitlow; }
			set { _isChanged |= (_limitlow != value); _limitlow = value; }
		}
			
		/// <summary>
		/// 测试项适用性别，M-男，F-女 ，B-俩者皆可
		/// </summary>		
		public string Forsex
		{
			get { return _forsex; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Forsex", value, value.ToString());
				
				_isChanged |= (_forsex != value); _forsex = value;
			}
		}
			
		/// <summary>
		/// 参考值方式：<10,<=10,>20,1-20等等
		/// </summary>		
		public string Refmethod
		{
			get { return _refmethod; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Refmethod", value, value.ToString());
				
				_isChanged |= (_refmethod != value); _refmethod = value;
			}
		}
			
		/// <summary>
		/// 私隐项目
		/// </summary>		
		public string Privacy
		{
			get { return _privacy; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Privacy", value, value.ToString());
				
				_isChanged |= (_privacy != value); _privacy = value;
			}
		}
			
		/// <summary>
		/// 临床意义
		/// </summary>		
		public string Clinicalremark
		{
			get { return _clinicalremark; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Clinicalremark", value, value.ToString());
				
				_isChanged |= (_clinicalremark != value); _clinicalremark = value;
			}
		}
			
		/// <summary>
		/// 操作备注
		/// </summary>		
		public string Operationremark
		{
			get { return _operationremark; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Operationremark", value, value.ToString());
				
				_isChanged |= (_operationremark != value); _operationremark = value;
			}
		}
			
		/// <summary>
		/// 试剂消耗量(毫升)
		/// </summary>		
		public float Reagentcost
		{
			get { return _reagentcost; }
			set { _isChanged |= (_reagentcost != value); _reagentcost = value; }
		}
			
		/// <summary>
		/// 上次对比的设定值百分比（当前结果-上次结果）/当前结果的%值
		/// </summary>		
		public float Deltacheck
		{
			get { return _deltacheck; }
			set { _isChanged |= (_deltacheck != value); _deltacheck = value; }
		}
			
		/// <summary>
		/// 1-定量比较，结合本表字段DeltaCheck比较 2-定性比较，文字结果，则要求与上次结果须一样
		/// </summary>		
		public string Deltatype
		{
			get { return _deltatype; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Deltatype", value, value.ToString());
				
				_isChanged |= (_deltatype != value); _deltatype = value;
			}
		}
			
		/// <summary>
		/// 默认结果
		/// </summary>		
		public string Defaultresult
		{
			get { return _defaultresult; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Defaultresult", value, value.ToString());
				
				_isChanged |= (_defaultresult != value); _defaultresult = value;
			}
		}
			
		/// <summary>
		/// 是否外包项目0-否  1-是
		/// </summary>		
		public string Sendouttest
		{
			get { return _sendouttest; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Sendouttest", value, value.ToString());
				
				_isChanged |= (_sendouttest != value); _sendouttest = value;
			}
		}
			
		/// <summary>
		/// 抽血量（单位：毫升）
		/// </summary>		
		public float Specimenvolumn
		{
			get { return _specimenvolumn; }
			set { _isChanged |= (_specimenvolumn != value); _specimenvolumn = value; }
		}
			
		/// <summary>
		/// 特别处理项目，例染色体  0-否  1- 是
		/// </summary>		
		public string Specialhandle
		{
			get { return _specialhandle; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Specialhandle", value, value.ToString());
				
				_isChanged |= (_specialhandle != value); _specialhandle = value;
			}
		}
			
		/// <summary>
		/// 标本保存时间（单位：天）
		/// </summary>		
		public float Specimenstoretime
		{
			get { return _specimenstoretime; }
			set { _isChanged |= (_specimenstoretime != value); _specimenstoretime = value; }
		}
			
		/// <summary>
		/// 结果低值
		/// </summary>		
		public float Resultlow
		{
			get { return _resultlow; }
			set { _isChanged |= (_resultlow != value); _resultlow = value; }
		}
			
		/// <summary>
		/// 结果提示，0-否  1-是；是否用别的文字替代显示
		/// </summary>		
		public string Resulttips
		{
			get { return _resulttips; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Resulttips", value, value.ToString());
				
				_isChanged |= (_resulttips != value); _resulttips = value;
			}
		}
			
		/// <summary>
		/// 结果低显示值时报告打印内容
		/// </summary>		
		public string Resultlowprint
		{
			get { return _resultlowprint; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Resultlowprint", value, value.ToString());
				
				_isChanged |= (_resultlowprint != value); _resultlowprint = value;
			}
		}
			
		/// <summary>
		/// 结果高值
		/// </summary>		
		public float Resulthigh
		{
			get { return _resulthigh; }
			set { _isChanged |= (_resulthigh != value); _resulthigh = value; }
		}
			
		/// <summary>
		/// 结果高值时报告打印内容
		/// </summary>		
		public string Resulthighprint
		{
			get { return _resulthighprint; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Resulthighprint", value, value.ToString());
				
				_isChanged |= (_resulthighprint != value); _resulthighprint = value;
			}
		}
			
		/// <summary>
		/// 单位
		/// </summary>		
		public string Unit
		{
			get { return _unit; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Unit", value, value.ToString());
				
				_isChanged |= (_unit != value); _unit = value;
			}
		}
			
		/// <summary>
		/// 备注信息
		/// </summary>		
		public string Remark
		{
			get { return _remark; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Remark", value, value.ToString());
				
				_isChanged |= (_remark != value); _remark = value;
			}
		}
			
		/// <summary>
		/// 测试项的类别：0-单项  1-组合
		/// </summary>		
		public string Testtype
		{
			get { return _testtype; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Testtype", value, value.ToString());
				
				_isChanged |= (_testtype != value); _testtype = value;
			}
		}
			
		/// <summary>
		/// 测试项物理实验室分组,对应表DictLibrary
		/// </summary>		
		public float Dictlabdeptid
		{
			get { return _dictlabdeptid; }
			set { _isChanged |= (_dictlabdeptid != value); _dictlabdeptid = value; }
		}
			
		/// <summary>
		/// 重要标本  0-否  1-是，如果此结果是阳性，则入库时重色显示
		/// </summary>		
		public string Vitalsample
		{
			get { return _vitalsample; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Vitalsample", value, value.ToString());
				
				_isChanged |= (_vitalsample != value); _vitalsample = value;
			}
		}
			
		/// <summary>
		/// 模板ID，对应表DictReportTemplate
		/// </summary>		
		public float Dictreporttemplateid
		{
			get { return _dictreporttemplateid; }
			set { _isChanged |= (_dictreporttemplateid != value); _dictreporttemplateid = value; }
		}
			
		/// <summary>
		/// 报告所占的行数
		/// </summary>		
		public float Reportrow
		{
			get { return _reportrow; }
			set { _isChanged |= (_reportrow != value); _reportrow = value; }
		}
			
		/// <summary>
		/// 分发标本时是否提示标本类型不对(跟参考范围设置设置进行比对)  1-提示 0-不提示
		/// </summary>		
		public string Showtips
		{
			get { return _showtips; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Showtips", value, value.ToString());
				
				_isChanged |= (_showtips != value); _showtips = value;
			}
		}
			
		/// <summary>
		/// 需要冷藏的标本  0-否  1-是
		/// </summary>		
		public string Coldstore
		{
			get { return _coldstore; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Coldstore", value, value.ToString());
				
				_isChanged |= (_coldstore != value); _coldstore = value;
			}
		}
			
		/// <summary>
		/// 英文长名称
		/// </summary>		
		public string Englongname
		{
			get { return _englongname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Englongname", value, value.ToString());
				
				_isChanged |= (_englongname != value); _englongname = value;
			}
		}
			
		/// <summary>
		/// 验单入库时需提示 0-否 1-是
		/// </summary>		
		public string Requestformtips
		{
			get { return _requestformtips; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Requestformtips", value, value.ToString());
				
				_isChanged |= (_requestformtips != value); _requestformtips = value;
			}
		}
			
		/// <summary>
		/// 全国唯一编码
		/// </summary>		
		public string Uniqueid
		{
			get { return _uniqueid; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Uniqueid", value, value.ToString());
				
				_isChanged |= (_uniqueid != value); _uniqueid = value;
			}
		}
			
		/// <summary>
		/// 计算的例数
		/// </summary>		
		public float Caculatecount
		{
			get { return _caculatecount; }
			set { _isChanged |= (_caculatecount != value); _caculatecount = value; }
		}
			
		/// <summary>
		/// 是否重要项目
		/// </summary>		
		public string Isimportant
		{
			get { return _isimportant; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Isimportant", value, value.ToString());
				
				_isChanged |= (_isimportant != value); _isimportant = value;
			}
		}
			
		/// <summary>
		/// 是否能单独开单 ，1-是  0 -否
		/// </summary>		
		public string Iscanorder
		{
			get { return _iscanorder; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Iscanorder", value, value.ToString());
				
				_isChanged |= (_iscanorder != value); _iscanorder = value;
			}
		}
			
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 
		
		
		#region Public Functions
		
		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		#endregion
		
		
	}
}
