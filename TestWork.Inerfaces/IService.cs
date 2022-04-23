using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWork.Interfaces
{
    /// <summary>
    /// Интерфейс для сервисов
    /// </summary>
    public interface IService<T, Y>
    {
        /// <summary>
        /// Получить список элементов
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат выборки</returns>
        public Task<IEnumerable<T>> GetAsync(int? id);

        /// <summary>
        /// Создать элемент
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат создания</returns>
        public Task<T> PutAsync(Y model);

        /// <summary>
        /// Изменить элемент
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат изменения</returns>
        public Task<T> PostAsync(T model);

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат удаления</returns>
        public Task<T> DeleteAsync(int id);
    }
}
