using InternKYCApplication.DTOs.Requests;
using InternKYCApplication.DTOs.Responses;

namespace InternKYCApplication.Services.UserDetailService
{
    public interface ICustomerDataService
    {
        BaseResponse CreateCustomerData(CreateCustomerDataRequest request);
        BaseResponse CustomerList();
        // string SaveBase64Image(string base64Image);
        // BaseResponse ImageValidation(string base64Image);
    }
}
