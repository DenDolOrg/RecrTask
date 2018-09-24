// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="RouteConfig.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Mvc;
using System.Web.Routing;

namespace RekrutTask
{
    /// <summary>
    /// Route configuration class.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Routes registration. Invoked from Global.asax&gt;.
        /// </summary>
        /// <param name="routes">Empty routes collection from <see cref="RouteTable.Routes" />.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FullInfo",
                url: "People/Person_info/{fullName}",
                defaults: new {controller = "Person", action = "PersonFullInfo", fullName = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ErrorList",
                url: "Error_list",
                defaults: new { controller = "Person", action = "UploadErrors"}
            );

            routes.MapRoute(
                name: "PersonList",
                url: "People",
                defaults: new { controller = "Person", action = "PersonList" }
            );

            routes.MapRoute(
                name: "FileChoose",
                url: "File_choose",
                defaults: new { controller = "Excel", action = "FileChoose"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

        }
    }
}
