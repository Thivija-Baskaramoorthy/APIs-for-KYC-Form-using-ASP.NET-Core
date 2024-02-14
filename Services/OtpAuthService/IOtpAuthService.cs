using InternKYCApplication.DTOs.Requests;
using InternKYCApplication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InternKYCApplication.Services.UserService
{
    public interface IOtpAuthService
    {
        BaseResponse RequestOtp(OtpRequest request);
        BaseResponse VerifyOtp(OtpVerifyRequest request);
        
    }
}
