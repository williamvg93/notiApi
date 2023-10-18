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

public class GenePermiController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenePermiController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Generic Permissions in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericPermissionsDto>>> Get()
    {
        var genePermisions = await _unitOfWork.GenePermissions.GetAllAsync();
        /* return Ok(genePermisions); */
        return _mapper.Map<List<GenericPermissionsDto>>(genePermisions);
    }

    /* Get Generic Permission by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericPermissionsDto>> Get(int id)
    {
        var genePermision = await _unitOfWork.GenePermissions.GetByIdAsync(id);
        if (genePermision == null)
        {
            return NotFound();
        }
        return _mapper.Map<GenericPermissionsDto>(genePermision);
    }

    /* Add a new Generic Permission in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericPermissions>> Post(GenericPermissionsDto genericPermissionsDto)
    {
        var genePermi = _mapper.Map<GenericPermissions>(genericPermissionsDto);

        if (genePermi.CreationDate == DateTime.MinValue)
        {
            genePermi.CreationDate = DateTime.Now;
            genericPermissionsDto.CreationDate = DateTime.Now;
        }
        if (genePermi.ModificationDate == DateTime.MinValue)
        {
            genePermi.ModificationDate = DateTime.Now;
            genericPermissionsDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.GenePermissions.Add(genePermi);
        await _unitOfWork.SaveAsync();
        if (genePermi == null)
        {
            return BadRequest();
        }
        genericPermissionsDto.Id = genePermi.Id;
        return CreatedAtAction(nameof(Post), new { id = genericPermissionsDto.Id }, genericPermissionsDto);
    }

    /* Update Generic Permission in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericPermissionsDto>> Put(int id, [FromBody] GenericPermissionsDto genericPermissionsDto)
    {
        var genePermi = _mapper.Map<GenericPermissions>(genericPermissionsDto);
        if (genePermi.Id == 0)
        {
            genePermi.Id = id;
        }
        if (genePermi.Id != id)
        {
            return BadRequest();
        }
        if (genePermi == null)
        {
            return NotFound();
        }

        if (genePermi.CreationDate == DateTime.MinValue)
        {
            genePermi.CreationDate = DateTime.Now;
            genericPermissionsDto.CreationDate = DateTime.Now;
        }
        if (genePermi.ModificationDate == DateTime.MinValue)
        {
            genePermi.ModificationDate = DateTime.Now;
            genericPermissionsDto.ModificationDate = DateTime.Now;
        }

        genericPermissionsDto.Id = genePermi.Id;
        _unitOfWork.GenePermissions.Update(genePermi);
        await _unitOfWork.SaveAsync();
        return genericPermissionsDto;
    }

    /* Delete Generic Permission in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericPermissions>> Delete(int id)
    {
        var genePermi = await _unitOfWork.GenePermissions.GetByIdAsync(id);
        if (genePermi == null)
        {
            return NotFound();
        }
        _unitOfWork.GenePermissions.Remove(genePermi);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

