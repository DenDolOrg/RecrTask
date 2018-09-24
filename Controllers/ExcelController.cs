// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="ExcelController.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RekrutTask.Models.Abstract;
using RekrutTask.Infrastructure;
using RekrutTask.Models;
using System.IO;

namespace RekrutTask.Controllers
{
    /// <summary>
    /// Controller for uploading and handling Excel file.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ExcelController : Controller
    {
        /// <summary>
        /// Database data storage, type of <see cref="IFullInfoRepository" />.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelController" />.</permission>
        private IFullInfoRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelController" /> class.
        /// </summary>
        /// <param name="repository">Received database data</param>
        public ExcelController(IFullInfoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Action of <see cref="ExcelController" />.
        /// Redirects to the appropriate page, where user can choose Excel file for upload.
        /// </summary>
        /// <returns>Returns a view with the name of "<c>Views/Excel/FileChoose.cshtml</c>".</returns>
        public ViewResult FileChoose()
        {
            return View();
        }
        /// <summary>
        /// Action of <see cref="ExcelController" />.
        /// <list type="destination"><item><term>Receives chosen by user Excel file.</term></item><item><term>Writes to the database suitable elements.</term></item><item><term>Creates the list of unsuitable elements.</term></item><item><term>Creates <see cref="ServiceWSDL.Person" /> for every <see cref="Person" /> in database and invokes <c>DoImport()</c> function for each of them</term></item><item><term>Depending on writing to database result, redirects on the appropriate page.</term></item></list>
        /// </summary>
        /// <returns><list type="results">
        ///   <listheader>
        ///     <term>Context</term>
        ///     <term>Сause</term>
        ///   </listheader>
        ///   <item>
        ///     <term>Failed load file page (<c>Views/Excel/InvalidExcelFile.cshtml</c>).</term>
        ///     <term>Chosen Excel file contains wrong data to upload.</term>
        ///   </item>
        ///   <item>
        ///     <term>Error list page (<c>Views/Person/UploadErrors.cshtml</c>).</term>
        ///     <term>One or more <see cref="Person" /> from Excel file has invalid parameter <see cref="Person.NationalIdentificationNumber" />.</term>
        ///   </item>
        /// </list>
        /// <item>
        ///   <term>Person list page (<c>Views/Person/PersonList.cshtml</c>).</term>
        ///   <term>No upload errors detected.</term>
        /// </item></returns>
        public ActionResult FileReceiver()
        {
            HttpPostedFileBase dataFile = Request.Files[0];
            ExcelHelper excelHelper = new ExcelHelper(_repository);
            ServiceHelper serviceHelper = new ServiceHelper();

            string pathName = Path.Combine(Server.MapPath("../Upload/"), Path.GetFileName(dataFile.FileName));
            dataFile.SaveAs(pathName);
            IList<Person> invalidPersonList;

            try
            {
                invalidPersonList = excelHelper.UploadToDBExcelFile(pathName);
                System.IO.File.Delete(pathName);
            }
            catch
            {
                invalidPersonList = null;
                return View("InvalidExcelFile");
            }

            //serviceHelper.DoImport(_repository);


            if (invalidPersonList.Count() > 0)
            {
                Session["invalid"] = invalidPersonList;
                return RedirectToAction("UploadErrors", "Person");
            }
            else
            {
                return RedirectToAction("PersonList", "Person");
            }

        }
    }
}