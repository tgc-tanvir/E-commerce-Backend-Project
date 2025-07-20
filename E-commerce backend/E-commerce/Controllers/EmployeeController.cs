using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace E_commerce.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/customers")]

        public HttpResponseMessage Customers()
        {
            try
            {
                var data = CustomerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/customers/{id}")]
        public HttpResponseMessage Customer(int id)
        {
            try
            {
                var data = CustomerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/customers/create")]
        public HttpResponseMessage CustomerCreate(CustomerDTO cs)
        {
            try
            {
                var isCreated = CustomerService.Create(cs);
                if (isCreated)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Customer created successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Customer creation failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/customers/delete/{id}")]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            try
            {
                var isDeleted = CustomerService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found or deletion failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/customers/update/{id}")]
        public HttpResponseMessage UpdateCustomer(int id, CustomerDTO cd)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                if (cd == null)
                {
                    return Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        new { Message = "CustomerService is not initialized." }
                    );
                }

                if (cd == null)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        "Customer data is missing from the request."
                    );
                }

                cd.Id = id;
                var isUpdated = CustomerService.Update(cd);

                return isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, "Customer information updated successfully.")
                    : Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update the customer information.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new { Message = ex.Message }
                );
            }
        }

        [HttpGet]
        [Route("api/employees")]

        public HttpResponseMessage Employees()
        {
            try
            {
                var data = EmployeeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/employees/{id}")]
        public HttpResponseMessage Employees(int id)
        {
            try
            {
                var data = EmployeeService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/employees/products/create")]
        public HttpResponseMessage ProductCreate(ProductDTO ps)
        {
            try
            {
                var isCreated = ProductService.Create(ps);
                if (isCreated)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Product created successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Product creation failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpDelete]
        [Route("api/products/delete/{id}")]
        public HttpResponseMessage ProductDelete(int id)
        {
            try
            {
                var isDeleted = ProductService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found or deletion failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpPut]
        [Route("api/products/update/{id}")]
        public HttpResponseMessage UpdateProduct(int id, ProductDTO pd)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                if (pd == null)
                {
                    return Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        new { Message = "ProductService is not initialized." }
                    );
                }

                if (pd == null)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        "Product data is missing from the request."
                    );
                }

                pd.Id = id;
                var isUpdated = ProductService.Update(pd);

                return isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, "Product information updated successfully.")
                    : Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update the product information.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new { Message = ex.Message }
                );
            }
        }
        [HttpGet]
        [Route("api/orderdetails")]

        public HttpResponseMessage OrderDetails()
        {
            try
            {
                var data = OrderDetailService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/productinfo")]
        public HttpResponseMessage ProductInfo()
        {
            try
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/orderstatus")]
        public HttpResponseMessage OrderStatus()
        {
            try
            {
                var data = StatusService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/employees/products/upload")]
        public HttpResponseMessage UploadImage()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files[0];
                var fileName = Path.GetFileName(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                postedFile.SaveAs(filePath);

                var relativePath = "/Uploads/" + fileName;
                return Request.CreateResponse(HttpStatusCode.OK, new { path = relativePath });
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No file uploaded");
        }

        [HttpPost]
        [Route("api/employees/email")]
        public HttpResponseMessage SendEmail(EmailDTO dto)
        {
            bool result = EmailService.SendEmail(dto.ToEmail, dto.Subject, dto.Body);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Email sent successfully.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to send email!");
            }
        }
    }

 }

