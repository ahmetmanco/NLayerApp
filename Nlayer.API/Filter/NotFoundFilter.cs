﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nlayer.Core.DTOs;
using Nlayer.Core.Entities;
using Nlayer.Core.Services;

namespace Nlayer.API.Filter
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            {  if (idValue == null) { await next.Invoke();
                    return;
                }
            }
            var id = (int)idValue;
            var anyentity = await _service.AnyAsync(x => x.Id == id);

            if(anyentity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail($"{typeof(T).Name}({id})", 404));
        }
    }
}
