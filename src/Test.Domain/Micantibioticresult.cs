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
    public sealed class Micantibioticresult : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private string _subbarcode; 
		private float _dicttestitemid; 
		private float _dictorganismid; 
		private float _dictantibioticid; 
		private string _antibioticcode; 
		private string _antibioticcname; 
		private string _antibioticename; 
		private string _micresult; 
		private string _kbresult; 
		private string _result; 
		private float _displayorder; 
		private string _status; 
		private DateTime _createdate; 
		private float _srange; 
		private float _rrange; 
		private float _dicttantibioticgroupid; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Micantibioticresult()
		{
			_subbarcode = null; 
			_dicttestitemid = 0; 
			_dictorganismid = 0; 
			_dictantibioticid = 0; 
			_antibioticcode = null; 
			_antibioticcname = null; 
			_antibioticename = null; 
			_micresult = null; 
			_kbresult = null; 
			_result = null; 
			_displayorder = 0; 
			_status = null; 
			_createdate = new DateTime(); 
			_srange = 0; 
			_rrange = 0; 
			_dicttantibioticgroupid = 0; 
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
		/// 细菌ID
		/// </summary>		
		public float Dictorganismid
		{
			get { return _dictorganismid; }
			set { _isChanged |= (_dictorganismid != value); _dictorganismid = value; }
		}
			
		/// <summary>
		/// 抗生素ID
		/// </summary>		
		public float Dictantibioticid
		{
			get { return _dictantibioticid; }
			set { _isChanged |= (_dictantibioticid != value); _dictantibioticid = value; }
		}
			
		/// <summary>
		/// 抗生素编码
		/// </summary>		
		public string Antibioticcode
		{
			get { return _antibioticcode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Antibioticcode", value, value.ToString());
				
				_isChanged |= (_antibioticcode != value); _antibioticcode = value;
			}
		}
			
		/// <summary>
		/// 抗生素中文名
		/// </summary>		
		public string Antibioticcname
		{
			get { return _antibioticcname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Antibioticcname", value, value.ToString());
				
				_isChanged |= (_antibioticcname != value); _antibioticcname = value;
			}
		}
			
		/// <summary>
		/// 抗生素英文名
		/// </summary>		
		public string Antibioticename
		{
			get { return _antibioticename; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Antibioticename", value, value.ToString());
				
				_isChanged |= (_antibioticename != value); _antibioticename = value;
			}
		}
			
		/// <summary>
		/// MIC结果（仪器）
		/// </summary>		
		public string Micresult
		{
			get { return _micresult; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Micresult", value, value.ToString());
				
				_isChanged |= (_micresult != value); _micresult = value;
			}
		}
			
		/// <summary>
		/// KB结果（手工）
		/// </summary>		
		public string Kbresult
		{
			get { return _kbresult; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Kbresult", value, value.ToString());
				
				_isChanged |= (_kbresult != value); _kbresult = value;
			}
		}
			
		/// <summary>
		/// 最终测定结果
		/// </summary>		
		public string Result
		{
			get { return _result; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Result", value, value.ToString());
				
				_isChanged |= (_result != value); _result = value;
			}
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
		/// 状态  0-等待处理   1-提交  2-审核
		/// </summary>		
		public string Status
		{
			get { return _status; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				
				_isChanged |= (_status != value); _status = value;
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
		/// 抗生素敏感起始值
		/// </summary>		
		public float Srange
		{
			get { return _srange; }
			set { _isChanged |= (_srange != value); _srange = value; }
		}
			
		/// <summary>
		/// 抗生素耐药起始值
		/// </summary>		
		public float Rrange
		{
			get { return _rrange; }
			set { _isChanged |= (_rrange != value); _rrange = value; }
		}
			
		/// <summary>
		/// 抗生素分组ID
		/// </summary>		
		public float Dicttantibioticgroupid
		{
			get { return _dicttantibioticgroupid; }
			set { _isChanged |= (_dicttantibioticgroupid != value); _dicttantibioticgroupid = value; }
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
