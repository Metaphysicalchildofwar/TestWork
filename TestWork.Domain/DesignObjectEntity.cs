using TestWork.Domain.Base;
using System.Collections.Generic;

namespace TestWork.Domain
{
    /// <summary>
    /// Entity для объекта проектирования
    /// </summary>
    public class DesignObjectEntity : BaseModel
    {
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Проект
        /// </summary>
        public ProjectEntity Project { get; set; }

        /// <summary>
        /// Связь с объектами
        /// </summary>
        public virtual IEnumerable<ObjectEntity> ObjectEntity { get; set; }
    }
}
