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
    public sealed class Instrumenttempresult : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _souid; 
		private float _deviceid; 
		private string _soufull; 
		private string _soufull2; 
		private string _soufull3; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Instrumenttempresult()
		{
			_souid = 0; 
			_deviceid = 0; 
			_soufull = null; 
			_soufull2 = null; 
			_soufull3 = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 序列号，主键
		/// </summary>		
		public float Souid
		{
			get { return _souid; }
			set { _isChanged |= (_souid != value); _souid = value; }
		}
			
		/// <summary>
		/// 仪器ID
		/// </summary>		
		public float Deviceid
		{
			get { return _deviceid; }
			set { _isChanged |= (_deviceid != value); _deviceid = value; }
		}
			
		/// <summary>
		/// 原始数据内容1
		/// </summary>		
		public string Soufull
		{
			get { return _soufull; }
			set	
			{
				if( value!= null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Soufull", value, value.ToString());
				
				_isChanged |= (_soufull != value); _soufull = value;
			}
		}
			
		/// <summary>
		/// 原始数据内容2
		/// </summary>		
		public string Soufull2
		{
			get { return _soufull2; }
			set	
			{
				if( value!= null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Soufull2", value, value.ToString());
				
				_isChanged |= (_soufull2 != value); _soufull2 = value;
			}
		}
			
		/// <summary>
		/// 原始数据内容3
		/// </summary>		
		public string Soufull3
		{
			get { return _soufull3; }
			set	
			{
				if( value!= null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Soufull3", value, value.ToString());
				
				_isChanged |= (_soufull3 != value); _soufull3 = value;
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
