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
    public sealed class Dictqccontrol : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictqccontrolid; 
		private string _controlname; 
		private string _active; 
		private string _controlshape; 
		private string _controlcolor; 
		private string _uniqueid; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictqccontrol()
		{
			_dictqccontrolid = 0; 
			_controlname = null; 
			_active = null; 
			_controlshape = null; 
			_controlcolor = null; 
			_uniqueid = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自动ID
		/// </summary>		
		public float Dictqccontrolid
		{
			get { return _dictqccontrolid; }
			set { _isChanged |= (_dictqccontrolid != value); _dictqccontrolid = value; }
		}
			
		/// <summary>
		/// 水平名称
		/// </summary>		
		public string Controlname
		{
			get { return _controlname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Controlname", value, value.ToString());
				
				_isChanged |= (_controlname != value); _controlname = value;
			}
		}
			
		/// <summary>
		/// 是否可用  0-否  1-是
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
		/// 水平所用的点的形状
		/// </summary>		
		public string Controlshape
		{
			get { return _controlshape; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Controlshape", value, value.ToString());
				
				_isChanged |= (_controlshape != value); _controlshape = value;
			}
		}
			
		/// <summary>
		/// 水平所有的点及线颜色
		/// </summary>		
		public string Controlcolor
		{
			get { return _controlcolor; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Controlcolor", value, value.ToString());
				
				_isChanged |= (_controlcolor != value); _controlcolor = value;
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
