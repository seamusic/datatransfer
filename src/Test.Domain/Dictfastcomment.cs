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
    public sealed class Dictfastcomment : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictfastcommentid; 
		private string _moduleid; 
		private string _fastcode; 
		private string _commentdesc; 
		private string _keymask; 
		private string _hotkey; 
		private float _dictlabdeptid; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictfastcomment()
		{
			_dictfastcommentid = 0; 
			_moduleid = null; 
			_fastcode = null; 
			_commentdesc = null; 
			_keymask = null; 
			_hotkey = null; 
			_dictlabdeptid = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自动ID
		/// </summary>		
		public float Dictfastcommentid
		{
			get { return _dictfastcommentid; }
			set { _isChanged |= (_dictfastcommentid != value); _dictfastcommentid = value; }
		}
			
		/// <summary>
		/// 使用模块
		/// </summary>		
		public string Moduleid
		{
			get { return _moduleid; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Moduleid", value, value.ToString());
				
				_isChanged |= (_moduleid != value); _moduleid = value;
			}
		}
			
		/// <summary>
		/// 助记码
		/// </summary>		
		public string Fastcode
		{
			get { return _fastcode; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Fastcode", value, value.ToString());
				
				_isChanged |= (_fastcode != value); _fastcode = value;
			}
		}
			
		/// <summary>
		/// 显示内容
		/// </summary>		
		public string Commentdesc
		{
			get { return _commentdesc; }
			set	
			{
				if( value!= null && value.Length > 2000)
					throw new ArgumentOutOfRangeException("Invalid value for Commentdesc", value, value.ToString());
				
				_isChanged |= (_commentdesc != value); _commentdesc = value;
			}
		}
			
		/// <summary>
		/// ALT/SHIFT/CTRL
		/// </summary>		
		public string Keymask
		{
			get { return _keymask; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Keymask", value, value.ToString());
				
				_isChanged |= (_keymask != value); _keymask = value;
			}
		}
			
		/// <summary>
		/// 热键
		/// </summary>		
		public string Hotkey
		{
			get { return _hotkey; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Hotkey", value, value.ToString());
				
				_isChanged |= (_hotkey != value); _hotkey = value;
			}
		}
			
		/// <summary>
		/// 物理实验室分组,对应表DictLibrary
		/// </summary>		
		public float Dictlabdeptid
		{
			get { return _dictlabdeptid; }
			set { _isChanged |= (_dictlabdeptid != value); _dictlabdeptid = value; }
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