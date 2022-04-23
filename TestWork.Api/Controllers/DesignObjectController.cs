using TestWork.DAL.Services;
using TestWork.Dto.DesignObjects;
using TestWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TestWork.Api.Controllers
{
    /// <summary>
    /// Контроллер для объектов проектирования
    /// </summary>
    [ApiController]
    [Route("Сomponents")]
    public class DesignObjectController : ControllerBase
    {
        private readonly IService<DesignObjectDto, DesignObjectWithoutIdDto> _service;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="service">Сервис для видов объектов проектирования</param>
        public DesignObjectController(DesignObjectService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить список объектов проектирования
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат выборки</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignObjectDto>>> GetAsync(int? id)
        {
            return Ok(await _service.GetAsync(id));
        }

        /// <summary>
        /// Создать объект проектирования
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат создания объекта</returns>
        [HttpPut]
        public async Task<ActionResult<DesignObjectDto>> PutAsync([Required] DesignObjectWithoutIdDto model)
        {
            return Ok(await _service.PutAsync(model));
        }

        /// <summary>
        /// Изменить объект проектирования
        /// </summary>
        /// <param name="model">Объект для изменения</param>
        ///<returns>Результат изменения объекта</returns>
        [HttpPost]
        public async Task<ActionResult<DesignObjectDto>> PostAsync([Required] DesignObjectDto model)
        {
            return Ok(await _service.PostAsync(model));
        }

        /// <summary>
        /// Удалить объект проектирования
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат удаления объекта</returns>
        [HttpDelete]
        public async Task<ActionResult<DesignObjectDto>> DeleteAsync([Required] int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}
