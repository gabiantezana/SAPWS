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
        public String ItemCode { get; set; } = String.Empty;
        public Int32 Quantity { get; set; } = 0;
        public Double UnitPrice { get; set; } = 0;
        public Double Price { get; set; } = 0;
        [MaxLength(8)]
        public String TaxCode { get; set; } = String.Empty;
        [MaxLength(8)]
        public String WarehouseCode { get; set; } = String.Empty;
        [MaxLength(20)]
        public String CostingCode { get; set; } = String.Empty;
        [MaxLength(20)]
        public String CostingCode2 { get; set; } = String.Empty;
        [MaxLength(20)]
        public String CostingCode3 { get; set; }
        public virtual Int32 BaseType { get; set; } = 0;
        public virtual Int32 BaseEntry { get; set; } = 0;
        public virtual Int32 BaseLine { get; set; } = 0;
        #endregion

    }
}
