using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
	/// <summary>
	/// Core_MovieShelf.Interface.Domain.IBorrower
	/// </summary>
	[DataContract]
	public class BorrowerContract : BaseEntityContract, IBorrowerContract
	{
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string Phone { get; set; }
	}
}
