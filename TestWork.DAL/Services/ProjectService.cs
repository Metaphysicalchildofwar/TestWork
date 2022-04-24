using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWork.Domain;
using TestWork.Dto.Base;
using TestWork.Interfaces;

namespace TestWork.DAL.Services
{
    /// <summary>
    /// Сервис для проектов
    /// </summary>
    public class ProjectService : IService<BaseModelDto, BaseModelWithoutIdDto>
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public ProjectService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список проектов
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат выборки</returns>
        public async Task<IEnumerable<BaseModelDto>> GetAsync(int? id)
        {
            return id == null ? await _context.Projects
                .ProjectTo<BaseModelDto>(_mapper.ConfigurationProvider)
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false) :

                await _context.Projects
                .ProjectTo<BaseModelDto>(_mapper.ConfigurationProvider)
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Создать проект
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат создания</returns>
        public async Task<BaseModelDto> PutAsync(BaseModelWithoutIdDto model)
        {
            var newProject = new ProjectEntity
            {
                Name = model.Name,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            };

            await _context.AddAsync(newProject);
            await _context.SaveChangesAsync();
            return _mapper.Map<BaseModelDto>(newProject);
        }

        /// <summary>
        /// Изменить проект
        /// </summary>
        /// <param name="model">Объект для изменения</param>
        ///<returns>Результат изменения</returns>
        public async Task<BaseModelDto> PostAsync(BaseModelDto model)
        {
            var updateProject = await GetProjectAsync(model.Id);

            if (updateProject == null)
            {
                throw new Exception("Указанного проекта не существует");
            }

            updateProject.Name = model.Name;
            updateProject.DateUpdate = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<BaseModelDto>(updateProject);
        }

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат удаления</returns>
        public async Task<BaseModelDto> DeleteAsync(int id)
        {
            var delProject = await GetProjectAsync(id);

            if (delProject == null)
            {
                throw new Exception("Указанного типа объекта проектирования не существует");
            }

            _context.Projects.Remove(delProject);

            await _context.SaveChangesAsync();

            return _mapper.Map<BaseModelDto>(delProject);
        }

        /// <summary>
        /// Получить проект
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат получения</returns>
        private async Task<ProjectEntity> GetProjectAsync(int? id)
        {
            return await _context.Projects
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }
    }
}
