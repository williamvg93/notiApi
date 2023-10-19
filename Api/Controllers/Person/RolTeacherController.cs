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

public class RolTeacherController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolTeacherController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Rol Teachers in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolTeacherDto>>> Get()
    {
        var rolTeachers = await _unitOfWork.RolTeachers.GetAllAsync();
        /* return Ok(rolTeachers); */
        return _mapper.Map<List<RolTeacherDto>>(rolTeachers);
    }

    /* Get Rol Teacher by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolTeacherDto>> Get(int id)
    {
        var rolTeacher = await _unitOfWork.RolTeachers.GetByIdAsync(id);
        if (rolTeacher == null)
        {
            return NotFound();
        }
        return _mapper.Map<RolTeacherDto>(rolTeacher);
    }

    /* Add a new Rol Teacher in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolTeacher>> Post(RolTeacherPDto rolTeacherPDto)
    {
        var rolTeacher = _mapper.Map<RolTeacher>(rolTeacherPDto);

        if (rolTeacher.CreationDate == DateTime.MinValue)
        {
            rolTeacher.CreationDate = DateTime.Now;
            rolTeacherPDto.CreationDate = DateTime.Now;
        }
        if (rolTeacher.ModificationDate == DateTime.MinValue)
        {
            rolTeacher.ModificationDate = DateTime.Now;
            rolTeacherPDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.RolTeachers.Add(rolTeacher);
        await _unitOfWork.SaveAsync();
        if (rolTeacher == null)
        {
            return BadRequest();
        }
        rolTeacherPDto.Id = rolTeacher.Id;
        return CreatedAtAction(nameof(Post), new { id = rolTeacherPDto.Id }, rolTeacherPDto);
    }

    /* Update Rol Teacher in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolTeacherPDto>> Put(int id, [FromBody] RolTeacherPDto rolTeacherPDto)
    {
        var rolTeacher = _mapper.Map<RolTeacher>(rolTeacherPDto);
        if (rolTeacher.Id == 0)
        {
            rolTeacher.Id = id;
        }
        if (rolTeacher.Id != id)
        {
            return BadRequest();
        }
        if (rolTeacher == null)
        {
            return NotFound();
        }

        if (rolTeacher.CreationDate == DateTime.MinValue)
        {
            rolTeacher.CreationDate = DateTime.Now;
            rolTeacherPDto.CreationDate = DateTime.Now;
        }
        if (rolTeacher.ModificationDate == DateTime.MinValue)
        {
            rolTeacher.ModificationDate = DateTime.Now;
            rolTeacherPDto.ModificationDate = DateTime.Now;
        }

        rolTeacherPDto.Id = rolTeacher.Id;
        _unitOfWork.RolTeachers.Update(rolTeacher);
        await _unitOfWork.SaveAsync();
        return rolTeacherPDto;
    }

    /* Delete Rol Teacher in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Delete(int id)
    {
        var rolTeacher = await _unitOfWork.RolTeachers.GetByIdAsync(id);
        if (rolTeacher == null)
        {
            return NotFound();
        }
        _unitOfWork.RolTeachers.Remove(rolTeacher);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
