namespace Core_MovieShelf.Interface.Domain
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IDisplayImage
    /// </summary>
    public interface IDisplayImage : IBaseDomain
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        string Path { get; set; }
    }
}
