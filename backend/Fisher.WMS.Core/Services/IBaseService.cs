
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fisher.WMS.Core.DI;
using Fisher.WMS.Core.Models;
namespace Fisher.WMS.Core.Services
{

    public interface IBaseService<TEntity> : IDependency where TEntity : BaseModel
    {
        
    }
}
