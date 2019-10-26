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
    public sealed class Dictinstrument : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictinstrumentid; 
		private string _instrumentcode; 
		private string _fastcode; 
		private string _instrumentname; 
		private string _model; 
		private string _status; 
		private string _vendor; 
		private string _address; 
		private string _telephone; 
		private DateTime _purchasedate; 
		private string _manufacture; 
		private string _setupdate; 
		private string _contactman; 
		private string _contactphone; 
		private string _maintenanceman; 
		private string _communicatemode; 
		private string _protocol; 
		private string _comport; 
		private string _baudrate; 
		private string _databit; 
		private string _stopbit; 
		private string _parity; 
		private string _qc; 
		private string _active; 
		private float _dicttesttypeid; 
		private float _dictlabdeptid; 
		private string _remark; 
		private string _formname; 
		private float _dictcustomerid; 
		private float _dictreporttemplateid; 
		private float _monthinterval; 
		private string _printdaanheader; 
		private string _uniqueid; 
		private string _hostip; 
		private string _portno; 
		private string _filepath; 
		private string _datasource; 
		private float _endcode; 
		private float _isneedresponse; 
		private string _responseat; 
		private float _responsecode; 
		private string _classname; 
		private float _virtualinstrumentid; 
		private float _parsetime; 
		private string _ismic; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictinstrument()
		{
			_dictinstrumentid = 0; 
			_instrumentcode = null; 
			_fastcode = null; 
			_instrumentname = null; 
			_model = null; 
			_status = null; 
			_vendor = null; 
			_address = null; 
			_telephone = null; 
			_purchasedate = new DateTime(); 
			_manufacture = null; 
			_setupdate = null; 
			_contactman = null; 
			_contactphone = null; 
			_maintenanceman = null; 
			_communicatemode = null; 
			_protocol = null; 
			_comport = null; 
			_baudrate = null; 
			_databit = null; 
			_stopbit = null; 
			_parity = null; 
			_qc = null; 
			_active = null; 
			_dicttesttypeid = 0; 
			_dictlabdeptid = 0; 
			_remark = null; 
			_formname = null; 
			_dictcustomerid = 0; 
			_dictreporttemplateid = 0; 
			_monthinterval = 0; 
			_printdaanheader = null; 
			_uniqueid = null; 
			_hostip = null; 
			_portno = null; 
			_filepath = null; 
			_datasource = null; 
			_endcode = 0; 
			_isneedresponse = 0; 
			_responseat = null; 
			_responsecode = 0; 
			_classname = null; 
			_virtualinstrumentid = 0; 
			_parsetime = 0; 
			_ismic = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键
		/// </summary>		
		public float Dictinstrumentid
		{
			get { return _dictinstrumentid; }
			set { _isChanged |= (_dictinstrumentid != value); _dictinstrumentid = value; }
		}
			
		/// <summary>
		/// 仪器代码
		/// </summary>		
		public string Instrumentcode
		{
			get { return _instrumentcode; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Instrumentcode", value, value.ToString());
				
				_isChanged |= (_instrumentcode != value); _instrumentcode = value;
			}
		}
			
		/// <summary>
		/// 助记码
		/// </summary>		
		public string Fastcode
		{
			get { return _fastcode; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Fastcode", value, value.ToString());
				
				_isChanged |= (_fastcode != value); _fastcode = value;
			}
		}
			
		/// <summary>
		/// 仪器名称
		/// </summary>		
		public string Instrumentname
		{
			get { return _instrumentname; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Instrumentname", value, value.ToString());
				
				_isChanged |= (_instrumentname != value); _instrumentname = value;
			}
		}
			
		/// <summary>
		/// 型号
		/// </summary>		
		public string Model
		{
			get { return _model; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Model", value, value.ToString());
				
				_isChanged |= (_model != value); _model = value;
			}
		}
			
		/// <summary>
		/// 正常使用，报损处理，维修
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
		/// 供应商
		/// </summary>		
		public string Vendor
		{
			get { return _vendor; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Vendor", value, value.ToString());
				
				_isChanged |= (_vendor != value); _vendor = value;
			}
		}
			
		/// <summary>
		/// 供应商地址
		/// </summary>		
		public string Address
		{
			get { return _address; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Address", value, value.ToString());
				
				_isChanged |= (_address != value); _address = value;
			}
		}
			
		/// <summary>
		/// 供应商电话
		/// </summary>		
		public string Telephone
		{
			get { return _telephone; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Telephone", value, value.ToString());
				
				_isChanged |= (_telephone != value); _telephone = value;
			}
		}
			
		/// <summary>
		/// 购买日期
		/// </summary>		
		public DateTime Purchasedate
		{
			get { return _purchasedate; }
			set { _isChanged |= (_purchasedate != value); _purchasedate = value; }
		}
			
		/// <summary>
		/// 制造商
		/// </summary>		
		public string Manufacture
		{
			get { return _manufacture; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Manufacture", value, value.ToString());
				
				_isChanged |= (_manufacture != value); _manufacture = value;
			}
		}
			
		/// <summary>
		/// 安装日期
		/// </summary>		
		public string Setupdate
		{
			get { return _setupdate; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Setupdate", value, value.ToString());
				
				_isChanged |= (_setupdate != value); _setupdate = value;
			}
		}
			
		/// <summary>
		/// 仪器联系人
		/// </summary>		
		public string Contactman
		{
			get { return _contactman; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Contactman", value, value.ToString());
				
				_isChanged |= (_contactman != value); _contactman = value;
			}
		}
			
		/// <summary>
		/// 联系电话
		/// </summary>		
		public string Contactphone
		{
			get { return _contactphone; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Contactphone", value, value.ToString());
				
				_isChanged |= (_contactphone != value); _contactphone = value;
			}
		}
			
		/// <summary>
		/// 维护人，来自LIS用户
		/// </summary>		
		public string Maintenanceman
		{
			get { return _maintenanceman; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Maintenanceman", value, value.ToString());
				
				_isChanged |= (_maintenanceman != value); _maintenanceman = value;
			}
		}
			
		/// <summary>
		/// 无通信/单向/双向无校验位/双向有校验位
		/// </summary>		
		public string Communicatemode
		{
			get { return _communicatemode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Communicatemode", value, value.ToString());
				
				_isChanged |= (_communicatemode != value); _communicatemode = value;
			}
		}
			
		/// <summary>
		/// 无/XonXof/RTS or CTS/ASTM
		/// </summary>		
		public string Protocol
		{
			get { return _protocol; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Protocol", value, value.ToString());
				
				_isChanged |= (_protocol != value); _protocol = value;
			}
		}
			
		/// <summary>
		/// COM1/COM2...
		/// </summary>		
		public string Comport
		{
			get { return _comport; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Comport", value, value.ToString());
				
				_isChanged |= (_comport != value); _comport = value;
			}
		}
			
		/// <summary>
		/// 4800/9600/...
		/// </summary>		
		public string Baudrate
		{
			get { return _baudrate; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Baudrate", value, value.ToString());
				
				_isChanged |= (_baudrate != value); _baudrate = value;
			}
		}
			
		/// <summary>
		/// 数据位
		/// </summary>		
		public string Databit
		{
			get { return _databit; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Databit", value, value.ToString());
				
				_isChanged |= (_databit != value); _databit = value;
			}
		}
			
		/// <summary>
		/// 停止位
		/// </summary>		
		public string Stopbit
		{
			get { return _stopbit; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Stopbit", value, value.ToString());
				
				_isChanged |= (_stopbit != value); _stopbit = value;
			}
		}
			
		/// <summary>
		/// 奇偶校验
		/// </summary>		
		public string Parity
		{
			get { return _parity; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Parity", value, value.ToString());
				
				_isChanged |= (_parity != value); _parity = value;
			}
		}
			
		/// <summary>
		/// 0-不用QC  1-需用QC
		/// </summary>		
		public string Qc
		{
			get { return _qc; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Qc", value, value.ToString());
				
				_isChanged |= (_qc != value); _qc = value;
			}
		}
			
		/// <summary>
		/// 是否可用 0-不可用 1-可用
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
		/// 医学专业组ID，对应表DICTLIABRARYID
		/// </summary>		
		public float Dicttesttypeid
		{
			get { return _dicttesttypeid; }
			set { _isChanged |= (_dicttesttypeid != value); _dicttesttypeid = value; }
		}
			
		/// <summary>
		/// 实验室分组ID，对应表DICTLIABRARYID
		/// </summary>		
		public float Dictlabdeptid
		{
			get { return _dictlabdeptid; }
			set { _isChanged |= (_dictlabdeptid != value); _dictlabdeptid = value; }
		}
			
		/// <summary>
		/// 备注
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
		/// 窗口名称
		/// </summary>		
		public string Formname
		{
			get { return _formname; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Formname", value, value.ToString());
				
				_isChanged |= (_formname != value); _formname = value;
			}
		}
			
		/// <summary>
		/// 外包客户ID，对应表DictCustomer
		/// </summary>		
		public float Dictcustomerid
		{
			get { return _dictcustomerid; }
			set { _isChanged |= (_dictcustomerid != value); _dictcustomerid = value; }
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
		/// 表示该仪器只看几个月之内的数据
		/// </summary>		
		public float Monthinterval
		{
			get { return _monthinterval; }
			set { _isChanged |= (_monthinterval != value); _monthinterval = value; }
		}
			
		/// <summary>
		/// 是否打印DAAN的抬头
		/// </summary>		
		public string Printdaanheader
		{
			get { return _printdaanheader; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Printdaanheader", value, value.ToString());
				
				_isChanged |= (_printdaanheader != value); _printdaanheader = value;
			}
		}
			
		/// <summary>
		/// 全国统一码
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
		/// 主机IP
		/// </summary>		
		public string Hostip
		{
			get { return _hostip; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Hostip", value, value.ToString());
				
				_isChanged |= (_hostip != value); _hostip = value;
			}
		}
			
		/// <summary>
		/// 端口号
		/// </summary>		
		public string Portno
		{
			get { return _portno; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Portno", value, value.ToString());
				
				_isChanged |= (_portno != value); _portno = value;
			}
		}
			
		/// <summary>
		/// 文件路径
		/// </summary>		
		public string Filepath
		{
			get { return _filepath; }
			set	
			{
				if( value!= null && value.Length > 2000)
					throw new ArgumentOutOfRangeException("Invalid value for Filepath", value, value.ToString());
				
				_isChanged |= (_filepath != value); _filepath = value;
			}
		}
			
		/// <summary>
		/// 数据源名称
		/// </summary>		
		public string Datasource
		{
			get { return _datasource; }
			set	
			{
				if( value!= null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for Datasource", value, value.ToString());
				
				_isChanged |= (_datasource != value); _datasource = value;
			}
		}
			
		/// <summary>
		/// 结束码
		/// </summary>		
		public float Endcode
		{
			get { return _endcode; }
			set { _isChanged |= (_endcode != value); _endcode = value; }
		}
			
		/// <summary>
		/// 需要回应
		/// </summary>		
		public float Isneedresponse
		{
			get { return _isneedresponse; }
			set { _isChanged |= (_isneedresponse != value); _isneedresponse = value; }
		}
			
		/// <summary>
		/// 回应遇到码
		/// </summary>		
		public string Responseat
		{
			get { return _responseat; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Responseat", value, value.ToString());
				
				_isChanged |= (_responseat != value); _responseat = value;
			}
		}
			
		/// <summary>
		/// 回应码
		/// </summary>		
		public float Responsecode
		{
			get { return _responsecode; }
			set { _isChanged |= (_responsecode != value); _responsecode = value; }
		}
			
		/// <summary>
		///  类名
		/// </summary>		
		public string Classname
		{
			get { return _classname; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Classname", value, value.ToString());
				
				_isChanged |= (_classname != value); _classname = value;
			}
		}
			
		/// <summary>
		/// 仪器ID，虚拟仪器传结果使用此仪器ID
		/// </summary>		
		public float Virtualinstrumentid
		{
			get { return _virtualinstrumentid; }
			set { _isChanged |= (_virtualinstrumentid != value); _virtualinstrumentid = value; }
		}
			
		/// <summary>
		/// 解析间隔时间
		/// </summary>		
		public float Parsetime
		{
			get { return _parsetime; }
			set { _isChanged |= (_parsetime != value); _parsetime = value; }
		}
			
		/// <summary>
		/// 是否是微生物仪器
		/// </summary>		
		public string Ismic
		{
			get { return _ismic; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Ismic", value, value.ToString());
				
				_isChanged |= (_ismic != value); _ismic = value;
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
