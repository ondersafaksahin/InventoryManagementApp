using System.ComponentModel;
/// <summary>
/// Enumeration of ISO 4217 currency codes, indexed with their respective ISO 4217 numeric currency codes. 
/// Only codes support in .Net with RegionInfo objects are listed
/// </summary>
public enum CurrencyCodes
{
    [Description("EUR - Euro")] EUR = 978,
    [Description("GBP - Pound sterling")] GBP = 826,
    [Description("TRY - Turkish lira")] TRY = 949,
    [Description("USD - United States dollar")] USD = 840,
}
