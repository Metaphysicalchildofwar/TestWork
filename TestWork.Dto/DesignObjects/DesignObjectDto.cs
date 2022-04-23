using TestWork.Dto.Base;

namespace TestWork.Dto.DesignObjects
{
    /// <summary>
    /// Модель для объектов проектирования с идентификатором
    /// </summary>
    public class DesignObjectDto : BaseModelDto
    {
        /// <summary>
        /// Проект
        /// </summary>
        public BaseModelDto Project { get; set; }
    }
}
