using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ISportListOutput
    {
        string GetSportList(IEnumerable<SportType> sportTypes);
    }
}
