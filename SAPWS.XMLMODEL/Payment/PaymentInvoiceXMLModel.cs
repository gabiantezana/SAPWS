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
        public Int32 LineNum { get; set; }
        public Int32 DocEntry { get; set; }
        public Double SumApplied { get; set; }
        [MaxLength(15)]
        public String InvoiceType { get; set; }
        public Int32 InstallmentId { get; set; }
        public String DistributionRule { get; set; }
        public String DistributionRule2 { get; set; }
        public String DistributionRule3 { get; set; }
    }
}
