﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.ServiceRequest;
using Services.Models.Request.TennantRequest;
using Services.Models.Response.ServiceResponse;
using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TennantController : ControllerBase
    {
        private TennantService _tennantService;
        public TennantController(TennantService tennantService)
        {
            _tennantService = tennantService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseOfTennant>>> GetAllTennants()
        {
            try
            {
                var tennant = await _tennantService.GetAllTennants();
                return Ok(tennant);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseOfTennant>> GetTennantById(int id)
        {
            try
            {
                var staff = await _tennantService.GetTennantById(id);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseOfTennant>> CreateTennant(RequestCreateTennant tennant)
        {
            var createdTennant = await _tennantService.CreateTennant(tennant);
            return createdTennant == null ? NotFound() : Ok(createdTennant);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseOfTennant>> UpdateTennant(int tennantId, UpdateTennant updateTennant)
        {
            var updatedTennant = await _tennantService.UpdateTennant(tennantId, updateTennant);
            return updateTennant == null ? NotFound() : Ok(updateTennant);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTennant(int tennantId)
        {
            var deletedTennant = _tennantService.DeleteTennant(tennantId);
            return deletedTennant == null ? NoContent() : Ok(deletedTennant);
        }
    }
}
