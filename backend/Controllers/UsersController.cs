using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController:ControllerBase
    {
        private readonly DataContext context;
        public UsersController(DataContext context){
            this.context = context;

        }

        // This is synchronous code
        // [HttpGet()] // /api/users
        // public  ActionResult<IEnumerable<AppUser>> GetUsers(){
        //     var users = context.Users.ToList();
        //     return users;
        // }



        // Let make it asynchronous code 
        [HttpGet()] // /api/users
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users = await context.Users.ToListAsync();
            return users;
        }

        // This is synchronous code
        // [HttpGet("{id}")] // /api/users/3
        // public  ActionResult<AppUser> GetUser(int id){
        //     var user = context.Users.Find(id);
        //     if(user==null){
        //         return NotFound();
        //     }
        //     return user;
        // }


        // Let make it asynchronous code 
        [HttpGet("{id}")] // /api/users/3
        public  async Task<ActionResult<AppUser>> GetUser(int id){
            var user = await context.Users.FindAsync(id);
            if(user==null){
                return NotFound();
            }
            return user;
        }
        
    }
}