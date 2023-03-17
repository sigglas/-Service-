using 兩個Service共用交易.Models.Data.Context;

namespace 兩個Service共用交易.Models.Data
{
    public class UnitOfWork
    {
        private readonly ILogger<UnitOfWork> logger;
        private readonly MyContext context;

        public UnitOfWork(
            ILogger<UnitOfWork> logger,
            MyContext context)
        {
            this.logger = logger;
            this.context = context;
        }


        public async Task<bool> CommitByTransactionAsync()
        {
            bool isSaved = false;
            using var conn = await context.Database.BeginTransactionAsync();
            try
            {
                await context.SaveChangesAsync();
                await conn.CommitAsync();
                isSaved = true;
            }
            catch (Exception ex)
            {
                if (isSaved == false)
                {
                    await conn.RollbackAsync();
                }
                logger.LogError(ex, nameof(CommitByTransactionAsync));
            }
            return isSaved;
        }
    }
}
