using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.XMLMODEL.Document
{
    [XmlType("DocumentLine")]
    public class DocumentLineXMLModel
    {
        #region XMLProperties

        public Int32 LineNum { get; set; }
        [MaxLength(50)]
        public String ItemCode { get; set; }
        public Int32 Quantity { get; set; }
        public Double UnitPrice { get; set; }
        public Double Price { get; set; }
        [MaxLength(8)]
        public String TaxCode { get; set; }
        [MaxLength(8)]
        public String WarehouseCode { get; set; }
        [MaxLength(20)]
        public String CostingCode { get; set; }
        [MaxLength(20)]
        public String CostingCode2 { get; set; }
        [MaxLength(20)]
        public String CostingCode3 { get; set; }
        public virtual Int32 BaseType { get; set; }
        public virtual Int32 BaseEntry { get; set; }
        public virtual Int32 BaseLine { get; set; }


        #region DownPayment

        public Int32 DocEntry { get; set; }
        public Double SumApplied { get; set; }
        public String InvoiceType { get; set; }
        public Int32 InstalimentId { get; set; }
        public String DistributionRule { get; set; }
        public String DistributionRule2 { get; set; }
        public String DistributionRule3 { get; set; }

        #endregion

        #endregion




    }
}
