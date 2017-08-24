using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using SAPWS.EXCEPTION;

namespace SAPWS.HELPER
{
    public class QueryConstructorHelper
    {
        #region  InternalMethods

        private BoDataServerTypes dbSAPServerType { get; set; }
        public QueryConstructorHelper(BoDataServerTypes dbServerType)
        {
            this.dbSAPServerType = dbServerType;
        }
        private String QueryResponse()
        {
            switch (dbSAPServerType)
            {
                case BoDataServerTypes.dst_MSSQL2005:
                case BoDataServerTypes.dst_MSSQL2008:
                case BoDataServerTypes.dst_MSSQL2012:
                case BoDataServerTypes.dst_MSSQL2014:
                case BoDataServerTypes.dst_MSSQL:
                    return SQLQuery;
                case BoDataServerTypes.dst_HANADB:
                    return HanaQuery;
                default:
                    throw new CustomException("DbServerType Company not supported for queries.");
            }
        }
        private String SQLQuery;
        private String HanaQuery;

        #endregion

        #region Queries

        public String GetDocumentSeries(String codigoTienda, BoObjectTypes objectType, BoDocumentSubType documentSubType = BoDocumentSubType.bod_None, String docTypeBase = null)
        {
            String documentStringName = String.Empty;
            String baseDocumentType = String.Empty;

            switch (objectType)
            {
                case BoObjectTypes.oInvoices:
                    documentStringName = ConstantHelper.UDOSeriesDocumentTypeNames.FACTURA;
                    switch (documentSubType)
                    {
                        case BoDocumentSubType.bod_Bill:
                            documentStringName = ConstantHelper.UDOSeriesDocumentTypeNames.BOLETA;
                            break;
                        case BoDocumentSubType.bod_DebitMemo:
                            documentStringName = ConstantHelper.UDOSeriesDocumentTypeNames.NOTADEBITO;
                            baseDocumentType = docTypeBase;
                            break;
                    }
                    break;

                case BoObjectTypes.oCreditNotes:
                    documentStringName = ConstantHelper.UDOSeriesDocumentTypeNames.NOTACREDITO;
                    baseDocumentType = docTypeBase;
                    break;

                default:
                    throw new CustomException("Document Series method is not implemmented for this objectType: " + objectType);
            }

            if ((objectType == BoObjectTypes.oCreditNotes || documentSubType == BoDocumentSubType.bod_DebitMemo)
                && String.IsNullOrEmpty(baseDocumentType))
                throw new CustomException("A value is required for U_BPP_MDTO field.");


            SQLQuery = "select b.U_MSS_SSAP FROM [@MSS_SDVC] a join [dbo].[@MSS_SDVD] b " +
                                   " ON a.DocEntry = b.DocEntry " +
                                   " where " +
                                   " a.U_MSS_CODE = '" + documentStringName + "'" +
                                   " and b.U_MSS_TIDA = '" + codigoTienda + "'" +
                                   (String.IsNullOrEmpty(docTypeBase) ? "" : "and b.U_MSS_TDBA = '" + docTypeBase + "'");

            HanaQuery = "select b.U_MSS_SSAP FROM [@MSS_SDVC] a join [dbo].[@MSS_SDVD] b " +
                               " ON a.DocEntry = b.DocEntry " +
                               " where " +
                               " a.U_MSS_CODE = '" + documentStringName + "'" +
                               " and b.U_MSS_TIDA = '" + codigoTienda + "'" +
                               (String.IsNullOrEmpty(docTypeBase) ? "" : "and b.U_MSS_TDBA = '" + docTypeBase + "'");

            return QueryResponse();
        }

        public String GetDocEntry(String tipoDocumento, String serieDocumento, String correlativoDocumento)
        {
            String documentStringName = String.Empty;
            String baseDocumentType = String.Empty;

            SQLQuery = "SELECT DOCENTRY FROM OINV WHERE U_BPP_MDTD='" + tipoDocumento + "' and U_BPP_MDSD='" + serieDocumento + "' and U_BPP_MDCD ='" + correlativoDocumento + "'";
            HanaQuery = "SELECT DOCENTRY FROM OINV WHERE U_BPP_MDTD='" + tipoDocumento + "' and U_BPP_MDSD='" + serieDocumento + "' and U_BPP_MDCD ='" + correlativoDocumento + "'";

            return QueryResponse();
        }

        public String UpdateFieldsCancellDocument(Documents document)
        {
            String tableName = String.Empty;
            switch (document.DocObjectCode)
            {
                case BoObjectTypes.oInvoices:
                    tableName = ConstantHelper.SAPTableNames.OINV;
                    break;
                case BoObjectTypes.oCreditNotes:
                    tableName = ConstantHelper.SAPTableNames.ORIN;
                    break;
            }

            SQLQuery = "UPDATE " + tableName + " SET Indicator = 'DI', FolioPref = NULL, ";
            SQLQuery += "FolioNum = NULL WHERE DocEntry = " + document.DocEntry.ToString();

            HanaQuery = "UPDATE \"" + tableName + "\" SET \"Indicator\" = 'DI', \"FolioPref\" = NULL, ";
            HanaQuery += "\"FolioNum\" = NULL WHERE \"DocEntry\" = " + document.DocEntry.ToString();

            return QueryResponse();
        }

        public String GetBPAddressLineNum(String cardCode, String bpAddressName)
        {
            SQLQuery = "select LineNum from crd1 where Address='" + cardCode + "' and CardCode='" + bpAddressName + "'";
            HanaQuery = "select LineNum from crd1 where Address='" + cardCode + "' and CardCode='" + bpAddressName + "'";
            return QueryResponse();
        }

        public String GetContactEmployeeLineNum(String cardCode, String contactEmployeeName)
        {
            SQLQuery = "select LineNum from ocpr where Address='" + cardCode + "' and CardCode='" + contactEmployeeName + "'";
            HanaQuery = "select LineNum from ocpr where Address='" + cardCode + "' and CardCode='" + contactEmployeeName + "'";
            return QueryResponse();
        }

        public String GetCashAccountForIncommingPayment(String medioPagoSAP, String currency)
        {
            SQLQuery = "SELECT y.AcctCode FROM [dbo].[@MSS_CCPR] x  join oact y " +
                       "on x.u_mss_ctac = y.FormatCode " +
                       "where X.U_MSS_MPSP = '" + medioPagoSAP + "' AND X.U_MSS_MONE = '" + currency + "'";
            HanaQuery = String.Empty;
            return QueryResponse();
        }

        #endregion

    }
}
