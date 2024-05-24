using goods_server.Contracts;
using goods_server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Service.InterfaceService
{
    public interface IAccountService
    {
        Task<AccountDTO?> GetAccountByEmailAsync(string email);

        Task<AccountDTO?> GetAccountByUsernameAsync(string username);

        Task<GetAccountDTO?> GetAccountByEmailAndPasswordAsync(string email, string password);

        Task<bool> CreateAccountAsync(RegisterDTO account);

        Task<IEnumerable<AccountDTO>> SearchAccountsAsync(string username);

        Task<bool> UpdateAccountAsync(int id, UpdateProfileDTO account);

        Task<GetAccountDTO?> GetAccountByIdAsync(int accountId);

        Task<bool> DeleteAccountAsync(int accountId);
    }
}
