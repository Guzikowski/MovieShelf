namespace Core_MovieShelf.Interface.Domain
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IBaseEntity
    /// </summary>
    public interface IBaseEntity : IBaseDomain
    {
        /// <summary>
        /// Gets or sets the DisplayImage.
        /// </summary>
        /// <value>The name.</value>
        IDisplayImage DisplayImage { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
    }
}
