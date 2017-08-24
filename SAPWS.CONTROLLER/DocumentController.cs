using SAPbobsCOM;
using SAPWS.HELPER;
using SAPWS.LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.CONTROLLER
{
    public class DocumentController : BaseController
    {
        public virtual ApplicationResponse AddUpdateDocument(ApplicationDocumentType documentType, String xml)
        {
            try
            {
                new DocumentLogic().AddUpdateDocument(ConnectAndGetCompany(), documentType, xml);
                return CreateResponseSuccessDocEntry();
            }
            catch (Exception ex)
            {
                return CreateResponseError(ex);
            }
        }

        public ApplicationResponse CancelDocument(ApplicationDocumentType documentType, String xml)
        {
            return new ApplicationResponse();
        }
    }
}
