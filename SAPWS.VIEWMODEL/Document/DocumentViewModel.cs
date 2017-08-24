using SAPbobsCOM;
using SAPWS.VIEWMODEL.Payment;
using SAPWS.XMLMODEL.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.VIEWMODEL.Document
{
    public class DocumentViewModel
    {
        public DocumentViewModel()
        {
            this.DocumentLines = new List<DocumentLineViewModel>();
        }

        #region XMLProperties

        public Int32 DocEntry { get; set; }
        public String CardCode { get; set; }
        public String DocCurrency { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public DateTime DueDate { get; set; } //Error Paiva
        public DateTime TaxDate { get; set; }
        public Int32 PaymentGroupCode { get; set; }
        public String Comments { get; set; }
        public Double TotalDiscount { get; set; }
        public Double TotalDiscountFC { get; set; }
        #region UserFields

        public String U_BPP_MDTD { get; set; }
        public String U_BPP_MDSD { get; set; }
        public String U_BPP_MDCD { get; set; }
        public String U_MSS_TVTA { get; set; }
        public String U_MSS_TIDA { get; set; }
        public String U_BPP_MDTS { get; set; }
        public DateTime? U_BPP_SDocDate { get; set; }

        #endregion

        public List<DocumentLineViewModel> DocumentLines { get; set; }

        #region CreditNote

        public String U_BPP_MDTO { get; set; }
        public String U_BPP_MDSO { get; set; }
        public String U_BPP_MDCO { get; set; }

        #endregion

        #endregion


        #region SAPProperties 

        public BoObjectTypes ObjectType { get; set; }
        public BoDocumentTypes DocumentType { get; set; }
        public BoDocumentSubType DocumentSubType { get; set; }
        public Int32 Series { get; set; }
        public Double DiscountPercent { get; set; }

        #endregion

        #region ApplicationProperties

        public Boolean IsUpdate { get; set; }

        #endregion

    }




}
