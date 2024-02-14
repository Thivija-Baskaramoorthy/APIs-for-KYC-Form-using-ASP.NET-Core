using InternKYCApplication.DTOs.Requests;
using InternKYCApplication.DTOs.Responses;
using InternKYCApplication.Services.UserDetailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternKYCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitCustomerDataController : ControllerBase
    {
        private readonly ICustomerDataService customerDataService;
        public SubmitCustomerDataController (ICustomerDataService customerDataService)
        {
            this.customerDataService = customerDataService;
        }

        [HttpPost("SubmitData")]
        public ActionResult<BaseResponse> CreateCustomerDataRequest(CreateCustomerDataRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return customerDataService.CreateCustomerData(request);
        }

        [HttpGet("CustomerList")]
        public BaseResponse CustomerList()
        {
            return customerDataService.CustomerList();
        }

    }
}
