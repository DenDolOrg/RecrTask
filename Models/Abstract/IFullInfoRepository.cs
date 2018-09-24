// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="IFullInfoRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RekrutTask.Models.Abstract
{
    /// <summary>
    /// Interface IFullInfoRepository. Contains all other repositories.
    /// </summary>
    public interface IFullInfoRepository
    {
        /// <summary>
        /// Gets the address repository.
        /// </summary>
        /// <value>Address repository, type of <see cref="IAddressRepository" /></value>
        IAddressRepository AddressRepository { get; }
        /// <summary>
        /// Gets the agreement repository.
        /// </summary>
        /// <value>Agreement repository, type of <see cref="IAgreementRepository" /></value>
        IAgreementRepository AgreementRepository { get; }
        /// <summary>
        /// Gets the financial state repository.
        /// </summary>
        /// <value>Financial state repository, type of <see cref="IFinancialStateRepository" /></value>
        IFinancialStateRepository FinancialStateRepository { get; }
        /// <summary>
        /// Gets the person repository.
        /// </summary>
        /// <value>Person repository, type of <see cref="IPersonRepository" /></value>
        IPersonRepository PersonRepository { get; }
    }
}
