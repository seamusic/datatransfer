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
    public sealed class Specimenpatientname : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private string _barcode; 
		private byte[] _patientname; 
		private DateTime _createdate; 
		private string _useimage; 
		private byte[] _captureimage; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Specimenpatientname()
		{
			_barcode = null; 
			_patientname = new byte[]{}; 
			_createdate = new DateTime(); 
			_useimage = null; 
			_captureimage = new byte[]{}; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 子条码号
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
		/// 病人名字扫描图片
		/// </summary>		
		public byte[] Patientname
		{
			get { return _patientname; }
			set { _isChanged |= (_patientname != value); _patientname = value; }
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
		/// 是否使用图片
		/// </summary>		
		public string Useimage
		{
			get { return _useimage; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Useimage", value, value.ToString());
				
				_isChanged |= (_useimage != value); _useimage = value;
			}
		}
			
		/// <summary>
		/// 保存好的截图
		/// </summary>		
		public byte[] Captureimage
		{
			get { return _captureimage; }
			set { _isChanged |= (_captureimage != value); _captureimage = value; }
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
