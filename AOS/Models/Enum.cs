using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOS.Models
{
    public enum userTypes
    {
        State = 1,
        Operator = 2,
    }
    public enum Language
    {
        English = 1,
        French = 2,
        Spanish = 3,
        Chinese = 4,
        Russian = 5,
        Arabic = 6
    }
    public enum OrganizationCategory
    {
        Airline = 1,
        AirlineServicesSupplier = 2,
        AirportServicesSupplier = 3,
        Business = 4,
        Consulate = 5,
        Consultant = 6,
        Education = 7,
        Government = 8,
        ICAO = 9,
        InformationServicesProvider = 10,
        InternationalOrganization = 11,
        LegalServicesProvider = 12,
        Librarian = 13,
        Manufacturer = 14,
        Media = 15,
        MeteorologicalServices = 16,
        Military = 17,
        NGO = 18,
        PrivateIndividuals = 19,
        Retailer = 20,
        Telemarketing = 21,
        TrainingServicesSupplier = 22,
        UN = 23,
        Other = 24
    }
    public enum Title
    {
        Mr = 1,
        Mrs = 2,
        Miss = 3,
        Ms = 4,
        Sir = 5,
        Dr = 6
    }
}