namespace 兩個Service共用交易.Models.EntityModel
{
    public class 帳號
    {
        public int Id { get; set; }
        public string 帳號名稱 { get; set; } = null!;
        public string 密碼 { get; set; } = null!;
    }
}
