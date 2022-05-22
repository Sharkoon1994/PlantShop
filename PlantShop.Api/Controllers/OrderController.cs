//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using PlantShop.Data.Entities;
//using PlantShop.Service.Repository;

//namespace PlantShop.Api.Controllers
//{
//    [ApiController]
//    [AllowAnonymous]
//    [Route("/api/[controller]/")]
//    public class OrderController : ControllerBase
//    {
//        private readonly IOrderRepository _orderRepository;

//        public OrderController(IOrderRepository orderRepository)
//        {
//            _orderRepository = orderRepository;
//        }

//        [HttpPost]
//        [Route("/api/order/add")]
//        public async Task<IActionResult> Post([FromBody] Order order)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            var model = await _orderRepository.InsertOrder(order);

//            return Ok(model);
//        }

//        [HttpGet]
//        [Route("/api/order/all")]
//        public async Task<IActionResult> Get()
//        {
//            var orders = await _orderRepository.GetOrders();

//            return Ok(orders);
//        }

//        [HttpGet]
//        [Route("/api/order/{id:int}")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var order = await _orderRepository.GetOrderById(id);

//            return Ok(order);
//        }
//    }
//}