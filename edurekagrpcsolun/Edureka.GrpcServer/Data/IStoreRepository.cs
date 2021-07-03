using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edureka.GrpcServer.Data
{
    public interface IStoreRepository
    {
        Task<List<AccountInformation>> GetAccounts();
        Task AddAccount(AccountInformation account);
        Task DeleteAccount(int accountNumber);
        Task UpdateAccount(AccountInformation account);
        IEnumerable<AccountInformation> GetAccount(string accountType);
        Task<AccountInformation> GetAccountByNumber(int accountNumber);
    }
}
