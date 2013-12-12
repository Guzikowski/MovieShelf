using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IDisplayImage
    /// </summary>
    [DataContract]
    public class DisplayImageContract : BaseDomainContract, IDisplayImageContract
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [DataMember]
        public string Path { get; set; }
    }
}
