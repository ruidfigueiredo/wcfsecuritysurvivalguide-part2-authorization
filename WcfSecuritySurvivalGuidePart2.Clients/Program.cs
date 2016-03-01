using System;
using System.ServiceModel;
using WCFSecuritySurvivalGuidePart2.Services;

namespace WcfSecuritySurvivalGuidePart2.Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var cf = new ChannelFactory<IUserInformationService>("*"))
                {
                    cf.Credentials.UserName.UserName = "johndoe";
                    cf.Credentials.UserName.Password = "P@ssw0rd";
                    var proxy = cf.CreateChannel();

                    var userInfo = proxy.GetUserInfo();

                    Console.WriteLine(new string('-', 79));
                    Console.WriteLine("Username: " + userInfo.UserName);
                    Console.WriteLine("Thead.CurrentPrincipal.Identity.Name: " + userInfo.UserName);
                    foreach (var role in userInfo.Roles)
                        Console.WriteLine("\t" + role);
                    Console.WriteLine(new string('-', 79));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var inner = ex.InnerException;
                while (inner != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t" + inner.Message);
                    inner = inner.InnerException;
                }
            }

            Console.ReadLine();
        }

    }
}
