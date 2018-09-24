// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="EFAgreementRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using RekrutTask.Models.Abstract;

namespace RekrutTask.Models.Concrete
{
    /// <summary>
    /// Class EFAgreementRepository. Contains <see cref="Agreement" /> list, and communication methods.
    /// </summary>
    /// <seealso cref="RekrutTask.Models.Abstract.IAgreementRepository" />
    public class EFAgreementRepository : IAgreementRepository
    {
        /// <summary>
        /// Database connection element.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="EFAgreementRepository" />.</permission>
        private RekrutDBEntities context = new RekrutDBEntities();
        /// <summary>
        /// Contains agreement list from database;
        /// </summary>
        /// <value><see cref="Agreement" /> list, type of <see cref="IQueryable{Agreement}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IQueryable<Agreement> AgreementList
        {
            get { return context.Agreements; }
        }
        /// <summary>
        /// Saves new agreement.
        /// </summary>
        /// <param name="agreement">Agreement to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public void SaveAgreement(Agreement agreement)
        {
            context.Agreements.Add(agreement);
            context.SaveChanges();
        }
    }
}