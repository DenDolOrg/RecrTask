// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="EFPersonRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using RekrutTask.Models.Abstract;

namespace RekrutTask.Models.Concrete
{
    /// <summary>
    /// Class EFPersonRepository. Contains <see cref="Person" /> list, and communication methods.
    /// </summary>
    /// <seealso cref="RekrutTask.Models.Abstract.IPersonRepository" />
    public class EFPersonRepository :IPersonRepository
    {
        /// <summary>
        /// Database connection element.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="EFPersonRepository" />.</permission>
        private RekrutDBEntities context = new RekrutDBEntities();
        /// <summary>
        /// Contains person list from database;
        /// </summary>
        /// <value><see cref="Person" /> list, type of <see cref="IQueryable{Person}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IQueryable<Person> PersonList
        {
            get { return context.People; }
        }
        /// <summary>
        /// Saves new person.
        /// </summary>
        /// <param name="person">Person to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public void SavePerson(Person person)
        {
            context.People.Add(person);
            context.SaveChanges();
        }
    }
}