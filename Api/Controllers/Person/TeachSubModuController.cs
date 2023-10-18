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

public class TeachSubModuController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TeachSubModuController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Auditors in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TeacherSubModuleDto>>> Get()
    {
        var teacherSubModules = await _unitOfWork.TeacherSubModules.GetAllAsync();
        /* return Ok(teacherSubModules); */
        return _mapper.Map<List<TeacherSubModuleDto>>(teacherSubModules);
    }

    /* Get Auditor by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TeacherSubModuleDto>> Get(int id)
    {
        var teacherSubModule = await _unitOfWork.TeacherSubModules.GetByIdAsync(id);
        if (teacherSubModule == null)
        {
            return NotFound();
        }
        return _mapper.Map<TeacherSubModuleDto>(teacherSubModule);
    }

    /* Add a new Auditor in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherSubModule>> Post(TeacherSubModulePDto TeacherSubModulePDto)
    {
        var teacherSubModule = _mapper.Map<TeacherSubModule>(TeacherSubModulePDto);

        if (teacherSubModule.CreationDate == DateTime.MinValue)
        {
            teacherSubModule.CreationDate = DateTime.Now;
            TeacherSubModulePDto.CreationDate = DateTime.Now;
        }
        if (teacherSubModule.ModificationDate == DateTime.MinValue)
        {
            teacherSubModule.ModificationDate = DateTime.Now;
            TeacherSubModulePDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.TeacherSubModules.Add(teacherSubModule);
        await _unitOfWork.SaveAsync();
        if (teacherSubModule == null)
        {
            return BadRequest();
        }
        TeacherSubModulePDto.Id = teacherSubModule.Id;
        return CreatedAtAction(nameof(Post), new { id = TeacherSubModulePDto.Id }, TeacherSubModulePDto);
    }

    /* Update Audtior in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherSubModulePDto>> Put(int id, [FromBody] TeacherSubModulePDto teacherSubModulePDto)
    {
        var teacherSubModule = _mapper.Map<TeacherSubModule>(teacherSubModulePDto);
        if (teacherSubModule.Id == 0)
        {
            teacherSubModule.Id = id;
        }
        if (teacherSubModule.Id != id)
        {
            return BadRequest();
        }
        if (teacherSubModule == null)
        {
            return NotFound();
        }

        if (teacherSubModule.CreationDate == DateTime.MinValue)
        {
            teacherSubModule.CreationDate = DateTime.Now;
            teacherSubModulePDto.CreationDate = DateTime.Now;
        }
        if (teacherSubModule.ModificationDate == DateTime.MinValue)
        {
            teacherSubModule.ModificationDate = DateTime.Now;
            teacherSubModulePDto.ModificationDate = DateTime.Now;
        }

        teacherSubModulePDto.Id = teacherSubModule.Id;
        _unitOfWork.TeacherSubModules.Update(teacherSubModule);
        await _unitOfWork.SaveAsync();
        return teacherSubModulePDto;
    }

    /* Delete Auditor in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherSubModule>> Delete(int id)
    {
        var teacherSubModule = await _unitOfWork.TeacherSubModules.GetByIdAsync(id);
        if (teacherSubModule == null)
        {
            return NotFound();
        }
        _unitOfWork.TeacherSubModules.Remove(teacherSubModule);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
