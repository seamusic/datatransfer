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
    public sealed class Specimenreport : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _specimenreportid; 
		private string _barcode; 
		private float _reporttemplateid; 
		private string _papersize; 
		private float _landscape; 
		private float _printcount; 
		private float _printby; 
		private DateTime _printdate; 
		private DateTime _createdate; 
		private float _reportoption; 
		private float _cusomerheader; 
		private string _dictlabdeptname; 
		private DateTime _authorizedate; 
		private string _authorizedbynames; 
		private DateTime _releasedate; 
		private string _releasebynames; 
		private DateTime _signaturedate; 
		private string _signaturebynames; 
		private string _hashcode; 
		private string _specimentype; 
		private string _specimenstatus; 
		private string _reportremark; 
		private string _subbarcode; 
		private string _seq; 
		private float _dictmedicaltypeid; 
		private string _status; 
		private string _mergereport; 
		private string _englishreport; 
		private float _batchreport; 
		private float _printcounttotal; 
		private float _webprintcount; 
		private string _reportshowmethod; 
		private string _usbkeyid; 
		private string _istm15item; 
		private string _exceptionitemmemos; 
		private string _reportremark2; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Specimenreport()
		{
			_specimenreportid = 0; 
			_barcode = null; 
			_reporttemplateid = 0; 
			_papersize = null; 
			_landscape = 0; 
			_printcount = 0; 
			_printby = 0; 
			_printdate = new DateTime(); 
			_createdate = new DateTime(); 
			_reportoption = 0; 
			_cusomerheader = 0; 
			_dictlabdeptname = null; 
			_authorizedate = new DateTime(); 
			_authorizedbynames = null; 
			_releasedate = new DateTime(); 
			_releasebynames = null; 
			_signaturedate = new DateTime(); 
			_signaturebynames = null; 
			_hashcode = null; 
			_specimentype = null; 
			_specimenstatus = null; 
			_reportremark = null; 
			_subbarcode = null; 
			_seq = null; 
			_dictmedicaltypeid = 0; 
			_status = null; 
			_mergereport = null; 
			_englishreport = null; 
			_batchreport = 0; 
			_printcounttotal = 0; 
			_webprintcount = 0; 
			_reportshowmethod = null; 
			_usbkeyid = null; 
			_istm15item = null; 
			_exceptionitemmemos = null; 
			_reportremark2 = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 报告id
		/// </summary>		
		public float Specimenreportid
		{
			get { return _specimenreportid; }
			set { _isChanged |= (_specimenreportid != value); _specimenreportid = value; }
		}
			
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
		/// 报表模板id
		/// </summary>		
		public float Reporttemplateid
		{
			get { return _reporttemplateid; }
			set { _isChanged |= (_reporttemplateid != value); _reporttemplateid = value; }
		}
			
		/// <summary>
		/// 纸张大小
		/// </summary>		
		public string Papersize
		{
			get { return _papersize; }
			set	
			{
				if( value!= null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Papersize", value, value.ToString());
				
				_isChanged |= (_papersize != value); _papersize = value;
			}
		}
			
		/// <summary>
		/// 横向/纵向打印
		/// </summary>		
		public float Landscape
		{
			get { return _landscape; }
			set { _isChanged |= (_landscape != value); _landscape = value; }
		}
			
		/// <summary>
		/// 打印次数
		/// </summary>		
		public float Printcount
		{
			get { return _printcount; }
			set { _isChanged |= (_printcount != value); _printcount = value; }
		}
			
		/// <summary>
		/// 最后打印人
		/// </summary>		
		public float Printby
		{
			get { return _printby; }
			set { _isChanged |= (_printby != value); _printby = value; }
		}
			
		/// <summary>
		/// 最后打印时间
		/// </summary>		
		public DateTime Printdate
		{
			get { return _printdate; }
			set { _isChanged |= (_printdate != value); _printdate = value; }
		}
			
		/// <summary>
		/// 创建日期
		/// </summary>		
		public DateTime Createdate
		{
			get { return _createdate; }
			set { _isChanged |= (_createdate != value); _createdate = value; }
		}
			
		/// <summary>
		/// 打印选项，扩展用
		/// </summary>		
		public float Reportoption
		{
			get { return _reportoption; }
			set { _isChanged |= (_reportoption != value); _reportoption = value; }
		}
			
		/// <summary>
		/// 是否以客户名称为报告抬头
		/// </summary>		
		public float Cusomerheader
		{
			get { return _cusomerheader; }
			set { _isChanged |= (_cusomerheader != value); _cusomerheader = value; }
		}
			
		/// <summary>
		/// 检验科室以逗号分隔
		/// </summary>		
		public string Dictlabdeptname
		{
			get { return _dictlabdeptname; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Dictlabdeptname", value, value.ToString());
				
				_isChanged |= (_dictlabdeptname != value); _dictlabdeptname = value;
			}
		}
			
		/// <summary>
		/// 审核日期
		/// </summary>		
		public DateTime Authorizedate
		{
			get { return _authorizedate; }
			set { _isChanged |= (_authorizedate != value); _authorizedate = value; }
		}
			
		/// <summary>
		/// 审核人多个以逗号隔开
		/// </summary>		
		public string Authorizedbynames
		{
			get { return _authorizedbynames; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Authorizedbynames", value, value.ToString());
				
				_isChanged |= (_authorizedbynames != value); _authorizedbynames = value;
			}
		}
			
		/// <summary>
		/// 检验时间
		/// </summary>		
		public DateTime Releasedate
		{
			get { return _releasedate; }
			set { _isChanged |= (_releasedate != value); _releasedate = value; }
		}
			
		/// <summary>
		/// 检验人，多个以逗号隔开
		/// </summary>		
		public string Releasebynames
		{
			get { return _releasebynames; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Releasebynames", value, value.ToString());
				
				_isChanged |= (_releasebynames != value); _releasebynames = value;
			}
		}
			
		/// <summary>
		/// 数字签名时间
		/// </summary>		
		public DateTime Signaturedate
		{
			get { return _signaturedate; }
			set { _isChanged |= (_signaturedate != value); _signaturedate = value; }
		}
			
		/// <summary>
		/// 数字签名人，多个以逗号隔开
		/// </summary>		
		public string Signaturebynames
		{
			get { return _signaturebynames; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Signaturebynames", value, value.ToString());
				
				_isChanged |= (_signaturebynames != value); _signaturebynames = value;
			}
		}
			
		/// <summary>
		/// 数字签名序列号
		/// </summary>		
		public string Hashcode
		{
			get { return _hashcode; }
			set	
			{
				if( value!= null && value.Length > 256)
					throw new ArgumentOutOfRangeException("Invalid value for Hashcode", value, value.ToString());
				
				_isChanged |= (_hashcode != value); _hashcode = value;
			}
		}
			
		/// <summary>
		/// 标本类型
		/// </summary>		
		public string Specimentype
		{
			get { return _specimentype; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Specimentype", value, value.ToString());
				
				_isChanged |= (_specimentype != value); _specimentype = value;
			}
		}
			
		/// <summary>
		/// 标本状态
		/// </summary>		
		public string Specimenstatus
		{
			get { return _specimenstatus; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Specimenstatus", value, value.ToString());
				
				_isChanged |= (_specimenstatus != value); _specimenstatus = value;
			}
		}
			
		/// <summary>
		/// 建议及解释
		/// </summary>		
		public string Reportremark
		{
			get { return _reportremark; }
			set	
			{
				if( value!= null && value.Length > 2000)
					throw new ArgumentOutOfRangeException("Invalid value for Reportremark", value, value.ToString());
				
				_isChanged |= (_reportremark != value); _reportremark = value;
			}
		}
			
		/// <summary>
		/// 子条码
		/// </summary>		
		public string Subbarcode
		{
			get { return _subbarcode; }
			set	
			{
				if( value!= null && value.Length > 40)
					throw new ArgumentOutOfRangeException("Invalid value for Subbarcode", value, value.ToString());
				
				_isChanged |= (_subbarcode != value); _subbarcode = value;
			}
		}
			
		/// <summary>
		/// 样本准备的流水号
		/// </summary>		
		public string Seq
		{
			get { return _seq; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Seq", value, value.ToString());
				
				_isChanged |= (_seq != value); _seq = value;
			}
		}
			
		/// <summary>
		/// 医学专业分组ID
		/// </summary>		
		public float Dictmedicaltypeid
		{
			get { return _dictmedicaltypeid; }
			set { _isChanged |= (_dictmedicaltypeid != value); _dictmedicaltypeid = value; }
		}
			
		/// <summary>
		/// 状态 0-未处理 1-已处理
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
		/// 按审核次数分次生成报告
		/// </summary>		
		public float Batchreport
		{
			get { return _batchreport; }
			set { _isChanged |= (_batchreport != value); _batchreport = value; }
		}
			
		/// <summary>
		/// 打印次数合计
		/// </summary>		
		public float Printcounttotal
		{
			get { return _printcounttotal; }
			set { _isChanged |= (_printcounttotal != value); _printcounttotal = value; }
		}
			
		/// <summary>
		/// Web打印次数记录
		/// </summary>		
		public float Webprintcount
		{
			get { return _webprintcount; }
			set { _isChanged |= (_webprintcount != value); _webprintcount = value; }
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
		/// 数字签名棒的唯一标识
		/// </summary>		
		public string Usbkeyid
		{
			get { return _usbkeyid; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Usbkeyid", value, value.ToString());
				
				_isChanged |= (_usbkeyid != value); _usbkeyid = value;
			}
		}
			
		/// <summary>
		/// 标识是否TM15体检标本 0 -常规标本    1-TM15体检标本
		/// </summary>		
		public string Istm15item
		{
			get { return _istm15item; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Istm15item", value, value.ToString());
				
				_isChanged |= (_istm15item != value); _istm15item = value;
			}
		}
			
		/// <summary>
		/// 异常项目列表，用于TM15报告单自动小结显示异常项目
		/// </summary>		
		public string Exceptionitemmemos
		{
			get { return _exceptionitemmemos; }
			set	
			{
				if( value!= null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Exceptionitemmemos", value, value.ToString());
				
				_isChanged |= (_exceptionitemmemos != value); _exceptionitemmemos = value;
			}
		}
			
		/// <summary>
		/// 
		/// </summary>		
		public string Reportremark2
		{
			get { return _reportremark2; }
			set	
			{
				if( value!= null && value.Length > 2000)
					throw new ArgumentOutOfRangeException("Invalid value for Reportremark2", value, value.ToString());
				
				_isChanged |= (_reportremark2 != value); _reportremark2 = value;
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
