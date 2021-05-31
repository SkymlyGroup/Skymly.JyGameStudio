using BootstrapBlazor.Components;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Skymly.JyGameStudio.Data;
using Skymly.JyGameStudio.Models;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.JyGameStudio.BlazorApp.Shared.Data
{
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
                    var f = item;
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
                    var f = item;
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
}
