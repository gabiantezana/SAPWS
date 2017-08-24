using SAPbobsCOM;
using SAPWS.LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPWS.HELPER;
using SAPWS.EXCEPTION;

namespace SAPWS.CONTROLLER
{
    public class CompanyController : BaseController
    {
        public CompanyController()
        {
            DisconnectCompanyAfterOutMethod = false;
        }
        #region ApplicationResponse

        public ApplicationResponse ConnectCompany(String xml)
        {
            try
            {
                new CompanyLogic().ConnectCompany(xml);
                return CreateResponseSuccess();
            }
            catch (Exception ex)
            {
                return CreateResponseError(ex);
            }
        }

        public ApplicationResponse GetCurrentCompany()
        {
            try
            {
                CompanyLogic logic = new CompanyLogic();
                var model = logic.GetCurrentCompany();
                return CreateResponseSuccessWithObject(model);
            }
            catch (Exception ex)
            {
                return CreateResponseError(ex);
            }
        }

        public ApplicationResponse DisconnectCompany()
        {
            try
            {
                new CompanyLogic().DisconnectCompany();
                return CreateResponseSuccess();
            }
            catch (Exception ex)
            {
                return CreateResponseError(ex);
            }
        }

        #endregion
    }

}
