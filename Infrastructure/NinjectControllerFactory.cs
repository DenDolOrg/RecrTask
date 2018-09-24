// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="NinjectControllerFactory.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using RekrutTask.Models.Abstract;
using RekrutTask.Models.Concrete;

namespace RekrutTask.Infrastructure
{
    /// <summary>
    /// Class for introduction Ninject DI container
    /// </summary>
    /// <seealso cref="System.Web.Mvc.DefaultControllerFactory" />
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Ninject kernel.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet">Available only inside class <see cref="NinjectControllerFactory" />.</permission>
        private IKernel ninjectKernel;
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectControllerFactory" /> class.
        /// </summary>
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        /// <summary>
        /// Извлекает экземпляр контроллера для заданного контекста запроса и типа контроллера.
        /// </summary>
        /// <param name="requestContext">Контекст HTTP-запроса, включающий в себя контекст HTTP и данные маршрута.</param>
        /// <param name="controllerType">Тип контроллера.</param>
        /// <returns>Экземпляр контроллера.</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
                return (IController)ninjectKernel.Get(controllerType);
            else
                return null;
        }
        /// <summary>
        /// Adds bindings to Ninject DI container
        /// </summary>
        private void AddBindings()
        {
            ninjectKernel.Bind<IFullInfoRepository>().To<FullInfoRepository>();
        }
    }
}