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
    public sealed class Qcmonthlycomment : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _qcmonthlycommentid; 
		private float _dictqclotid; 
		private float _dicttestitemid; 
		private DateTime _qcmonth; 
		private string _monthlycomment; 
		private float _commentby; 
		private DateTime _createdate; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Qcmonthlycomment()
		{
			_qcmonthlycommentid = 0; 
			_dictqclotid = 0; 
			_dicttestitemid = 0; 
			_qcmonth = new DateTime(); 
			_monthlycomment = null; 
			_commentby = 0; 
			_createdate = new DateTime(); 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自增长ID
		/// </summary>		
		public float Qcmonthlycommentid
		{
			get { return _qcmonthlycommentid; }
			set { _isChanged |= (_qcmonthlycommentid != value); _qcmonthlycommentid = value; }
		}
			
		/// <summary>
		/// 批号ID
		/// </summary>		
		public float Dictqclotid
		{
			get { return _dictqclotid; }
			set { _isChanged |= (_dictqclotid != value); _dictqclotid = value; }
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
		/// 备注月份，提取有用值：年及月份
		/// </summary>		
		public DateTime Qcmonth
		{
			get { return _qcmonth; }
			set { _isChanged |= (_qcmonth != value); _qcmonth = value; }
		}
			
		/// <summary>
		/// 备注
		/// </summary>		
		public string Monthlycomment
		{
			get { return _monthlycomment; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Monthlycomment", value, value.ToString());
				
				_isChanged |= (_monthlycomment != value); _monthlycomment = value;
			}
		}
			
		/// <summary>
		/// 备注人
		/// </summary>		
		public float Commentby
		{
			get { return _commentby; }
			set { _isChanged |= (_commentby != value); _commentby = value; }
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
