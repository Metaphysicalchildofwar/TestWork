using TestWork.DAL.Services;
using TestWork.Dto.Base;
using TestWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TestWork.Api.Controllers
{
    /// <summary>
    /// Контроллер для проектов
    /// </summary>
    [ApiController]
    [Route("TypesOfСomponents")]
    public class ProjectController : ControllerBase
    {
        private readonly IService<BaseModelDto, BaseModelWithoutIdDto> _service;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="service">Сервис для проектов</param>
        public ProjectController(ProjectService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить список проектов
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат выборки</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseModelDto>>> GetAsync(int? id)
        {
            return Ok(await _service.GetAsync(id));
        }

        /// <summary>
        /// Создать объект проектов
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат создания объекта</returns>
        [HttpPut]
        public async Task<ActionResult<BaseModelDto>> PutAsync([Required] BaseModelWithoutIdDto model)
        {
            return Ok(await _service.PutAsync(model));
        }

        /// <summary>
        /// Изменить объект проектов
        /// </summary>
        /// <param name="model">Объект для изменения</param>
        ///<returns>Результат изменения объекта</returns>
        [HttpPost]
        public async Task<ActionResult<BaseModelDto>> PostAsync([Required] BaseModelDto model)
        {
            return Ok(await _service.PostAsync(model));
        }

        /// <summary>
        /// Удалить объект проектов
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат удаления объекта</returns>
        [HttpDelete]
        public async Task<ActionResult<BaseModelDto>> DeleteAsync([Required] int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}
