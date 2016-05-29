using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Interfaces;

namespace BusinessLogic
{
    public class SportListOutputHtml: ISportListOutput
    {
        public string GetSportList(IEnumerable<SportType> sportTypes)
        {
            var items = string.Join("", sportTypes.Select(x => $"<li>{x.Name}</li>").ToArray());
            return $"<ul>{items}</ul>";
        }
    }
}
