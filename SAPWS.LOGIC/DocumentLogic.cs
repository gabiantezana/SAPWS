using SAPbobsCOM;
using SAPWS.DATAACCESS;
using SAPWS.EXCEPTION;
using SAPWS.HELPER;
using SAPWS.VIEWMODEL;
using SAPWS.VIEWMODEL.Document;
using SAPWS.XMLMODEL.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.LOGIC
{
    public class DocumentLogic
    {
        #region Principal Methods

        public virtual void AddUpdateDocument(Company company, ApplicationDocumentType documentType, String xml)
        {
            DocumentViewModel model = CreateViewModel.GenerateViewModel(documentType, SerializeHelper.XMLToObject(xml, typeof(DocumentXMLModel)));

            SetDocumentProperties(company, ref model);
            model.DocumentLines.ForEach(documentLine => SetDocumentProperties(company, model, ref documentLine));

            new DocumentDataAccess().AddUpdateDocument(company, model);
        }

        public virtual void SetDocumentProperties(Company company, ref DocumentViewModel model)
        {
            SetDocumentProperties_Series(company, ref model);
            SetDocumentProperties_DisccountPercent(company, ref model);
        }

        public virtual void SetDocumentProperties(Company company, DocumentViewModel parentModel, ref DocumentLineViewModel model)
        {
            model.LineTotal = model.Price * model.Quantity;
            SetDocumentProperties_DisccountPercent(company, parentModel, ref model);
        }

        #endregion

        #region SetProperties

        public virtual void SetDocumentProperties_Series(Company company, ref DocumentViewModel model)
        {
            model.Series = GetDocumentSeries(company, model, true);
        }

        public virtual void SetDocumentProperties_DisccountPercent(Company company, ref DocumentViewModel model)
        {
            Double SubTotal = model.DocumentLines.Sum(x => (x.Price * x.Quantity));
            Double TotalDocument = 0;
            Double TotalDiscountsApplied = 0;

            switch (model.DocCurrency)
            {
                case ConstantHelper.SAPConstants.Currency.SOL: TotalDiscountsApplied = model.TotalDiscount; break;
                case ConstantHelper.SAPConstants.Currency.USD: TotalDiscountsApplied = model.TotalDiscountFC; break;
            }

            TotalDocument = SubTotal - TotalDiscountsApplied;

            model.DiscountPercent = CalculationHelper.CalculatePercent(SubTotal, TotalDocument);
        }

        public virtual void SetDocumentProperties_DisccountPercent(Company company, DocumentViewModel parentModel, ref DocumentLineViewModel model)
        {
            model.DisccountPercent = CalculationHelper.CalculatePercent(model.UnitPrice, model.Price);
        }

        #endregion

        public void CancelDocument(Company company, ApplicationDocumentType documentType, String xml)
        {
            DocumentXMLModel model = SerializeHelper.XMLToObject(xml, typeof(DocumentXMLModel));
        }

        #region General Methods

        public Int32 GetDocumentSeries(Company company, DocumentViewModel model, Boolean throwIfNull = false)
        {
            Int32 series = default(Int32);
            var response = new DocumentDataAccess().GetDocumentSeries(company, model.U_MSS_TIDA, model.ObjectType, model.DocumentSubType, model.U_BPP_MDTO);
            if (response != null)
                if (response.Count > 0)
                    if (response.Item(0) != null)
                        if (!String.IsNullOrEmpty(response.Item(0).Value))
                        {
                            try
                            {
                                series = Convert.ToInt32(response.Item(0).Value);
                                return series;
                            }
                            catch (Exception ex)
                            {
                                throw new CustomException("Impossible parse value: '" + response.Item(0).Value + "'SAP Series to Int32.");
                            }
                        }
            if (throwIfNull)
                throw new CustomException("Series SAP not found in database");
            else
                return series;
        }

        private Int32 GetDocEntry(Company company, DocumentViewModel model, Boolean throwIfNull = false)
        {
            Int32 docNum = default(Int32);

            var response = new DocumentDataAccess().GetDocEntry(company, model.U_BPP_MDTD, model.U_BPP_MDSD, model.U_BPP_MDCD);
            if (response != null)
                if (response.Count > 0)
                    if (response.Item(0) != null)
                    {
                        var value = response.Item(0).Value;
                        try
                        {
                            docNum = Convert.ToInt32(value);
                            return docNum;
                        }
                        catch (Exception ex)
                        {
                            throw new CustomException("Impossible parse value: '" + response.Item(0).Value + "'DocEntry to Int32.");
                        }
                    }
            if (throwIfNull)
                throw new CustomException("Doc Entry not found in database.");
            else
                return docNum;
        }

        public Documents GetDocumentByKey(Company company, BoObjectTypes documentType, Int32 docEntry, Boolean throwIfNull = false)
        {
            return new DocumentDataAccess().GetDocumentByKey(company, documentType, docEntry, throwIfNull);
        }

        #endregion


    }
}
