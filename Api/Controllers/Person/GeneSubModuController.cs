using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Person;
using Api.Dtos.Post.Person;
using AutoMapper;
using Core.Entities.Person;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Person;

public class GeneSubModuController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GeneSubModuController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Generic Sub Modules in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericSubModulesDto>>> Get()
    {
        var geneSubMods = await _unitOfWork.GeneSubModules.GetAllAsync();
        /* return Ok(geneSubMods); */
        return _mapper.Map<List<GenericSubModulesDto>>(geneSubMods);
    }

    /* Get Generic Sub Module by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericSubModulesDto>> Get(int id)
    {
        var geneSubMod = await _unitOfWork.GeneSubModules.GetByIdAsync(id);
        if (geneSubMod == null)
        {
            return NotFound();
        }
        return _mapper.Map<GenericSubModulesDto>(geneSubMod);
    }

    /* Add a new Generic Sub Module in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericSubModules>> Post(GenericSubModulesPDto genericSubModulesPDto)
    {
        var geneSubMod = _mapper.Map<GenericSubModules>(genericSubModulesPDto);

        if (geneSubMod.CreationDate == DateTime.MinValue)
        {
            geneSubMod.CreationDate = DateTime.Now;
            genericSubModulesPDto.CreationDate = DateTime.Now;
        }
        if (geneSubMod.ModificationDate == DateTime.MinValue)
        {
            geneSubMod.ModificationDate = DateTime.Now;
            genericSubModulesPDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.GeneSubModules.Add(geneSubMod);
        await _unitOfWork.SaveAsync();
        if (geneSubMod == null)
        {
            return BadRequest();
        }
        genericSubModulesPDto.Id = geneSubMod.Id;
        return CreatedAtAction(nameof(Post), new { id = genericSubModulesPDto.Id }, genericSubModulesPDto);
    }

    /* Update Generic Sub Module in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericSubModulesPDto>> Put(int id, [FromBody] GenericSubModulesPDto genericSubModulesPDto)
    {
        var geneSubMod = _mapper.Map<GenericSubModules>(genericSubModulesPDto);
        if (geneSubMod.Id == 0)
        {
            geneSubMod.Id = id;
        }
        if (geneSubMod.Id != id)
        {
            return BadRequest();
        }
        if (geneSubMod == null)
        {
            return NotFound();
        }

        if (geneSubMod.CreationDate == DateTime.MinValue)
        {
            geneSubMod.CreationDate = DateTime.Now;
            genericSubModulesPDto.CreationDate = DateTime.Now;
        }
        if (geneSubMod.ModificationDate == DateTime.MinValue)
        {
            geneSubMod.ModificationDate = DateTime.Now;
            genericSubModulesPDto.ModificationDate = DateTime.Now;
        }

        genericSubModulesPDto.Id = geneSubMod.Id;
        _unitOfWork.GeneSubModules.Update(geneSubMod);
        await _unitOfWork.SaveAsync();
        return genericSubModulesPDto;
    }

    /* Delete Generic Sub Module in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericSubModules>> Delete(int id)
    {
        var geneSubMod = await _unitOfWork.GeneSubModules.GetByIdAsync(id);
        if (geneSubMod == null)
        {
            return NotFound();
        }
        _unitOfWork.GeneSubModules.Remove(geneSubMod);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

