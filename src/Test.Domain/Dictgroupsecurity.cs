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
    public sealed class Dictgroupsecurity : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictgroupsecurityid; 
		private float _dictusergroupid; 
		private float _dictsecurityresourceid; 
		private string _ispermit; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictgroupsecurity()
		{
			_dictgroupsecurityid = 0; 
			_dictusergroupid = 0; 
			_dictsecurityresourceid = 0; 
			_ispermit = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自动ID
		/// </summary>		
		public float Dictgroupsecurityid
		{
			get { return _dictgroupsecurityid; }
			set { _isChanged |= (_dictgroupsecurityid != value); _dictgroupsecurityid = value; }
		}
			
		/// <summary>
		/// 关联权限组表的权限组代码
		/// </summary>		
		public float Dictusergroupid
		{
			get { return _dictusergroupid; }
			set { _isChanged |= (_dictusergroupid != value); _dictusergroupid = value; }
		}
			
		/// <summary>
		/// 关联权限资源表的权限资源编码
		/// </summary>		
		public float Dictsecurityresourceid
		{
			get { return _dictsecurityresourceid; }
			set { _isChanged |= (_dictsecurityresourceid != value); _dictsecurityresourceid = value; }
		}
			
		/// <summary>
		/// 是否有权限
		/// </summary>		
		public string Ispermit
		{
			get { return _ispermit; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Ispermit", value, value.ToString());
				
				_isChanged |= (_ispermit != value); _ispermit = value;
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
