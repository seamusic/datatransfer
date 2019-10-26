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
    public sealed class Instrumentpicture : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _instrumentpictureid; 
		private string _subbarcode; 
		private string _batchno; 
		private string _filename; 
		private float _displayorder; 
		private DateTime _createdate; 
		private string _pictype; 
		private string _isuse; 
		private string _picbinary; 
		private string _imagedotvalue; 
		private float _isreport; 
		private string _seq; 
		private float _instrumentseqid; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Instrumentpicture()
		{
			_instrumentpictureid = 0; 
			_subbarcode = null; 
			_batchno = null; 
			_filename = null; 
			_displayorder = 0; 
			_createdate = new DateTime(); 
			_pictype = null; 
			_isuse = null; 
			_picbinary = null; 
			_imagedotvalue = null; 
			_isreport = 0; 
			_seq = null; 
			_instrumentseqid = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自动ID
		/// </summary>		
		public float Instrumentpictureid
		{
			get { return _instrumentpictureid; }
			set { _isChanged |= (_instrumentpictureid != value); _instrumentpictureid = value; }
		}
			
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
		/// 批次号
		/// </summary>		
		public string Batchno
		{
			get { return _batchno; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Batchno", value, value.ToString());
				
				_isChanged |= (_batchno != value); _batchno = value;
			}
		}
			
		/// <summary>
		/// 文件路径及名字
		/// </summary>		
		public string Filename
		{
			get { return _filename; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Filename", value, value.ToString());
				
				_isChanged |= (_filename != value); _filename = value;
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
		/// 生成日期
		/// </summary>		
		public DateTime Createdate
		{
			get { return _createdate; }
			set { _isChanged |= (_createdate != value); _createdate = value; }
		}
			
		/// <summary>
		/// 图片类型，例PLT，WBC，RBC等
		/// </summary>		
		public string Pictype
		{
			get { return _pictype; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Pictype", value, value.ToString());
				
				_isChanged |= (_pictype != value); _pictype = value;
			}
		}
			
		/// <summary>
		/// 是否在用  0-否 1-是
		/// </summary>		
		public string Isuse
		{
			get { return _isuse; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Isuse", value, value.ToString());
				
				_isChanged |= (_isuse != value); _isuse = value;
			}
		}
			
		/// <summary>
		/// 图片的字符流或二进制流
		/// </summary>		
		public string Picbinary
		{
			get { return _picbinary; }
			set	
			{
				if( value!= null && value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for Picbinary", value, value.ToString());
				
				_isChanged |= (_picbinary != value); _picbinary = value;
			}
		}
			
		/// <summary>
		/// 表示图像坐标值的字符串（某些仪器适用)
		/// </summary>		
		public string Imagedotvalue
		{
			get { return _imagedotvalue; }
			set	
			{
				if( value!= null && value.Length > 2147483647)
					throw new ArgumentOutOfRangeException("Invalid value for Imagedotvalue", value, value.ToString());
				
				_isChanged |= (_imagedotvalue != value); _imagedotvalue = value;
			}
		}
			
		/// <summary>
		/// 是否需要打印报告  0-否  1-是
		/// </summary>		
		public float Isreport
		{
			get { return _isreport; }
			set { _isChanged |= (_isreport != value); _isreport = value; }
		}
			
		/// <summary>
		/// 流水号
		/// </summary>		
		public string Seq
		{
			get { return _seq; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Seq", value, value.ToString());
				
				_isChanged |= (_seq != value); _seq = value;
			}
		}
			
		/// <summary>
		/// 仪器流水号ID，系统内码
		/// </summary>		
		public float Instrumentseqid
		{
			get { return _instrumentseqid; }
			set { _isChanged |= (_instrumentseqid != value); _instrumentseqid = value; }
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
