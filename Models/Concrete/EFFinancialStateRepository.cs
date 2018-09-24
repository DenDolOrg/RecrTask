// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="EFFinancialStateRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using RekrutTask.Models.Abstract;

namespace RekrutTask.Models.Concrete
{
    /// <summary>
    /// Class EFFinancialStateRepository. Contains <see cref="FinancialState" /> list, and communication methods.
    /// </summary>
    /// <seealso cref="RekrutTask.Models.Abstract.IFinancialStateRepository" />
    public class EFFinancialStateRepository : IFinancialStateRepository
    {
        /// <summary>
        /// Database connection element.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="EFFinancialStateRepository" />.</permission>
        private RekrutDBEntities context = new RekrutDBEntities();
        /// <summary>
        /// Contains financial state list from database;
        /// </summary>
        /// <value><see cref="FinancialState" /> list, type of <see cref="IQueryable{FinancialState}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IQueryable<FinancialState> FinancialStateList
        {
            get { return context.FinancialStates; }
        }
        /// <summary>
        /// Saves new financial state.
        /// </summary>
        /// <param name="financialState">Financial state to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public void SaveFinancialState(FinancialState financialState)
        {
            context.FinancialStates.Add(financialState);
            context.SaveChanges();
        }
    }
}