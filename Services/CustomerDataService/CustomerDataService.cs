using InternKYCApplication.DTOs;
using InternKYCApplication.DTOs.Requests;
using InternKYCApplication.DTOs.Responses;
using InternKYCApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;


namespace InternKYCApplication.Services.UserDetailService
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _environment;

        public CustomerDataService(ApplicationDbContext applicationDbContext, IWebHostEnvironment environment)
        {
            context = applicationDbContext;
            _environment = environment;
        }

        public BaseResponse CreateCustomerData(CreateCustomerDataRequest request)
        {
            BaseResponse response;
            try
            {
                // Convert base64 encoded images to byte arrays
                byte[] selfieImage = Convert.FromBase64String(request.selfie);
                byte[] nicFrontImage = Convert.FromBase64String(request.nic_front);
                byte[] nicRearImage = Convert.FromBase64String(request.nic_rear);

                // Save images to server and get file paths
                string selfieImagePath = SaveBase64Image(selfieImage, "selfie");
                string nicFrontImagePath = SaveBase64Image(nicFrontImage, "nic_front");
                string nicRearImagePath = SaveBase64Image(nicRearImage, "nic_rear");

                CustomerDataModel newCustomerData = new CustomerDataModel
                {
                    title = request.title,
                    full_name = request.fullname,
                    phone_number = request.phone_number,
                    email = request.email,
                    nic = request.nic,
                    nationality = request.nationality,
                    selfie_image_path = selfieImagePath,
                    nic_front_image_path = nicFrontImagePath,
                    nic_rear_image_path = nicRearImagePath

                };

                using (context)
                {
                    context.Add(newCustomerData);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully submitted user's KYC data " }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error:" + ex.Message }
                };
            }

            return response;
        }

        private string SaveBase64Image(byte[] imageBytes, string prefix)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return null;
            }

            try
            {
                string fileName = $"{prefix}_{Guid.NewGuid()}.jpg";
                string uploadFolder = Path.Combine(_environment.WebRootPath, "Upload");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string filePath = Path.Combine(uploadFolder, fileName);

                using (FileStream filestream = System.IO.File.Create(filePath))
                {
                    filestream.Write(imageBytes, 0, imageBytes.Length);
                }
                 //return Path.Combine("Upload", fileName);
                 string relativePath = Path.Combine("Upload", fileName);
                 // relativePath = relativePath.Replace("/", "\\"); 
                 return relativePath;
                
            }

            catch (Exception ex)
            {
                throw new Exception($"Error saving {prefix} image: {ex.Message}");
            }
        }



        public BaseResponse CustomerList()
        {
            BaseResponse response;

            try
            {
                List<CustomerDTO> customer = new List<CustomerDTO>();

                foreach (var customers in context.CustomerData.ToList())
                {
                    customer.Add(new CustomerDTO
                    {
                        id = customers.id,
                        title = customers.title,
                        full_name = customers.full_name,
                        phone_number = customers.phone_number,
                        email = customers.email,
                        nationality = customers.nationality,
                        nic = customers.nic,
                        selfie_image_path = ReplaceSlash(customers.selfie_image_path),    
                        nic_front_image_path = ReplaceSlash(customers.nic_front_image_path),
                        nic_rear_image_path= ReplaceSlash(customers.nic_rear_image_path),
                        created_at = customers.created_at,
                        updated_at  = customers.updated_at
                    }); ;
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { customer }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error: " + ex.Message }
                };
            }

            return response;
        }
        private string ReplaceSlash(string path)
        {

            return path.Replace("\\", "/");
        }
    }
}
