using CoreWCF;
using System;
using System.Runtime.Serialization;

namespace chat_wcf
{
    public class Service : IService
    {
	public string Echo(string text)
        {
            System.Console.WriteLine($"Received {text} from client!");
            return text;
        }

        public string ComplexEcho(EchoMessage text)
        {
            System.Console.WriteLine($"Received {text.Text} from client!");
            return text.Text;
        }

        public string FailEcho(string text)
            => throw new FaultException<EchoFault>(new EchoFault() { Text = "WCF Fault OK" }, new FaultReason("FailReason"));

        [AuthorizeRole("CoreWCFGroupAdmin")]
        public string EchoForPermission(string echo)
        {
            return echo;
        }
    }
}
