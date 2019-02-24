using Microsoft.AspNetCore.Components;
using System;
using System.Linq;

namespace WebApplication1.Client.Components.SortableColumnHeader
{
    public class SortableColumnHeaderComponent<CollectionType, PropertyType> : ComponentBase
    {
        [Parameter]
        protected string ColumnTitle { get; set; }

        [Parameter]
        protected string SortColumn { get; set; }

        [Parameter]
        protected Action<CollectionType[]> UpdateCollection { get; set; }

        private string _CurrentSortColumn;

        [Parameter]
        protected string CurrentSortColumn
        { 
            get
            {
                return _CurrentSortColumn;
            }
            set
            {
                if (value != SortColumn)
                {
                    SortDirection = "ASC";
                }
                _CurrentSortColumn = value;
            }
        }
        [Parameter]
        protected Action<string> CurrentSortColumnChanged { get; set; }

        protected string SortDirection { get; set; }

        [Parameter]
        protected CollectionType[] Collection { get; set; }

        [Parameter]
        protected Func<CollectionType, PropertyType> SortBy { get; set; }

        protected void Sort()
        {
            if (CurrentSortColumn != SortColumn || SortDirection == "DESC")
            {
                SortDirection = "ASC";
                Collection = Collection.OrderBy(x => SortBy(x)).ToArray();
            }
            else if (SortDirection == "ASC")
            {
                SortDirection = "DESC";
                Collection = Collection.OrderByDescending(x => SortBy(x)).ToArray();
            }
            else
            {
                return;
            }

            CurrentSortColumn = SortColumn;
            CurrentSortColumnChanged(CurrentSortColumn);
            UpdateCollection(Collection);
        }

        protected override void OnInit()
        {
            Console.WriteLine("SortableColumnHeader.OnInit");
            SortDirection = "ASC";
        }
    }
}
