// ***********************************************************************
// Assembly         : RekrutTask
// Author           : Денис
// Created          : 08-04-2018
//
// Last Modified By : Денис
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="ExcelHelper.cs" company="">
//     © , 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using RekrutTask.Models.Abstract;
using RekrutTask.Models;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Data;

namespace RekrutTask.Infrastructure
{
    /// <summary>
    /// Class, which contains processing methods for Excel file.
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// Database data storage, type of <see cref="IFullInfoRepository" />.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private IFullInfoRepository _repository;

        /// <summary>
        /// First sheet name of chosen Excel file (assumed, that data for upload, locates at first sheet).
        /// </summary>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private string sheetName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelHelper" /> class.
        /// </summary>
        /// <param name="repository">Received database data.</param>
        public ExcelHelper(IFullInfoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Determines the name of first sheet in chosen Excel file.
        /// </summary>
        /// <param name="connection">Connection object to Excel file.</param>
        /// <returns>System.String.</returns>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private string GetSheetName(OleDbConnection connection)
        {
            connection.Open();

            var a = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string name = null;
            foreach (DataRow row in a.Rows)
            {
                if (row["TABLE_NAME"].ToString().Contains("$"))
                {
                    name = row["TABLE_NAME"].ToString();
                    break;
                }
            }
            connection.Close();

            return name;
        }
        /// <summary>
        /// Gets list of <see cref="Address" /> from Excel file;
        /// </summary>
        /// <param name="connection">Connection object to Excel file.</param>
        /// <returns>Returns <see cref="Address" /> list, type of <see cref="IList{Address}" /></returns>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private IList<Address> GetAddressTableData(OleDbConnection connection)
        {
            IList<Address> addressList = new List<Address>();

            string selectCommand = "SELECT [MAIN_STREET_NAME]," +
                                   "[MAIN_STREET_NUMBER]," +
                                   "[MAIN_STREET_FLAT_NUMBER]," +
                                   "[MAIN_POST_CODE]," +
                                   "[MAIN_POST_OFFICE_CITY]," +
                                   "[CORRESPONDENCE_STREET_NAME]," +
                                   "[CORRESPONDENCE_STREET_NUMBER]," +
                                   "[CORRESPONDENCE_STREET_FLAT_NUMBER]," +
                                   "[CORRESPONDENCE_POST_CODE]," +
                                   "[CORRESPONDENCE_POST_OFFICE_CITY] FROM" + sheetName;

            OleDbCommand command = new OleDbCommand(selectCommand, connection);


            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read() && reader[0].ToString() != String.Empty)
            {
                Address newAddress = new Address
                {
                    StreetName = reader[0].ToString(),
                    StreetNumber = reader[1].ToString(),
                    FlatNumber = reader[2].ToString(),
                    PostCode = reader[3].ToString(),
                    PostOfficeCity = reader[4].ToString(),
                    CorrespondenceStreetName = reader[5].ToString(),
                    CorrespondenceStreetNumber = reader[6].ToString(),
                    CorrespondenceFlatNumber = reader[7].ToString(),
                    CorrespondencePostCode = reader[8].ToString(),
                    CorrespondencePostOfficeCity = reader[9].ToString(),

                };

                addressList.Add(newAddress);
            }
            connection.Close();
            return addressList;
        }
        /// <summary>
        /// Gets list of <see cref="Agreement" /> from Excel file;
        /// </summary>
        /// <param name="connection">Connection object to Excel file.</param>
        /// <returns>Returns <see cref="Agreement" /> list, type of <see cref="IList{Agreement}" /></returns>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private IList<Agreement> GetAgreementTableData(OleDbConnection connection)
        {
            IList<Agreement> agreementList = new List<Agreement>();

            string selectCommand = "SELECT [nr_umowy] FROM" + sheetName;

            OleDbCommand command = new OleDbCommand(selectCommand, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read() && reader[0].ToString() != String.Empty)
            {
                Agreement newAgreement = new Agreement
                {
                    Number = reader[0].ToString(),
                };

                agreementList.Add(newAgreement);
            }
            connection.Close();
            return agreementList;
        }

        /// <summary>
        /// Gets list of <see cref="FinancialState" /> from Excel file;
        /// </summary>
        /// <param name="connection">Connection object to Excel file.</param>
        /// <returns>Returns <see cref="FinancialState" /> list, type of <see cref="IList{FinancialState}" /></returns>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private IList<FinancialState> GetFinancialStateTableData(OleDbConnection connection)
        {
            IList<FinancialState> financialStateList = new List<FinancialState>();

            string selectCommand = "SELECT [Kapital]," +
                                   "[odsetki]," +
                                   "[odsetki Karne]," +
                                   "[opłaty]," +
                                   "[koszty sadowe]," +
                                   "[koszty zastepstwa sadowego]," +
                                   "[koszty egzekucji]," +
                                   "[koszty zastepstwa egzekucyjnego] FROM" + sheetName;

            OleDbCommand command = new OleDbCommand(selectCommand, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read() && reader[0].ToString() != String.Empty)
            {
                FinancialState newFinancialState = new FinancialState
                {
                    OutstandingLiabilities = Decimal.Parse(reader[0].ToString()),
                    Interests = Decimal.Parse(reader[1].ToString()),
                    PenaltyInterests = Decimal.Parse(reader[2].ToString()),
                    Fees = !String.IsNullOrEmpty(reader[3].ToString()) ? Decimal.Parse(reader[3].ToString()) : (decimal?)null,
                    CourtFees = Decimal.Parse(reader[4].ToString()),
                    RepresentationCourtFees = !String.IsNullOrEmpty(reader[5].ToString()) ? Decimal.Parse(reader[5].ToString()) : (decimal?)null,
                    VindicationCosts = !String.IsNullOrEmpty(reader[6].ToString()) ? Decimal.Parse(reader[6].ToString()) : (decimal?)null,
                    RepresentationVindicationCosts = !String.IsNullOrEmpty(reader[7].ToString()) ? Decimal.Parse(reader[7].ToString()) : (decimal?)null,
                };

                financialStateList.Add(newFinancialState);
            }
            connection.Close();
            return financialStateList;
        }

