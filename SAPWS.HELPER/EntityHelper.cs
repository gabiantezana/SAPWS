using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SAPWS.HELPER
{
    public class EntityHelper
    {

    }



    #region ApplicationResponse
    public class ApplicationResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public ResponseType ResponseType { get; set; }
        public Int32 ResponseCount { get; set; }
        public Response Response { get; set; }
        public String ResponseTime { get; set; }

        public ApplicationResponse()
        {
            //TODOG:
            ResponseCount = 1;
            ResponseTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        }
    }

    public class Response
    {
        public Int32? Code { get; set; }
        //public Boolean IsSapException { get; set; }
        public Message Message { get; set; }
    }

    public class Message
    {
        public Message()
        {
            this.Lang = ConstantHelper.ResponseLanguaje;
        }

        public String Lang { get; set; }
        public String Text { get; set; }
        public XElement Object { get; set; }
       
    }

    public class Value
    {
        public Object Model { get; set; }
        public String DocEntry { get; set; }
        public String ErrorMessage { get; set; }
    }

    #endregion

}
