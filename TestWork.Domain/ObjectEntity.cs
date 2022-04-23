using TestWork.Domain.Base;

namespace TestWork.Domain
{
    /// <summary>
    /// Entity для объекта
    /// </summary>
    public class ObjectEntity : BaseModel
    {
        /// <summary>
        /// Идентификатор объекта проектирования
        /// </summary>
        public int? DesignObjectId { get; set; }

        /// <summary>
        /// Объект проектирования
        /// </summary>
        public DesignObjectEntity DesignObject { get; set; }
    }
}
