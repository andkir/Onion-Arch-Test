using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Interfaces;

namespace BusinessLogic
{
    public class SportListOutputCsv: ISportListOutput
    {
        public string GetSportList(IEnumerable<SportType> sportTypes)
        {
            return string.Join(";", sportTypes.Select(x => x.Name).ToArray());
        }
    }
}
