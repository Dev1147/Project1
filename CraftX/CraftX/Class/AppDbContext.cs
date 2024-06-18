using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CraftX.Class
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // 데이터베이스 테이블에 해당하는 DbSet<클래스생성> DB테이블명 속성 정의
        public DbSet<User> TBL_USERS { get; set; }
        public DbSet<InternalMemo> TBL_InternalMemos { get; set; }

        public DbSet<DefectRate> TBL_DefectRates { get; set; }

        //이 방법이 더 좋다고 함
        public async Task<List<T>> CallStoredProcedureAsync2<T>(string procedureName, Dictionary<string, object> parameters) where T : class
        {
            var sqlParameters = parameters.Select(p => new SqlParameter(p.Key, p.Value ?? DBNull.Value)).ToArray();
            var parameterNames = string.Join(", ", parameters.Select(p => p.Key));

            string sqlQuery = $"EXEC {procedureName} {string.Join(", ", sqlParameters.Select(p => p.ParameterName))}";

            return await Set<T>()
                .FromSqlRaw(sqlQuery, sqlParameters)
                .ToListAsync();
        }
    }
}
