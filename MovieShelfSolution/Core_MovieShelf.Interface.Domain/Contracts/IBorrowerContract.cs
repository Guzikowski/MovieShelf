namespace Core_MovieShelf.Interface.Domain.Contracts
{
	/// <summary>
	/// Core_MovieShelf.Interface.Domain.IBorrower
	/// </summary>
	public interface IBorrowerContract : IBaseEntityContract
	{
		string Email { get; set; }
		string Phone { get; set; }
	}
}
