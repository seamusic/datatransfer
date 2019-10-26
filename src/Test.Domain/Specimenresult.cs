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
    public sealed class Specimenresult : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private string _subbarcode; 
		private float _dicttestitemid; 
		private string _result; 
		private string _resultcomment; 
		private string _unit; 
		private float _precision; 
		private float _displayorder; 
		private string _hlflag; 
		private string _panicflag; 
		private string _deltaflag; 
		private string _reflow; 
		private string _refhigh; 
		private string _refmethod; 
		private string _textshow; 
		private string _paniclow; 
		private string _panichigh; 
		private string _status; 
		private string _report; 
		private DateTime _createdate; 
		private float _dictinstrumentid; 
		private string _remark; 
		private float _specimenresultid; 
		private string _engtextshow; 
		private string _engremark; 
		private float _specimenreportid; 
		private string _transed; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Specimenresult()
		{
			_subbarcode = null; 
			_dicttestitemid = 0; 
			_result = null; 
			_resultcomment = null; 
			_unit = null; 
			_precision = 0; 
			_displayorder = 0; 
			_hlflag = null; 
			_panicflag = null; 
			_deltaflag = null; 
			_reflow = null; 
			_refhigh = null; 
			_refmethod = null; 
			_textshow = null; 
			_paniclow = null; 
			_panichigh = null; 
			_status = null; 
			_report = null; 
			_createdate = new DateTime(); 
			_dictinstrumentid = 0; 
			_remark = null; 
			_specimenresultid = 0; 
			_engtextshow = null; 
			_engremark = null; 
			_specimenreportid = 0; 
			_transed = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 子条码号
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
		/// 测试项ID
		/// </summary>		
		public float Dicttestitemid
		{
			get { return _dicttestitemid; }
			set { _isChanged |= (_dicttestitemid != value); _dicttestitemid = value; }
		}
			
		/// <summary>
		/// 结果
		/// </summary>		
		public string Result
		{
			get { return _result; }
			set	
			{
				if( value!= null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for Result", value, value.ToString());
				
				_isChanged |= (_result != value); _result = value;
			}
		}
			
		/// <summary>
		/// 结果备注
		/// </summary>		
		public string Resultcomment
		{
			get { return _resultcomment; }
			set	
			{
				if( value!= null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Resultcomment", value, value.ToString());
				
				_isChanged |= (_resultcomment != value); _resultcomment = value;
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
		/// 精度
		/// </summary>		
		public float Precision
		{
			get { return _precision; }
			set { _isChanged |= (_precision != value); _precision = value; }
		}
			
		/// <summary>
		/// 打印顺序
		/// </summary>		
		public float Displayorder
		{
			get { return _displayorder; }
			set { _isChanged |= (_displayorder != value); _displayorder = value; }
		}
			
		/// <summary>
		/// 高低值标志
		/// </summary>		
		public string Hlflag
		{
			get { return _hlflag; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Hlflag", value, value.ToString());
				
				_isChanged |= (_hlflag != value); _hlflag = value;
			}
		}
			
		/// <summary>
		/// 危险值标志
		/// </summary>		
		public string Panicflag
		{
			get { return _panicflag; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Panicflag", value, value.ToString());
				
				_isChanged |= (_panicflag != value); _panicflag = value;
			}
		}
			
		/// <summary>
		/// 上次对比标志
		/// </summary>		
		public string Deltaflag
		{
			get { return _deltaflag; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Deltaflag", value, value.ToString());
				
				_isChanged |= (_deltaflag != value); _deltaflag = value;
			}
		}
			
		/// <summary>
		/// 参考低值
		/// </summary>		
		public string Reflow
		{
			get { return _reflow; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Reflow", value, value.ToString());
				
				_isChanged |= (_reflow != value); _reflow = value;
			}
		}
			
		/// <summary>
		/// 参考高值
		/// </summary>		
		public string Refhigh
		{
			get { return _refhigh; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Refhigh", value, value.ToString());
				
				_isChanged |= (_refhigh != value); _refhigh = value;
			}
		}
			
		/// <summary>
		/// 参考范围显示方式
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
		/// 文字参考范围
		/// </summary>		
		public string Textshow
		{
			get { return _textshow; }
			set	
			{
				if( value!= null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for Textshow", value, value.ToString());
				
				_isChanged |= (_textshow != value); _textshow = value;
			}
		}
			
		/// <summary>
		/// 危险低值
		/// </summary>		
		public string Paniclow
		{
			get { return _paniclow; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Paniclow", value, value.ToString());
				
				_isChanged |= (_paniclow != value); _paniclow = value;
			}
		}
			
		/// <summary>
		/// 危险高值
		/// </summary>		
		public string Panichigh
		{
			get { return _panichigh; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Panichigh", value, value.ToString());
				
				_isChanged |= (_panichigh != value); _panichigh = value;
			}
		}
			
		/// <summary>
		/// 状态，对应表INITBASIC  0-初始化  1-技术员提交  2-审核完成
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
		/// 是否需打印报告  0-否，1-是
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
		/// 记录生成日期
		/// </summary>		
		public DateTime Createdate
		{
			get { return _createdate; }
			set { _isChanged |= (_createdate != value); _createdate = value; }
		}
			
		/// <summary>
		/// 外键，对应表DictInstrument
		/// </summary>		
		public float Dictinstrumentid
		{
			get { return _dictinstrumentid; }
			set { _isChanged |= (_dictinstrumentid != value); _dictinstrumentid = value; }
		}
			
		/// <summary>
		/// 参考范围备注，来自表DictTestRefRang
		/// </summary>		
		public string Remark
		{
			get { return _remark; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Remark", value, value.ToString());
				
				_isChanged |= (_remark != value); _remark = value;
			}
		}
			
		/// <summary>
		/// 序列，主键ID
		/// </summary>		
		public float Specimenresultid
		{
			get { return _specimenresultid; }
			set { _isChanged |= (_specimenresultid != value); _specimenresultid = value; }
		}
			
		/// <summary>
		/// 英文的文字参考范围
		/// </summary>		
		public string Engtextshow
		{
			get { return _engtextshow; }
			set	
			{
				if( value!= null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for Engtextshow", value, value.ToString());
				
				_isChanged |= (_engtextshow != value); _engtextshow = value;
			}
		}
			
		/// <summary>
		/// 英文的参考范围备注，来自表DictTestRefRang
		/// </summary>		
		public string Engremark
		{
			get { return _engremark; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Engremark", value, value.ToString());
				
				_isChanged |= (_engremark != value); _engremark = value;
			}
		}
			
		/// <summary>
		/// 报告单ID
		/// </summary>		
		public float Specimenreportid
		{
			get { return _specimenreportid; }
			set { _isChanged |= (_specimenreportid != value); _specimenreportid = value; }
		}
			
		/// <summary>
		/// 大众平台结果传输标志。0未传输，1传输
		/// </summary>		
		public string Transed
		{
			get { return _transed; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Transed", value, value.ToString());
				
				_isChanged |= (_transed != value); _transed = value;
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
