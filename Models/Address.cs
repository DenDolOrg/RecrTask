// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Δενθρ
// Created          : 08-05-2018
//
// Last Modified By : Δενθρ
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="Address.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RekrutTask.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class Address. Contains properties for compliance to database table Address.
    /// </summary>
    public partial class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.People = new HashSet<Person>();
        }

        /// <summary>
        /// Gets or sets address identifier.
        /// </summary>
        /// <value>Identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets name of the street.
        /// </summary>
        /// <value>Name of the street.</value>
        public string StreetName { get; set; }
        /// <summary>
        /// Gets or sets street number.
        /// </summary>
        /// <value>Street number.</value>
        public string StreetNumber { get; set; }
        /// <summary>
        /// Gets or sets flat number.
        /// </summary>
        /// <value>Flat number.</value>
        public string FlatNumber { get; set; }
        /// <summary>
        /// Gets or sets postal code.
        /// </summary>
        /// <value>Post code.</value>
        public string PostCode { get; set; }
        /// <summary>
        /// Gets or sets post office city.
        /// </summary>
        /// <value>Post office city.</value>
        public string PostOfficeCity { get; set; }
        /// <summary>
        /// Gets or sets name of the correspondence street.
        /// </summary>
        /// <value>Name of the correspondence street.</value>
        public string CorrespondenceStreetName { get; set; }
        /// <summary>
        /// Gets or sets correspondence street number.
        /// </summary>
        /// <value>Correspondence street number.</value>
        public string CorrespondenceStreetNumber { get; set; }
        /// <summary>
        /// Gets or sets correspondence flat number.
        /// </summary>
        /// <value>Correspondence flat number.</value>
        public string CorrespondenceFlatNumber { get; set; }
        /// <summary>
        /// Gets or sets correspondence postal code.
        /// </summary>
        /// <value>Correspondence postal code.</value>
        public string CorrespondencePostCode { get; set; }
        /// <summary>
        /// Gets or sets correspondence post office city.
        /// </summary>
        /// <value>Correspondence post office city.</value>
        public string CorrespondencePostOfficeCity { get; set; }
        /// <summary>
        /// Gets or sets person collection.
        /// </summary>
        /// <value>People.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }
    }
}
