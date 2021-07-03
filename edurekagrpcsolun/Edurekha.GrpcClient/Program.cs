using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Edurekha.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

           
            var client = new Account.AccountClient(channel);

            // Update Account
            client.UpdateAccount(new AccountModel
            {
                CustomerId = 110,
                AccountNumber =17,
                AccountHolderName = "Naredra Karmarkar",
                Address = "Kolkata",
                Balance = 21323,
                MobileNumber = "2424",
                TypeofAccount = "Savings"
            });
            Console.WriteLine("Data Modified Successfully Successfully");

            // Delete Account
            client.DeleteAccount(new AccountNumberModel
            {
                AccountNumber=19
            });
            Console.WriteLine("Data Deleted Successfully");

            // Add New Account
            client.AddAccount(new AccountModel
            {
                CustomerId = 110,
                AccountHolderName = "Swapnil Gaikwad",
                Address = "Mumbai",
                Balance = 21323,
                MobileNumber = "2424",
                TypeofAccount = "Savings"
            });
            Console.WriteLine("Data Added Successfully");
            Console.ReadKey();

            // Read All Accounts
            using (var call = client.GetAccounts(new EmptyModel { }))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var currentResult = call.ResponseStream.Current;
                    Console.WriteLine(currentResult.CustomerId + "  "
                        + currentResult.AccountHolderName + " " +
                        currentResult.Address + " "
                        + currentResult.Balance);
                }

            }
            Console.ReadKey();
        }
    }
}
