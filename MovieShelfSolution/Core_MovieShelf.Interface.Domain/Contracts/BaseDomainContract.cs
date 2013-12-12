using System;
using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IBaseDomain
    /// </summary>
    [DataContract]
    public class BaseDomainContract : IBaseDomainContract
    {
        [DataMember]
        public bool IsNew { get; set; }
        [DataMember]
        public bool IsValid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is removed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is removed; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsRemoved { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has changed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has changed; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool HasChanged { get; set; }
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the Last Login that Modified the record.
        /// </summary>
        /// <value>The Last Modified Person.</value>
        [DataMember]
        public string LastModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets the Last date a successful modification occurred.
        /// </summary>
        /// <value>The Last successful modification date.</value>
        [DataMember]
        public DateTime LastModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        [DataMember]
        public byte[] Timestamp { get; set; }

        [DataMember]
        public DomainStatusContract DomainStatus { get; set; }
    }
}
