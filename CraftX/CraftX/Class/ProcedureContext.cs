using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CraftX.Class
{
    public class ProcedureContext
    {
        private readonly AppDbContext _context;

        public ProcedureContext(AppDbContext context) { 
            
            _context = context;
        
        }

        //이 방법이 더 좋다고 함
        public async Task<List<T>> CallStoredProcedureAsync<T>(string procedureName, Dictionary<string, object> parameters) where T : class
        {
            var sqlParameters = parameters.Select(p => new SqlParameter(p.Key, p.Value ?? DBNull.Value)).ToArray();
            var parameterNames = string.Join(", ", parameters.Select(p => p.Key));

            string sqlQuery = $"EXEC {procedureName} {string.Join(", ", sqlParameters.Select(p => p.ParameterName))}";

            return await _context.Set<T>()
                .FromSqlRaw(sqlQuery, sqlParameters)
                .ToListAsync();
        }
    }


}
