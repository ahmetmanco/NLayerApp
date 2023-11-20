using AutoMapper;
using Microsoft.AspNetCore.Http;
using Nlayer.Core.DTOs;
using Nlayer.Core.Entities;
using Nlayer.Core.Repositories;
using Nlayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Services
{
    public class ServiceWithDto<Entity, Dto> : IServiceWithDto<Entity, Dto> where Entity : BaseEntity where Dto : class
    {
        private readonly IGenericRepository<Entity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ServiceWithDto(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Entity> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CustomResponseDto<Dto>> AddAsync(Dto dto)
        {
            Entity entity = _mapper.Map<Entity>(dto);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            var Dto = _mapper.Map<Dto>(entity);

            return CustomResponseDto<Dto>.Success(StatusCodes.Status200OK, Dto);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dto)
        {
            var newEntities = _mapper.Map<IEnumerable<Entity>>(dto);
            await _repository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();
            var Dto = _mapper.Map<IEnumerable<Dto>>(newEntities);

            return CustomResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var result = await _repository.AnyAsync(expression);
            return CustomResponseDto<bool>(StatusCodes.Status200OK, result);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();
        }

        public Task<CustomResponseDto<Dto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<int> id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<NoContentDto>> UpdateAsync(Dto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<IQueryable<Dto>>> Where(Expression<Func<Dto, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
