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
    public sealed class Qcprocesslog : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _qcprocesslogid; 
		private float _qcresultid; 
		private string _outrules; 
		private string _reason; 
		private string _processnote; 
		private string _processresult; 
		private float _processby; 
		private DateTime _processdate; 
		private float _auditby; 
		private DateTime _auditdate; 
		private string _status; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Qcprocesslog()
		{
			_qcprocesslogid = 0; 
			_qcresultid = 0; 
			_outrules = null; 
			_reason = null; 
			_processnote = null; 
			_processresult = null; 
			_processby = 0; 
			_processdate = new DateTime(); 
			_auditby = 0; 
			_auditdate = new DateTime(); 
			_status = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 自动生成主键
		/// </summary>		
		public float Qcprocesslogid
		{
			get { return _qcprocesslogid; }
			set { _isChanged |= (_qcprocesslogid != value); _qcprocesslogid = value; }
		}
			
		/// <summary>
		/// 关联质控结果表主键
		/// </summary>		
		public float Qcresultid
		{
			get { return _qcresultid; }
			set { _isChanged |= (_qcresultid != value); _qcresultid = value; }
		}
			
		/// <summary>
		/// 违反的质控规则清单
		/// </summary>		
		public string Outrules
		{
			get { return _outrules; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Outrules", value, value.ToString());
				
				_isChanged |= (_outrules != value); _outrules = value;
			}
		}
			
		/// <summary>
		/// 失控原因分析
		/// </summary>		
		public string Reason
		{
			get { return _reason; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Reason", value, value.ToString());
				
				_isChanged |= (_reason != value); _reason = value;
			}
		}
			
		/// <summary>
		/// 处理措施
		/// </summary>		
		public string Processnote
		{
			get { return _processnote; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Processnote", value, value.ToString());
				
				_isChanged |= (_processnote != value); _processnote = value;
			}
		}
			
		/// <summary>
		/// 处理的结果
		/// </summary>		
		public string Processresult
		{
			get { return _processresult; }
			set	
			{
				if( value!= null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Processresult", value, value.ToString());
				
				_isChanged |= (_processresult != value); _processresult = value;
			}
		}
			
		/// <summary>
		/// 处理人
		/// </summary>		
		public float Processby
		{
			get { return _processby; }
			set { _isChanged |= (_processby != value); _processby = value; }
		}
			
		/// <summary>
		/// 处理时间
		/// </summary>		
		public DateTime Processdate
		{
			get { return _processdate; }
			set { _isChanged |= (_processdate != value); _processdate = value; }
		}
			
		/// <summary>
		/// 审核人，主管
		/// </summary>		
		public float Auditby
		{
			get { return _auditby; }
			set { _isChanged |= (_auditby != value); _auditby = value; }
		}
			
		/// <summary>
		/// 审核时间
		/// </summary>		
		public DateTime Auditdate
		{
			get { return _auditdate; }
			set { _isChanged |= (_auditdate != value); _auditdate = value; }
		}
			
		/// <summary>
		/// 状态0 已处理, 1 已审核
		/// </summary>		
		public string Status
		{
			get { return _status; }
			set	
			{
				if( value!= null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				
				_isChanged |= (_status != value); _status = value;
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