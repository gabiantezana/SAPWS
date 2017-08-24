using SAPbobsCOM;
using SAPWS.EXCEPTION;
using SAPWS.HELPER;
using SAPWS.VIEWMODEL.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.DATAACCESS
{

    public class DocumentDataAccess
    {
        private Boolean Save { get; set; }

        #region SAPDataAccess

        #region AddUpdateDocument

        public void AddUpdateDocument(Company company, DocumentViewModel model)
        {
            Documents document = company.GetBusinessObject((BoObjectTypes)model.ObjectType);

            if (model.IsUpdate)
                document.GetByKey(model.DocEntry);

            document.DocumentSubType = model.DocumentSubType;
            document.DocType = model.DocumentType;
            document.CardCode = model.CardCode;
            document.DocCurrency = model.DocCurrency;
            document.DocDate = model.DocDate;
            document.DocDueDate = model.DocDueDate;
            document.TaxDate = model.TaxDate;
            document.PaymentGroupCode = model.PaymentGroupCode;
            document.Comments = model.Comments;
            document.Series = model.Series;
            document.DiscountPercent = model.DiscountPercent;

            SetUserFields(model, ref document);

            model.DocumentLines.ForEach(x => AddUpdateDocumentLine(x, ref document));


            if (model.IsUpdate)
                Save = document.Update() == ConstantHelper.SuccessSaveSap;
            else
                Save = document.Add() == ConstantHelper.SuccessSaveSap;
            if (!Save)
                throw new SapException();
        }

        private void AddUpdateDocumentLine(DocumentLineViewModel model, ref Documents document)
        {
            if (model.BaseEntry != ConstantHelper.INT_EMPTY && model.BaseEntry != default(Int32))
            {
                document.Lines.BaseEntry = model.BaseEntry;
                document.Lines.BaseType = model.BaseType;
                document.Lines.BaseLine = model.LineNum;
            }

            document.Lines.ItemCode = model.ItemCode;
            document.Lines.UnitPrice = model.UnitPrice;
            document.Lines.Price = model.Price;
            document.Lines.Quantity = model.Quantity;
            document.Lines.LineTotal = model.LineTotal;
            document.Lines.TaxCode = model.TaxCode;
            document.Lines.WarehouseCode = model.WarehouseCode;
            document.Lines.CostingCode = model.CostingCode;
            document.Lines.CostingCode2 = model.CostingCode2;
            document.Lines.CostingCode3 = model.CostingCode3;

            SetUserFields(model, ref document);

            document.Lines.Add();
        }

        public virtual void SetUserFields(DocumentViewModel model, ref Documents document)
        {
            foreach (PropertyInfo property in ReflectionHelper.GetSAPUserFieldsProperties(model))
            {
                try { document.UserFields.Fields.Item(property.Name).Value = property.GetValue(model, null); }
                catch (Exception ex) { { ExceptionHelper.LogException(ex); } }
            }
        }

        public virtual void SetUserFields(DocumentLineViewModel model, ref Documents document)
        {
            foreach (PropertyInfo property in ReflectionHelper.GetSAPUserFieldsProperties(model))
            {
                try { document.Lines.UserFields.Fields.Item(property.Name).Value = property.GetValue(model, null); }
                catch (Exception ex) { { ExceptionHelper.LogException(ex); } }
            }
        }

        #endregion

        #region CancellDocument

        public void CancelDocument(Company company, DocumentViewModel model)
        {
            if (DocumentExists(company, model.ObjectType, model.DocEntry, true))
            {
                Documents baseDocument = company.GetBusinessObject((BoObjectTypes)model.ObjectType);
                UpdateFieldsBaseDocumentToCancell(company, baseDocument);

                Documents cancellationDocument = CreateCancellationDocument(baseDocument);

                Save = cancellationDocument.Add() == ConstantHelper.SuccessSaveSap;
                if (!Save)
                    throw new SapException();
            }
        }

        private Documents CreateCancellationDocument(Documents baseDocument)
        {
            Documents cancellationDocument = baseDocument.CreateCancellationDocument();
            if (cancellationDocument != null)
            {
                cancellationDocument.DocDate = baseDocument.DocDate;
                return cancellationDocument;
            }
            else
                throw new CustomException("Impossible to create cancellation document for this base document. DocEntry: " + baseDocument.DocEntry);
        }

        #endregion

        #region General Methods

        public Boolean DocumentExists(Company company, BoObjectTypes documentType, Int32 docEntry, Boolean throwIfNull = false)
        {
            Documents document = GetDocumentByKey(company, documentType, docEntry, throwIfNull);
            if (document == null)
                return false;
            else
                return true;
        }

        public Documents GetDocumentByKey(Company company, BoObjectTypes documentType, Int32 docEntry, Boolean throwIfNull = false)
        {
            Documents document = company.GetBusinessObject(documentType);
            Boolean exists = document.GetByKey(docEntry);

            if (exists)
                return document;
            if (throwIfNull)
                throw new CustomException("Document with docEntry: '" + docEntry + "' does not exists.");

            return null;
        }

        #endregion

        #endregion

        #region Queries

        public Fields GetDocumentSeries(Company company, String codigoTienda, BoObjectTypes objectType, BoDocumentSubType documentSubType = BoDocumentSubType.bod_None, String docTypeBase = null)
        {
            String query = new QueryConstructorHelper(company.DbServerType).GetDocumentSeries(codigoTienda, objectType, documentSubType, docTypeBase);
            var _object = ExecuteRecordSet(company, query);
            return _object;
        }

        public Fields GetDocEntry(Company company, String tipoDocumento, String serieDocumento, String correlativoDocumento)
        {
            String query = new QueryConstructorHelper(company.DbServerType).GetDocEntry(tipoDocumento, serieDocumento, correlativoDocumento);
            var _object = ExecuteRecordSet(company, query);
            return _object;
        }

        private Fields UpdateFieldsBaseDocumentToCancell(Company company, Documents baseDocument)
        {
            String query = new QueryConstructorHelper(company.DbServerType).UpdateFieldsCancellDocument(baseDocument);
            var _object = ExecuteRecordSet(company, query);
            return _object;
        }


        private Fields ExecuteRecordSet(Company company, String query, Boolean throwIfNull = false)
        {
            Fields response = null;
            try
            {
                Recordset recordSet = company.GetBusinessObject(BoObjectTypes.BoRecordset);
                recordSet.DoQuery(query);
                response = recordSet.Fields;
                return response;
            }
            catch (Exception ex)
            {
                if (throwIfNull)
                    throw ex;
                return response;
            }
            finally
            {
                //TODOG: CLEAN OBJECT
            }
        }

        #endregion

    }
}
