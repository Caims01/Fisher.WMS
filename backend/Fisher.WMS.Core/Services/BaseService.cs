﻿
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fisher.WMS.Core.Models;
using Microsoft.Extensions.Localization;

namespace Fisher.WMS.Core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseModel
    {

    }
}
