using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.XMLMODEL.Document
{
    [XmlRoot("object")]
    public class DocumentXMLModel
    {
        public String DocumentType { get; set; } = String.Empty;

        [Required]
        public Int32 DocEntry { get; set; } = 0;

        [Required]
        [MaxLength(15)]
        public String CardCode { get; set; } = String.Empty;

        [Required]
        [MaxLength(3)]
        public String DocCurrency { get; set; } = String.Empty;

        [Required]
        public String DocDate { get; set; } = String.Empty;

        public String DueDate { get; set; } = String.Empty;

        [Required]
        public String DocDueDate { get; set; } = String.Empty;

        [Required]
        public String TaxDate { get; set; } = String.Empty;

        [Required]
        public Int32 PaymentGroupCode { get; set; } = 0;

        [MaxLength(254)]
        public String Comments { get; set; } = String.Empty;

        public Double TotalDiscount { get; set; } = 0;

        public Double TotalDiscountFC { get; set; } = 0;


        #region UserFields

        [Required]
        [MaxLength(2)]
        public String U_BPP_MDTD { get; set; } = String.Empty;

        [MaxLength(4)]
        public String U_BPP_MDSD { get; set; } = String.Empty;

        [MaxLength(15)]
        public String U_BPP_MDCD { get; set; } = String.Empty;

        [MaxLength(2)]
        public String U_MSS_TVTA { get; set; } = String.Empty;

        [MaxLength(7)]
        public String U_MSS_TIDA { get; set; } = String.Empty;

        public String U_BPP_MDTS { get; set; } = String.Empty;

        public String U_BPP_SDocDate { get; set; } = String.Empty;



        [XmlArray("DocumentLines")]
        public List<DocumentLineXMLModel> DocumentLines { get; set; }

        #region CreditNote

        public String U_BPP_MDTO { get; set; }

        public String U_BPP_MDSO { get; set; }

        public String U_BPP_MDCO { get; set; }

        #endregion CreditoNote


        #endregion


    }




}
