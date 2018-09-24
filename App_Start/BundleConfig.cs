// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="BundleConfig.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Optimization;

namespace RekrutTask
{

    /// <summary>
    /// Bundle configuration class.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Adding bundlings for JS and(or) CSS files. Invoked from Global.asax.
        /// </summary>
        /// <param name="bundles">Default bundle collection of <see cref="Bundle" /> from <see cref="BundleTable.Bundles" />.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/myScripts.min.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/*.css"));
        }
    }
}
