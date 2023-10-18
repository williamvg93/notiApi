using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Notifications;
using Api.Dtos.Post.Notification;
using AutoMapper;
using Core.Entities.Notifications;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Notifications;

public class NotifiModuleController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotifiModuleController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Notification Modules in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NotificationModuleDto>>> Get()
    {
        var notiModules = await _unitOfWork.NotiModules.GetAllAsync();
        /* return Ok(notiModules); */
        return _mapper.Map<List<NotificationModuleDto>>(notiModules);
    }

    /* Get Notification Module by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NotificationModuleDto>> Get(int id)
    {
        var notiModule = await _unitOfWork.NotiModules.GetByIdAsync(id);
        if (notiModule == null)
        {
            return NotFound();
        }
        return _mapper.Map<NotificationModuleDto>(notiModule);
    }

    /* Add a new Notification Module in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationModule>> Post(NotificationModulePDto notificationModulePDto
    )
    {
        var notiModule = _mapper.Map<NotificationModule>(notificationModulePDto);

        if (notiModule.CreationDate == DateTime.MinValue)
        {
            notiModule.CreationDate = DateTime.Now;
            notificationModulePDto.CreationDate = DateTime.Now;
        }
        if (notiModule.ModificationDate == DateTime.MinValue)
        {
            notiModule.ModificationDate = DateTime.Now;
            notificationModulePDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.NotiModules.Add(notiModule);
        await _unitOfWork.SaveAsync();
        if (notiModule == null)
        {
            return BadRequest();
        }
        notificationModulePDto.Id = notiModule.Id;
        return CreatedAtAction(nameof(Post), new { id = notificationModulePDto.Id }, notificationModulePDto);
    }

    /* Update Notification Module in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationModulePDto>> Put(int id, [FromBody] NotificationModulePDto notificationModulePDto)
    {
        var notiModule = _mapper.Map<NotificationModule>(notificationModulePDto);
        if (notiModule.Id == 0)
        {
            notiModule.Id = id;
        }
        if (notiModule.Id != id)
        {
            return BadRequest();
        }
        if (notiModule == null)
        {
            return NotFound();
        }

        if (notiModule.CreationDate == DateTime.MinValue)
        {
            notiModule.CreationDate = DateTime.Now;
            notificationModulePDto.CreationDate = DateTime.Now;
        }
        if (notiModule.ModificationDate == DateTime.MinValue)
        {
            notiModule.ModificationDate = DateTime.Now;
            notificationModulePDto.ModificationDate = DateTime.Now;
        }

        notificationModulePDto.Id = notiModule.Id;
        _unitOfWork.NotiModules.Update(notiModule);
        await _unitOfWork.SaveAsync();
        return notificationModulePDto;
    }

    /* Delete Notification Module in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationModule>> Delete(int id)
    {
        var notiModule = await _unitOfWork.NotiModules.GetByIdAsync(id);
        if (notiModule == null)
        {
            return NotFound();
        }
        _unitOfWork.NotiModules.Remove(notiModule);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

