using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Interfaces;

namespace BusinessLogic
{
    public class SportListOutputXml: ISportListOutput
    {
        public string GetSportList(IEnumerable<SportType> sportTypes)
        {
            var items = string.Join("", sportTypes.Select(x => $"<SportType>{x.Name}</SportType>").ToArray());

            return $"<SportTypes>{items}</SportTypes>";
        }
    }
}
