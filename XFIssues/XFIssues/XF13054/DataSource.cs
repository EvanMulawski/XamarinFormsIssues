using DynamicData;
using System;
using XFIssues.XF13054.Models;

namespace XFIssues.XF13054
{
    public sealed class DataSource
    {
        public DataSource()
        {
            Items = new SourceCache<Item, Guid>(x => x.Id);

            Items.AddOrUpdate(new Item { Id = Guid.NewGuid(), Text = "First item" });
            Items.AddOrUpdate(new Item { Id = Guid.NewGuid(), Text = "Second item" });
        }

        public SourceCache<Item, Guid> Items { get; }

        public static readonly DataSource Instance = new DataSource();
    }
}