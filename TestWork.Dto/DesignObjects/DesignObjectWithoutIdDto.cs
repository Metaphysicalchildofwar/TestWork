using TestWork.Dto.Base;

namespace TestWork.Dto.DesignObjects
{
    /// <summary>
    /// Модель для объектов проектирования без идентификатора
    /// </summary>
    public class DesignObjectWithoutIdDto : BaseModelWithoutIdDto
    {
        /// <summary>
        /// Проект
        /// </summary>
        public BaseModelDto Project { get; set; }
    }
}