        /// <summary>
        /// Gets list of <see cref="Person" /> from Excel file;
        /// </summary>
        /// <param name="connection">Connection object to Excel file.</param>
        /// <returns>Returns <see cref="Person" /> list, type of <see cref="IList{Person}" /></returns>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private IList<Person> GetPersonTableData(OleDbConnection connection)
        {
            IList<Person> personList = new List<Person>();

            string selectCommand = "SELECT [imie]," +
                                   "[nazwisko]," +
                                   "[PESEL]," +
                                   "[Telefon 1]," +
                                   "[Telefon2] FROM" + sheetName;

            OleDbCommand command = new OleDbCommand(selectCommand, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read() && reader[0].ToString() != String.Empty)
            {
                Person newPerson = new Person
                {
                    FirstName = reader[0].ToString(),
                    SecondName = String.Empty,
                    Surname = reader[1].ToString(),
                    NationalIdentificationNumber = reader[2].ToString(),
                    PhoneNumber = reader[3].ToString(),
                    PhoneNumber2 = reader[4].ToString(),

                };

                personList.Add(newPerson);
            }
            connection.Close();
            return personList;
        }

        /// <summary>
        /// Determines, whether <see cref="Person.NationalIdentificationNumber" /> from <see cref="IList{Person}" /> is valid
        /// </summary>
        /// <param name="personList">Full list of <see cref="Person" /></param>
        /// <param name="currentPerson"><see cref="Person" /> to check.</param>
        /// <returns><c>true</c> if <see cref="Person.NationalIdentificationNumber" /> is unique in database and list, also it should be a 11 digit number; otherwise, <c>false</c>.</returns>
        /// <permission cref="System.Security.PermissionSet"> Available only inside class <see cref="ExcelHelper" />.</permission>
        private bool IsAvailableForUpload(IList<Person> personList, Person currentPerson)
        {
            Regex peselRegex = new Regex(@"^\d{11}$");
            if (peselRegex.Match(currentPerson.NationalIdentificationNumber).Success &&
               personList.Count(p => p.NationalIdentificationNumber == currentPerson.NationalIdentificationNumber) == 1 &&
               _repository.PersonRepository.PersonList.Where(e => e.NationalIdentificationNumber == currentPerson.NationalIdentificationNumber).Count() == 0)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Uploads to database Excel file.
        /// </summary>
        /// <param name="pathName">Path, to temporary saved on server, copy of chosen Excel file.</param>
        /// <returns>Returns the list of <see cref="Person" />, whose <see cref="Person.NationalIdentificationNumber" /> is not valid.</returns>
        /// <permission cref="System.Security.PermissionSet"> Accessible from the outside.</permission>
        public IList<Person> UploadToDBExcelFile(string pathName)
        {            
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + pathName + "; Extended Properties='Excel 8.0;HDR=Yes'");
            sheetName = "[" + GetSheetName(connection) + "]";
            
            IList<Address> addressList = GetAddressTableData(connection);
            IList<FinancialState> financialStateList = GetFinancialStateTableData(connection);
            IList<Person> personList = GetPersonTableData(connection);
            IList<Agreement> agreementList = GetAgreementTableData(connection);
            
            IList<Person> invalidPersonList = new List<Person>();

            int listPosIterator = 0;
            foreach (var address in addressList)
            {
                Person currentPerson = personList.ElementAt(listPosIterator);
                FinancialState currentFinancialState = financialStateList.ElementAt(listPosIterator);
                Agreement currentAgreement = agreementList.ElementAt(listPosIterator);

                if (IsAvailableForUpload(personList, currentPerson))
                {
                    
                    _repository.AddressRepository.SaveAddress(address);
                    _repository.FinancialStateRepository.SaveFinancialState(currentFinancialState);

                    currentPerson.AddressId = _repository.AddressRepository.AddressList.OrderByDescending(e => e.Id).First().Id;
                    _repository.PersonRepository.SavePerson(currentPerson);

                    currentAgreement.FinancialStateId = _repository.FinancialStateRepository.FinancialStateList.OrderByDescending(e => e.Id).First().Id;
                    currentAgreement.PersonId = _repository.PersonRepository.PersonList.OrderByDescending(e => e.Id).First().Id;
                    _repository.AgreementRepository.SaveAgreement(currentAgreement);
                }
                else
                {
                    invalidPersonList.Add(currentPerson);
                }

                listPosIterator++;
            }
            return invalidPersonList;
        }
    }
}