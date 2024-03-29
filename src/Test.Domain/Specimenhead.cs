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
    public sealed class Specimenhead : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private string _barcode; 
		private float _patientid; 
		private float _dictpattypeid; 
		private string _patientno; 
		private string _patientname; 
		private string _patientphone; 
		private string _bultrasonic; 
		private string _sex; 
		private string _age; 
		private float _caculatedage; 
		private DateTime _birthday; 
		private float _weight; 
		private float _height; 
		private string _menstrualcycle; 
		private float _uninevolumn; 
		private string _bodystyle; 
		private string _doctorphone; 
		private string _pregnant; 
		private string _clinicalremark; 
		private string _room; 
		private string _bed; 
		private float _locationid; 
		private string _locationname; 
		private float _customerid; 
		private string _customername; 
		private float _doctorid; 
		private string _doctorname; 
		private string _remark; 
		private DateTime _splitdate; 
		private float _splitby; 
		private DateTime _enterdate; 
		private float _enterby; 
		private DateTime _deliverydate; 
		private float _deliveryby; 
		private DateTime _takedate; 
		private float _takeby; 
		private DateTime _createdate; 
		private string _deliverytype; 
		private DateTime _collectdate; 
		private float _collectby; 
		private DateTime _firstcheckdate; 
		private float _firstcheckby; 
		private DateTime _checkdate; 
		private float _checkby; 
		private string _needseperate; 
		private string _rerun; 
		private string _rerunfor; 
		private string _paymethod; 
		private string _status; 
		private DateTime _editdate; 
		private float _editby; 
		private string _programid; 
		private string _mergereport; 
		private string _lmp; 
		private string _lmpdate; 
		private string _babycount; 
		private float _dictrouteid; 
		private float _regionid; 
		private string _salesman; 
		private float _dictcustdistrictid; 
		private string _englishreport; 
		private float _dictsalemanid; 
		private float _batchreport; 
		private string _reportshowmethod; 
		private DateTime _lastupdatedate; 
		private float _delaycount; 
		private DateTime _getspecdate; 
		private string _specimensource; 
		private string _orderno; 
		private string _sqflag; 
		private string _idnum; 
		private string _sqtablename; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Specimenhead()
		{
			_barcode = null; 
			_patientid = 0; 
			_dictpattypeid = 0; 
			_patientno = null; 
			_patientname = null; 
			_patientphone = null; 
			_bultrasonic = null; 
			_sex = null; 
			_age = null; 
			_caculatedage = 0; 
			_birthday = new DateTime(); 
			_weight = 0; 
			_height = 0; 
			_menstrualcycle = null; 
			_uninevolumn = 0; 
			_bodystyle = null; 
			_doctorphone = null; 
			_pregnant = null; 
			_clinicalremark = null; 
			_room = null; 
			_bed = null; 
			_locationid = 0; 
			_locationname = null; 
			_customerid = 0; 
			_customername = null; 
			_doctorid = 0; 
			_doctorname = null; 
			_remark = null; 
			_splitdate = new DateTime(); 
			_splitby = 0; 
			_enterdate = new DateTime(); 
			_enterby = 0; 
			_deliverydate = new DateTime(); 
			_deliveryby = 0; 
			_takedate = new DateTime(); 
			_takeby = 0; 
			_createdate = new DateTime(); 
			_deliverytype = null; 
			_collectdate = new DateTime(); 
			_collectby = 0; 
			_firstcheckdate = new DateTime(); 
			_firstcheckby = 0; 
			_checkdate = new DateTime(); 
			_checkby = 0; 
			_needseperate = null; 
			_rerun = null; 
			_rerunfor = null; 
			_paymethod = null; 
			_status = null; 
			_editdate = new DateTime(); 
			_editby = 0; 
			_programid = null; 
			_mergereport = null; 
			_lmp = null; 
			_lmpdate = null; 
			_babycount = null; 
			_dictrouteid = 0; 
			_regionid = 0; 
			_salesman = null; 
			_dictcustdistrictid = 0; 
			_englishreport = null; 
			_dictsalemanid = 0; 
			_batchreport = 0; 
			_reportshowmethod = null; 
			_lastupdatedate = new DateTime(); 
			_delaycount = 0; 
			_getspecdate = new DateTime(); 
			_specimensource = null; 
			_orderno = null; 
			_sqflag = null; 
			_idnum = null; 
			_sqtablename = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 条码号
		/// </summary>		
		public string Barcode
		{
			get { return _barcode; }
			set	
			{
				if( value!= null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Barcode", value, value.ToString());
				
				_isChanged |= (_barcode != value); _barcode = value;
			}
		}
			
		/// <summary>
		/// 病人内码
		/// </summary>		
		public float Patientid
		{
			get { return _patientid; }
			set { _isChanged |= (_patientid != value); _patientid = value; }
		}
			
		/// <summary>
		/// 病人类型，对应表DictLiabrary
		/// </summary>		
		public float Dictpattypeid
		{
			get { return _dictpattypeid; }
			set { _isChanged |= (_dictpattypeid != value); _dictpattypeid = value; }
		}
			
		/// <summary>
		/// 病人号，例住院号/门诊号
		/// </summary>		
		public string Patientno
		{
			get { return _patientno; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Patientno", value, value.ToString());
				
				_isChanged |= (_patientno != value); _patientno = value;
			}
		}
			
		/// <summary>
		/// 病人名
		/// </summary>		
		public string Patientname
		{
			get { return _patientname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Patientname", value, value.ToString());
				
				_isChanged |= (_patientname != value); _patientname = value;
			}
		}
			
		/// <summary>
		/// 病人电话
		/// </summary>		
		public string Patientphone
		{
			get { return _patientphone; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Patientphone", value, value.ToString());
				
				_isChanged |= (_patientphone != value); _patientphone = value;
			}
		}
			
		/// <summary>
		/// B超孕周
		/// </summary>		
		public string Bultrasonic
		{
			get { return _bultrasonic; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Bultrasonic", value, value.ToString());
				
				_isChanged |= (_bultrasonic != value); _bultrasonic = value;
			}
		}
			
		/// <summary>
		/// 性别 （男/女/‘ ’）
		/// </summary>		
		public string Sex
		{
			get { return _sex; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Sex", value, value.ToString());
				
				_isChanged |= (_sex != value); _sex = value;
			}
		}
			
		/// <summary>
		/// 年龄
		/// </summary>		
		public string Age
		{
			get { return _age; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Age", value, value.ToString());
				
				_isChanged |= (_age != value); _age = value;
			}
		}
			
		/// <summary>
		/// 计算后的年龄（小时为单位）
		/// </summary>		
		public float Caculatedage
		{
			get { return _caculatedage; }
			set { _isChanged |= (_caculatedage != value); _caculatedage = value; }
		}
			
		/// <summary>
		/// 生日
		/// </summary>		
		public DateTime Birthday
		{
			get { return _birthday; }
			set { _isChanged |= (_birthday != value); _birthday = value; }
		}
			
		/// <summary>
		/// 体重
		/// </summary>		
		public float Weight
		{
			get { return _weight; }
			set { _isChanged |= (_weight != value); _weight = value; }
		}
			
		/// <summary>
		/// 身高
		/// </summary>		
		public float Height
		{
			get { return _height; }
			set { _isChanged |= (_height != value); _height = value; }
		}
			
		/// <summary>
		/// 月经生育历史
		/// </summary>		
		public string Menstrualcycle
		{
			get { return _menstrualcycle; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Menstrualcycle", value, value.ToString());
				
				_isChanged |= (_menstrualcycle != value); _menstrualcycle = value;
			}
		}
			
		/// <summary>
		/// 24小时尿量（ml)
		/// </summary>		
		public float Uninevolumn
		{
			get { return _uninevolumn; }
			set { _isChanged |= (_uninevolumn != value); _uninevolumn = value; }
		}
			
		/// <summary>
		/// 体位
		/// </summary>		
		public string Bodystyle
		{
			get { return _bodystyle; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Bodystyle", value, value.ToString());
				
				_isChanged |= (_bodystyle != value); _bodystyle = value;
			}
		}
			
		/// <summary>
		/// 医生电话
		/// </summary>		
		public string Doctorphone
		{
			get { return _doctorphone; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Doctorphone", value, value.ToString());
				
				_isChanged |= (_doctorphone != value); _doctorphone = value;
			}
		}
			
		/// <summary>
		/// 妊娠备注/孕周(日)
		/// </summary>		
		public string Pregnant
		{
			get { return _pregnant; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Pregnant", value, value.ToString());
				
				_isChanged |= (_pregnant != value); _pregnant = value;
			}
		}
			
		/// <summary>
		/// 临床备注
		/// </summary>		
		public string Clinicalremark
		{
			get { return _clinicalremark; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Clinicalremark", value, value.ToString());
				
				_isChanged |= (_clinicalremark != value); _clinicalremark = value;
			}
		}
			
		/// <summary>
		/// 房号
		/// </summary>		
		public string Room
		{
			get { return _room; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Room", value, value.ToString());
				
				_isChanged |= (_room != value); _room = value;
			}
		}
			
		/// <summary>
		/// 床号
		/// </summary>		
		public string Bed
		{
			get { return _bed; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Bed", value, value.ToString());
				
				_isChanged |= (_bed != value); _bed = value;
			}
		}
			
		/// <summary>
		/// 送检科室内码
		/// </summary>		
		public float Locationid
		{
			get { return _locationid; }
			set { _isChanged |= (_locationid != value); _locationid = value; }
		}
			
		/// <summary>
		/// 送检科室名称
		/// </summary>		
		public string Locationname
		{
			get { return _locationname; }
			set	
			{
				if( value!= null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for Locationname", value, value.ToString());
				
				_isChanged |= (_locationname != value); _locationname = value;
			}
		}
			
		/// <summary>
		/// 送检顾客内码
		/// </summary>		
		public float Customerid
		{
			get { return _customerid; }
			set { _isChanged |= (_customerid != value); _customerid = value; }
		}
			
		/// <summary>
		/// 客户名字
		/// </summary>		
		public string Customername
		{
			get { return _customername; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Customername", value, value.ToString());
				
				_isChanged |= (_customername != value); _customername = value;
			}
		}
			
		/// <summary>
		/// 送检医生ID
		/// </summary>		
		public float Doctorid
		{
			get { return _doctorid; }
			set { _isChanged |= (_doctorid != value); _doctorid = value; }
		}
			
		/// <summary>
		/// 送检医生名字
		/// </summary>		
		public string Doctorname
		{
			get { return _doctorname; }
			set	
			{
				if( value!= null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for Doctorname", value, value.ToString());
				
				_isChanged |= (_doctorname != value); _doctorname = value;
			}
		}
			
		/// <summary>
		/// 备注
		/// </summary>		
		public string Remark
		{
			get { return _remark; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Remark", value, value.ToString());
				
				_isChanged |= (_remark != value); _remark = value;
			}
		}
			
		/// <summary>
		/// 标本分管日期
		/// </summary>		
		public DateTime Splitdate
		{
			get { return _splitdate; }
			set { _isChanged |= (_splitdate != value); _splitdate = value; }
		}
			
		/// <summary>
		/// 标本分管人
		/// </summary>		
		public float Splitby
		{
			get { return _splitby; }
			set { _isChanged |= (_splitby != value); _splitby = value; }
		}
			
		/// <summary>
		/// 录入时间
		/// </summary>		
		public DateTime Enterdate
		{
			get { return _enterdate; }
			set { _isChanged |= (_enterdate != value); _enterdate = value; }
		}
			
		/// <summary>
		/// 录入者
		/// </summary>		
		public float Enterby
		{
			get { return _enterby; }
			set { _isChanged |= (_enterby != value); _enterby = value; }
		}
			
		/// <summary>
		/// 外勤标本送达时间
		/// </summary>		
		public DateTime Deliverydate
		{
			get { return _deliverydate; }
			set { _isChanged |= (_deliverydate != value); _deliverydate = value; }
		}
			
		/// <summary>
		/// 外勤送标本人
		/// </summary>		
		public float Deliveryby
		{
			get { return _deliveryby; }
			set { _isChanged |= (_deliveryby != value); _deliveryby = value; }
		}
			
		/// <summary>
		/// 内勤接收时间
		/// </summary>		
		public DateTime Takedate
		{
			get { return _takedate; }
			set { _isChanged |= (_takedate != value); _takedate = value; }
		}
			
		/// <summary>
		/// 内勤接收人
		/// </summary>		
		public float Takeby
		{
			get { return _takeby; }
			set { _isChanged |= (_takeby != value); _takeby = value; }
		}
			
		/// <summary>
		/// 生成日期
		/// </summary>		
		public DateTime Createdate
		{
			get { return _createdate; }
			set { _isChanged |= (_createdate != value); _createdate = value; }
		}
			
		/// <summary>
		/// 交接类型 0-常规 1-病理
		/// </summary>		
		public string Deliverytype
		{
			get { return _deliverytype; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Deliverytype", value, value.ToString());
				
				_isChanged |= (_deliverytype != value); _deliverytype = value;
			}
		}
			
		/// <summary>
		/// 标本采集日期
		/// </summary>		
		public DateTime Collectdate
		{
			get { return _collectdate; }
			set { _isChanged |= (_collectdate != value); _collectdate = value; }
		}
			
		/// <summary>
		/// 收集人
		/// </summary>		
		public float Collectby
		{
			get { return _collectby; }
			set { _isChanged |= (_collectby != value); _collectby = value; }
		}
			
		/// <summary>
		/// 信息校验-初审日期
		/// </summary>		
		public DateTime Firstcheckdate
		{
			get { return _firstcheckdate; }
			set { _isChanged |= (_firstcheckdate != value); _firstcheckdate = value; }
		}
			
		/// <summary>
		/// 信息校验-初审者
		/// </summary>		
		public float Firstcheckby
		{
			get { return _firstcheckby; }
			set { _isChanged |= (_firstcheckby != value); _firstcheckby = value; }
		}
			
		/// <summary>
		/// 信息校验-审核日期
		/// </summary>		
		public DateTime Checkdate
		{
			get { return _checkdate; }
			set { _isChanged |= (_checkdate != value); _checkdate = value; }
		}
			
		/// <summary>
		/// 信息校验-审核者
		/// </summary>		
		public float Checkby
		{
			get { return _checkby; }
			set { _isChanged |= (_checkby != value); _checkby = value; }
		}
			
		/// <summary>
		/// 是否需要分瓶  0-否  1- 是
		/// </summary>		
		public string Needseperate
		{
			get { return _needseperate; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Needseperate", value, value.ToString());
				
				_isChanged |= (_needseperate != value); _needseperate = value;
			}
		}
			
		/// <summary>
		/// 是否是复查标本  0-否  1- 是，一般复查标本不收费
		/// </summary>		
		public string Rerun
		{
			get { return _rerun; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Rerun", value, value.ToString());
				
				_isChanged |= (_rerun != value); _rerun = value;
			}
		}
			
		/// <summary>
		/// 对应的标本复查标本号
		/// </summary>		
		public string Rerunfor
		{
			get { return _rerunfor; }
			set	
			{
				if( value!= null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Rerunfor", value, value.ToString());
				
				_isChanged |= (_rerunfor != value); _rerunfor = value;
			}
		}
			
		/// <summary>
		/// 付款方式：C-现金(Cash)  A-记账(Account)
		/// </summary>		
		public string Paymethod
		{
			get { return _paymethod; }
			set	
			{
				if( value!= null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Paymethod", value, value.ToString());
				
				_isChanged |= (_paymethod != value); _paymethod = value;
			}
		}
			
		/// <summary>
		/// 1-已交收   2-异常，等待处理，对应表INITBASIC
		/// </summary>		
		public string Status
		{
			get { return _status; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				
				_isChanged |= (_status != value); _status = value;
			}
		}
			
		/// <summary>
		/// 编辑时间
		/// </summary>		
		public DateTime Editdate
		{
			get { return _editdate; }
			set { _isChanged |= (_editdate != value); _editdate = value; }
		}
			
		/// <summary>
		/// 编辑人
		/// </summary>		
		public float Editby
		{
			get { return _editby; }
			set { _isChanged |= (_editby != value); _editby = value; }
		}
			
		/// <summary>
		/// 1-内部LIS录入 2-外部Web录入  3-EXCEL导入 4-电商入口
		/// </summary>		
		public string Programid
		{
			get { return _programid; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Programid", value, value.ToString());
				
				_isChanged |= (_programid != value); _programid = value;
			}
		}
			
		/// <summary>
		/// 是否合并报告  0-否  1-是
		/// </summary>		
		public string Mergereport
		{
			get { return _mergereport; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Mergereport", value, value.ToString());
				
				_isChanged |= (_mergereport != value); _mergereport = value;
			}
		}
			
		/// <summary>
		/// 未次月经孕周(Last Menstrual Pregant )
		/// </summary>		
		public string Lmp
		{
			get { return _lmp; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Lmp", value, value.ToString());
				
				_isChanged |= (_lmp != value); _lmp = value;
			}
		}
			
		/// <summary>
		/// 未次月经孕日
		/// </summary>		
		public string Lmpdate
		{
			get { return _lmpdate; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Lmpdate", value, value.ToString());
				
				_isChanged |= (_lmpdate != value); _lmpdate = value;
			}
		}
			
		/// <summary>
		/// 怀孕的胎数
		/// </summary>		
		public string Babycount
		{
			get { return _babycount; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Babycount", value, value.ToString());
				
				_isChanged |= (_babycount != value); _babycount = value;
			}
		}
			
		/// <summary>
		/// 客户所在路线
		/// </summary>		
		public float Dictrouteid
		{
			get { return _dictrouteid; }
			set { _isChanged |= (_dictrouteid != value); _dictrouteid = value; }
		}
			
		/// <summary>
		/// 客户区域ID，对应表DICTLIBRARY
		/// </summary>		
		public float Regionid
		{
			get { return _regionid; }
			set { _isChanged |= (_regionid != value); _regionid = value; }
		}
			
		/// <summary>
		/// 销售人员
		/// </summary>		
		public string Salesman
		{
			get { return _salesman; }
			set	
			{
				if( value!= null && value.Length > 60)
					throw new ArgumentOutOfRangeException("Invalid value for Salesman", value, value.ToString());
				
				_isChanged |= (_salesman != value); _salesman = value;
			}
		}
			
		/// <summary>
		/// 客户地区ID，对应表DictLibrary
		/// </summary>		
		public float Dictcustdistrictid
		{
			get { return _dictcustdistrictid; }
			set { _isChanged |= (_dictcustdistrictid != value); _dictcustdistrictid = value; }
		}
			
		/// <summary>
		/// 是否出具英语报告(0-否 1-是)
		/// </summary>		
		public string Englishreport
		{
			get { return _englishreport; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Englishreport", value, value.ToString());
				
				_isChanged |= (_englishreport != value); _englishreport = value;
			}
		}
			
		/// <summary>
		/// 销售人员ID，对应表DictUser
		/// </summary>		
		public float Dictsalemanid
		{
			get { return _dictsalemanid; }
			set { _isChanged |= (_dictsalemanid != value); _dictsalemanid = value; }
		}
			
		/// <summary>
		/// 按审核次数分次生成报告
		/// </summary>		
		public float Batchreport
		{
			get { return _batchreport; }
			set { _isChanged |= (_batchreport != value); _batchreport = value; }
		}
			
		/// <summary>
		/// 报告上是否显示检测方法 0-不显示  1-显示
		/// </summary>		
		public string Reportshowmethod
		{
			get { return _reportshowmethod; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Reportshowmethod", value, value.ToString());
				
				_isChanged |= (_reportshowmethod != value); _reportshowmethod = value;
			}
		}
			
		/// <summary>
		/// 最后操作时间，新增、修改都要保存最后操作的时间
		/// </summary>		
		public DateTime Lastupdatedate
		{
			get { return _lastupdatedate; }
			set { _isChanged |= (_lastupdatedate != value); _lastupdatedate = value; }
		}
			
		/// <summary>
		/// 迟发次数
		/// </summary>		
		public float Delaycount
		{
			get { return _delaycount; }
			set { _isChanged |= (_delaycount != value); _delaycount = value; }
		}
			
		/// <summary>
		/// 外勤得到标本的时间
		/// </summary>		
		public DateTime Getspecdate
		{
			get { return _getspecdate; }
			set { _isChanged |= (_getspecdate != value); _getspecdate = value; }
		}
			
		/// <summary>
		/// 来源1电子商务，2体检，0，lis
		/// </summary>		
		public string Specimensource
		{
			get { return _specimensource; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Specimensource", value, value.ToString());
				
				_isChanged |= (_specimensource != value); _specimensource = value;
			}
		}
			
		/// <summary>
		/// 电商订单号
		/// </summary>		
		public string Orderno
		{
			get { return _orderno; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Orderno", value, value.ToString());
				
				_isChanged |= (_orderno != value); _orderno = value;
			}
		}
			
		/// <summary>
		/// 社区样本，结果需要传到社区系统，0不需要，1需要
		/// </summary>		
		public string Sqflag
		{
			get { return _sqflag; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Sqflag", value, value.ToString());
				
				_isChanged |= (_sqflag != value); _sqflag = value;
			}
		}
			
		/// <summary>
		/// 身份证号,社区系统使用
		/// </summary>		
		public string Idnum
		{
			get { return _idnum; }
			set	
			{
				if( value!= null && value.Length > 18)
					throw new ArgumentOutOfRangeException("Invalid value for Idnum", value, value.ToString());
				
				_isChanged |= (_idnum != value); _idnum = value;
			}
		}
			
		/// <summary>
		/// 社区表单名称，对应社区
		/// </summary>		
		public string Sqtablename
		{
			get { return _sqtablename; }
			set	
			{
				if( value!= null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Sqtablename", value, value.ToString());
				
				_isChanged |= (_sqtablename != value); _sqtablename = value;
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
