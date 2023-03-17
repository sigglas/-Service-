using Microsoft.EntityFrameworkCore;
using 兩個Service共用交易.Models.Data.Context;
using 兩個Service共用交易.Models.EntityModel;

namespace 兩個Service共用交易.Models.Repository
{
    public class 帳號Repository
    {
        private readonly MyContext _context;

        public 帳號Repository(MyContext context)
        {
            _context = context;
        }

        public async Task<帳號?> GetByIdAsync(int id)
        {
            return await _context.帳號s.FindAsync(id);
        }

        public async Task<帳號?> GetByAccountAsync(string 帳號名稱)
        {
            return await _context.帳號s.Where(w => w.帳號名稱 == 帳號名稱).FirstOrDefaultAsync();
        }

        public async Task<帳號> AddAsync(帳號 帳號)
        {
            var _ = await _context.帳號s.AddAsync(帳號);
            return _.Entity;
            //await _context.SaveChangesAsync();
        }
    }
}
