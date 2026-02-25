using TurkcellEsirketIntegration.Enum;

namespace TurkcellEsirketIntegration.Models;

public class RecordType
{
    public const int Earsiv = 0;
    public const int Efatura = 1;
}

public static class SampleUblBuilder
{
    public static UblBuilderModel CreateSampleInvoice()
    {
        var id = Guid.NewGuid();

        var invoiceLines = new List<InvoiceLineModel>()
        {
            new InvoiceLineModel
            {
                InventoryCard = "aaa",
                Amount = 1,
                UnitCode = "C62",
                UnitPrice = 2,
                VatRate = 1,
                VatExemptionReasonCode = "",
                LineExtensionAmount = 2,
                // Taxes = new List<InvoiceLineTaxModel>(), 
                // InvoiceLineDeliveryInfoModel = new InvoiceLineDeliveryInfoModel() 
            }
        };

        var ublModel = new UblBuilderModel
        {
            InvoiceId = id,
            Status = (int)InvoiceStatus.Queued,
            RecordType = (int)RecordType.Efatura,
            UseManualInvoiceId = false,
            XsltCode = "master",

            GeneralInfoModel = new GeneralInfoModel
            {
                Ettn = Guid.NewGuid(),
                Prefix = "EPT",
                // InvoiceNumber = "ELA2026000000003",
                InvoiceProfileType = (int)InvoiceProfileType.TEMELFATURA,
                IssueDate = DateTime.Now,
                Type = (int)InvoiceType.SATIS,
                CurrencyCode = "TRY",
                // ReturnInvoiceDate = null,
                // ExchangeRate = 0,
                // PeriodDate = DateTime.Now,
                // DespatchType = 0,
                // Standard = 0
            },

            AddressBook = new AddressBookModel
            {
                Alias = "urn:mail:test03firmapk@d.com",
                IdentificationNumber = "1234567803",
                Name = "TEST KURUM 23",
                ReceiverPersonSurName = "Medyasoft Test",
                ReceiverCity = "İstanbul",
                ReceiverDistrict = "Üsküdar",
                ReceiverCountry = "Türkiye",
                ReceiverEmail = "test@medyasoft.com.tr",
                RegisterNumber = "1",
                ReceiverStreet = "Test Mahallesi 123. Sokak",
                ReceiverBuildingName = "Test Bina",
                ReceiverBuildingNumber = "10",
                ReceiverDoorNumber = "2",
                ReceiverSmallTown = "1",
                ReceiverZipCode = "34000",
                ReceiverPhoneNumber = "02121234567",
                ReceiverFaxNumber = "02121234568",
                ReceiverWebSite = "https://medyasoft.com.tr",
                ReceiverTaxOffice = "Üsküdar Vergi Dairesi"
            },

            InvoiceLines = invoiceLines,

            // RelatedDespatchList = new List<RelatedDespatchModel>(),

            // PaymentMeansModel = new PaymentMeansModel
            // {
            //     PaymentMeansCode = 0,
            //     PaymentDueDate = null,
            //     PaymentChannelCode = null,
            //     InstructionNote = null,
            //     PayeeFinancialAccountId = null,
            //     PayeeFinancialAccountCurrencyCode = null
            // },

            // PaymentTermsModel = new PaymentTermsModel
            // {
            //     Amount = null,
            //     Note = null,
            //     PenaltySurchargePercent = null
            // },

            // UblSettingsModel = new UblSettingsModel
            // {
            //     UseCalculatedVatAmount = true,
            //     UseCalculatedTotalSummary = true,
            //     HideDespatchMessage = true
            // }
        };

        return ublModel;
    }
}