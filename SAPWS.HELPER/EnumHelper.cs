using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWS.HELPER
{
    class EnumHelper
    {
    }
    public enum ResponseStatus
    {
        Success = 0,
        Error = 1
    }

    public enum ResponseType
    {
        Message = 1,
        Object = 2,
    }

    public enum ResponseObjectType
    {
        None = 0,
        DocEntry = 1,
        Dynamic = 2
    }

    public enum ResponseTypes
    {
        XMLResponse = 1,
        ObjectResponse = 2,
        XMLObjectResponse = 3,
        NoResponse = 4
    }

    public enum MessageTypes
    {
        None = 0,
        Success = 1,
        Errors = 2,
        Warnings = 3,
        Information = 4
    }

    public enum ApplicationDocumentType
    {
        Invoice = 1,
        CreditNote = 2,
        DebitMemo = 3,
        IncomingPayments = 4,
        InventoryAjusted = 5
    }

    public enum _DocumentType
    {
        Boleta = 1,
        Factura = 2,
        NotaCredito = 3,
        NotaDebito = 4
    }
}
