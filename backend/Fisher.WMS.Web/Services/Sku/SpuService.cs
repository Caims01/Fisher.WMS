/*
 * date：2022-12-21
 * developer：AMo
 */
 using Mapster;
 using Microsoft.EntityFrameworkCore;
 using Fisher.WMS.Core.DBContext;
 using Fisher.WMS.Core.Services;
 using Fisher.WMS.Web.Entities.Models;
 using Fisher.WMS.Web.Entities.ViewModels;
 using Fisher.WMS.Web.IServices;
 using Microsoft.Extensions.Localization;
using Fisher.WMS.Core.DynamicSearch;
using Fisher.WMS.Core.Models;
using Fisher.WMS.Core.JWT;

namespace Fisher.WMS.Web.Services
{
    /// <summary>
    ///  Spu Service
    /// </summary>
    public class SpuService : BaseService<SpuEntity>, ISpuService
    {
        #region Args
        /// <summary>
        /// The DBContext
        /// </summary>
        private readonly SqlDBContext _dBContext;

        /// <summary>
        /// Localizer Service
        /// </summary>
        private readonly IStringLocalizer<Core.MultiLanguage> _stringLocalizer;
        #endregion

        #region constructor
        /// <summary>
        ///Spu  constructor
        /// </summary>
        /// <param name="dBContext">The DBContext</param>
        /// <param name="stringLocalizer">Localizer</param>
        public SpuService(
            SqlDBContext dBContext
          , IStringLocalizer<Core.MultiLanguage> stringLocalizer
            )
        {
            this._dBContext = dBContext;
            this._stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Api
        /// <summary>
        /// page search
        /// </summary>
        /// <param name="pageSearch">args</param>
        /// <param name="currentUser">currentUser</param>
        /// <returns></returns>
        public async Task<(List<SpuBothViewModel> data, int totals)> PageAsync(PageSearch pageSearch, CurrentUser currentUser)
        {
            QueryCollection queries = new QueryCollection();
            if (pageSearch.searchObjects.Any())
            {
                pageSearch.searchObjects.ForEach(s =>
                {
                    queries.Add(s);
                });
            }
            var Categorys = _dBContext.GetDbSet<CategoryEntity>();
            var Spus = _dBContext.GetDbSet<SpuEntity>();
            var Skus = _dBContext.GetDbSet<SkuEntity>();
            var query = from m in Spus.AsNoTracking()
                        join c in Categorys.AsNoTracking() on m.category_id equals c.id
                        where m.tenant_id == currentUser.tenant_id
                        select new SpuBothViewModel
                        {
                            id = m.id,
                            spu_code = m.spu_code,
                            spu_name = m.spu_name,
                            category_id = m.category_id,
                            category_name = c.category_name,
                            spu_description = m.spu_description,
                            bar_code = m.bar_code,
                            supplier_id = m.supplier_id,
                            supplier_name = m.supplier_name,
                            brand = m.brand,
                            origin = m.origin,
                            length_unit = m.length_unit,
                            volume_unit = m.volume_unit,
                            weight_unit = m.weight_unit,
                            creator = m.creator,
                            create_time = m.create_time,
                            last_update_time = m.last_update_time,
                            is_valid = m.is_valid,
                            detailList = Skus.AsNoTracking().Where(t => t.spu_id.Equals(m.id))
                                         .Select(t => new SkuViewModel
                                         {
                                             id = t.id,
                                             spu_id = t.spu_id,
                                             sku_code = t.sku_code,
                                             sku_name = t.sku_name,
                                             weight = t.weight,
                                             lenght = t.lenght,
                                             width = t.width,
                                             height = t.height,
                                             volume = t.volume,
                                             unit = t.unit,
                                             cost = t.cost,
                                             price = t.price,
                                             create_time = t.create_time,
                                             last_update_time = t.last_update_time
                                         }).ToList()

                        };
            query = query.Where(queries.AsExpression<SpuBothViewModel>());
            int totals = await query.CountAsync();
            var list = await query.OrderByDescending(t => t.create_time)
                       .Skip((pageSearch.pageIndex - 1) * pageSearch.pageSize)
                       .Take(pageSearch.pageSize)
                       .ToListAsync();
            return (list, totals);
        }

        /// <summary>
        /// Get a record by id
        /// </summary>
        /// <returns></returns>
        public async Task<SpuBothViewModel> GetAsync(int id)
        {
            var Categorys = _dBContext.GetDbSet<CategoryEntity>();
            var Spus = _dBContext.GetDbSet<SpuEntity>();
            var Skus = _dBContext.GetDbSet<SkuEntity>();
            var query = from m in Spus.AsNoTracking()
                        join c in Categorys.AsNoTracking() on m.category_id equals c.id
                        where m.id == id
                        select new SpuBothViewModel
                        {
                            id = m.id,
                            spu_code = m.spu_code,
                            spu_name = m.spu_name,
                            category_id = m.category_id,
                            category_name = c.category_name,
                            spu_description = m.spu_description,
                            bar_code = m.bar_code,
                            supplier_id = m.supplier_id,
                            supplier_name = m.supplier_name,
                            brand = m.brand,
                            origin = m.origin,
                            length_unit = m.length_unit,
                            volume_unit = m.volume_unit,
                            weight_unit = m.weight_unit,
                            creator = m.creator,
                            create_time = m.create_time,
                            last_update_time = m.last_update_time,
                            is_valid = m.is_valid,
                            detailList = Skus.Where(t => t.spu_id.Equals(m.id))
                                         .Select(t => new SkuViewModel
                                         {
                                             id = t.id,
                                             spu_id = t.spu_id,
                                             sku_code = t.sku_code,
                                             sku_name = t.sku_name,
                                             weight = t.weight,
                                             lenght = t.lenght,
                                             width = t.width,
                                             height = t.height,
                                             volume = t.volume,
                                             unit = t.unit,
                                             cost = t.cost,
                                             price = t.price,
                                             create_time = t.create_time,
                                             last_update_time = t.last_update_time
                                         }).ToList()

                        };
            var data = await query.FirstOrDefaultAsync();
            if (data != null)
            {
                return data;
            }
            else
            {
                return new SpuBothViewModel();
            }
        }
        /// <summary>
        /// get sku info by sku_id
        /// </summary>
        /// <param name="sku_id">sku_id</param>
        /// <returns></returns>
        public async Task<SkuDetailViewModel> GetSkuAsync(int sku_id)
        {
            var Categorys = _dBContext.GetDbSet<CategoryEntity>();
            var Spus = _dBContext.GetDbSet<SpuEntity>();
            var Skus = _dBContext.GetDbSet<SkuEntity>();
            var query = from m in Spus.AsNoTracking()
                        join c in Categorys.AsNoTracking() on m.category_id equals c.id
                        join d in Skus.AsNoTracking() on m.id equals d.spu_id
                        where d.id == sku_id
                        select new SkuDetailViewModel
                        {  
                            spu_id = m.id,
                            spu_code = m.spu_code,
                            spu_name = m.spu_name,
                            category_id = m.category_id,
                            category_name = c.category_name,
                            spu_description = m.spu_description,
                            bar_code = m.bar_code,
                            supplier_id = m.supplier_id,
                            supplier_name = m.supplier_name,
                            brand = m.brand,
                            origin = m.origin,
                            length_unit = m.length_unit,
                            volume_unit = m.volume_unit,
                            weight_unit = m.weight_unit,
                            sku_id = d.id,
                            sku_code = d.sku_code,
                            sku_name = d.sku_name,
                            weight = d.weight,
                            lenght = d.lenght,
                            width = d.width,
                            height = d.height,
                            volume = d.volume,
                            unit = d.unit,
                            cost = d.cost,
                            price = d.price
                        };
            var data = await query.FirstOrDefaultAsync();
            if (data != null)
            {
                return data;
            }
            else
            {
                return new SkuDetailViewModel();
            }

        }

        /// <summary>
        /// add a new record
        /// </summary>
        /// <param name="viewModel">viewmodel</param>
        /// <param name="currentUser">currentUser</param>
        /// <returns></returns>
        public async Task<(int id, string msg)> AddAsync(SpuBothViewModel viewModel, CurrentUser currentUser)
        {
            var DbSet = _dBContext.GetDbSet<SpuEntity>();
            if (await DbSet.AsNoTracking().AnyAsync(t => t.tenant_id.Equals(currentUser.tenant_id) && t.spu_code.Equals(viewModel.spu_code)))
            {
                return (0, string.Format(_stringLocalizer["exists_entity"], _stringLocalizer["spu_code"], viewModel.spu_code));
            }
            var entity = viewModel.Adapt<SpuEntity>();
            entity.id = 0;
            entity.creator = currentUser.user_name;
            entity.create_time = DateTime.Now;
            entity.last_update_time = DateTime.Now;
            entity.tenant_id = currentUser.tenant_id;
            if (viewModel.detailList.Any())
            {
                decimal dec = ChangeLengthUnit(entity.length_unit, entity.volume_unit);
                viewModel.detailList.ForEach(t =>
                {
                    t.id = 0;
                    t.volume = Math.Round(t.lenght * dec * t.width * dec * t.height * dec, 3);
                });
            }
            await DbSet.AddAsync(entity);
            await _dBContext.SaveChangesAsync();
            if (entity.id > 0)
            {
                return (entity.id, _stringLocalizer["save_success"]);
            }
            else
            {
                return (0, _stringLocalizer["save_failed"]);
            }
        }
        /// <summary>
        /// change to the volume unit
        /// </summary>
        /// <param name="length_unit">length_unit</param>
        /// <param name="volume_unit">volume_unit</param>
        /// <returns></returns>
        private decimal ChangeLengthUnit(byte length_unit, byte volume_unit)
        {
            if (volume_unit.Equals(0)) // cm3
            {
                if (length_unit.Equals(0)) //mm
                {
                    return 0.1M;
                }
                else if (length_unit.Equals(2)) // dm
                {
                    return 10M;
                }
                else if (length_unit.Equals(3)) // m
                {
                    return 100M;
                }
                else // cm
                {
                    return 1M;
                }
            }
            else if (volume_unit.Equals(1)) // dm3
            {
                if (length_unit.Equals(0))
                {
                    return 0.01M;
                }
                else if (length_unit.Equals(2))
                {
                    return 1M;
                }
                else if (length_unit.Equals(3))
                {
                    return 10M;
                }
                else
                {
                    return 0.1M;
                }
            }
            else if (volume_unit.Equals(2)) // m3
            {
                if (length_unit.Equals(0))
                {
                    return 0.001M;
                }
                else if (length_unit.Equals(2))
                {
                    return 0.1M;
                }
                else if (length_unit.Equals(3))
                {
                    return 1M;
                }
                else
                {
                    return 0.01M;
                }
            }
            else
            {
                return 1M;
            }

        }
        /// <summary>
        /// update a record
        /// </summary>
        /// <param name="viewModel">args</param>
        /// <returns></returns>
        public async Task<(bool flag, string msg)> UpdateAsync(SpuBothViewModel viewModel)
        {
            var DbSet = _dBContext.GetDbSet<SpuEntity>();
            var entity = await DbSet.Include(d => d.detailList).FirstOrDefaultAsync(t => t.id.Equals(viewModel.id));
            if (entity == null)
            {
                return (false, _stringLocalizer["not_exists_entity"]);
            }
            if (await DbSet.AsNoTracking().AnyAsync(t => !t.id.Equals(viewModel.id) && t.tenant_id.Equals(entity.tenant_id) && t.spu_code.Equals(viewModel.spu_code)))
            {
                return (false, string.Format(_stringLocalizer["exists_entity"], _stringLocalizer["spu_code"], viewModel.spu_code));
            }
            entity.spu_code = viewModel.spu_code;
            entity.spu_name = viewModel.spu_name;
            entity.category_id = viewModel.category_id;
            entity.spu_description = viewModel.spu_description;
            entity.bar_code = viewModel.bar_code;
            entity.supplier_id = viewModel.supplier_id;
            entity.supplier_name = viewModel.supplier_name;
            entity.brand = viewModel.brand;
            entity.origin = viewModel.origin;
            entity.length_unit = viewModel.length_unit;
            entity.volume_unit = viewModel.volume_unit;
            entity.weight_unit = viewModel.weight_unit;
            entity.is_valid = viewModel.is_valid;
            entity.last_update_time = DateTime.Now;
           
            
            if (viewModel.detailList.Any(t => t.id > 0))
            {
                entity.detailList.ForEach(d =>
                {
                    var vm = viewModel.detailList.Where(t => t.id > 0).FirstOrDefault(t => t.id == d.id);
                    if (vm != null)
                    {
                        d.sku_code = vm.sku_code;
                        d.sku_name = vm.sku_name;
                        d.weight = vm.weight;
                        d.lenght = vm.lenght;
                        d.width = vm.width;
                        d.height = vm.height;
                        d.volume = vm.volume;
                        d.unit = vm.unit;
                        d.cost = vm.cost;
                        d.price = vm.price;
                        d.last_update_time = DateTime.Now;
                    }
                });
            }
            if (viewModel.detailList.Any(t => t.id == 0))
            {
                entity.detailList.AddRange(viewModel.detailList.Where(t => t.id == 0).ToList().Adapt<List<SkuEntity>>());
            }
            if (viewModel.detailList.Any(t => t.id < 0))
            {
                var delIds = viewModel.detailList.Where(t => t.id < 0).Select(t => t.id * -1).ToList();
                entity.detailList.RemoveAll(entity => delIds.Contains(entity.id));
            }
            var qty = await _dBContext.SaveChangesAsync();
            if (qty > 0)
            {
                decimal dec = ChangeLengthUnit(entity.length_unit, entity.volume_unit);
                await _dBContext.GetDbSet<SkuEntity>().Where(t => t.spu_id.Equals(entity.id))
                    .ExecuteUpdateAsync(p => p.SetProperty(x => x.volume, x => Math.Round(x.lenght * dec * x.width * dec * x.height * dec, 3)));
                return (true, _stringLocalizer["save_success"]);
            }
            else
            {
                return (false, _stringLocalizer["save_failed"]);
            }
        }
        /// <summary>
        /// delete a record
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<(bool flag, string msg)> DeleteAsync(int id)
        {
            var Asns = _dBContext.GetDbSet<AsnEntity>();
            if(await Asns.AsNoTracking().AnyAsync(t => t.spu_id.Equals(id)))
            {
                return (false, _stringLocalizer["delete_referenced"]);
            }
            var qty = await _dBContext.GetDbSet<SkuEntity>().Where(t => t.spu_id.Equals(id)).ExecuteDeleteAsync();
            qty += await _dBContext.GetDbSet<SpuEntity>().Where(t => t.id.Equals(id)).ExecuteDeleteAsync();
            if (qty > 0)
            {
                return (true, _stringLocalizer["delete_success"]);
            }
            else
            {
                return (false, _stringLocalizer["delete_failed"]);
            }
        }
        #endregion
    }
 }
 
