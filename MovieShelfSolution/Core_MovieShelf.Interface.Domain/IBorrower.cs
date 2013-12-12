namespace Core_MovieShelf.Interface.Domain
{
	/// <summary>
	/// Core_MovieShelf.Interface.Domain.IBorrower
	/// </summary>
	public interface IBorrower : IBaseEntity
	{
		string Email { get; set; }
		string Phone { get; set; }
	}
}
