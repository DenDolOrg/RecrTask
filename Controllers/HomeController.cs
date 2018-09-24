// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-06-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="HomeController.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Mvc;

namespace RekrutTask.Controllers
{
    /// <summary>
    /// Controller for home page
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Action of <see cref="HomeController" />.
        /// Redirects to home page.
        /// </summary>
        /// <returns>Returns view, with the name of "<c>Views/Person/PersonFull info.cshtml</c>"</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}