using SAPWS.EXCEPTION;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SAPWS.HELPER
{
    public static class ConvertHelper
    {
        public static void ConvertToObject(ref Object _object, Type type)
        {

        }

        public static Object GetValueFromXMlNode(Object _object)
        {
            try
            {
                XmlNode[] xmlNode = (XmlNode[])_object;
                return xmlNode[0].Value;
            }
            catch (Exception ex)
            {
                //TODO:
                throw new CustomException("Error al obtener valor de nodo xml: " + ex.Message);
            }
        }

        public static String ToSafeString(this object val)
        {
            return (val ?? String.Empty).ToString();
        }

        public static string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression)expr.Body;

            return body.Member.Name;
        }

        public static Int32 ToInt32(Object value)
        {
            Int32 response = default(Int32);
            try
            {
                response = Convert.ToInt32(value);
                return response;
            }
            catch (Exception ex)
            {
                throw new CustomException("Parse error value: " + value.ToSafeString());
            }
        }

        public static DateTime ToDate(String value)
        {
            try
            {
                return DateTime.ParseExact(value.ToSafeString(), ConstantHelper.DateFormat, null);
            }
            catch (Exception ex)
            {
                throw new CustomException("Date parse error. Value: " + value.ToSafeString());
            }

        }
    }
}
