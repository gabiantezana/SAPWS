using SAPWS.DATAACCESS;
using SAPWS.HELPER;
using SAPWS.VIEWMODEL.Company;
using static SAPWS.HELPER.ConstantHelper;
using System;
using SAPWS.VIEWMODEL;
using SAPbobsCOM;
using SAPWS.EXCEPTION;
using System.Configuration;

namespace SAPWS.LOGIC
{
    public class CompanyLogic
    {
        Boolean SapCommpanyIsConstant = Convert.ToBoolean(ConfigurationManager.AppSettings[ConstantHelper.KEYS.SAPCOMMPANYISCONSTANT]);

        public void ConnectCompany(String xml)
        {
            if (String.IsNullOrEmpty(xml))
                ConnectCompanyFromConstantResource();
            else
                ConnectCompanyFromXML(xml);
        }

        private void ConnectCompanyFromConstantResource()
        {
            if (SapCommpanyIsConstant)
            {
                CompanyViewModel model = GetCompanyViewModelFromFile();
                BaseDataAccess.ConnectNewCompany(model);
            }
            else
                throw new CustomException("Application is not defined for work with a company constant.");
        }

        private void ConnectCompanyFromXML(String xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                CompanyViewModel model = CreateViewModel.GenerateViewModel(SerializeHelper.XMLToObject(xml, typeof(CompanyXMLModel)));
                BaseDataAccess.ConnectNewCompany(model);
            }
            else
                throw new CustomException("You need to specify a xml string with your company data");
        }

        public void DisconnectCompany()
        {
            BaseDataAccess.Disconnect();
        }

        public Company ConnectAndGetCurrentCompany()
        {
            CompanyViewModel model = null;

            if (SapCommpanyIsConstant)
            {
                model = GetCompanyViewModelFromFile();
                BaseDataAccess.Connect(model);
                return BaseDataAccess.GetCommpany();
            }
            else
            {
                var currentCompany = BaseDataAccess.GetCommpany();
                if (currentCompany != null)
                {
                    BaseDataAccess.TryConnectCurrentCompany();
                    return BaseDataAccess.GetCommpany();
                }

                throw new CustomException("You need to connect your company before call any transaction method.");
            }
        }

        public SapExceptionEntity GetLastSapError()
        {
            return BaseDataAccess.GetLastSapError();
        }

        public String GetLastDocEntry()
        {
            string sNewObjCode = String.Empty;
            try
            {
                ConnectAndGetCurrentCompany().GetNewObjectCode(out sNewObjCode);
                return sNewObjCode;
            }
            catch (Exception ex)
            {
                sNewObjCode = "Error in GetDocEntry()";
            }
            return sNewObjCode;
        }

        public CompanyViewModel GetCurrentCompany()
        {
            Company company = BaseDataAccess.GetCommpany();
            //TODOG: Not working on server client, just local
            /*CompanyViewModel model = ReflectionHelper.CopyAToB(company, typeof(CompanyViewModel), true);*/

            CompanyViewModel model = new CompanyViewModel();
           
            if (company != null)
            {
                model.CompanyDB = company.CompanyDB;
                model.DbPassword = company.DbPassword;
                model.DbServerType = company.DbServerType;
                model.DbUserName = company.DbUserName;
                model.language = company.language;
                model.LicenseServer = company.LicenseServer;
                model.Password = company.Password;
                model.Server = company.Server;
                model.UserName = company.UserName;
                model.UseTrusted = company.UseTrusted;
                model.XMLAsString = company.XMLAsString;
                model.Connected = company.Connected;
            }
            return model;
        }

        private CompanyViewModel GetCompanyViewModelFromFile()
        {
            String xml = System.IO.File.ReadAllText(XMLParametersPath);
            CompanyViewModel model = CreateViewModel.GenerateViewModel(SerializeHelper.XMLToObject(xml, typeof(CompanyXMLModel)));

            return model;
        }

        private static string XMLParametersPath
        {
            get
            {
                string pathDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string pathArch = System.IO.Path.Combine(pathDir, ConstantHelper.ParameterPath);
                var localPath = new Uri(pathArch).LocalPath;
                return localPath;
            }
        }

    }
}
