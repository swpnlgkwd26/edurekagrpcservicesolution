using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edureka.GrpcServer.Data
{
    public class AccountDBRepository : IStoreRepository
    {
        private readonly EdurekaDBContext _context;

        public AccountDBRepository(EdurekaDBContext context)
        {
            _context = context;
        }

        public Task<List<AccountInformation>> GetAccounts()
        {
            return Task.FromResult(_context.Accounts.ToList());
        }
        public async Task AddAccount(AccountInformation account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAccount(int accountNumber)
        {
            var account = _context.Accounts.Single(p => p.AccountNumber == accountNumber);// Find
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
         
        }
        public IEnumerable<AccountInformation> GetAccount(string accountType)
        {
            var accounts = _context.Accounts.Where(x => x.TypeOfAccount == accountType);
            return accounts;
        }
        public async Task<AccountInformation> GetAccountByNumber(int accountNumber)
        {
            return await _context.Accounts.FindAsync(accountNumber);
        }
        public async Task UpdateAccount(AccountInformation account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
