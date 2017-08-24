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
        public String DocumentType { get; set; }

        [Required]
        public Int32 DocEntry { get; set; }

        [Required]
        [MaxLength(15)]
        public String CardCode { get; set; }

        [Required]
        [MaxLength(3)]
        public String DocCurrency { get; set; }

        [Required]
        public String DocDate { get; set; }

        public String DueDate { get; set; }

        [Required]
        public String DocDueDate { get; set; }

        [Required]
        public String TaxDate { get; set; }

        [Required]
        public Int32 PaymentGroupCode { get; set; }

        [MaxLength(254)]
        public String Comments { get; set; }

        public Double TotalDiscount { get; set; }

        public Double TotalDiscountFC { get; set; }


        #region UserFields

        [Required]
        [MaxLength(2)]
        public String U_BPP_MDTD { get; set; }

        [MaxLength(4)]
        public String U_BPP_MDSD { get; set; }

        [MaxLength(15)]
        public String U_BPP_MDCD { get; set; }

        [MaxLength(2)]
        public String U_MSS_TVTA { get; set; }

        [MaxLength(7)]
        public String U_MSS_TIDA { get; set; }

        public String U_BPP_MDTS { get; set; }

        public String U_BPP_SDocDate { get; set; }



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
