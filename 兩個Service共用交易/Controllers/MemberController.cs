using Microsoft.AspNetCore.Mvc;
using 兩個Service共用交易.Models.Data;
using 兩個Service共用交易.Models.ViewModel;
using 兩個Service共用交易.Services;

namespace 兩個Service共用交易.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly 帳號服務 _帳號服務;
        private readonly 會員服務 _會員服務;
        private readonly UnitOfWork unitOfWork;

        public MemberController(帳號服務 帳號服務, 會員服務 會員服務, UnitOfWork unitOfWork)
        {
            _帳號服務 = 帳號服務;
            _會員服務 = 會員服務;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            bool result = false;
            var _ = await _帳號服務.加入新帳號(request.帳號名稱, request.密碼);
            if (_.成功否)
            {
                await _會員服務.加入新會員(request.姓名, request.推薦人, _.帳號id!.Value);

                result = await unitOfWork.CommitByTransactionAsync();
            }
            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}
