﻿using EcommerceApplication.DTO.Users;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Orders;
using EcommerceApplication.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCRUDController : ControllerBase
    {
        private readonly IUserRepoCRUD _repoCrud;
        private readonly IUserRepoBasics _repoBasics;
        public UserCRUDController(IUserRepoCRUD crud, IUserRepoBasics basics)
        {
            _repoCrud = crud;
            _repoBasics = basics;

        }
        [HttpPost("/user/create")]
        public IActionResult CreateUser(CreateUserDto userDto)
        {
            if(userDto == null)
            {
                return BadRequest("User info is invalid.");
            }

            User user = new User();
            user.Address = userDto.Address;
            user.Password = userDto.Password;
            user.Email = userDto.Email;
            user.UserName = userDto.FirstName + " " + userDto.LastName;
            user.Orders = new List<Order>();
            user.Cart = new Cart();
            user.Contacts = userDto.Contacts;

            try
            {
                if (_repoBasics.IfExists(user.Email))
                {
                    return Forbid("User already exists with same email.");
                }
                bool result = _repoCrud.Create(user);
                if (result)
                {
                    return Ok("Succesfully created new user");
                }
                else return StatusCode(500, "An internal error has occured");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An internal error has occured: "+ex);
            }
        }
        [HttpGet("/user/{UserID:int}")]
        public IActionResult ReadById(int UserID)
        {
            var user = _repoCrud.Read(UserID);
            if (user == null)
            {
                return NotFound("User with given ID doesn't exist.");
            }
            else if (user.UserId == -1)
            {
                return StatusCode(500, "Internal server error occured while fatching the user.");
            }
            return Ok(user);
        }
        [HttpGet("/user/{email}")]
        public IActionResult ReadByEmail(string email)
        {
            var user = _repoCrud.Read(email);
            if (user == null)
            {
                return NotFound("User with given email doesn't exist.");
            }
            else if (user.UserId == -1)
            {
                return StatusCode(500, "Internal server error occured while fatching the user.");
            }
            return Ok(user);
        }
        [HttpPut("/user/update")]
        public IActionResult UpdateUser(int UserId, UpdateUserDto userDto)
        {
            try
            {
                User user = _repoCrud.Read(UserId);
                if(user == null)
                {
                    return NotFound("User with Id " + UserId + " doesn't exist.");
                }
                user.Address = userDto.Address;
                user.Password = userDto.Password;
                user.UserName = userDto.FirstName + " " + userDto.LastName;
                user.Contacts = userDto.Contacts;

                bool result = _repoCrud.Update(user);
                if (result)
                {
                    return Ok("Updates successfull.");
                }
                else return BadRequest("Failed to update user.");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error while updating - " + ex);
            }
        }
        [HttpDelete("/user/delete")]
        public IActionResult DeleteUser(int UserId)
        {
            bool result = _repoCrud.Delete(UserId);
            if (result) return Ok("User deleted");
            else return BadRequest("Failed to delete user");
        }
    }
}
