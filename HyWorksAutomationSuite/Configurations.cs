using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HyWorksAutomationSuite
{
    [XmlRootAttribute("HyWorksConfig")]
    public class HyWorksConfig
    {
        [XmlElement("LoginDetails")]
        public LoginDetails[] LoginList { get; set; }
        public SessionProvider SessionProvider { get; set; }
    }
    public class LoginDetails
    {
        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class SessionProvider
    {
        public string SharedProviderCount { get; set; }
        [XmlElement("SharedProviders")]
        public SharedProvider[] RDSDetailList { get; set; }
    }
    public class SharedProvider
    {
        public string Name { get; set; }
        public string HostAddress { get; set; }
        public string Weight { get; set; }
        public string MaxSession { get; set; }
    }
    public class Serializer
    {
        public T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
