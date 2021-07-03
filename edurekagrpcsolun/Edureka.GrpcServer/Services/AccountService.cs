using Edureka.GrpcServer.Data;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edureka.GrpcServer.Services
{
    public class AccountService : Account.AccountBase
    {
        private readonly IStoreRepository _repository;

        public AccountService(IStoreRepository repository)
        {
            _repository = repository;
        }
        public override async Task GetAccounts(EmptyModel request,
            IServerStreamWriter<AccountModel> responseStream,
            ServerCallContext context)
        {
            var data = await _repository.GetAccounts();
            foreach (var item in data)
            {
                await Task.Delay(2000);
                await responseStream.WriteAsync(new AccountModel
                {
                    CustomerId = item.CustomerId,
                    AccountHolderName = item.AccountHolderName,
                    AccountNumber = item.AccountNumber,
                    Address = item.Address,
                    MobileNumber = item.Address,
                    Balance = item.Balance,
                    TypeofAccount = item.TypeOfAccount
                });
            }

        }

        public override async Task<EmptyModel> AddAccount(AccountModel request,
          ServerCallContext context)
        {
            await _repository.AddAccount(new AccountInformation
            {
                CustomerId = request.CustomerId,
                AccountHolderName = request.AccountHolderName,
                Address = request.Address,
                Balance = request.Balance,
                MobileNumber = request.MobileNumber,
                TypeOfAccount = request.TypeofAccount
            });
            return new EmptyModel();
        }

        public override async Task<EmptyModel> DeleteAccount(AccountNumberModel request,
        ServerCallContext context)
        {
            await _repository.DeleteAccount(request.AccountNumber);
            return new EmptyModel();
        }

        public override async Task<EmptyModel> UpdateAccount(AccountModel request,
       ServerCallContext context)
        {
            await _repository.UpdateAccount(new AccountInformation
            {
                CustomerId = request.CustomerId,
                AccountNumber = request.AccountNumber,
                AccountHolderName = request.AccountHolderName,
                Address = request.Address,
                Balance = request.Balance,
                MobileNumber = request.MobileNumber,
                TypeOfAccount = request.TypeofAccount
            });
            return new EmptyModel();
        }

    }
}
