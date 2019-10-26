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
    public sealed class Instrumentrawdata : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _instrumentrawdataid; 
		private float _dictinstrumentid; 
		private string _rawdata; 
		private DateTime _createdate; 
		private float _status; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Instrumentrawdata()
		{
			_instrumentrawdataid = 0; 
			_dictinstrumentid = 0; 
			_rawdata = null; 
			_createdate = new DateTime(); 
			_status = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 仪器原始结果ID，系统内码
		/// </summary>		
		public float Instrumentrawdataid
		{
			get { return _instrumentrawdataid; }
			set { _isChanged |= (_instrumentrawdataid != value); _instrumentrawdataid = value; }
		}
			
		/// <summary>
		/// 
		/// </summary>		
		public float Dictinstrumentid
		{
			get { return _dictinstrumentid; }
			set { _isChanged |= (_dictinstrumentid != value); _dictinstrumentid = value; }
		}
			
		/// <summary>
		/// 原始结果
		/// </summary>		
		public string Rawdata
		{
			get { return _rawdata; }
			set	
			{
				if( value!= null && value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for Rawdata", value, value.ToString());
				
				_isChanged |= (_rawdata != value); _rawdata = value;
			}
		}
			
		/// <summary>
		/// 用户生成日期
		/// </summary>		
		public DateTime Createdate
		{
			get { return _createdate; }
			set { _isChanged |= (_createdate != value); _createdate = value; }
		}
			
		/// <summary>
		/// 仪器数据处理状态
		/// </summary>		
		public float Status
		{
			get { return _status; }
			set { _isChanged |= (_status != value); _status = value; }
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