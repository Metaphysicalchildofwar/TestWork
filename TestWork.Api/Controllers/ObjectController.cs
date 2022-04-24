using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TestWork.DAL.Services;
using TestWork.Dto.Objects;
using TestWork.Interfaces;

namespace TestWork.Api.Controllers
{
    /// <summary>
    /// Контроллер для объектов
    /// </summary>
    [ApiController]
    [Route("Objects")]
    public class ObjectController : ControllerBase
    {
        private readonly IService<ObjectDto, ObjectWithoutIdDto> _service;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="service">Сервис для проектов</param>
        public ObjectController(ObjectService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить список объектов
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат выборки</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectDto>>> GetAsync(int? id)
        {
            return Ok(await _service.GetAsync(id));
        }

        /// <summary>
        /// Создать объект
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат создания объекта</returns>
        [HttpPut]
        public async Task<ActionResult<ObjectDto>> PutAsync([Required] ObjectWithoutIdDto model)
        {
            return Ok(await _service.PutAsync(model));
        }

        /// <summary>
        /// Изменить объект
        /// </summary>
        /// <param name="model">Объект для изменения</param>
        ///<returns>Результат изменения объекта</returns>
        [HttpPost]
        public async Task<ActionResult<ObjectDto>> PostAsync([Required] ObjectDto model)
        {
            return Ok(await _service.PostAsync(model));
        }

        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат удаления объекта</returns>
        [HttpDelete]
        public async Task<ActionResult<ObjectDto>> DeleteAsync([Required] int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}
