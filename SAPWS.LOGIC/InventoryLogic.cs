using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using SAPWS.HELPER;
using SAPWS.VIEWMODEL.Document;
using SAPWS.XMLMODEL.Document;
using SAPWS.VIEWMODEL;
using SAPWS.DATAACCESS;

namespace SAPWS.LOGIC
{
    public class InventoryLogic : DocumentLogic
    {
        public override void SetDocumentProperties_DisccountPercent(Company company, DocumentViewModel parentModel, ref DocumentLineViewModel model) { }

        public override void SetDocumentProperties_DisccountPercent(Company company, ref DocumentViewModel model) { }

        public override void SetDocumentProperties_Series(Company company, ref DocumentViewModel model) { }

    }
}
