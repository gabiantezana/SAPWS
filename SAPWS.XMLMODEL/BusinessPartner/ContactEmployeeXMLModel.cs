using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.XMLMODEL.BusinessPartner
{
    [XmlType("ContactEmployee")]
    public class ContactEmployeeXMLModel
    {
        [MaxLength(50)]
        public String Name { get; set; }

        [MaxLength(20)]
        public String Phone1 { get; set; }

        [MaxLength(20)]
        public String Phone2 { get; set; }

        [MaxLength(20)]
        public String MobilePhone { get; set; }

        [MaxLength(100)]
        public String E_Mail { get; set; }

        [MaxLength(100)]
        public String Gender { get; set; }

    }
}
