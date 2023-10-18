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

public class NotifiResponseController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotifiResponseController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Notification Responses in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NotificationResponseDto>>> Get()
    {
        var notiResponses = await _unitOfWork.NotiResponses.GetAllAsync();
        /* return Ok(notiResponses); */
        return _mapper.Map<List<NotificationResponseDto>>(notiResponses);
    }

    /* Get Notification Response by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NotificationResponseDto>> Get(int id)
    {
        var notiResponse = await _unitOfWork.NotiResponses.GetByIdAsync(id);
        if (notiResponse == null)
        {
            return NotFound();
        }
        return _mapper.Map<NotificationResponseDto>(notiResponse);
    }

    /* Add a new Notification Response in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationResponse>> Post(NotificationResponseDto notificationResponseDto)
    {
        var notiResponse = _mapper.Map<NotificationResponse>(notificationResponseDto);

        if (notiResponse.CreationDate == DateTime.MinValue)
        {
            notiResponse.CreationDate = DateTime.Now;
            notificationResponseDto.CreationDate = DateTime.Now;
        }
        if (notiResponse.ModificationDate == DateTime.MinValue)
        {
            notiResponse.ModificationDate = DateTime.Now;
            notificationResponseDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.NotiResponses.Add(notiResponse);
        await _unitOfWork.SaveAsync();
        if (notiResponse == null)
        {
            return BadRequest();
        }
        notificationResponseDto.Id = notiResponse.Id;
        return CreatedAtAction(nameof(Post), new { id = notificationResponseDto.Id }, notificationResponseDto);
    }

    /* Update Notification Response in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationResponseDto>> Put(int id, [FromBody] NotificationResponseDto notificationResponseDto)
    {
        var notiResponse = _mapper.Map<NotificationResponse>(notificationResponseDto);
        if (notiResponse.Id == 0)
        {
            notiResponse.Id = id;
        }
        if (notiResponse.Id != id)
        {
            return BadRequest();
        }
        if (notiResponse == null)
        {
            return NotFound();
        }

        if (notiResponse.CreationDate == DateTime.MinValue)
        {
            notiResponse.CreationDate = DateTime.Now;
            notificationResponseDto.CreationDate = DateTime.Now;
        }
        if (notiResponse.ModificationDate == DateTime.MinValue)
        {
            notiResponse.ModificationDate = DateTime.Now;
            notificationResponseDto.ModificationDate = DateTime.Now;
        }

        notificationResponseDto.Id = notiResponse.Id;
        _unitOfWork.NotiResponses.Update(notiResponse);
        await _unitOfWork.SaveAsync();
        return notificationResponseDto;
    }

    /* Delete Notification Response in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationResponse>> Delete(int id)
    {
        var notiResponse = await _unitOfWork.NotiResponses.GetByIdAsync(id);
        if (notiResponse == null)
        {
            return NotFound();
        }
        _unitOfWork.NotiResponses.Remove(notiResponse);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

