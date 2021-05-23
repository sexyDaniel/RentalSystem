using PapsCourse.Server.Models;
using PapsCourse.Shared.Models.Area;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface ISquareRepository
    {
        IQueryable<Models.Area> Squares { get; }
        void Update(EditSquareRequest request);
        List<Shared.Models.Area.Area> GetAreas();
        Shared.Models.Area.Area GetAreaById(int id);
    }
}
