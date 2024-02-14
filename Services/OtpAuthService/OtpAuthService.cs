using InternKYCApplication.DTOs;
using InternKYCApplication.DTOs.Requests;
using InternKYCApplication.DTOs.Responses;
using InternKYCApplication.Helpers.Utils;
using InternKYCApplication.Models;
using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InternKYCApplication.Services.UserService
{
    public class OtpAuthService : IOtpAuthService
    {
        private readonly ApplicationDbContext context;

        public OtpAuthService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        
        public BaseResponse RequestOtp(OtpRequest request)
        { 
            try
            {   
                
                
                if (string.IsNullOrEmpty(request.phone_number))
                {
                    return new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new MessageDTO("Phone number is required")
                    };
                    
                }
                var existingPhoneNo = context.OtpDetail.FirstOrDefault(u => u.phone_number == request.phone_number);
                string otp = GenerateOTP();
                if (existingPhoneNo != null)
                {
                    existingPhoneNo.otp = otp;
                    existingPhoneNo.updated_at = DateTime.UtcNow;
                }
                else
                {
                    var newPhoneNo = new OtpDetailModel
                    {
                        phone_number = request.phone_number,
                        otp = otp,
                        updated_at = DateTime.UtcNow

                    };
                    context.Add(newPhoneNo);
                }
                context.SaveChanges();
                
                return new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new MessageDTO("OTP has been sent to your phone")
                };  
                
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new MessageDTO(ex.Message)
                };
            }
            
        }
        private string GenerateOTP()
        {
            // Generate a random 5-digit OTP
            Random random = new Random();
            int otp = random.Next(10000, 99999);
            return otp.ToString();
        }

        public BaseResponse VerifyOtp(OtpVerifyRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.phone_number) || string.IsNullOrEmpty(request.otp))
                {
                    return new BaseResponse
                    {
                        status_code = StatusCodes.Status400BadRequest,
                        data = new MessageDTO("Phone number and OTP are required")
                    };
                }

                var user = context.OtpDetail.FirstOrDefault(u => u.phone_number == request.phone_number);

                if (user == null)
                {
                    return new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new MessageDTO("PhoneNo not found")
                    };
                }

                if (user.otp != request.otp)
                {
                    return new BaseResponse
                    {
                        status_code = StatusCodes.Status400BadRequest,
                        data = new MessageDTO("Invalid OTP")
                    };
                }

                return new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new MessageDTO("OTP verification successful")
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new MessageDTO(ex.Message)
                };
            }
        }

    }
}
