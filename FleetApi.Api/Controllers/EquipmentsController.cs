using FleetApi.Application.DTOS;
using FleetApi.Application.Interfaces;
using FleetApi.Domain.Entities;
using FleetApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipmentsController : ControllerBase
{
    private IEquipmentService _service;
    public EquipmentsController(IEquipmentService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetAll()
    {
        var equipments = await _service.GetAll();
        return Ok(equipments);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<EquipmentDTO>> Get(int id)
    {
        var equipment = await _service.GetBy(id);
        if(equipment == null)return NotFound("Equipment not found");
        return Ok(equipment);
    }
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Equipment>>> Add([FromBody] EquipmentDTO equipmentDto)
    {
        if(equipmentDto == null)return BadRequest("Invalid data");
        await _service.Add(equipmentDto);
        return Ok();
    }
    [HttpPut]
    public async Task<ActionResult> Update(int fleet, [FromBody] EquipmentDTO equipmentDto)
    {
        if(fleet != equipmentDto.Fleet)return BadRequest();
        if(equipmentDto == null)return BadRequest();
        await _service.Update(equipmentDto);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }
}
