using Core.Core;
using Interface.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public string GetText()
        {
            return "secret " + typeof(T).Name;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<T>> Get()
        {
            return await _unitOfWork.Repository<T>().GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<T> Get(int id)
        {
            return await _unitOfWork.Repository<T>().GetByIdAsync(id);
        }

    }
}
