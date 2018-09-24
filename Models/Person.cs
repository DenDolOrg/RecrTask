// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Δενθρ
// Created          : 08-05-2018
//
// Last Modified By : Δενθρ
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="Person.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RekrutTask.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class Person. Contains properties for compliance to database table Person.
    /// </summary>
    public partial class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Agreements = new HashSet<Agreement>();
        }

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        /// <value>Identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        /// <value>First name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets second name.
        /// </summary>
        /// <value>Second name.</value>
        public string SecondName { get; set; }
        /// <summary>
        /// Gets or sets surname.
        /// </summary>
        /// <value>Surname.</value>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets national identification number.
        /// </summary>
        /// <value>National identification number.</value>
        public string NationalIdentificationNumber { get; set; }
        /// <summary>
        /// Gets or sets address identifier.
        /// </summary>
        /// <value>Address identifier.</value>
        public int AddressId { get; set; }
        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        /// <value>Phone number.</value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets phone number 2.
        /// </summary>
        /// <value>Phone number 2.</value>
        public string PhoneNumber2 { get; set; }
        /// <summary>
        /// Gets or sets address.
        /// </summary>
        /// <value>Address.</value>
        public virtual Address Address { get; set; }
        /// <summary>
        /// Gets or sets agreements collection.
        /// </summary>
        /// <value>Agreements.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agreement> Agreements { get; set; }
    }
}