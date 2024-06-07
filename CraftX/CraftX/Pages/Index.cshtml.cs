using CraftX.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CraftX.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CraftX.Class.AppDbContext _context;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public IndexModel(CraftX.Class.AppDbContext context, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _context = context;
        }
        public IList<InternalMemo> InternalMemos { get; set; }

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

            /*
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
            */

            IQueryable<InternalMemo> data = _context.TBL_InternalMemos.OrderByDescending(x => x.CreatedDate).Take(5);

            var InternalMemoList = await data.ToListAsync(); //�񵿱� ���

            InternalMemos = InternalMemoList.AsEnumerable().Select((x, index) => new InternalMemo
            {
                RowNumber = index + 1, // �� ��ȣ�� 1���� ����
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Writer = x.Writer
            }).ToList(); //IQueryable�� ����Ͽ� ���� �ε带 ��. ToList() �Ǵ� ToListAsync()�� �ö� DB���� ���ư� ��뷮�� ����

            //�ֿܼ� JOSN Ȯ�ο�
            //var defectRates = await _context.TBL_DefectRates.ToListAsync();

            //var options = new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //};

            //var json = System.Text.Json.JsonSerializer.Serialize(defectRates, options);
            ////Console.WriteLine(json);
            //return Content(json, "application/json");

            //var defectRates = await _context.TBL_DefectRates.ToListAsync();
            //return new JsonResult(defectRates);


        }

        public async Task<IActionResult> OnGetDefectRatesDataAsync()
        {
            // �������� �����͸� ���������� �����ɴϴ�.
            var defectRates = await _context.TBL_DefectRates
                .Select(dr => new { dr.ID, dr.Rate, dr.DateRecorded })  // ���ϴ� �ʵ常 ����
                .ToListAsync();

            //var defectRates = await _context.TBL_DefectRates.ToListAsync();
            return new JsonResult(defectRates);

        }


        // ���÷� ������ ������ ��ȯ
        //public async Task<IActionResult> OnGetDefectRatesData444()
        //{
        //    // ���� �ҷ��� ������ ���� (�����δ� �����ͺ��̽����� �����;� ��)
        //    var random = new Random();
        //    var labels = new List<string> { "January", "February", "March", "April", "May", "June" };
        //    var defectRates = new List<int>();

        //    foreach (var label in labels)
        //    {
        //        defectRates.Add(random.Next(1, 100)); // ������ �ҷ��� ���� (1���� 100����)
        //    }

        //    var data = new { labels, defectRates };
        //    return Json(data); // JSON �������� ������ ��ȯ

        //    IQueryable<DefectRate> data = _context.TBL_DefectRates;
        //    var defectRates = data.ToList();
        //}

        //public async Task<IActionResult> OnGetDefectRatesData(HttpContent httpContent)
        //{
        //    var defectRates = await _context.TBL_DefectRates.ToArrayAsync();
        //    return new JsonResult(defectRates);
        //}

        //    public async Task<IActionResult> OnGetDefectRatesData()
        //    {
        //        try
        //        {
        //            var defectRates = await _context.TBL_DefectRates.ToListAsync();
        //            return new JsonResult(defectRates);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error: {ex.Message}");
        //            return StatusCode(500, "Internal server error");
        //        }
        //    }

        //}


        //public async Task OnGetDefectRatesDataAsync()
        //{
        //    var defectRates = await _context.TBL_DefectRates.ToListAsync();

        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    };

        //    var json = System.Text.Json.JsonSerializer.Serialize(defectRates, options);
        //    Console.WriteLine(json);
        //}





    }
}
