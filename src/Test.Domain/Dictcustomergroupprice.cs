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
    public sealed class Dictcustomergroupprice : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictcustomergrouppriceid; 
		private float _dictcustomergroupid; 
		private float _dicttestitemid; 
		private float _groupprice; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictcustomergroupprice()
		{
			_dictcustomergrouppriceid = 0; 
			_dictcustomergroupid = 0; 
			_dicttestitemid = 0; 
			_groupprice = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，序列
		/// </summary>		
		public float Dictcustomergrouppriceid
		{
			get { return _dictcustomergrouppriceid; }
			set { _isChanged |= (_dictcustomergrouppriceid != value); _dictcustomergrouppriceid = value; }
		}
			
		/// <summary>
		/// 客户标准价分组
		/// </summary>		
		public float Dictcustomergroupid
		{
			get { return _dictcustomergroupid; }
			set { _isChanged |= (_dictcustomergroupid != value); _dictcustomergroupid = value; }
		}
			
		/// <summary>
		/// 项目ID
		/// </summary>		
		public float Dicttestitemid
		{
			get { return _dicttestitemid; }
			set { _isChanged |= (_dicttestitemid != value); _dicttestitemid = value; }
		}
			
		/// <summary>
		/// 不同区域的达安标准价
		/// </summary>		
		public float Groupprice
		{
			get { return _groupprice; }
			set { _isChanged |= (_groupprice != value); _groupprice = value; }
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