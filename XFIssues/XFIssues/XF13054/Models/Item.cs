using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;

namespace XFIssues.XF13054.Models
{
    public class Item : ReactiveObject
    {
        [Reactive] public Guid Id { get; set; }
        [Reactive] public string Text { get; set; }
    }
}