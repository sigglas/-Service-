using 兩個Service共用交易.Models.Repository;

namespace 兩個Service共用交易.Services
{
    public class 帳號服務
    {
        private readonly 帳號Repository repository;

        public 帳號服務(帳號Repository repository)
        {
            this.repository = repository;
        }

        public async Task<(bool 成功否, int? 帳號id)> 加入新帳號(string 帳號名稱, string 密碼)
        {
            var 已存在的帳號 = await repository.GetByAccountAsync(帳號名稱);
            if (已存在的帳號 is null)
            {
                var entity = await repository.AddAsync(new Models.EntityModel.帳號
                {
                    密碼 = 密碼,
                    帳號名稱 = 帳號名稱
                });
                return (true, entity.Id);
            }
            else
                return (false, null);
        }
    }
}
