using Datacar.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacar.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
        {
            // EntityFrameworkCore: Skip the first n amount of records and then take the x records of the remaining sequence
            return queryable
                .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage)
                .Take(paginationDTO.RecordsPerPage);
        }
    }
}
