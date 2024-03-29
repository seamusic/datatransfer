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
	public sealed class Dictantibiotic : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictantibioticid; 
		private string _fastcode; 
		private string _antibioticcode; 
		private string _antibioticename; 
		private string _antibioticcname; 
		private float _displayorder; 
		private string _report; 
		private string _active; 
		private string _whonetid; 
		private string _whonetkbid; 
		private string _whonetmicid; 
		private string _whonetetestid; 
		private string _dosage1; 
		private string _dosage2; 
		private string _serum1; 
		private string _serum2; 
		private string _urine1; 
		private string _urine2; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictantibiotic()
		{
			_dictantibioticid = 0; 
			_fastcode = null; 
			_antibioticcode = null; 
			_antibioticename = null; 
			_antibioticcname = null; 
			_displayorder = 0; 
			_report = null; 
			_active = null; 
			_whonetid = null; 
			_whonetkbid = null; 
			_whonetmicid = null; 
			_whonetetestid = null; 
			_dosage1 = null; 
			_dosage2 = null; 
			_serum1 = null; 
			_serum2 = null; 
			_urine1 = null; 
			_urine2 = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自动ID
		/// </summary>		
		public float Dictantibioticid
		{
			get { return _dictantibioticid; }
			set { _isChanged |= (_dictantibioticid != value); _dictantibioticid = value; }
		}
			
		/// <summary>
		/// 助记码
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
		/// 抗生素代码
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
		/// 显示顺序
		/// </summary>		
		public float Displayorder
		{
			get { return _displayorder; }
			set { _isChanged |= (_displayorder != value); _displayorder = value; }
		}
			
		/// <summary>
		/// 是否需要打印报告  0-否 1--是
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
		/// WHONET代码
		/// </summary>		
		public string Whonetid
		{
			get { return _whonetid; }
			set	
			{
				if( value!= null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Whonetid", value, value.ToString());
				
				_isChanged |= (_whonetid != value); _whonetid = value;
			}
		}
			
		/// <summary>
		/// WHONET纸片法代码
		/// </summary>		
		public string Whonetkbid
		{
			get { return _whonetkbid; }
			set	
			{
				if( value!= null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Whonetkbid", value, value.ToString());
				
				_isChanged |= (_whonetkbid != value); _whonetkbid = value;
			}
		}
			
		/// <summary>
		/// WHONET mic法代码
		/// </summary>		
		public string Whonetmicid
		{
			get { return _whonetmicid; }
			set	
			{
				if( value!= null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Whonetmicid", value, value.ToString());
				
				_isChanged |= (_whonetmicid != value); _whonetmicid = value;
			}
		}
			
		/// <summary>
		/// WHONET ETest法代码
		/// </summary>		
		public string Whonetetestid
		{
			get { return _whonetetestid; }
			set	
			{
				if( value!= null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Whonetetestid", value, value.ToString());
				
				_isChanged |= (_whonetetestid != value); _whonetetestid = value;
			}
		}
			
		/// <summary>
		/// 用药剂量1
		/// </summary>		
		public string Dosage1
		{
			get { return _dosage1; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Dosage1", value, value.ToString());
				
				_isChanged |= (_dosage1 != value); _dosage1 = value;
			}
		}
			
		/// <summary>
		/// 用药剂量2
		/// </summary>		
		public string Dosage2
		{
			get { return _dosage2; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Dosage2", value, value.ToString());
				
				_isChanged |= (_dosage2 != value); _dosage2 = value;
			}
		}
			
		/// <summary>
		/// 血药浓度1
		/// </summary>		
		public string Serum1
		{
			get { return _serum1; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Serum1", value, value.ToString());
				
				_isChanged |= (_serum1 != value); _serum1 = value;
			}
		}
			
		/// <summary>
		/// 血药浓度2
		/// </summary>		
		public string Serum2
		{
			get { return _serum2; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Serum2", value, value.ToString());
				
				_isChanged |= (_serum2 != value); _serum2 = value;
			}
		}
			
		/// <summary>
		/// 尿药浓度1
		/// </summary>		
		public string Urine1
		{
			get { return _urine1; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Urine1", value, value.ToString());
				
				_isChanged |= (_urine1 != value); _urine1 = value;
			}
		}
			
		/// <summary>
		/// 尿药浓度2
		/// </summary>		
		public string Urine2
		{
			get { return _urine2; }
			set	
			{
				if( value!= null && value.Length > 300)
					throw new ArgumentOutOfRangeException("Invalid value for Urine2", value, value.ToString());
				
				_isChanged |= (_urine2 != value); _urine2 = value;
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
