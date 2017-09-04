using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.XMLMODEL.Payment
{
    [XmlType("PaymentInvoice")]
    public class PaymentInvoiceXMLModel
    {
        public Int32 LineNum { get; set; } = 0;
        public Int32 DocEntry { get; set; } = 0;
        public Double SumApplied { get; set; } = 0;
        [MaxLength(15)]
        public String InvoiceType { get; set; } = String.Empty;
        public Int32 InstallmentId { get; set; } = 0;
        public String DistributionRule { get; set; } = String.Empty;
        public String DistributionRule2 { get; set; } = String.Empty;
        public String DistributionRule3 { get; set; } = String.Empty;
    }
}
