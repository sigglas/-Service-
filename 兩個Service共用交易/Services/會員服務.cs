using 兩個Service共用交易.Models.Repository;

namespace 兩個Service共用交易.Services
{
    public class 會員服務
    {
        private readonly 會員Repository repository;

        public 會員服務(會員Repository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> 加入新會員(string 姓名, string 推薦人, int 帳號Id)
        {
            bool result = false;
            if (姓名.Contains("sigg"))
                throw new ArgumentException("不准用我的名字");

            await repository.AddAsync(new Models.EntityModel.會員
            {
                姓名 = 姓名,
                帳號Id = 帳號Id,
                推薦人 = 推薦人
            });
            result = true;
            return result;
        }
    }
}
