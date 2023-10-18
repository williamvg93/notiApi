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

public class SubModulesController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubModulesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Sub Modules in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubModulesDto>>> Get()
    {
        var subModules = await _unitOfWork.SubModules.GetAllAsync();
        /* return Ok(subModules); */
        return _mapper.Map<List<SubModulesDto>>(subModules);
    }

    /* Get Sub Module by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubModulesDto>> Get(int id)
    {
        var subModule = await _unitOfWork.SubModules.GetByIdAsync(id);
        if (subModule == null)
        {
            return NotFound();
        }
        return _mapper.Map<SubModulesDto>(subModule);
    }

    /* Add a new Sub Module in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubModules>> Post(SubModulesDto subModulesDto)
    {
        var subModule = _mapper.Map<SubModules>(subModulesDto);

        if (subModule.CreationDate == DateTime.MinValue)
        {
            subModule.CreationDate = DateTime.Now;
            subModulesDto.CreationDate = DateTime.Now;
        }
        if (subModule.ModificationDate == DateTime.MinValue)
        {
            subModule.ModificationDate = DateTime.Now;
            subModulesDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.SubModules.Add(subModule);
        await _unitOfWork.SaveAsync();
        if (subModule == null)
        {
            return BadRequest();
        }
        subModulesDto.Id = subModule.Id;
        return CreatedAtAction(nameof(Post), new { id = subModulesDto.Id }, subModulesDto);
    }

    /* Update Sub Module in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubModulesDto>> Put(int id, [FromBody] SubModulesDto subModulesDto)
    {
        var subModule = _mapper.Map<SubModules>(subModulesDto);
        if (subModule.Id == 0)
        {
            subModule.Id = id;
        }
        if (subModule.Id != id)
        {
            return BadRequest();
        }
        if (subModule == null)
        {
            return NotFound();
        }

        if (subModule.CreationDate == DateTime.MinValue)
        {
            subModule.CreationDate = DateTime.Now;
            subModulesDto.CreationDate = DateTime.Now;
        }
        if (subModule.ModificationDate == DateTime.MinValue)
        {
            subModule.ModificationDate = DateTime.Now;
            subModulesDto.ModificationDate = DateTime.Now;
        }

        subModulesDto.Id = subModule.Id;
        _unitOfWork.SubModules.Update(subModule);
        await _unitOfWork.SaveAsync();
        return subModulesDto;
    }

    /* Delete Sub Module in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubModules>> Delete(int id)
    {
        var subModule = await _unitOfWork.SubModules.GetByIdAsync(id);
        if (subModule == null)
        {
            return NotFound();
        }
        _unitOfWork.SubModules.Remove(subModule);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
