// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="IFinancialStateRepository.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace RekrutTask.Models.Abstract
{
    /// <summary>
    /// Interface IFinancialStateRepository. Contains <see cref="FinancialState" /> list, and communication methods.
    /// </summary>
    public interface IFinancialStateRepository
    {
        /// <summary>
        /// Contains financial state list from database;
        /// </summary>
        /// <value><see cref="FinancialState" /> list, type of <see cref="IQueryable{FinancialState}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        IQueryable<FinancialState> FinancialStateList { get; }
        /// <summary>
        /// Saves new financial state.
        /// </summary>
        /// <param name="financialState">Financial state to save.</param>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        void SaveFinancialState(FinancialState financialState);
    }
}
