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

public class BlockChainController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BlockChainController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all blockChains in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BlockChainDto>>> Get()
    {
        var blockChains = await _unitOfWork.BlockChains.GetAllAsync();
        /* return Ok(blockChains); */
        return _mapper.Map<List<BlockChainDto>>(blockChains);
    }

    /* Get blockChain by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BlockChainDto>> Get(int id)
    {
        var blockChain = await _unitOfWork.BlockChains.GetByIdAsync(id);
        if (blockChain == null)
        {
            return NotFound();
        }
        return _mapper.Map<BlockChainDto>(blockChain);
    }

    /* Add a new blockChain in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BlockChain>> Post(BlockChainDto blockChainDto)
    {
        var blockChain = _mapper.Map<BlockChain>(blockChainDto);

        if (blockChain.CreationDate == DateTime.MinValue)
        {
            blockChain.CreationDate = DateTime.Now;
            blockChainDto.CreationDate = DateTime.Now;
        }
        if (blockChain.ModificationDate == DateTime.MinValue)
        {
            blockChain.ModificationDate = DateTime.Now;
            blockChainDto.ModificationDate = DateTime.Now;
        }

        this._unitOfWork.BlockChains.Add(blockChain);
        await _unitOfWork.SaveAsync();
        if (blockChain == null)
        {
            return BadRequest();
        }
        blockChainDto.Id = blockChain.Id;
        return CreatedAtAction(nameof(Post), new { id = blockChainDto.Id }, blockChainDto);
    }

    /* Update blockChain in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BlockChainDto>> Put(int id, [FromBody] BlockChainDto blockChainDto)
    {
        var blockChain = _mapper.Map<BlockChain>(blockChainDto);
        if (blockChain.Id == 0)
        {
            blockChain.Id = id;
        }
        if (blockChain.Id != id)
        {
            return BadRequest();
        }
        if (blockChain == null)
        {
            return NotFound();
        }

        if (blockChain.CreationDate == DateTime.MinValue)
        {
            blockChain.CreationDate = DateTime.Now;
            blockChainDto.CreationDate = DateTime.Now;
        }
        if (blockChain.ModificationDate == DateTime.MinValue)
        {
            blockChain.ModificationDate = DateTime.Now;
            blockChainDto.ModificationDate = DateTime.Now;
        }

        blockChainDto.Id = blockChain.Id;
        _unitOfWork.BlockChains.Update(blockChain);
        await _unitOfWork.SaveAsync();
        return blockChainDto;
    }

    /* Delete blockChain in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BlockChain>> Delete(int id)
    {
        var blockChain = await _unitOfWork.BlockChains.GetByIdAsync(id);
        if (blockChain == null)
        {
            return NotFound();
        }
        _unitOfWork.BlockChains.Remove(blockChain);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
