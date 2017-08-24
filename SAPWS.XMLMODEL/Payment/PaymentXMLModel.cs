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
        public String DocType { get; set; }//TODOG:
        public String DocDate { get; set; }
        public String TaxDate { get; set; }
        public String DueDate { get; set; }
        [MaxLength(15)]
        public String CardCode { get; set; }
        [MaxLength(3)]
        public String DocCurrency { get; set; }
        public Int32 DocRate { get; set; }
        [MaxLength(8)]
        public String CounterReference { get; set; }
        [MaxLength(254)]
        public String Remarks { get; set; }
        public Double CashSum { get; set; }

        #region UserFields

        [MaxLength(3)]
        public String U_BPP_MPPG { get; set; }
        [MaxLength(2)]
        public String U_MSS_MPSA { get; set; }

        #endregion

        [XmlArray("PaymentInvoices")]
        public List<PaymentInvoiceXMLModel> PaymentInvoices { get; set; }
    }
}
