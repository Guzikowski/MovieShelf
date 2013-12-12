namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IBaseLookup
    /// </summary>
    public interface IBaseLookupContract : IBaseDomainContract
    {
        /// <summary>
        /// Gets or sets the DisplayImage.
        /// </summary>
        /// <value>The name.</value>
        DisplayImageContract DisplayImage { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
        
    }
}
