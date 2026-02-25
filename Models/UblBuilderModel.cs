using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurkcellEsirketIntegration.Models;

//örnek model yapısıdır. İhtiyaçlara göre düzenlenebilir.ß
public class UblBuilderModel
{
    public Guid InvoiceId { get; set; }
    public int Status { get; set; }
    public int RecordType { get; set; }
    public bool UseManualInvoiceId { get; set; }
    public string XsltCode { get; set; }
    public GeneralInfoModel GeneralInfoModel { get; set; }
    public AddressBookModel AddressBook { get; set; }
    public List<InvoiceLineModel> InvoiceLines { get; set; } = new();
}

public class GeneralInfoModel
{
    public Guid Ettn { get; set; }
    public string Prefix { get; set; }
    public string InvoiceNumber { get; set; }
    public int InvoiceProfileType { get; set; }
    public int Type { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime IssueDate { get; set; }
}

public class AddressBookModel
{
    public string Alias { get; set; }
    public string IdentificationNumber { get; set; }
    public string ReceiverPersonSurName { get; set; }
    public string Name { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverDistrict { get; set; }
    public string ReceiverCountry { get; set; }
    public string ReceiverEmail { get; set; }
    public string RegisterNumber { get; set; }
    public string ReceiverStreet { get; set; }
    public string ReceiverBuildingName { get; set; }
    public string ReceiverBuildingNumber { get; set; }
    public string ReceiverDoorNumber { get; set; }
    public string ReceiverSmallTown { get; set; }
    public string ReceiverZipCode { get; set; }
    public string ReceiverPhoneNumber { get; set; }
    public string ReceiverFaxNumber { get; set; }
    public string ReceiverWebSite { get; set; }
    public string ReceiverTaxOffice { get; set; }
}

public class InvoiceLineModel
{
    public string InventoryCard { get; set; }
    public decimal Amount { get; set; }
    public string UnitCode { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal VatRate { get; set; }
    public string VatExemptionReasonCode { get; set; }
    public decimal LineExtensionAmount { get; set; }
}