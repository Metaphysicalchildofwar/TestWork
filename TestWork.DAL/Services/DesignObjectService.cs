using AutoMapper;
using AutoMapper.QueryableExtensions;
using TestWork.Domain;
using TestWork.Dto.DesignObjects;
using TestWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWork.DAL.Services
{
    /// <summary>
    /// Сервис для объектов проектирования
    /// </summary>
    public class DesignObjectService : IService<DesignObjectDto, DesignObjectWithoutIdDto>
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public DesignObjectService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список объектов проектирования
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат выборки</returns>
        public async Task<IEnumerable<DesignObjectDto>> GetAsync(int? id)
        {
            return id == null ? await _context.DesignObjects
                .Include(x => x.Project)
                .ProjectTo<DesignObjectDto>(_mapper.ConfigurationProvider)
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false) :

                await _context.DesignObjects
                .Include(x => x.Project)
                .ProjectTo<DesignObjectDto>(_mapper.ConfigurationProvider)
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Создать объекты проектирования
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат создания</returns>
        public async Task<DesignObjectDto> PutAsync(DesignObjectWithoutIdDto model)
        {
            var project = await GetProjectAsync(model.Project.Id);
            if (project == null)
            {
                throw new Exception("Указанного проекта не существует");
            }

            var newDesignObject = new DesignObjectEntity
            {
                Name = model.Name,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                Project = project
            };

            await _context.AddAsync(newDesignObject);
            await _context.SaveChangesAsync();
            return _mapper.Map<DesignObjectDto>(newDesignObject);
        }

        /// <summary>
        /// Изменить объекты проектирования
        /// </summary>
        /// <param name="model">Объект для изменения</param>
        ///<returns>Результат изменения</returns>
        public async Task<DesignObjectDto> PostAsync(DesignObjectDto model)
        {
            var updateDesignObject = await GetDesignObjectAsync(model.Id);
            if (updateDesignObject == null)
            {
                throw new Exception("Указанного объекта проектирования не существует");
            }
            if (model.Project != null)
            {
                var project = await GetProjectAsync(model.Project.Id);
                updateDesignObject.Project = project ?? throw new Exception("Указанного проекта не существует");
            }

            updateDesignObject.Name = model.Name;
            updateDesignObject.DateUpdate = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<DesignObjectDto>(updateDesignObject);
        }

        /// <summary>
        /// Удалить объекты проектирования
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат удаления</returns>
        public async Task<DesignObjectDto> DeleteAsync(int id)
        {
            var delDesignObject = await GetDesignObjectAsync(id);

            if (delDesignObject == null)
            {
                throw new Exception("Указанного объекта проектирования не существует");
            }

            _context.DesignObjects.Remove(delDesignObject);
            await _context.SaveChangesAsync();

            return _mapper.Map<DesignObjectDto>(delDesignObject);
        }

        /// <summary>
        /// Получить объекты проектирования
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат получения</returns>
        private async Task<DesignObjectEntity> GetDesignObjectAsync(int? id)
        {
            return await _context.DesignObjects
                .AsQueryable()
                .Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Получить проекты
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
