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

public class FiledNumberController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FiledNumberController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all FiledNumbers in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FiledNumberDto>>> Get()
    {
        var filedNumbers = await _unitOfWork.FiledNumbers.GetAllAsync();
        /* return Ok(filedNumbers); */
        return _mapper.Map<List<FiledNumberDto>>(filedNumbers);
    }

    /* Get FiledNumber by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FiledNumberDto>> Get(int id)
    {
        var filedNumber = await _unitOfWork.FiledNumbers.GetByIdAsync(id);
        if (filedNumber == null)
        {
            return NotFound();
        }
        return _mapper.Map<FiledNumberDto>(filedNumber);
    }

    /* Add a new FiledNumber in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FiledNumber>> Post(FiledNumberDto filedNumberDto)
    {
        var filedNumber = _mapper.Map<FiledNumber>(filedNumberDto);

        if (filedNumber.CreationDate == DateTime.MinValue)
        {
            filedNumber.CreationDate = DateTime.Now;
            filedNumberDto.CreationDate = DateTime.Now;
        }
        if (filedNumber.ModificationDate == DateTime.MinValue)
        {
            filedNumber.ModificationDate = DateTime.Now;
            filedNumberDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.FiledNumbers.Add(filedNumber);
        await _unitOfWork.SaveAsync();
        if (filedNumber == null)
        {
            return BadRequest();
        }
        filedNumberDto.Id = filedNumber.Id;
        return CreatedAtAction(nameof(Post), new { id = filedNumberDto.Id }, filedNumberDto);
    }

    /* Update FiledNumber in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FiledNumberDto>> Put(int id, [FromBody] FiledNumberDto filedNumberDto)
    {
        var filedNumber = _mapper.Map<FiledNumber>(filedNumberDto);
        if (filedNumber.Id == 0)
        {
            filedNumber.Id = id;
        }
        if (filedNumber.Id != id)
        {
            return BadRequest();
        }
        if (filedNumber == null)
        {
            return NotFound();
        }

        if (filedNumber.CreationDate == DateTime.MinValue)
        {
            filedNumber.CreationDate = DateTime.Now;
            filedNumberDto.CreationDate = DateTime.Now;
        }
        if (filedNumber.ModificationDate == DateTime.MinValue)
        {
            filedNumber.ModificationDate = DateTime.Now;
            filedNumberDto.ModificationDate = DateTime.Now;
        }

        filedNumberDto.Id = filedNumber.Id;
        _unitOfWork.FiledNumbers.Update(filedNumber);
        await _unitOfWork.SaveAsync();
        return filedNumberDto;
    }

    /* Delete FiledNumber in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FiledNumber>> Delete(int id)
    {
        var filedNumber = await _unitOfWork.FiledNumbers.GetByIdAsync(id);
        if (filedNumber == null)
        {
            return NotFound();
        }
        _unitOfWork.FiledNumbers.Remove(filedNumber);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

