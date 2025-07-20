using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace E_commerce.Controllers
{
    public class CustomerController : ApiController
    {

        [HttpGet]
        [Route("api/orders")]

        public HttpResponseMessage Orders()
        {
            try
            {
                var data = OrderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/orders/{id}")]
        public HttpResponseMessage Order(int id)
        {
            try
            {
                var data = OrderService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/orders/create")]
        public HttpResponseMessage OrderCreate(OrderDTO os)
        {
            try
            {
                var isCreated = OrderService.Create(os);
                if (isCreated)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Order created successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Order creation failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/orders/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isDeleted = OrderService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Order deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Order not found or deletion failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/orders/update/{id}")]
        public HttpResponseMessage Update(int id, OrderDTO od)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                if (od == null)
                {
                    return Request.CreateResponse(
                        HttpStatusCode.InternalServerError,
                        new { Message = "OrderService is not initialized." }
                    );
                }

                if (od == null)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        "Order data is missing from the request."
                    );
                }

                od.Id = id;
                var isUpdated = OrderService.Update(od);

                return isUpdated
                    ? Request.CreateResponse(HttpStatusCode.OK, "Order updated successfully.")
                    : Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update the order.");
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
        [Route("api/orderdetails/{id}")]
        public HttpResponseMessage OrderDetails(int id)
        {
            try
            {
                var data = OrderDetailService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/carts")]
        public HttpResponseMessage Carts()
        {
            try
            {
                var data = CartService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/carts/{id}")]
        public HttpResponseMessage Carts(int id)
        {
            try
            {
                var data = CartService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/carts/create")]
        public HttpResponseMessage CreateCart(CartDTO cs)
        {
            try
            {
                var isCreated = CartService.Create(cs);
                if (isCreated)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Cart created successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cart creation failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/carts/delete/{id}")]
        public HttpResponseMessage DeleteCart(int id)
        {
            try
            {
                var isDeleted = CartService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Cart deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Cart not found or deletion failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/orderstatus/{id}")]
        public HttpResponseMessage OrderStatus(int id)
        {
            try
            {
                var data = StatusService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/productcatalog")]
        public HttpResponseMessage Products()
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
        [Route("api/products/{id}")]
        public HttpResponseMessage Product(int id)
        {
            try
            {
                var data = ProductService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/orders/complexsearch")]
        public IHttpActionResult ComplexSearch(
            DateTime? startDate = null, DateTime? endDate = null,
            int? statusId = null, decimal? minTotal = null, decimal? maxTotal = null,
            int? customerId = null,
            int? productId = null, int? minQty = null, int? maxQty = null,
            decimal? minPrice = null, decimal? maxPrice = null)
        {
            var orders = OrderService.Get();
            var details = OrderDetailService.Get();

            var query = from order in orders
                        join detail in details on order.Id equals detail.OId
                        select new
                        {
                            Order = order,
                            OrderDetail = detail
                        };

            if (startDate.HasValue) query = query.Where(q => q.Order.Time >= startDate.Value);
            if (endDate.HasValue) query = query.Where(q => q.Order.Time <= endDate.Value);
            if (statusId.HasValue) query = query.Where(q => q.Order.StatusId == statusId.Value);
            if (minTotal.HasValue) query = query.Where(q => q.Order.Total >= minTotal.Value);
            if (maxTotal.HasValue) query = query.Where(q => q.Order.Total <= maxTotal.Value);
            if (customerId.HasValue) query = query.Where(q => q.Order.CusId == customerId.Value);

            if (productId.HasValue) query = query.Where(q => q.OrderDetail.PId == productId.Value);
            if (minQty.HasValue) query = query.Where(q => q.OrderDetail.Qty >= minQty.Value);
            if (maxQty.HasValue) query = query.Where(q => q.OrderDetail.Qty <= maxQty.Value);
            if (minPrice.HasValue) query = query.Where(q => q.OrderDetail.Price >= minPrice.Value);
            if (maxPrice.HasValue) query = query.Where(q => q.OrderDetail.Price <= maxPrice.Value);

            return Ok(query.ToList());
        }

    }
}

