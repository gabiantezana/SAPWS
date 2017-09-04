using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.XMLMODEL.BusinessPartner
{
    [XmlRoot("object")]
    public class BusinessPartnerXMLModel
    {
        [Required]
        [MaxLength(15)]
        public String CardCode { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public String CardName { get; set; } = String.Empty;

        [Required]
        [MaxLength(9)]
        public String CardType { get; set; } = String.Empty;

        [Required]
        [MaxLength(32)]
        public String FederalTaxID { get; set; } = String.Empty;

        [Required]
        public Int32 GroupCode { get; set; } = 0;

        [Required]
        [MaxLength(3)]
        public String Currency { get; set; } = String.Empty;

        [Required]
        [MaxLength(3)]
        public String U_BPP_BPTP { get; set; } = String.Empty;

        [Required]
        [MaxLength(1)]
        public String U_BPP_BPTD { get; set; } = String.Empty;

        [Required]
        public Int32 PayTermsGrpCode { get; set; } = 0;

        [XmlArray("ContactEmployees")]
        public List<ContactEmployeeXMLModel> ContactEmployees { get; set; } = new List<ContactEmployeeXMLModel>();

        [XmlArray("BPAddresses")]
        public List<BPAddressXMLModel> BPAddresses { get; set; } = new List<BPAddressXMLModel>();

    }






}
