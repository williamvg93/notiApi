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

public class NotifiTypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotifiTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Notifications Type in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NotificationTypeDto>>> Get()
    {
        var notiTypes = await _unitOfWork.NotiTypes.GetAllAsync();
        /* return Ok(notiTypes); */
        return _mapper.Map<List<NotificationTypeDto>>(notiTypes);
    }

    /* Get Notification Type by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NotificationTypeDto>> Get(int id)
    {
        var notiType = await _unitOfWork.NotiTypes.GetByIdAsync(id);
        if (notiType == null)
        {
            return NotFound();
        }
        return _mapper.Map<NotificationTypeDto>(notiType);
    }

    /* Add a new Notification Type in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationType>> Post(NotificationTypeDto notificationTypeDto)
    {
        var notiType = _mapper.Map<NotificationType>(notificationTypeDto);

        if (notiType.CreationDate == DateTime.MinValue)
        {
            notiType.CreationDate = DateTime.Now;
            notificationTypeDto.CreationDate = DateTime.Now;
        }
        if (notiType.ModificationDate == DateTime.MinValue)
        {
            notiType.ModificationDate = DateTime.Now;
            notificationTypeDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.NotiTypes.Add(notiType);
        await _unitOfWork.SaveAsync();
        if (notiType == null)
        {
            return BadRequest();
        }
        notificationTypeDto.Id = notiType.Id;
        return CreatedAtAction(nameof(Post), new { id = notificationTypeDto.Id }, notificationTypeDto);
    }

    /* Update Notification Type in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationTypeDto>> Put(int id, [FromBody] NotificationTypeDto notificationTypeDto)
    {
        var notiType = _mapper.Map<NotificationType>(notificationTypeDto);
        if (notiType.Id == 0)
        {
            notiType.Id = id;
        }
        if (notiType.Id != id)
        {
            return BadRequest();
        }
        if (notiType == null)
        {
            return NotFound();
        }

        if (notiType.CreationDate == DateTime.MinValue)
        {
            notiType.CreationDate = DateTime.Now;
            notificationTypeDto.CreationDate = DateTime.Now;
        }
        if (notiType.ModificationDate == DateTime.MinValue)
        {
            notiType.ModificationDate = DateTime.Now;
            notificationTypeDto.ModificationDate = DateTime.Now;
        }

        notificationTypeDto.Id = notiType.Id;
        _unitOfWork.NotiTypes.Update(notiType);
        await _unitOfWork.SaveAsync();
        return notificationTypeDto;
    }

    /* Delete Notification Type in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationTypeDto>> Delete(int id)
    {
        var notiType = await _unitOfWork.NotiTypes.GetByIdAsync(id);
        if (notiType == null)
        {
            return NotFound();
        }
        _unitOfWork.NotiTypes.Remove(notiType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

