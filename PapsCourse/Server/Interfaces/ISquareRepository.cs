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
        void Update(AreaResponse request);
        List<AreaResponse> GetAreas();
        AreaResponse GetAreaById(int id);

        List<UserArea> GetAreasByUserId(int userId);
    }
}
