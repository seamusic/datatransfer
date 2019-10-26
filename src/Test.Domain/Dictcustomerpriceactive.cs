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
    public sealed class Dictcustomerpriceactive : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictcustomerpriceactiveid; 
		private float _dicttestitemid; 
		private float _dictcustomergroupid; 
		private float _originalprice; 
		private float _newprice; 
		private DateTime _activedate; 
		private DateTime _operatedate; 
		private float _operateby; 
		private float _executed; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictcustomerpriceactive()
		{
			_dictcustomerpriceactiveid = 0; 
			_dicttestitemid = 0; 
			_dictcustomergroupid = 0; 
			_originalprice = 0; 
			_newprice = 0; 
			_activedate = new DateTime(); 
			_operatedate = new DateTime(); 
			_operateby = 0; 
			_executed = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自增长
		/// </summary>		
		public float Dictcustomerpriceactiveid
		{
			get { return _dictcustomerpriceactiveid; }
			set { _isChanged |= (_dictcustomerpriceactiveid != value); _dictcustomerpriceactiveid = value; }
		}
			
		/// <summary>
		/// 测试项ID
		/// </summary>		
		public float Dicttestitemid
		{
			get { return _dicttestitemid; }
			set { _isChanged |= (_dicttestitemid != value); _dicttestitemid = value; }
		}
			
		/// <summary>
		/// 客户区域分组ID
		/// </summary>		
		public float Dictcustomergroupid
		{
			get { return _dictcustomergroupid; }
			set { _isChanged |= (_dictcustomergroupid != value); _dictcustomergroupid = value; }
		}
			
		/// <summary>
		/// 原始价钱
		/// </summary>		
		public float Originalprice
		{
			get { return _originalprice; }
			set { _isChanged |= (_originalprice != value); _originalprice = value; }
		}
			
		/// <summary>
		/// 新价钱
		/// </summary>		
		public float Newprice
		{
			get { return _newprice; }
			set { _isChanged |= (_newprice != value); _newprice = value; }
		}
			
		/// <summary>
		/// 激活日期
		/// </summary>		
		public DateTime Activedate
		{
			get { return _activedate; }
			set { _isChanged |= (_activedate != value); _activedate = value; }
		}
			
		/// <summary>
		/// 操作日期
		/// </summary>		
		public DateTime Operatedate
		{
			get { return _operatedate; }
			set { _isChanged |= (_operatedate != value); _operatedate = value; }
		}
			
		/// <summary>
		/// 操作者
		/// </summary>		
		public float Operateby
		{
			get { return _operateby; }
			set { _isChanged |= (_operateby != value); _operateby = value; }
		}
			
		/// <summary>
		/// 语句执行标记 1 执行 0 未执行
		/// </summary>		
		public float Executed
		{
			get { return _executed; }
			set { _isChanged |= (_executed != value); _executed = value; }
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