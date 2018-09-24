// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="FilterConfig.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Mvc;

namespace RekrutTask
{
    /// <summary>
    /// Filter configuration class.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Global filters registration. Invoked from Global.asax.
        /// </summary>
        /// <param name="filters">Standard basic filters from <see cref="GlobalFilters.Filters" /></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
