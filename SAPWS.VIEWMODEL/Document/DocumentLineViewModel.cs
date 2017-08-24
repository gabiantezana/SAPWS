using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.VIEWMODEL.Document
{
    public class DocumentLineViewModel
    {

        public Int32 LineNum { get; set; }
        public String ItemCode { get; set; }
        public Int32 Quantity { get; set; }
        public Double UnitPrice { get; set; }
        public Double Price { get; set; }
        public String TaxCode { get; set; }
        public String WarehouseCode { get; set; }
        public String CostingCode { get; set; }
        public String CostingCode2 { get; set; }
        public String CostingCode3 { get; set; }
        public virtual Int32 BaseType { get; set; }
        public virtual Int32 BaseEntry { get; set; }
        public virtual Int32 BaseLine { get; set; }
        public Double DisccountPercent { get; set; }
        public Double LineTotal { get; set; }

        #region DownPayment

        public virtual Int32 DocEntry { get; set; }
        public Decimal SumApplied { get; set; }
        public String InvoiceType { get; set; }
        public Int32 InstalimentId { get; set; }
        public String DistributionRule { get; set; }
        public String DistributionRule2 { get; set; }
        public String DistributionRule3 { get; set; }

        #endregion


        #region ApplicationProperties

        public Boolean IsUpdate { get; set; }

        #endregion
    }
}
