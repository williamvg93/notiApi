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

public class NotifiStatusController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotifiStatusController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Notification Status in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NotificationStatusDto>>> Get()
    {
        var notiStatus = await _unitOfWork.NotiStatus.GetAllAsync();
        /* return Ok(notiStatus); */
        return _mapper.Map<List<NotificationStatusDto>>(notiStatus);
    }

    /* Get Notification Status by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NotificationStatusDto>> Get(int id)
    {
        var notiSta = await _unitOfWork.NotiStatus.GetByIdAsync(id);
        if (notiSta == null)
        {
            return NotFound();
        }
        return _mapper.Map<NotificationStatusDto>(notiSta);
    }

    /* Add a new Notification Status in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationStatus>> Post(NotificationStatusDto notificationStatusDto)
    {
        var notiSta = _mapper.Map<NotificationStatus>(notificationStatusDto);

        if (notiSta.CreationDate == DateTime.MinValue)
        {
            notiSta.CreationDate = DateTime.Now;
            notificationStatusDto.CreationDate = DateTime.Now;
        }
        if (notiSta.ModificationDate == DateTime.MinValue)
        {
            notiSta.ModificationDate = DateTime.Now;
            notificationStatusDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.NotiStatus.Add(notiSta);
        await _unitOfWork.SaveAsync();
        if (notiSta == null)
        {
            return BadRequest();
        }
        notificationStatusDto.Id = notiSta.Id;
        return CreatedAtAction(nameof(Post), new { id = notificationStatusDto.Id }, notificationStatusDto);
    }

    /* Update Notification Status in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationStatusDto>> Put(int id, [FromBody] NotificationStatusDto notificationStatusDto)
    {
        var notiSta = _mapper.Map<NotificationStatus>(notificationStatusDto);
        if (notiSta.Id == 0)
        {
            notiSta.Id = id;
        }
        if (notiSta.Id != id)
        {
            return BadRequest();
        }
        if (notiSta == null)
        {
            return NotFound();
        }

        if (notiSta.CreationDate == DateTime.MinValue)
        {
            notiSta.CreationDate = DateTime.Now;
            notificationStatusDto.CreationDate = DateTime.Now;
        }
        if (notiSta.ModificationDate == DateTime.MinValue)
        {
            notiSta.ModificationDate = DateTime.Now;
            notificationStatusDto.ModificationDate = DateTime.Now;
        }

        notificationStatusDto.Id = notiSta.Id;
        _unitOfWork.NotiStatus.Update(notiSta);
        await _unitOfWork.SaveAsync();
        return notificationStatusDto;
    }

    /* Delete Notification Status in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationStatus>> Delete(int id)
    {
        var notiSta = await _unitOfWork.NotiStatus.GetByIdAsync(id);
        if (notiSta == null)
        {
            return NotFound();
        }
        _unitOfWork.NotiStatus.Remove(notiSta);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

