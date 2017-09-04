using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.XMLMODEL.Payment
{
    [XmlType("object")]
    public class PaymentXMLModel
    {
        [MaxLength(9)]
        public String DocType { get; set; } = String.Empty;
        public String DocDate { get; set; } = String.Empty;
        public String TaxDate { get; set; } = String.Empty;
        public String DueDate { get; set; } = String.Empty;
        [MaxLength(15)]
        public String CardCode { get; set; } = String.Empty;
        [MaxLength(3)]
        public String DocCurrency { get; set; } = String.Empty;
        public Int32 DocRate { get; set; } = 0;
        [MaxLength(8)]
        public String CounterReference { get; set; } = String.Empty;
        [MaxLength(254)]
        public String Remarks { get; set; } = String.Empty;
        public Double CashSum { get; set; } = 0;

        #region UserFields

        [MaxLength(3)]
        public String U_BPP_MPPG { get; set; } = String.Empty;
        [MaxLength(2)]
        public String U_MSS_MPSA { get; set; } = String.Empty;

        #endregion

        [XmlArray("PaymentInvoices")]
        public List<PaymentInvoiceXMLModel> PaymentInvoices { get; set; } = new List<PaymentInvoiceXMLModel>();
    }
}
