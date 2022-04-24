using System.Collections.Generic;
using TestWork.Domain.Base;

namespace TestWork.Domain
{
    /// <summary>
    /// Entity для проектов
    /// </summary>
    public class ProjectEntity : BaseModel
    {
        /// <summary>
        /// Связь с объектами проектирования
        /// </summary>
        public virtual IEnumerable<DesignObjectEntity> DesignObjectEntity { get; set; }
    }
}
