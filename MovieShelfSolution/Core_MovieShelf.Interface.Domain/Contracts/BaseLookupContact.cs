using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IBaseLookup
    /// </summary>
    [DataContract]
    public class BaseLookupContract : BaseDomainContract,  IBaseLookupContract
    {
        /// <summary>
        /// Gets or sets the DisplayImage.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public DisplayImageContract DisplayImage { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; set; }
        
    }
}
