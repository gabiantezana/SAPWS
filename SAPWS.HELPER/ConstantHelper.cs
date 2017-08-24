using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.HELPER
{
    public class ConstantHelper
    {
        public static String RESPONSE_FORMAT = "text/xml";
        public static class TipoDocumento
        {
            public static string BOLETA = "01";
            public static string FACTURA = "01";
            public static string NOTA_CREDITO = "01";
            public static string NOTA_DEBITO = "01";
        }

        public const Int32 SuccessSaveSap = 0;

        public static class CardType
        {
            public const string cCustomer = "cCustomer";
            public const string cSupplier = "cSupplier";
            public const string cLid = "cLid";
        }

        public static class AddressType
        {
            public const string bo_BillTo = "bo_BillTo";
            public const string bo_ShipTo = "bo_ShipTo";
        }


        #region Parameter
        public static class Parameter
        {
            public static class Connection
            {
                public static string CompanyServer = "CompanyServer";
                public static string LicenseServer = "LicenseServer";
                public static string DBServerType = "DBServerType";
                public static string DBUserName = "DBUserName";
                public static string DBUserPass = "DBUserPass";
                public static string CompanyDB = "CompanyDB";
                public static string B1UserName = "B1UserName";
                public static string B1UserPass = "B1UserPass";
                public static string languaje = "languaje";
            }
        }

        public static String ParametersName = "name";
        public static String ParameterValue = "value";
        public static String ParameterPath = "../Parameters/ConnectionParameters.xml";

        #endregion

        public const String ResponseLanguaje = "EN-US";
        public const String UserFieldNameStarsWith = "U_";
        public const String DateFormat = "yyyyMMdd";

        public static class Moneda
        {
            public const String USD = "USD";
            public const String SOL = "SOL";
        }

        public static class DocType
        {
            public const String Factura = "01";
            public const String Boleta = "03";
        }

        public static class UserTableNames
        {
            public const String Tienda = "Tienda";
        }
        public static class SAPTableNames
        {
            public const String ORIN = "ORIN";
            public const String OINV = "OINV";
        }
        public static class SAPConstants
        {
            public static class Currency
            {
                public const  String USD = "USD";
                public const String SOL = "SOL";
            }
        }

        public static class UDOSeriesDocumentTypeNames
        {
            public const String FACTURA = "FA";
            public const String BOLETA = "BL";
            public const String NOTACREDITO = "NC";
            public const String NOTADEBITO = "ND";
            public const String PAGORECIBIDO = "PR";

        }
        public static String XMLConnectionFileName = "//ConnectionParameters//ConnectionParameters.xml";

        public static Int32 INT_EMPTY = -1;

        public static class KEYS
        {
            public static String SAPCOMMPANYISCONSTANT = "SAPCOMMPANYISCONSTANT";
            public static String TESTWITHOUTCONNECTTOSAP = "TESTWITHOUTCONNECTTOSAP";
            
        }

        public static class InventoryDocumentType
        {
            public const String fo_GoodsReceipt = "fo_GoodsReceipt";
            public const String fo_GoodsIssue = "fo_GoodsIssue";
        }

        public static String SuccessMessage = "Successful operation.";
    }
}
