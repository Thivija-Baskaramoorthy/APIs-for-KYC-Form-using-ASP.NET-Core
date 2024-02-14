using InternKYCApplication.DTOs.Requests;
using InternKYCApplication.DTOs.Responses;
using InternKYCApplication.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternKYCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class otpAuthController : ControllerBase
    {
        private readonly IOtpAuthService otpAuthService;

        public otpAuthController(IOtpAuthService otpAuthService)
        {
            this.otpAuthService = otpAuthService;
        }


        [HttpPost("RequestOTP")]
        public BaseResponse RequestOtp(OtpRequest request)
        {
            return otpAuthService.RequestOtp(request);
        }


         [HttpPost("SubmitOTP")]
        public BaseResponse VerifyOtp(OtpVerifyRequest request)
        {
            return otpAuthService.VerifyOtp(request);
        }
        
    }
}
