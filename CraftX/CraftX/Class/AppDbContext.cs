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
        public DbSet<InternalMemos> TBL_InternalMemos { get; set; }
    }
}
