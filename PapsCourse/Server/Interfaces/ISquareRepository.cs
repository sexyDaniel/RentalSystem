using PapsCourse.Server.Models;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface ISquareRepository
    {
        IQueryable<Square> Squares { get; }
        void Update(EditSquareRequest request);
    }
}
