using SAPWS.EXCEPTION;
using SAPWS.HELPER;
using SAPWS.LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.CONTROLLER
{
    public class BusinessPartnerController : BaseController
    {
        public ApplicationResponse AddUpdateBusinessPartner(String xml)
        {
            try
            {
                new BusinessPartnerLogic().AddUpdateBusinessPartner(ConnectAndGetCompany(), xml);
                return CreateResponseSuccess();
            }
            catch (Exception ex)
            {
                return CreateResponseError(ex);
            }
        }
    }
}
