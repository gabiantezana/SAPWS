using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPWS.HELPER;
using SAPWS.LOGIC;

namespace SAPWS.CONTROLLER
{
    public class InventoryController : DocumentController
    {

        public override ApplicationResponse AddUpdateDocument(ApplicationDocumentType documentType, string xml)
        {
            try
            {
                new InventoryLogic().AddUpdateDocument(ConnectAndGetCompany(), documentType, xml);
                return CreateResponseSuccessDocEntry();
            }
            catch (Exception ex)
            {
                return CreateResponseError(ex);
            }
        }

    }
}
