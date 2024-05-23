using goods_server.Core.Interfaces;
using goods_server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goods_server.Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>,IAccountRepo
    {
        public AccountRepository(GoodsExchangeApplication2024DbContext dbContext) : base(dbContext) 
        { 

        }
        
    }
}
