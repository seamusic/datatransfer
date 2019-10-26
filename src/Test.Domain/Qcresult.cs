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
    public sealed class Qcresult : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _qcresultid; 
		private float _dicttestitemid; 
		private float _dictqclotid; 
		private DateTime _resultdate; 
		private string _result; 
		private string _resultcomment; 
		private string _resulttype; 
		private string _status; 
		private string _breakrule; 
		private string _rulestatus; 
		private float _operateby; 
		private float _authorizeby; 
		private DateTime _authorizedate; 
		private DateTime _createdate; 
		private string _fixcomment; 
		private string _isaccept; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Qcresult()
		{
			_qcresultid = 0; 
			_dicttestitemid = 0; 
			_dictqclotid = 0; 
			_resultdate = new DateTime(); 
			_result = null; 
			_resultcomment = null; 
			_resulttype = null; 
			_status = null; 
			_breakrule = null; 
			_rulestatus = null; 
			_operateby = 0; 
			_authorizeby = 0; 
			_authorizedate = new DateTime(); 
			_createdate = new DateTime(); 
			_fixcomment = null; 
			_isaccept = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自动ID
		/// </summary>		
		public float Qcresultid
		{
			get { return _qcresultid; }
			set { _isChanged |= (_qcresultid != value); _qcresultid = value; }
		}
			
		/// <summary>
		/// 测试项主键
		/// </summary>		
		public float Dicttestitemid
		{
			get { return _dicttestitemid; }
			set { _isChanged |= (_dicttestitemid != value); _dicttestitemid = value; }
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
		/// QC结果录入日期
		/// </summary>		
		public DateTime Resultdate
		{
			get { return _resultdate; }
			set { _isChanged |= (_resultdate != value); _resultdate = value; }
		}
			
		/// <summary>
		/// 结果
		/// </summary>		
		public string Result
		{
			get { return _result; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Result", value, value.ToString());
				
				_isChanged |= (_result != value); _result = value;
			}
		}
			
		/// <summary>
		/// 结果备注
		/// </summary>		
		public string Resultcomment
		{
			get { return _resultcomment; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Resultcomment", value, value.ToString());
				
				_isChanged |= (_resultcomment != value); _resultcomment = value;
			}
		}
			
		/// <summary>
		/// 0-仪器  1-手工录入
		/// </summary>		
		public string Resulttype
		{
			get { return _resulttype; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Resulttype", value, value.ToString());
				
				_isChanged |= (_resulttype != value); _resulttype = value;
			}
		}
			
		/// <summary>
		/// 状态  0-未审核  1-已审核
		/// </summary>		
		public string Status
		{
			get { return _status; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				
				_isChanged |= (_status != value); _status = value;
			}
		}
			
		/// <summary>
		/// 是否在控  0-在控 1-失控
		/// </summary>		
		public string Breakrule
		{
			get { return _breakrule; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Breakrule", value, value.ToString());
				
				_isChanged |= (_breakrule != value); _breakrule = value;
			}
		}
			
		/// <summary>
		/// 质控规则说明：在控/失控(XX)
		/// </summary>		
		public string Rulestatus
		{
			get { return _rulestatus; }
			set	
			{
				if( value!= null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Rulestatus", value, value.ToString());
				
				_isChanged |= (_rulestatus != value); _rulestatus = value;
			}
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
		/// 审核人
		/// </summary>		
		public float Authorizeby
		{
			get { return _authorizeby; }
			set { _isChanged |= (_authorizeby != value); _authorizeby = value; }
		}
			
		/// <summary>
		/// 审核日期
		/// </summary>		
		public DateTime Authorizedate
		{
			get { return _authorizedate; }
			set { _isChanged |= (_authorizedate != value); _authorizedate = value; }
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
		/// 解决失控问题的注解
		/// </summary>		
		public string Fixcomment
		{
			get { return _fixcomment; }
			set	
			{
				if( value!= null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Fixcomment", value, value.ToString());
				
				_isChanged |= (_fixcomment != value); _fixcomment = value;
			}
		}
			
		/// <summary>
		/// 结果是拒绝还是接受  1-接受  0-拒绝
		/// </summary>		
		public string Isaccept
		{
			get { return _isaccept; }
			set	
			{
				if( value!= null && value.Length > 1)
					throw new ArgumentOutOfRangeException("Invalid value for Isaccept", value, value.ToString());
				
				_isChanged |= (_isaccept != value); _isaccept = value;
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