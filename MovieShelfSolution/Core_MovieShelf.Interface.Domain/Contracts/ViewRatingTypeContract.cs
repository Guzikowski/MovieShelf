using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IViewRating
    /// </summary>
    [DataContract]
    public class ViewRatingTypeContract : BaseLookupContract, IViewRatingTypeContract
    {
    }
}
