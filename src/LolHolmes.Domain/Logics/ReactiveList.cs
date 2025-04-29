using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHolmes.Domain.Logics
{
    public class ReactiveList<T> : List<T>
    {
        public Action? StateHasChanged { get; set; }

        new public void Add(T obj)
        {
            base.Add(obj);
            if (StateHasChanged != null)
            {
                StateHasChanged();
            }
        }
    }
}
