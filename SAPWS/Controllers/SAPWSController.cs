using SAPWS.CONTROLLER;
using SAPWS.HELPER;
using System;
using System.Web.Mvc;

namespace SAPWS.Controllers
{
    [ValidateInput(false)]
    public class SAPWSController : Controller
    {
        #region Company

        public ActionResult ConnectCompany(String xml = null)
        {
            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new CompanyController().ConnectCompany(xml);

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        public ActionResult GetCurrentCompany()
        {
            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new CompanyController().GetCurrentCompany();

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        public ActionResult DisconnectCompany()
        {
            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new CompanyController().DisconnectCompany();

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        #endregion


        #region Business Partner

        public ActionResult AddUpdateBusinessPartner(String xml)
        {
            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new BusinessPartnerController().AddUpdateBusinessPartner(xml);

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        #endregion

        #region Documents

        public ActionResult AddUpdateInvoice(String xml)
        {

            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new DocumentController().AddUpdateDocument(ApplicationDocumentType.Invoice, xml);

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        public ActionResult AddUpdateCreditNote(String xml)
        {

            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new DocumentController().AddUpdateDocument(ApplicationDocumentType.CreditNote, xml);

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        public ActionResult AddUpdateDebitMemo(String xml)
        {

            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new DocumentController().AddUpdateDocument(ApplicationDocumentType.DebitMemo, xml);

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        public ActionResult AddUpdateInventoryAjusted(String xml)
        {
            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new InventoryController().AddUpdateDocument(ApplicationDocumentType.InventoryAjusted, xml);

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        #endregion

        #region Payments

        public ActionResult AddUpdateIncomingPayment(String xml)
        {

            Response.ContentType = ConstantHelper.RESPONSE_FORMAT;
            var response = new PaymentController().AddUpdatePayment(ApplicationDocumentType.IncomingPayments, xml);

            return Content(SerializeHelper.GetXMLFromObject(response));
        }

        #endregion
    }
}