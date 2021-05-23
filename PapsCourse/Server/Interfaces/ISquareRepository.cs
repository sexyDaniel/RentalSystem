using PapsCourse.Shared.Models;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface ISquareRepository
    {
        void Update(EditSquareRequest request);
        List<Area> GetAreas();
        Area GetAreaById(int id);
    }
}
