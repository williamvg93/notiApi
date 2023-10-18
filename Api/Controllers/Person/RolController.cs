using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Person;
using AutoMapper;
using Core.Entities.Person;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Person;

public class RolController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Rols in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolDto>>> Get()
    {
        var rols = await _unitOfWork.Rols.GetAllAsync();
        /* return Ok(rols); */
        return _mapper.Map<List<RolDto>>(rols);
    }

    /* Get Rol by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Get(int id)
    {
        var rol = await _unitOfWork.Rols.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        return _mapper.Map<RolDto>(rol);
    }

    /* Add a new Rol in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(RolDto rolDto)
    {
        var rol = _mapper.Map<Rol>(rolDto);

        if (rol.CreationDate == DateTime.MinValue)
        {
            rol.CreationDate = DateTime.Now;
            rolDto.CreationDate = DateTime.Now;
        }
        if (rol.ModificationDate == DateTime.MinValue)
        {
            rol.ModificationDate = DateTime.Now;
            rolDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.Rols.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null)
        {
            return BadRequest();
        }
        rolDto.Id = rol.Id;
        return CreatedAtAction(nameof(Post), new { id = rolDto.Id }, rolDto);
    }

    /* Update Rol in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto rolDto)
    {
        var rol = _mapper.Map<Rol>(rolDto);
        if (rol.Id == 0)
        {
            rol.Id = id;
        }
        if (rol.Id != id)
        {
            return BadRequest();
        }
        if (rol == null)
        {
            return NotFound();
        }

        if (rol.CreationDate == DateTime.MinValue)
        {
            rol.CreationDate = DateTime.Now;
            rolDto.CreationDate = DateTime.Now;
        }
        if (rol.ModificationDate == DateTime.MinValue)
        {
            rol.ModificationDate = DateTime.Now;
            rolDto.ModificationDate = DateTime.Now;
        }

        rolDto.Id = rol.Id;
        _unitOfWork.Rols.Update(rol);
        await _unitOfWork.SaveAsync();
        return rolDto;
    }

    /* Delete Rol in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDto>> Delete(int id)
    {
        var rol = await _unitOfWork.Rols.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        _unitOfWork.Rols.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
