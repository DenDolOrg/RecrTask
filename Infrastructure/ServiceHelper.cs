// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="ServiceHelper.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using RekrutTask.ServiceWSDL;
using RekrutTask.Models.Abstract;

namespace RekrutTask.Infrastructure
{
    /// <summary>
    /// Class, which plays container role for method <c>DoImport()</c>
    /// </summary>
    public class ServiceHelper
    {
        /// <summary>
        /// Preparing objects of type <see cref="ServiceWSDL.Person" /> and invokes method <c>DoImport()</c> from <see cref="ServiceWSDL" /> for each of them.
        /// </summary>
        /// <param name="repository">Received database data.</param>
        public void DoImport(IFullInfoRepository repository)
        {
            ImportServiceClient client = new ImportServiceClient();
            foreach (var p in repository.PersonRepository.PersonList)
            {
                Models.Address currentAddress = repository.AddressRepository.AddressList.First(a => a.Id == p.AddressId);
                Models.Agreement currentAgreement = repository.AgreementRepository.AgreementList.First(a => a.PersonId == p.Id);
                Models.FinancialState currentFinancialState = repository.FinancialStateRepository.FinancialStateList.First(a => a.Id == currentAgreement.FinancialStateId);

                client.DoImport(new Person()
                {
                    Name = p.FirstName,
                    Surname = p.Surname,
                    Addresses = new Address[]
                    {
                            new Address()
                            {
                                AddressType = "Main",
                                City = currentAddress.PostOfficeCity,
                                Street = currentAddress.StreetName,
                                HouseNo = currentAddress.StreetNumber,
                                LocaleNo = currentAddress.FlatNumber,
                                PostalCode = currentAddress.PostCode
                            },
                            new Address()
                            {
                                AddressType = "Correspondence",
                                City = currentAddress.CorrespondencePostOfficeCity,
                                Street = currentAddress.CorrespondenceStreetName,
                                HouseNo = currentAddress.CorrespondenceStreetNumber,
                                LocaleNo = currentAddress.CorrespondenceFlatNumber,
                                PostalCode = currentAddress.CorrespondencePostCode
                            }
                    },
                    FinancialState = new FinancialState()
                    {
                        Capital = currentFinancialState.OutstandingLiabilities,
                        Interest = currentFinancialState.Interests,
                        PenaltyInterest = currentFinancialState.PenaltyInterests,
                        Fees = currentFinancialState.Fees == null ? 0 : (decimal)currentFinancialState.Fees,
                        CourtFees = currentFinancialState.CourtFees,
                        CourtRepresentationFees = currentFinancialState.RepresentationCourtFees == null ? 0 : (decimal)currentFinancialState.RepresentationCourtFees,
                        EnforcementFees = currentFinancialState.VindicationCosts == null ? 0 : (decimal)currentFinancialState.VindicationCosts,
                        EnforcementRepresentationFees = currentFinancialState.RepresentationVindicationCosts == null ? 0 : (decimal)currentFinancialState.RepresentationVindicationCosts
                    },
                    NationalIdentificationNumber = p.NationalIdentificationNumber,
                    Phones = new Phone[]
                    {
                            //There is no properties to write in, for ServiceWSDL.Phone
                            new Phone()
                            {
                               //Phone 1
                            },
                            new Phone()
                            {
                                //Phone 2
                            }
                    },
                    IdentityDocuments = new IdentityDocument[]
                    {
                            new IdentityDocument()
                            {
                                Type = "PESEL",
                                ExpirationDate = new DateTime(),
                                Number = p.NationalIdentificationNumber
                            }
                    }
                });
            }
        }
    }
}