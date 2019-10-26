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
    public sealed class Dictsecurityresource : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictsecurityresourceid; 
		private string _resourcecode; 
		private string _resourcetext; 
		private float _resourcetier; 
		private float _displayorder; 
		private string _parentid; 
		private string _shortcutkey; 
		private string _keymask; 
		private string _iconkey; 
		private string _resourcetype; 
		private string _active; 
		private string _toolbutton; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictsecurityresource()
		{
			_dictsecurityresourceid = 0; 
			_resourcecode = null; 
			_resourcetext = null; 
			_resourcetier = 0; 
			_displayorder = 0; 
			_parentid = null; 
			_shortcutkey = null; 
			_keymask = null; 
			_iconkey = null; 
			_resourcetype = null; 
			_active = null; 
			_toolbutton = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 自动编码
		/// </summary>		
		public float Dictsecurityresourceid
		{
			get { return _dictsecurityresourceid; }
			set { _isChanged |= (_dictsecurityresourceid != value); _dictsecurityresourceid = value; }
		}
			
		/// <summary>
		/// 权限资源编码
		/// </summary>		
		public string Resourcecode
		{
			get { return _resourcecode; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Resourcecode", value, value.ToString());
				
				_isChanged |= (_resourcecode != value); _resourcecode = value;
			}
		}
			
		/// <summary>
		/// 权限资源标题
		/// </summary>		
		public string Resourcetext
		{
			get { return _resourcetext; }
			set	
			{
				if( value!= null && value.Length > 256)
					throw new ArgumentOutOfRangeException("Invalid value for Resourcetext", value, value.ToString());
				
				_isChanged |= (_resourcetext != value); _resourcetext = value;
			}
		}
			
		/// <summary>
		/// 层数
		/// </summary>		
		public float Resourcetier
		{
			get { return _resourcetier; }
			set { _isChanged |= (_resourcetier != value); _resourcetier = value; }
		}
			
		/// <summary>
		/// 排序
		/// </summary>		
		public float Displayorder
		{
			get { return _displayorder; }
			set { _isChanged |= (_displayorder != value); _displayorder = value; }
		}
			
		/// <summary>
		/// 父节点编码
		/// </summary>		
		public string Parentid
		{
			get { return _parentid; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Parentid", value, value.ToString());
				
				_isChanged |= (_parentid != value); _parentid = value;
			}
		}
			
		/// <summary>
		/// 快捷键
		/// </summary>		
		public string Shortcutkey
		{
			get { return _shortcutkey; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Shortcutkey", value, value.ToString());
				
				_isChanged |= (_shortcutkey != value); _shortcutkey = value;
			}
		}
			
		/// <summary>
		/// 快捷键掩码: Ctrl ,Alt, Shift
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
		/// 图标关键字
		/// </summary>		
		public string Iconkey
		{
			get { return _iconkey; }
			set	
			{
				if( value!= null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Iconkey", value, value.ToString());
				
				_isChanged |= (_iconkey != value); _iconkey = value;
			}
		}
			
		/// <summary>
		/// 类型： 0菜单，1功能点，2权限点
		/// </summary>		
		public string Resourcetype
		{
			get { return _resourcetype; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Resourcetype", value, value.ToString());
				
				_isChanged |= (_resourcetype != value); _resourcetype = value;
			}
		}
			
		/// <summary>
		/// 是否可用
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
		/// 是否在工具栏上显示0-否  1-是
		/// </summary>		
		public string Toolbutton
		{
			get { return _toolbutton; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Toolbutton", value, value.ToString());
				
				_isChanged |= (_toolbutton != value); _toolbutton = value;
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
