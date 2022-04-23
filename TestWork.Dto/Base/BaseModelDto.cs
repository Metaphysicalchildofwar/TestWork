using System.ComponentModel.DataAnnotations;

namespace TestWork.Dto.Base
{
    /// <summary>
    /// Базовая модель с идентификатором
    /// </summary>
    public class BaseModelDto : BaseModelWithoutIdDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required]
        public int? Id { get; set; }
    }
}
