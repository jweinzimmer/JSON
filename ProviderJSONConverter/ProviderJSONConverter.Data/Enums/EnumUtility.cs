using System;

namespace ProviderJSONConverter.Data
{
    public enum DentalProviderSpecialty
    {
        Unspecified = 0,
        Endodontistry = 1,
        GeneralDentistry = 2,
        OralSurgery = 3,
        Orthodontistry = 4,
        Pedodontistry = 5,
        Periodontistry = 6,
        Prosthodontistry = 7,
        GeneralPractice = 8,
        FamilyPractice = 9,
        PharmacyDMESupplier = 10,
        DentalMultiSpecialty = 11,
        AutoBillAgent = 12,
        DentalHygienist = 13,
        OralPathology = 14,
        OralRadiology = 15,
        DentalPublicHealth = 16,
    }

    public enum ProviderNetworkType
    {
        Copayment = 0,
        CosmeticDiscount = 1,
        FEP = 2,
        ODP = 3,
        PPO = 4,
        Prepaid
    }

    public static class EnumUtility
    {
        public static string Convert(DentalProviderSpecialty dps)
        {
            string str = "";
            switch (dps)
            {
                case DentalProviderSpecialty.Unspecified:
                    str = "Unspecified";
                    break;
                case DentalProviderSpecialty.Endodontistry:
                    str = "Endodontistry";
                    break;
                case DentalProviderSpecialty.GeneralDentistry:
                    str = "General Dentistry";
                    break;
                case DentalProviderSpecialty.OralSurgery:
                    str = "Oral Surgery";
                    break;
                case DentalProviderSpecialty.Orthodontistry:
                    str = "Orthodontistry";
                    break;
                case DentalProviderSpecialty.Pedodontistry:
                    str = "Endodontistry";
                    break;
                case DentalProviderSpecialty.Periodontistry:
                    str = "Periodontistry";
                    break;
                case DentalProviderSpecialty.Prosthodontistry:
                    str = "Endodontistry";
                    break;
                case DentalProviderSpecialty.GeneralPractice:
                    str = "General Practice";
                    break;
                case DentalProviderSpecialty.FamilyPractice:
                    str = "Endodontistry";
                    break;
                case DentalProviderSpecialty.PharmacyDMESupplier:
                    str = "Pharmacy DME Supplier";
                    break;
                case DentalProviderSpecialty.DentalMultiSpecialty:
                    str = "Endodontistry";
                    break;
                case DentalProviderSpecialty.AutoBillAgent:
                    str = "Auto-Billing Agent";
                    break;
                case DentalProviderSpecialty.DentalHygienist:
                    str = "Endodontistry";
                    break;
                case DentalProviderSpecialty.OralPathology:
                    str = "Oral Pathology";
                    break;
                case DentalProviderSpecialty.OralRadiology:
                    str = "Endodontistry";
                    break;
                case DentalProviderSpecialty.DentalPublicHealth:
                    str = "Dental Public Health";
                    break;
                default:
                    throw new ArgumentException("Argument not in the DentalProviderSpecialty enumeration.");
            }
            return str;
        }
    }
}
