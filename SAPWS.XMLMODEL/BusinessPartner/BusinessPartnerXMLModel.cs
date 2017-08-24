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
        public String CardCode { get; set; }

        [Required]
        [MaxLength(100)]
        public String CardName { get; set; }

        [Required]
        [MaxLength(9)]
        public String CardType { get; set; }

        [Required]
        [MaxLength(32)]
        public String FederalTaxID { get; set; }

        [Required]
        public Int32 GroupCode { get; set; }

        [Required]
        [MaxLength(3)]
        public String Currency { get; set; }

        [Required]
        [MaxLength(3)]
        public String U_BPP_BPTP { get; set; }

        [Required]
        [MaxLength(1)]
        public String U_BPP_BPTD { get; set; }

        [Required]
        public Int32 PayTermsGrpCode { get; set; }

        [XmlArray("ContactEmployees")]
        public List<ContactEmployeeXMLModel> ContactEmployees { get; set; }

        [XmlArray("BPAddresses")]
        public List<BPAddressXMLModel> BPAddresses { get; set; }

    }






}
