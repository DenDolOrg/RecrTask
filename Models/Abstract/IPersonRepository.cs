// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="IPersonRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace RekrutTask.Models.Abstract
{
    /// <summary>
    /// Interface IPersonRepository. Contains <see cref="Person" /> list, and communication methods.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Contains person list from database;
        /// </summary>
        /// <value><see cref="Person" /> list, type of <see cref="IQueryable{Person}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        IQueryable<Person> PersonList { get; }
        /// <summary>
        /// Saves new person.
        /// </summary>
        /// <param name="person">Person to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        void SavePerson(Person person);
    }
}
