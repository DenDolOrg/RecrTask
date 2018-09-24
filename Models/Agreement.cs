// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Δενθρ
// Created          : 08-05-2018
//
// Last Modified By : Δενθρ
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="Agreement.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RekrutTask.Models
{
    using System;

    /// <summary>
    /// Class Agreement. Contains properties for compliance to database table Agreement.
    /// </summary>
    public partial class Agreement
    {
        /// <summary>
        /// Gets or sets agreement identifier.
        /// </summary>
        /// <value>Identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets number.
        /// </summary>
        /// <value>Number.</value>
        public string Number { get; set; }
        /// <summary>
        /// Gets or sets person identifier.
        /// </summary>
        /// <value>Person identifier.</value>
        public Nullable<int> PersonId { get; set; }
        /// <summary>
        /// Gets or sets financial state identifier.
        /// </summary>
        /// <value>Financial state identifier.</value>
        public Nullable<int> FinancialStateId { get; set; }
        /// <summary>
        /// Gets or sets financial state.
        /// </summary>
        /// <value>Financial state.</value>
        public virtual FinancialState FinancialState { get; set; }
        /// <summary>
        /// Gets or sets person.
        /// </summary>
        /// <value>Person.</value>
        public virtual Person Person { get; set; }
    }
}
