using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Core;

namespace User.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [Authorize(Roles = Role.Admin)]
        [HttpGet("admin")]
        public List<Product> getAdminProducts()
        {
            return new List<Product>()
           {
                new Product(){
                Name = "admin product1"
                },
                new Product(){
                    Name= "admin product2"
                }
           };
        }


        [Authorize(Roles = Role.SuperAdmin)]
        [HttpGet("superAdmin")]
        public List<Product> getSuperAdminProducts()
        {
            return new List<Product>()
            {
                new Product(){
                Name = "super admin product1"
                },
                new Product(){
                    Name= "super admin product2"
                }
            };
        }

        [Authorize(Roles = Role.BasicUser)]
        [HttpGet("basicUser")]
        public List<Product> getBasicUserProducts()
        {
            return new List<Product>()
            {
                new Product(){
                Name = "basic user product1"
                },
                new Product(){
                    Name= "basic user product2"
                }
            };
        }
    }
}
