using Microsoft.EntityFrameworkCore;
using 兩個Service共用交易.Models.Data.Context;
using 兩個Service共用交易.Models.EntityModel;

namespace 兩個Service共用交易.Models.Repository
{
    public class 會員Repository
    {
        private readonly MyContext _context;

        public 會員Repository(MyContext context)
        {
            _context = context;
        }

        public async Task<會員?> GetByIdAsync(int id)
        {
            return await _context.會員s.FindAsync(id);
        }

        public async Task<會員> AddAsync(會員 會員)
        {
            var _ = await _context.會員s.AddAsync(會員);
            return _.Entity;
            //await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(會員 會員)
        {
            _context.Entry(會員).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }
    }
}
