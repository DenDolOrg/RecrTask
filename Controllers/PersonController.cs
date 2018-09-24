// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="PersonController.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RekrutTask.Models.Abstract;
using RekrutTask.Models;

namespace RekrutTask.Controllers
{
    /// <summary>
    /// Controller for creating different view models of Person
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class PersonController : Controller
    {
        /// <summary>
        /// Database data storage, type of <see cref="IFullInfoRepository" />.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="PersonController" />.</permission>
        private IFullInfoRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController" /> class.
        /// </summary>
        /// <param name="repository">Received database data.</param>
        public PersonController(IFullInfoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Action of <see cref="PersonController" />.
        /// <list type="destination"><item><term>Creates a special view model <see cref="FullInfoViewModel" /></term></item><item><term>Redirects to <see cref="Person" /> full information page with created view model.</term></item></list>
        /// </summary>
        /// <param name="currPerson">Requested Person, about whom to show full information.
        /// Creating automatically, by model binding mechanism, using relevant fields of <see cref="Person" />.</param>
        /// <param name="fullName">Full name of clicked Person</param>
        /// <returns>Returns a view with the name of "<c>Views/Person/PersonFull info.cshtml</c>", filled with <see cref="FullInfoViewModel" /> data.</returns>
        public ViewResult PersonFullInfo(Person currPerson, string fullName)
        {
            Address currAddress = _repository.AddressRepository.AddressList.First(a => a.Id == currPerson.AddressId);
            Agreement currAgreement = _repository.AgreementRepository.AgreementList.First(a => a.PersonId == currPerson.Id);
            FinancialState currFinancialState = _repository.FinancialStateRepository.FinancialStateList.First(f => f.Id == currAgreement.FinancialStateId);

            FullInfoViewModel viewModel = new FullInfoViewModel
            {
                PersonParamValues = new List<string>
                {
                   currPerson.FirstName,
                   currPerson.Surname,
                   currAgreement.Number,
                   currPerson.NationalIdentificationNumber,
                   currPerson.PhoneNumber,
                   currPerson.PhoneNumber2,
                   CreateFullAddress(currAddress.PostOfficeCity,
                                     currAddress.StreetName,
                                     currAddress.StreetNumber,
                                     currAddress.FlatNumber,
                                     currAddress.PostCode),

                   CreateFullAddress(currAddress.CorrespondencePostOfficeCity,
                                     currAddress.CorrespondenceStreetName,
                                     currAddress.CorrespondenceStreetNumber,
                                     currAddress.CorrespondenceFlatNumber,
                                     currAddress.CorrespondencePostCode)
                },
                FinancialStateParamValues = new List<string>
                {
                    currFinancialState.OutstandingLiabilities.ToString(),
                    currFinancialState.Interests.ToString(),
                    currFinancialState.PenaltyInterests.ToString(),
                    currFinancialState.Fees.ToString(),
                    currFinancialState.CourtFees.ToString(),
                    currFinancialState.RepresentationCourtFees.ToString(),
                    currFinancialState.VindicationCosts.ToString(),
                    currFinancialState.RepresentationVindicationCosts.ToString()
                }
            };
            return View(viewModel);
        }

        /// <summary>
        /// Action of <see cref="PersonController" />.
        /// Redirects to <see cref="Person" /> list page.
        /// </summary>
        /// <returns>Returns a view with the name of "<c>Views/Person/PersonList.cshtml</c>"</returns>
        public ViewResult PersonList()
        {
            return View(_repository.PersonRepository.PersonList.AsEnumerable());
        }
        /// <summary>
        /// Action of <see cref="PersonController" />.
        /// Redirects to uploading errors list page.
        /// </summary>
        /// <returns>Returns a view with the name of "<c>Views/PersonUploadErrors.cshtml</c>"</returns>
        public ViewResult UploadErrors()
        {
            IList<Person> invalidPersonList = (IList<Person>)Session["invalid"];
            return View(invalidPersonList.AsEnumerable());
        }
        /// <summary>
        /// Creates full address string for full <see cref="Person" /> information page.
        /// </summary>
        /// <param name="city">City.</param>
        /// <param name="street">Street.</param>
        /// <param name="strNumber">Street number.</param>
        /// <param name="flatNumber">Flat number.</param>
        /// <param name="postCode">Postal code.</param>
        /// <returns>Returns complete full address string</returns>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="PersonController" />.</permission>
        private string CreateFullAddress(string city, string street, string strNumber, string flatNumber, string postCode)
        {
            string fullAddress = city +
                                 ", ul." + street +
                                 " " + strNumber +
                                 (String.IsNullOrEmpty(flatNumber) ? String.Empty : " lok. " + flatNumber) +
                                 ", Post Code: " + postCode;
            return fullAddress;
        }
    }
}