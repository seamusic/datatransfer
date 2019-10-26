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
    public sealed class Dictinstrumenttest : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictinstrumenttestid; 
		private float _dictinstrumentid; 
		private float _dicttestitemid; 
		private string _analyzercode; 
		private float _factor; 
		private float _testtype; 
		private string _isdilution; 
		private string _isqc; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictinstrumenttest()
		{
			_dictinstrumenttestid = 0; 
			_dictinstrumentid = 0; 
			_dicttestitemid = 0; 
			_analyzercode = null; 
			_factor = 0; 
			_testtype = 0; 
			_isdilution = null; 
			_isqc = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键
		/// </summary>		
		public float Dictinstrumenttestid
		{
			get { return _dictinstrumenttestid; }
			set { _isChanged |= (_dictinstrumenttestid != value); _dictinstrumenttestid = value; }
		}
			
		/// <summary>
		/// 主键
		/// </summary>		
		public float Dictinstrumentid
		{
			get { return _dictinstrumentid; }
			set { _isChanged |= (_dictinstrumentid != value); _dictinstrumentid = value; }
		}
			
		/// <summary>
		/// 测试项目ID
		/// </summary>		
		public float Dicttestitemid
		{
			get { return _dicttestitemid; }
			set { _isChanged |= (_dicttestitemid != value); _dicttestitemid = value; }
		}
			
		/// <summary>
		/// 通道号
		/// </summary>		
		public string Analyzercode
		{
			get { return _analyzercode; }
			set	
			{
				if( value!= null && value.Length > 80)
					throw new ArgumentOutOfRangeException("Invalid value for Analyzercode", value, value.ToString());
				
				_isChanged |= (_analyzercode != value); _analyzercode = value;
			}
		}
			
		/// <summary>
		/// 转换参数，用来转换仪器结果
		/// </summary>		
		public float Factor
		{
			get { return _factor; }
			set { _isChanged |= (_factor != value); _factor = value; }
		}
			
		/// <summary>
		/// 项目类型，0：常规项目，1：微生物细菌，2：微生物抗生素
		/// </summary>		
		public float Testtype
		{
			get { return _testtype; }
			set { _isChanged |= (_testtype != value); _testtype = value; }
		}
			
		/// <summary>
		/// 是否需要稀释0-否  1-是
		/// </summary>		
		public string Isdilution
		{
			get { return _isdilution; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Isdilution", value, value.ToString());
				
				_isChanged |= (_isdilution != value); _isdilution = value;
			}
		}
			
		/// <summary>
		/// 是否需要做QC  0-否  1-是
		/// </summary>		
		public string Isqc
		{
			get { return _isqc; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Isqc", value, value.ToString());
				
				_isChanged |= (_isqc != value); _isqc = value;
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
