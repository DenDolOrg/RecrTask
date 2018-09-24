// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="FullInfoRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using RekrutTask.Models.Abstract;

namespace RekrutTask.Models.Concrete
{
    /// <summary>
    /// Class FullInfoRepository. Contains all other repositories.
    /// </summary>
    /// <seealso cref="RekrutTask.Models.Abstract.IFullInfoRepository" />
    public class FullInfoRepository : IFullInfoRepository
    {
        /// <summary>
        /// Gets the address repository.
        /// </summary>
        /// <value>Address repository, type of <see cref="IAddressRepository" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IAddressRepository AddressRepository
        {
            get { return new EFAddressRepository(); }
        }
        /// <summary>
        /// Gets the agreement repository.
        /// </summary>
        /// <value>Agreement repository, type of <see cref="IAgreementRepository" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IAgreementRepository AgreementRepository
        {
            get { return new EFAgreementRepository(); }
        }
        /// <summary>
        /// Gets the financial state repository.
        /// </summary>
        /// <value>Financial state repository, type of <see cref="IFinancialStateRepository" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IFinancialStateRepository FinancialStateRepository
        {
            get { return new EFFinancialStateRepository(); }
        }
        /// <summary>
        /// Gets the person repository.
        /// </summary>
        /// <value>Person repository, type of <see cref="IPersonRepository" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IPersonRepository PersonRepository
        {
            get { return new EFPersonRepository(); }
        }
    }
}