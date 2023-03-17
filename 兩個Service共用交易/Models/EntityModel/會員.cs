namespace 兩個Service共用交易.Models.EntityModel
{
    public class 會員
    {
        public int Id { get; set; }

        public int 帳號Id { get; set; }

        public string 姓名 { get; set; } = null!;

        public string 推薦人 { get; set; } = null!;
    }
}
