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
        private readonly ScriptsContext DataContext;

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
}
