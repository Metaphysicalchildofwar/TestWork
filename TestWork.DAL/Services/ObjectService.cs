using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWork.Domain;
using TestWork.Dto.Objects;
using TestWork.Interfaces;

namespace TestWork.DAL.Services
{
    /// <summary>
    /// Сервис для объектов
    /// </summary>
    public class ObjectService : IService<ObjectDto, ObjectWithoutIdDto>
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public ObjectService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список объектов
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат выборки</returns>
        public async Task<IEnumerable<ObjectDto>> GetAsync(int? id)
        {
            return id == null ? await _context.Objects
                .Include(x => x.DesignObject)
                .ProjectTo<ObjectDto>(_mapper.ConfigurationProvider)
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false) :

                await _context.Objects
                .Include(x => x.DesignObject)
                .ProjectTo<ObjectDto>(_mapper.ConfigurationProvider)
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Создать объект
        /// </summary>
        /// <param name="model">Объект для создания</param>
        ///<returns>Результат создания</returns>
        public async Task<ObjectDto> PutAsync(ObjectWithoutIdDto model)
        {
            var designObject = await GetDesignObjectAsync(model.DesignObject.Id);

            if (designObject == null)
            {
                throw new Exception("Указанного объекта проектирования не существует");
            }

            var newObject = new ObjectEntity
            {
                Name = model.Name,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now,
                DesignObject = designObject,
                Code = model.Code
            };

            await _context.AddAsync(newObject);
            await _context.SaveChangesAsync();
            return _mapper.Map<ObjectDto>(newObject);
        }

        /// <summary>
        /// Изменить объект
        /// </summary>
        /// <param name="model">Объект для изменения</param>
        ///<returns>Результат изменения</returns>
        public async Task<ObjectDto> PostAsync(ObjectDto model)
        {
            var updateObject = await GetObjectAsync(model.Id);
            if (updateObject == null)
            {
                throw new Exception("Указанного объекта не существует");
            }
            if (model.DesignObject != null)
            {
                var designObject = await GetDesignObjectAsync(model.DesignObject.Id);
                updateObject.DesignObject = designObject ?? throw new Exception("Указанного объекта проектирования не существует");
            }

            updateObject.Name = model.Name;
            updateObject.DateUpdate = DateTime.Now;
            updateObject.Code = model.Code;

            await _context.SaveChangesAsync();

            return _mapper.Map<ObjectDto>(updateObject);
        }

        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат удаления</returns>
        public async Task<ObjectDto> DeleteAsync(int id)
        {
            var delObject = await GetObjectAsync(id);

            if (delObject == null)
            {
                throw new Exception("Указанного типа объекта не существует");
            }

            _context.Objects.Remove(delObject);

            await _context.SaveChangesAsync();

            return _mapper.Map<ObjectDto>(delObject);
        }

        /// <summary>
        /// Получить объект
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат получения</returns>
        private async Task<ObjectEntity> GetObjectAsync(int? id)
        {
            return await _context.Objects
                .Include(x => x.DesignObject).ThenInclude(x => x.Project)
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Получить объект проектирования
        /// </summary>
        /// <param name="id">Идентификатор</param>
        ///<returns>Результат получения</returns>
        private async Task<DesignObjectEntity> GetDesignObjectAsync(int? id)
        {
            return await _context.DesignObjects
                .Include(x => x.Project)
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }
    }
}
