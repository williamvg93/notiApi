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

public class TeachModuController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TeachModuController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Teacher Modules in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TeacherModuleDto>>> Get()
    {
        var teachModules = await _unitOfWork.TeacherModules.GetAllAsync();
        /* return Ok(teachModules); */
        return _mapper.Map<List<TeacherModuleDto>>(teachModules);
    }

    /* Get Teacher Module by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TeacherModuleDto>> Get(int id)
    {
        var teachModule = await _unitOfWork.TeacherModules.GetByIdAsync(id);
        if (teachModule == null)
        {
            return NotFound();
        }
        return _mapper.Map<TeacherModuleDto>(teachModule);
    }

    /* Add a new Teacher Module in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherModule>> Post(TeacherModuleDto teacherModuleDto)
    {
        var teacherModule = _mapper.Map<TeacherModule>(teacherModuleDto);

        if (teacherModule.CreationDate == DateTime.MinValue)
        {
            teacherModule.CreationDate = DateTime.Now;
            teacherModuleDto.CreationDate = DateTime.Now;
        }
        if (teacherModule.ModificationDate == DateTime.MinValue)
        {
            teacherModule.ModificationDate = DateTime.Now;
            teacherModuleDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.TeacherModules.Add(teacherModule);
        await _unitOfWork.SaveAsync();
        if (teacherModule == null)
        {
            return BadRequest();
        }
        teacherModuleDto.Id = teacherModule.Id;
        return CreatedAtAction(nameof(Post), new { id = teacherModuleDto.Id }, teacherModuleDto);
    }

    /* Update Teacher Module in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherModuleDto>> Put(int id, [FromBody] TeacherModuleDto teacherModuleDto)
    {
        var teacherModule = _mapper.Map<TeacherModule>(teacherModuleDto);
        if (teacherModule.Id == 0)
        {
            teacherModule.Id = id;
        }
        if (teacherModule.Id != id)
        {
            return BadRequest();
        }
        if (teacherModule == null)
        {
            return NotFound();
        }

        if (teacherModule.CreationDate == DateTime.MinValue)
        {
            teacherModule.CreationDate = DateTime.Now;
            teacherModuleDto.CreationDate = DateTime.Now;
        }
        if (teacherModule.ModificationDate == DateTime.MinValue)
        {
            teacherModule.ModificationDate = DateTime.Now;
            teacherModuleDto.ModificationDate = DateTime.Now;
        }

        teacherModuleDto.Id = teacherModule.Id;
        _unitOfWork.TeacherModules.Update(teacherModule);
        await _unitOfWork.SaveAsync();
        return teacherModuleDto;
    }

    /* Delete Teacher Module in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherModule>> Delete(int id)
    {
        var teacherModule = await _unitOfWork.TeacherModules.GetByIdAsync(id);
        if (teacherModule == null)
        {
            return NotFound();
        }
        _unitOfWork.TeacherModules.Remove(teacherModule);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}

