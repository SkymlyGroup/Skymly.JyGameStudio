﻿using BootstrapBlazor.Components;

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

using Skymly.JyGameStudio.BlazorApp.Shared.Pages;
using Skymly.JyGameStudio.Data;
using Skymly.JyGameStudio.Models;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Data
{
    /// <summary>
    /// BootstrapBlazor 服务扩展类
    /// </summary>
    public static class TableDemoDataServiceCollectionExtensions
    {
        /// <summary>
        /// 增加 PetaPoco 数据库操作服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTableDemoDataService(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IDataService<Foo>), typeof(TableDemoDataService<>));
            services.AddScoped(typeof(IDataService<Aoyi>), typeof(AoyiDataService));
            services.AddScoped(typeof(IDataService<Battle>), typeof(BattleDataService));
            return services;
        }
    }

    internal class BattleDataService : DataServiceBase<Battle>
    {
        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<Battle>, string, SortOrder, IEnumerable<Battle>>> SortLambdaCache = new();

        private List<Battle> Items { get; set; }

        private IStringLocalizer<Battle> Localizer { get; set; }

        public BattleDataService(IStringLocalizer<Battle> localizer, ScriptsContext context)
        {
            DataContext = context;
            Localizer = localizer;
        }

        private ScriptsContext DataContext { get; set; }

        public override async Task<QueryData<Battle>> QueryAsync(QueryPageOptions options)
        {
            Items = await DataContext.Battle.Include(v => v.BattleRoles).ToListAsync();
            var items = Items.AsEnumerable();
            var isSearched = false;
            // 处理高级查询
            if (options.SearchModel is Battle model)
            {
                if (!string.IsNullOrEmpty(model.Key))
                {
                    items = items.Where(item => item.Key?.Contains(model.Key, StringComparison.OrdinalIgnoreCase) ?? false);
                }
                if (!string.IsNullOrEmpty(model.Mapkey))
                {
                    items = items.Where(item => item.Mapkey?.Contains(model.Mapkey, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                isSearched = !string.IsNullOrEmpty(model.Key) || !string.IsNullOrEmpty(model.Mapkey);
            }

            if (options.Searchs.Any())
            {
                // 针对 SearchText 进行模糊查询
                items = items.Where(options.Searchs.GetFilterFunc<Battle>(FilterLogic.Or));
            }

            // 过滤
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Battle>());
                isFiltered = true;
            }

            // 排序
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // 外部未进行排序，内部自动进行排序处理
                var invoker = SortLambdaCache.GetOrAdd(typeof(Battle), key => LambdaExtensions.GetSortLambda<Battle>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }
            var total = items.Count();
            return new QueryData<Battle>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            };
        }
    }


    internal class AoyiDataService : DataServiceBase<Aoyi>
    {
        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<Aoyi>, string, SortOrder, IEnumerable<Aoyi>>> SortLambdaCache = new();

        private List<Aoyi> Items { get; set; }

        private IStringLocalizer<Aoyi> Localizer { get; set; }

        public AoyiDataService(IStringLocalizer<Aoyi> localizer, ScriptsContext context)
        {
            DataContext = context;
            Localizer = localizer;
        }

        private ScriptsContext DataContext { get; set; }

        public override async Task<QueryData<Aoyi>> QueryAsync(QueryPageOptions options)
        {
            Items = await DataContext.Aoyi.Include(v => v.AoyiConditions).ToListAsync();
            var items = Items.AsEnumerable();
            var isSearched = false;
            // 处理高级查询
            if (options.SearchModel is Aoyi model)
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    items = items.Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false);
                }
                if (!string.IsNullOrEmpty(model.Start))
                {
                    items = items.Where(item => item.Start?.Contains(model.Start, StringComparison.OrdinalIgnoreCase) ?? false);
                }
                if (!string.IsNullOrEmpty(model.Buff))
                {
                    items = items.Where(item => item.Start?.Contains(model.Start, StringComparison.OrdinalIgnoreCase) ?? false);
                }
                isSearched = !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Start) || !string.IsNullOrEmpty(model.Buff);
            }

            if (options.Searchs.Any())
            {
                // 针对 SearchText 进行模糊查询
                items = items.Where(options.Searchs.GetFilterFunc<Aoyi>(FilterLogic.Or));
            }

            // 过滤
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<Aoyi>());
                isFiltered = true;
            }

            // 排序
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // 外部未进行排序，内部自动进行排序处理
                var invoker = SortLambdaCache.GetOrAdd(typeof(Aoyi), key => LambdaExtensions.GetSortLambda<Aoyi>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }
            var total = items.Count();
            return new QueryData<Aoyi>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override async Task<bool> SaveAsync(Aoyi model)
        {
            var ret = false;
            if (model is Aoyi foo)
            {
                var item = Items?.FirstOrDefault(item =>
                {
                    var f = item as Aoyi;
                    return f.Id == foo.Id;
                });
                if (item == null)
                {
                    var id = Guid.NewGuid();
                    item = new Aoyi()
                    {
                        Id = id,
                        Name = foo.Name,
                        Start = foo.Start,
                        AddPower = foo.AddPower,
                        Animation = foo.Animation,
                        AoyiConditions = foo.AoyiConditions,
                        Buff = foo.Buff,
                        Level = foo.Level,
                        Probability = foo.Probability
                    };
                    Items?.Add(item!);
                    DataContext.Add(item);
                }
                else
                {
                    var f = item as Aoyi;
                    f.Name = foo.Name;
                    f.Name = foo.Name;
                    f.Start = foo.Start;
                    f.AddPower = foo.AddPower;
                    f.Animation = foo.Animation;
                    f.AoyiConditions = foo.AoyiConditions;
                    f.Buff = foo.Buff;
                    f.Level = foo.Level;
                    f.Probability = foo.Probability;
                    DataContext.Update<Aoyi>(item);
                }
                var changes = await DataContext.SaveChangesAsync();
                ret = changes == 1;
            }
            return ret;
        }
    }

    /// <summary>
    /// 演示网站示例数据注入服务实现类
    /// </summary>
    internal class TableDemoDataService<TModel> : DataServiceBase<TModel> where TModel : class, new()
    {
        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<TModel>, string, SortOrder, IEnumerable<TModel>>> SortLambdaCache = new();

        private List<TModel> Items { get; set; }

        private IStringLocalizer<Foo> Localizer { get; set; }

        public TableDemoDataService(IStringLocalizer<Foo> localizer)
        {
            Localizer = localizer;

        }

        /// <summary>
        /// 查询操作方法
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Task<QueryData<TModel>> QueryAsync(QueryPageOptions options)
        {
            // 此处代码实战中不可用，仅仅为演示而写防止数据全部被删除
            if (Items == null || Items.Count == 0)
            {
                Items = Foo.GenerateFoo(Localizer).Cast<TModel>().ToList();
            }

            var items = Items.AsEnumerable();
            var isSearched = false;
            // 处理高级查询
            if (options.SearchModel is Foo model)
            {
                if (!string.IsNullOrEmpty(model.Name)) items = items.Cast<Foo>().Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false).Cast<TModel>();
                if (!string.IsNullOrEmpty(model.Address)) items = items.Cast<Foo>().Where(item => item.Address?.Contains(model.Address, StringComparison.OrdinalIgnoreCase) ?? false).Cast<TModel>();
                isSearched = !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Address);
            }

            if (options.Searchs.Any())
            {
                // 针对 SearchText 进行模糊查询
                items = items.Where(options.Searchs.GetFilterFunc<TModel>(FilterLogic.Or));
            }

            // 过滤
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<TModel>());
                isFiltered = true;
            }

            // 排序
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // 外部未进行排序，内部自动进行排序处理
                var invoker = SortLambdaCache.GetOrAdd(typeof(Foo), key => LambdaExtensions.GetSortLambda<TModel>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return Task.FromResult(new QueryData<TModel>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Task<bool> SaveAsync(TModel model)
        {
            var ret = false;
            if (model is Foo foo)
            {
                var item = Items?.FirstOrDefault(item =>
                {
                    var f = item as Foo;
                    return f.Id == foo.Id;
                });
                if (item == null)
                {
                    var id = Items!.Count + 1;
                    while (Items.FirstOrDefault(item => (item as Foo)!.Id == id) != null)
                    {
                        id++;
                    }
                    item = new Foo()
                    {
                        Id = id,
                        Name = foo.Name,
                        Address = foo.Address,
                        Complete = foo.Complete,
                        Count = foo.Count,
                        DateTime = foo.DateTime,
                        Education = foo.Education,
                        Hobby = foo.Hobby
                    } as TModel;
                    Items?.Add(item!);
                }
                else
                {
                    var f = item as Foo;
                    f.Name = foo.Name;
                    f.Address = foo.Address;
                    f.Complete = foo.Complete;
                    f.Count = foo.Count;
                    f.DateTime = foo.DateTime;
                    f.Education = foo.Education;
                    f.Hobby = foo.Hobby;
                }
                ret = true;
            }
            return Task.FromResult(ret);
        }

        public override Task<bool> DeleteAsync(IEnumerable<TModel> models)
        {
            foreach (var model in models)
            {
                Items?.Remove(model);
            }

            return base.DeleteAsync(models);
        }
    }
}
