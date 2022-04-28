using System;

namespace TestWork.Domain.Base
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        public DateTime DateUpdate { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }
    }
}
