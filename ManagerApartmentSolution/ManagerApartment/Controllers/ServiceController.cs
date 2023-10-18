﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Request.ServiceRequest;
using Services.Models.Response.ServiceResponse;
using Services.Servicesss;

namespace ManagerApartment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private ServiceService _serviceService;
        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseOfService>>> GetServices()
        {
            try
            {
                var services = await _serviceService.GetAllServices();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{serviceId}")]
        public async Task<ActionResult<ResponseOfService>> GetServiceById(int serviceId)
        {
            try
            {
                var service = await _serviceService.GetServiceById(serviceId);
                return Ok(service);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseOfService>> CreateService(RequestCreateService service)
        {
            var createdService = await _serviceService.CreateService(service);
            return createdService == null ? NotFound() : Ok(createdService);
        }
        [HttpPut("{serviceId}")]
        public async Task<ActionResult<ResponseOfService>> UpdateService(int serviceId, UpdateService updateService)
        {
            var updatedService = await _serviceService.UpdateService(serviceId, updateService);
            return updatedService == null ? NotFound() : Ok(updateService);
        }

        [HttpDelete("{serviceId}")]
        public async Task<ActionResult> DeleteService(int serviceId)
        {
            var deletedService = _serviceService.DeleteService(serviceId);
            return deletedService == null ? NoContent() : Ok(deletedService);
        }
    }
}
