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
        public Boolean? XMLAsString { get; set; }
        public String Server { get; set; }
        public String LicenseServer { get; set; }
        public String DbServerType { get; set; }
        public String DbUserName { get; set; }
        public String DbPassword { get; set; }
        public String CompanyDB { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String language { get; set; }
        public Boolean? UseTrusted { get; set; }

        public CompanyXMLModel()
        {
            XMLAsString = null;
            LicenseServer = String.Empty;
            DbServerType = String.Empty;
            DbUserName = String.Empty;
            DbPassword = String.Empty;
            CompanyDB = String.Empty;
            UserName = String.Empty;
            Password = String.Empty;
            language = String.Empty;
            UseTrusted = null;
        }
    }
}
