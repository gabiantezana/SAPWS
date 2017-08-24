using SAPbobsCOM;
using SAPWS.EXCEPTION;
using SAPWS.HELPER;
using SAPWS.LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPWS.VIEWMODEL;
using SAPWS.VIEWMODEL.BusinessPartner;
using SAPWS.VIEWMODEL.Document;
using SAPWS.VIEWMODEL.Company;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Configuration;

namespace SAPWS.CONTROLLER
{
    public class BaseController
    {
        private static Boolean SapCommpanyIsConstant { get { return Convert.ToBoolean(ConfigurationManager.AppSettings[ConstantHelper.KEYS.SAPCOMMPANYISCONSTANT]); } }
        private static Boolean TESTWITHOUTCONNECTTOSAP { get { return Convert.ToBoolean(ConfigurationManager.AppSettings[ConstantHelper.KEYS.TESTWITHOUTCONNECTTOSAP]); } }
        public static Boolean DisconnectCompanyAfterOutMethod = SapCommpanyIsConstant ? false : true;

        public static Company ConnectAndGetCompany()
        {
            if (TESTWITHOUTCONNECTTOSAP)
                return new Company();
            return new CompanyLogic().ConnectAndGetCurrentCompany();
        }

        private static SapExceptionEntity GetLastSapError()
        {
            return new CompanyLogic().GetLastSapError();
        }

        private static String GetLastDocEntry()
        {
            string sNewObjCode = String.Empty;
            try
            {
                ConnectAndGetCompany().GetNewObjectCode(out sNewObjCode);
                return sNewObjCode;
            }
            catch (Exception ex)
            {
                sNewObjCode = "Error in GetDocEntry()";
            }
            return sNewObjCode;
        }

        #region General ApplicationResponse

        public static ApplicationResponse CreateResponseSuccess(String message = null)
        {
            GenerateResponse();
            return ResponseHelper.CreateResponseSuccess(message);
        }

        public static ApplicationResponse CreateResponseSuccessDocEntry()
        {
            GenerateResponse();
            return ResponseHelper.CreateResponseSuccessDocEntry(GetLastDocEntry());
        }

        public static ApplicationResponse CreateResponseSuccessWithObject(Object message = null)
        {
            GenerateResponse();
            return ResponseHelper.CreateResponseSuccessWithObject(message);
        }

        public static ApplicationResponse CreateResponseError(Exception ex)
        {
            GenerateResponse();

            Type exceptionType = ex.GetType();

            try
            {
                ExceptionHelper.LogException(ex);

                String errorMessage = ex.Message;
                Int32? errorCode = null;
                Object objectToShow = null;

                if (exceptionType == typeof(SapException))
                {
                    SapExceptionEntity sapError = GetLastSapError();
                    errorMessage = sapError.errorMessage;
                    errorCode = sapError.errorCode;
                }

                else if (exceptionType == typeof(COMException))
                {
                    errorMessage = ((COMException)ex).Message;
                    errorCode = ((COMException)ex).ErrorCode;
                }

                else if (exceptionType == typeof(CustomException))
                {
                    objectToShow = ((CustomException)ex).o;
                    errorMessage = ((CustomException)ex).Message;
                    errorCode = -9999; //TODOG:
                }
                else
                {
                    if (ex.InnerException != null)
                        errorMessage += " " + ex.InnerException.Message;

                    var w32ex = ex as Win32Exception;
                    if (w32ex == null)
                        w32ex = ex.InnerException as Win32Exception;
                    if (w32ex != null)
                        errorCode = w32ex.ErrorCode;
                }

                return ResponseHelper.CreateResponseError(errorMessage, errorCode, objectToShow);
            }
            catch (Exception ex2)
            {
                ExceptionHelper.LogException(ex2);
                return ResponseHelper.CreateResponseError(ex2.Message);
            }

        }

        private static void GenerateResponse()
        {
            if (DisconnectCompanyAfterOutMethod)
                new CompanyLogic().DisconnectCompany();

            DisconnectCompanyAfterOutMethod = SapCommpanyIsConstant ? false : true;
        }

      
        #endregion

    }
}
