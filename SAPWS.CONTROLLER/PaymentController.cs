using SAPWS.HELPER;
using SAPWS.LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.CONTROLLER
{
    public class PaymentController : BaseController
    {
        public ApplicationResponse AddUpdatePayment(ApplicationDocumentType documentType, String xml)
        {
            try
            {
                new PaymentLogic().AddUpdatePayment(ConnectAndGetCompany(), documentType, xml);
                return CreateResponseSuccessDocEntry();
            }
            catch (Exception ex)
            {
                return CreateResponseError(ex);
            }
        }
    }
}
