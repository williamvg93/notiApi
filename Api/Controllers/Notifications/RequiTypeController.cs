using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Notifications;
using AutoMapper;
using Core.Entities.Notifications;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Notifications;

public class RequiTypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RequiTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Requirements Types in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RequirementTypeDto>>> Get()
    {
        var requiTypes = await _unitOfWork.RequiTypes.GetAllAsync();
        /* return Ok(requiTypes); */
        return _mapper.Map<List<RequirementTypeDto>>(requiTypes);
    }

    /* Get Requirement Type by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RequirementTypeDto>> Get(int id)
    {
        var requiType = await _unitOfWork.RequiTypes.GetByIdAsync(id);
        if (requiType == null)
        {
            return NotFound();
        }
        return _mapper.Map<RequirementTypeDto>(requiType);
    }

    /* Add a new Requirement Type in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RequirementType>> Post(RequirementTypeDto requirementTypeDto)
    {
        var requiType = _mapper.Map<RequirementType>(requirementTypeDto);

        if (requiType.CreationDate == DateTime.MinValue)
        {
            requiType.CreationDate = DateTime.Now;
            requirementTypeDto.CreationDate = DateTime.Now;
        }
        if (requiType.ModificationDate == DateTime.MinValue)
        {
            requiType.ModificationDate = DateTime.Now;
            requirementTypeDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.RequiTypes.Add(requiType);
        await _unitOfWork.SaveAsync();
        if (requiType == null)
        {
            return BadRequest();
        }
        requirementTypeDto.Id = requiType.Id;
        return CreatedAtAction(nameof(Post), new { id = requirementTypeDto.Id }, requirementTypeDto);
    }

    /* Update Requirement Type in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RequirementTypeDto>> Put(int id, [FromBody] RequirementTypeDto requirementTypeDto)
    {
        var requiType = _mapper.Map<RequirementType>(requirementTypeDto);
        if (requiType.Id == 0)
        {
            requiType.Id = id;
        }
        if (requiType.Id != id)
        {
            return BadRequest();
        }
        if (requiType == null)
        {
            return NotFound();
        }

        if (requiType.CreationDate == DateTime.MinValue)
        {
            requiType.CreationDate = DateTime.Now;
            requirementTypeDto.CreationDate = DateTime.Now;
        }
        if (requiType.ModificationDate == DateTime.MinValue)
        {
            requiType.ModificationDate = DateTime.Now;
            requirementTypeDto.ModificationDate = DateTime.Now;
        }

        requirementTypeDto.Id = requiType.Id;
        _unitOfWork.RequiTypes.Update(requiType);
        await _unitOfWork.SaveAsync();
        return requirementTypeDto;
    }

    /* Delete Requirement Type in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RequirementType>> Delete(int id)
    {
        var requiType = await _unitOfWork.RequiTypes.GetByIdAsync(id);
        if (requiType == null)
        {
            return NotFound();
        }
        _unitOfWork.RequiTypes.Remove(requiType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

