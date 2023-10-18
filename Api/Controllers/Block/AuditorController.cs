using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Block;
using AutoMapper;
using Core.Entities.Block;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Block;

public class AuditorController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuditorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Auditors in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AuditorDto>>> Get()
    {
        var auditors = await _unitOfWork.Auditors.GetAllAsync();
        /* return Ok(auditors); */
        return _mapper.Map<List<AuditorDto>>(auditors);
    }

    /* Get Auditor by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuditorDto>> Get(int id)
    {
        var auditor = await _unitOfWork.Auditors.GetByIdAsync(id);
        if (auditor == null)
        {
            return NotFound();
        }
        return _mapper.Map<AuditorDto>(auditor);
    }

    /* Add a new Auditor in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Auditor>> Post(AuditorDto auditorDto)
    {
        var auditor = _mapper.Map<Auditor>(auditorDto);

        if (auditor.CreationDate == DateTime.MinValue)
        {
            auditor.CreationDate = DateTime.Now;
            auditorDto.CreationDate = DateTime.Now;
        }
        if (auditor.ModificationDate == DateTime.MinValue)
        {
            auditor.ModificationDate = DateTime.Now;
            auditorDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.Auditors.Add(auditor);
        await _unitOfWork.SaveAsync();
        if (auditor == null)
        {
            return BadRequest();
        }
        auditorDto.Id = auditor.Id;
        return CreatedAtAction(nameof(Post), new { id = auditorDto.Id }, auditorDto);
    }

    /* Update Audtior in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AuditorDto>> Put(int id, [FromBody] AuditorDto auditorDto)
    {
        var auditor = _mapper.Map<Auditor>(auditorDto);
        if (auditor.Id == 0)
        {
            auditor.Id = id;
        }
        if (auditor.Id != id)
        {
            return BadRequest();
        }
        if (auditor == null)
        {
            return NotFound();
        }

        if (auditor.CreationDate == DateTime.MinValue)
        {
            auditor.CreationDate = DateTime.Now;
            auditorDto.CreationDate = DateTime.Now;
        }
        if (auditor.ModificationDate == DateTime.MinValue)
        {
            auditor.ModificationDate = DateTime.Now;
            auditorDto.ModificationDate = DateTime.Now;
        }

        auditorDto.Id = auditor.Id;
        _unitOfWork.Auditors.Update(auditor);
        await _unitOfWork.SaveAsync();
        return auditorDto;
    }

    /* Delete Auditor in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Auditor>> Delete(int id)
    {
        var auditor = await _unitOfWork.Auditors.GetByIdAsync(id);
        if (auditor == null)
        {
            return NotFound();
        }
        _unitOfWork.Auditors.Remove(auditor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
