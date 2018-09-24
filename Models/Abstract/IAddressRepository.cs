// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="IAddressRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace RekrutTask.Models.Abstract
{
    /// <summary>
    /// Interface IAddressRepository. Contains <see cref="Address" /> list, and communication methods.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Contains address list from database;
        /// </summary>
        /// <value><see cref="Address" /> list, type of <see cref="IQueryable{Address}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        IQueryable<Address> AddressList { get; }
        /// <summary>
        /// Saves new address.
        /// </summary>
        /// <param name="address">Address to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        void SaveAddress(Address address);
    }
}
