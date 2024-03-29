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
    public sealed class Dictorganismgroup : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictorganismgroupid; 
		private string _organismgroupcode; 
		private string _organismgroupname; 
		private float _dictantibioticgroupid; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictorganismgroup()
		{
			_dictorganismgroupid = 0; 
			_organismgroupcode = null; 
			_organismgroupname = null; 
			_dictantibioticgroupid = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 主键，自动ID
		/// </summary>		
		public float Dictorganismgroupid
		{
			get { return _dictorganismgroupid; }
			set { _isChanged |= (_dictorganismgroupid != value); _dictorganismgroupid = value; }
		}
			
		/// <summary>
		/// 细菌分组代码
		/// </summary>		
		public string Organismgroupcode
		{
			get { return _organismgroupcode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Organismgroupcode", value, value.ToString());
				
				_isChanged |= (_organismgroupcode != value); _organismgroupcode = value;
			}
		}
			
		/// <summary>
		/// 细菌分组名称
		/// </summary>		
		public string Organismgroupname
		{
			get { return _organismgroupname; }
			set	
			{
				if( value!= null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Organismgroupname", value, value.ToString());
				
				_isChanged |= (_organismgroupname != value); _organismgroupname = value;
			}
		}
			
		/// <summary>
		/// 抗生素分组
		/// </summary>		
		public float Dictantibioticgroupid
		{
			get { return _dictantibioticgroupid; }
			set { _isChanged |= (_dictantibioticgroupid != value); _dictantibioticgroupid = value; }
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
