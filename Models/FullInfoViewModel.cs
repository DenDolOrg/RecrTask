// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="FullInfoViewModel.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace RekrutTask.Models
{
    /// <summary>
    /// Class FullInfoViewModel. Container for view model parameters.
    /// </summary>
    public class FullInfoViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullInfoViewModel" /> class.
        /// </summary>
        public FullInfoViewModel()
        {
            PersonParamNames = new List<string>();
            FinancialStateParamNames = new List<string>();

            PersonParamNames.Add("Name");
            PersonParamNames.Add("Surname");
            PersonParamNames.Add("Agreement number");
            PersonParamNames.Add("PESEL");
            PersonParamNames.Add("Phone1");
            PersonParamNames.Add("Phone2");
            PersonParamNames.Add("Address");
            PersonParamNames.Add("Correspondence address");

            FinancialStateParamNames.Add("Outstanding Liabilities");
            FinancialStateParamNames.Add("Interests");
            FinancialStateParamNames.Add("Penalty Interests");
            FinancialStateParamNames.Add("Fees");
            FinancialStateParamNames.Add("Court Fees");
            FinancialStateParamNames.Add("Representation Court Fees");
            FinancialStateParamNames.Add("Vindication Costs");
            FinancialStateParamNames.Add("Representation Vindication Costs");

        }
        /// <summary>
        /// List of values of properties for <see cref="Person" /> and <see cref="Address" />
        /// </summary>
        /// <value>List of values, type of <see cref="IList{string}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IList<string> PersonParamValues { get; set; }
        /// <summary>
        /// List of names of properties for <see cref="Person" /> and <see cref="Address" />
        /// </summary>
        /// <value>List of names, type of <see cref="IList{string}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IList<string> PersonParamNames { get; set; }
        /// <summary>
        /// List of values of properties for <see cref="FinancialState" />
        /// </summary>
        /// <value>List of values, type of <see cref="IList{string}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IList<string> FinancialStateParamValues { get; set; }
        /// <summary>
        /// List of names of properties for <see cref="FinancialState" />
        /// </summary>
        /// <value>List of names, type of <see cref="IList{string}" /></value>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IList<string> FinancialStateParamNames { get; set; }
      
    }
}