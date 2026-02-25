using System.ComponentModel;

namespace TurkcellEsirketIntegration.Enum;

public enum InvoiceProfileType
{
    [Description("Temel")]
    TEMELFATURA,
    [Description("Ticari")]
    TICARIFATURA,
    [Description("İhracat")]
    IHRACAT,
    [Description("Yolcu Beraber")]
    YOLCUBERABERFATURA,
    [Description("E-Arşiv")]
    EARSIVFATURA,
    [Description("Kağıt")]
    KAGIT,
    [Description("HKS")]
    HKS,
    [Description("E-SMM")]
    EARSIVBELGE,
    [Description("Standart Kodlu")]
    STANDARTKODLUFATURA,
    [Description("Kamu")]
    KAMU,
    [Description("Enerji")]
    ENERJI,
    [Description("İlaç Tıbbi Cihaz")]
    ILAC_TIBBICIHAZ,
    [Description("Yatırım Teşvik")]
    YATIRIMTESVIK,
    [Description("IDIS")]
    IDIS
}