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
    public sealed class Initlocalsetting : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private string _hostmac; 
		private string _hostname; 
		private string _a4printer; 
		private string _a4tray; 
		private string _a5printer; 
		private string _a5tray; 
		private string _barcodeprinter; 
		private float _mergeprintjob; 
		private string _pdfprinter; 
		private string _pathologyprinter; 
		private float _dictinstrumentid1; 
		private float _dictinstrumentid2; 
		private float _dictinstrumentid3; 
		private float _dictinstrumentid4; 
		private float _dictinstrumentid5; 
		private float _dictinstrumentid6; 
		private float _dictinstrumentid7; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Initlocalsetting()
		{
			_hostmac = null; 
			_hostname = null; 
			_a4printer = null; 
			_a4tray = null; 
			_a5printer = null; 
			_a5tray = null; 
			_barcodeprinter = null; 
			_mergeprintjob = 0; 
			_pdfprinter = null; 
			_pathologyprinter = null; 
			_dictinstrumentid1 = 0; 
			_dictinstrumentid2 = 0; 
			_dictinstrumentid3 = 0; 
			_dictinstrumentid4 = 0; 
			_dictinstrumentid5 = 0; 
			_dictinstrumentid6 = 0; 
			_dictinstrumentid7 = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主机MAC地址
		/// </summary>		
		public string Hostmac
		{
			get { return _hostmac; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Hostmac", value, value.ToString());
				
				_isChanged |= (_hostmac != value); _hostmac = value;
			}
		}
			
		/// <summary>
		/// 主机名字
		/// </summary>		
		public string Hostname
		{
			get { return _hostname; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Hostname", value, value.ToString());
				
				_isChanged |= (_hostname != value); _hostname = value;
			}
		}
			
		/// <summary>
		/// A4报告打印机
		/// </summary>		
		public string A4printer
		{
			get { return _a4printer; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for A4printer", value, value.ToString());
				
				_isChanged |= (_a4printer != value); _a4printer = value;
			}
		}
			
		/// <summary>
		/// A4报告打印机纸柜
		/// </summary>		
		public string A4tray
		{
			get { return _a4tray; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for A4tray", value, value.ToString());
				
				_isChanged |= (_a4tray != value); _a4tray = value;
			}
		}
			
		/// <summary>
		/// A5报告打印机
		/// </summary>		
		public string A5printer
		{
			get { return _a5printer; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for A5printer", value, value.ToString());
				
				_isChanged |= (_a5printer != value); _a5printer = value;
			}
		}
			
		/// <summary>
		/// A5报告打印机纸柜
		/// </summary>		
		public string A5tray
		{
			get { return _a5tray; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for A5tray", value, value.ToString());
				
				_isChanged |= (_a5tray != value); _a5tray = value;
			}
		}
			
		/// <summary>
		/// 条码打印机
		/// </summary>		
		public string Barcodeprinter
		{
			get { return _barcodeprinter; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Barcodeprinter", value, value.ToString());
				
				_isChanged |= (_barcodeprinter != value); _barcodeprinter = value;
			}
		}
			
		/// <summary>
		/// 合并打印作业数量
		/// </summary>		
		public float Mergeprintjob
		{
			get { return _mergeprintjob; }
			set { _isChanged |= (_mergeprintjob != value); _mergeprintjob = value; }
		}
			
		/// <summary>
		/// PDF打印机名字
		/// </summary>		
		public string Pdfprinter
		{
			get { return _pdfprinter; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Pdfprinter", value, value.ToString());
				
				_isChanged |= (_pdfprinter != value); _pdfprinter = value;
			}
		}
			
		/// <summary>
		/// 
		/// </summary>		
		public string Pathologyprinter
		{
			get { return _pathologyprinter; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Pathologyprinter", value, value.ToString());
				
				_isChanged |= (_pathologyprinter != value); _pathologyprinter = value;
			}
		}
			
		/// <summary>
		/// 仪器结果ID，系统内码
		/// </summary>		
		public float Dictinstrumentid1
		{
			get { return _dictinstrumentid1; }
			set { _isChanged |= (_dictinstrumentid1 != value); _dictinstrumentid1 = value; }
		}
			
		/// <summary>
		/// 仪器结果ID，系统内码
		/// </summary>		
		public float Dictinstrumentid2
		{
			get { return _dictinstrumentid2; }
			set { _isChanged |= (_dictinstrumentid2 != value); _dictinstrumentid2 = value; }
		}
			
		/// <summary>
		/// 仪器结果ID，系统内码
		/// </summary>		
		public float Dictinstrumentid3
		{
			get { return _dictinstrumentid3; }
			set { _isChanged |= (_dictinstrumentid3 != value); _dictinstrumentid3 = value; }
		}
			
		/// <summary>
		/// 仪器结果ID，系统内码
		/// </summary>		
		public float Dictinstrumentid4
		{
			get { return _dictinstrumentid4; }
			set { _isChanged |= (_dictinstrumentid4 != value); _dictinstrumentid4 = value; }
		}
			
		/// <summary>
		/// 仪器结果ID，系统内码
		/// </summary>		
		public float Dictinstrumentid5
		{
			get { return _dictinstrumentid5; }
			set { _isChanged |= (_dictinstrumentid5 != value); _dictinstrumentid5 = value; }
		}
			
		/// <summary>
		/// 仪器结果ID，系统内码
		/// </summary>		
		public float Dictinstrumentid6
		{
			get { return _dictinstrumentid6; }
			set { _isChanged |= (_dictinstrumentid6 != value); _dictinstrumentid6 = value; }
		}
			
		/// <summary>
		/// 仪器结果ID，系统内码
		/// </summary>		
		public float Dictinstrumentid7
		{
			get { return _dictinstrumentid7; }
			set { _isChanged |= (_dictinstrumentid7 != value); _dictinstrumentid7 = value; }
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
