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
        public String AddressType { get; set; } = String.Empty;

        [Required]
        [MaxLength(50)]
        public String AddressName { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public String Street { get; set; } = String.Empty;

        [Required]
        [MaxLength(2)]
        public String Country { get; set; } = String.Empty;

        [Required]
        [MaxLength(2)]
        public String State { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public String City { get; set; } = String.Empty;

        public String Block { get; set; } = String.Empty;

    }
}
