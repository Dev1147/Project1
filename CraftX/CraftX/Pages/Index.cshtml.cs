using CraftX.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CraftX.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly CraftX.Class.AppDbContext _context;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public IndexModel(CraftX.Class.AppDbContext context)
        {
            _context = context;
        }
        public IList<InternalMemos> InternalMemo { get; set; }

        //public void OnGet()
        //{

        //}
        public async Task OnGetAsync()
        {
            //InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.MemoID).Take(5).ToListAsync(); //LinQ�� 5�� �����ϰ� �������� �ϱ�
            
            //InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.CreatedDate) //��������
            //                    .Take(5) // 5���� �̱�
            //                    .Select((x, index) => new InternalMemos
            //                    {
            //                        RowNumber = index + 1,
            //                        Title = x.Title,
            //                        CreatedDate = x.CreatedDate,
            //                        Writer = x.Writer
            //                    })
            //                    .ToListAsync(); //������ ���̽�����
            // �����ؾ� �Ǿ� �ȵǴ°ǰ�??


            // �������� �����͸� ������
            var query = await _context.TBL_InternalMemos.OrderByDescending(u => u.CreatedDate).Take(5).ToListAsync();

            // Ŭ���̾�Ʈ �ʿ��� �� ��ȣ�� �߰�
            InternalMemo = query.Select((x, index) => new InternalMemos
            {
                RowNumber = index + 1, // �� ��ȣ�� 1���� ����
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Writer = x.Writer
            }).ToList(); //�޸𸮾ȿ���

        }
    }
}
