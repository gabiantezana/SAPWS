using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SAPWS.XMLMODEL.BusinessPartner
{
    [XmlType("BPAddress")]
    public class BPAddressXMLModel
    {
        [Required]
        [MaxLength(20)]
        public String AddressType { get; set; }

        [Required]
        [MaxLength(50)]
        public String AddressName { get; set; }

        [Required]
        [MaxLength(100)]
        public String Street { get; set; }

        [Required]
        [MaxLength(2)]
        public String Country { get; set; }

        [Required]
        [MaxLength(2)]
        public String State { get; set; }

        [Required]
        [MaxLength(100)]
        public String City { get; set; }

        public String Block { get; set; }

    }
}
