using System.ComponentModel.DataAnnotations;

namespace TestWork.Dto.Base
{
    /// <summary>
    /// Базовая модель без идентификатора
    /// </summary>
    public class BaseModelWithoutIdDto
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
