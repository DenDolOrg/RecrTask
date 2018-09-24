// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="IAgreementRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace RekrutTask.Models.Abstract
{
    /// <summary>
    /// Interface IAgreementRepository. Contains <see cref="Agreement" /> list, and communication methods.
    /// </summary>
    public interface IAgreementRepository
    {
        /// <summary>
        /// Contains agreement list from database;
        /// </summary>
        /// <value><see cref="Agreement" /> list, type of <see cref="IQueryable{Agreement}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        IQueryable<Agreement> AgreementList { get; }
        /// <summary>
        /// Saves new agreement.
        /// </summary>
        /// <param name="agreement">Agreement to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        void SaveAgreement(Agreement agreement);
    }
}
