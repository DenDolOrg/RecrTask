// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Δενθρ
// Created          : 08-05-2018
//
// Last Modified By : Δενθρ
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="FinancialState.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RekrutTask.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class FinancialState. Contains properties for compliance to database table FinancialState.
    /// </summary>
    public partial class FinancialState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialState" /> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinancialState()
        {
            this.Agreements = new HashSet<Agreement>();
        }

        /// <summary>
        /// Gets or sets agreement identifier.
        /// </summary>
        /// <value>Identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets outstanding liabilities.
        /// </summary>
        /// <value>Outstanding liabilities.</value>
        public decimal OutstandingLiabilities { get; set; }
        /// <summary>
        /// Gets or sets interests.
        /// </summary>
        /// <value>Interests.</value>
        public decimal Interests { get; set; }
        /// <summary>
        /// Gets or sets penalty interests.
        /// </summary>
        /// <value>Penalty interests.</value>
        public decimal PenaltyInterests { get; set; }
        /// <summary>
        /// Gets or sets fees.
        /// </summary>
        /// <value>Fees.</value>
        public Nullable<decimal> Fees { get; set; }
        /// <summary>
        /// Gets or sets court fees.
        /// </summary>
        /// <value>Court fees.</value>
        public decimal CourtFees { get; set; }
        /// <summary>
        /// Gets or sets representation court fees.
        /// </summary>
        /// <value>Representation court fees.</value>
        public Nullable<decimal> RepresentationCourtFees { get; set; }
        /// <summary>
        /// Gets or sets vindication costs.
        /// </summary>
        /// <value>Vindication costs.</value>
        public Nullable<decimal> VindicationCosts { get; set; }
        /// <summary>
        /// Gets or set representation vindication costs.
        /// </summary>
        /// <value>Representation vindication costs.</value>
        public Nullable<decimal> RepresentationVindicationCosts { get; set; }
        /// <summary>
        /// Gets or sets agreements collection.
        /// </summary>
        /// <value>Agreements.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agreement> Agreements { get; set; }
    }
}
