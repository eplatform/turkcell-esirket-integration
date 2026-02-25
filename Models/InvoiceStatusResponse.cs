namespace TurkcellEsirketIntegration.Models;

public class InvoiceStatusResponse
{
    public Guid Id { get; set; }

    public string InvoiceNumber { get; set; }

    public int Status { get; set; }

    public string Message { get; set; }

    public Guid? EnvelopeId { get; set; }

    public int EnvelopeStatus { get; set; }

    public string EnvelopeMessage { get; set; }

    public int? HobimStatus { get; set; }

    public DateTime SentDate { get; set; }
}