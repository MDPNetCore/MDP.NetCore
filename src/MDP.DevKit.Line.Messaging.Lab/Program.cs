using System;
using System.IO;
using System.Threading.Tasks;
using MDP.DevKit.LineMessaging;

namespace MDP.DevKit.Line.Messaging.Lab
{
    public class Program
    {
        // Methods
        public static void Run(MessageContext messageContext)
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(messageContext);

            #endregion

           
            // Display
            Console.WriteLine("123");
        }

        public static void Main(string[] args)
        {
            // Host
            MDP.NetCore.Host.Run<Program>(args);
        }
    }
}
