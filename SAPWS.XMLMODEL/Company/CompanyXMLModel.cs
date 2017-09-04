using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SAPWS.VIEWMODEL.Company
{
    [XmlRoot("object")]
    public class CompanyXMLModel
    {
        public Boolean? XMLAsString { get; set; } = null;
        public String Server { get; set; } = String.Empty;
        public String LicenseServer { get; set; } = String.Empty;
        public String DbServerType { get; set; } = String.Empty;
        public String DbUserName { get; set; } = String.Empty;
        public String DbPassword { get; set; } = String.Empty;
        public String CompanyDB { get; set; } = String.Empty;
        public String UserName { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        public String language { get; set; } = String.Empty;
        public Boolean? UseTrusted { get; set; } = null;

        public CompanyXMLModel() { }
    }
}
