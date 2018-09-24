// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="EFAddressRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using RekrutTask.Models.Abstract;

namespace RekrutTask.Models.Concrete
{
    /// <summary>
    /// Class EFAddressRepository. Contains <see cref="Address" /> list, and communication methods.
    /// </summary>
    /// <seealso cref="RekrutTask.Models.Abstract.IAddressRepository" />
    public class EFAddressRepository : IAddressRepository
    {
        /// <summary>
        /// Database connection element.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="EFAddressRepository" />.</permission>
        private RekrutDBEntities context = new RekrutDBEntities();
        /// <summary>
        /// Contains address list from database;
        /// </summary>
        /// <value><see cref="Address" /> list, type of <see cref="IQueryable{Address}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IQueryable<Address> AddressList
        {
            get { return context.Addresses; }
        }
        /// <summary>
        /// Saves new address.
        /// </summary>
        /// <param name="address">Address to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public void SaveAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
        }
    }
}