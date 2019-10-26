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
    public sealed class Dictresulttypedetail : DomainBase
	{
		#region Private Members
		private bool _isChanged;
		private bool _isDeleted;
		private float _dictresulttypedetailid; 
		private float _resulttypeid; 
		private string _fastcode; 
		private string _resultdesc; 
		private float _displayorder; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public Dictresulttypedetail()
		{
			_dictresulttypedetailid = 0; 
			_resulttypeid = 0; 
			_fastcode = null; 
			_resultdesc = null; 
			_displayorder = 0; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// ID,主键，自增长
		/// </summary>		
		public float Dictresulttypedetailid
		{
			get { return _dictresulttypedetailid; }
			set { _isChanged |= (_dictresulttypedetailid != value); _dictresulttypedetailid = value; }
		}
			
		/// <summary>
		/// 结果类型，来自表DictLibrary
		/// </summary>		
		public float Resulttypeid
		{
			get { return _resulttypeid; }
			set { _isChanged |= (_resulttypeid != value); _resulttypeid = value; }
		}
			
		/// <summary>
		/// 助记码
		/// </summary>		
		public string Fastcode
		{
			get { return _fastcode; }
			set	
			{
				if( value!= null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Fastcode", value, value.ToString());
				
				_isChanged |= (_fastcode != value); _fastcode = value;
			}
		}
			
		/// <summary>
		/// 描述
		/// </summary>		
		public string Resultdesc
		{
			get { return _resultdesc; }
			set	
			{
				if( value!= null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Resultdesc", value, value.ToString());
				
				_isChanged |= (_resultdesc != value); _resultdesc = value;
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
