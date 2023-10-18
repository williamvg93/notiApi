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

public class FormatsController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FormatsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Formats in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FormatsDto>>> Get()
    {
        var formats = await _unitOfWork.Formats.GetAllAsync();
        /* return Ok(formats); */
        return _mapper.Map<List<FormatsDto>>(formats);
    }

    /* Get Format by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormatsDto>> Get(int id)
    {
        var format = await _unitOfWork.Formats.GetByIdAsync(id);
        if (format == null)
        {
            return NotFound();
        }
        return _mapper.Map<FormatsDto>(format);
    }

    /* Add a new Format in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Formats>> Post(FormatsDto formatsDto)
    {
        var format = _mapper.Map<Formats>(formatsDto);

        if (format.CreationDate == DateTime.MinValue)
        {
            format.CreationDate = DateTime.Now;
            formatsDto.CreationDate = DateTime.Now;
        }
        if (format.ModificationDate == DateTime.MinValue)
        {
            format.ModificationDate = DateTime.Now;
            formatsDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.Formats.Add(format);
        await _unitOfWork.SaveAsync();
        if (format == null)
        {
            return BadRequest();
        }
        formatsDto.Id = format.Id;
        return CreatedAtAction(nameof(Post), new { id = formatsDto.Id }, formatsDto);
    }

    /* Update Format in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FormatsDto>> Put(int id, [FromBody] FormatsDto formatsDto)
    {
        var format = _mapper.Map<Formats>(formatsDto);
        if (format.Id == 0)
        {
            format.Id = id;
        }
        if (format.Id != id)
        {
            return BadRequest();
        }
        if (format == null)
        {
            return NotFound();
        }

        if (format.CreationDate == DateTime.MinValue)
        {
            format.CreationDate = DateTime.Now;
            formatsDto.CreationDate = DateTime.Now;
        }
        if (format.ModificationDate == DateTime.MinValue)
        {
            format.ModificationDate = DateTime.Now;
            formatsDto.ModificationDate = DateTime.Now;
        }

        formatsDto.Id = format.Id;
        _unitOfWork.Formats.Update(format);
        await _unitOfWork.SaveAsync();
        return formatsDto;
    }

    /* Delete Format in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FormatsDto>> Delete(int id)
    {
        var format = await _unitOfWork.Formats.GetByIdAsync(id);
        if (format == null)
        {
            return NotFound();
        }
        _unitOfWork.Formats.Remove(format);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
