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
            //InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.MemoID).Take(5).ToListAsync(); //LinQ로 5개 고정하고 내림차순 하기

            //InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.CreatedDate) //내림차순
            //                    .Take(5) // 5개만 뽑기
            //                    .Select((x, index) => new InternalMemos
            //                    {
            //                        RowNumber = index + 1,
            //                        Title = x.Title,
            //                        CreatedDate = x.CreatedDate,
            //                        Writer = x.Writer
            //                    })
            //                    .ToListAsync(); //데이터 베이스에서
            // 가공해야 되어 안되는건가??

            /*
            // 서버에서 데이터를 가져옴
            var query = await _context.TBL_InternalMemos.OrderByDescending(u => u.CreatedDate).Take(5).ToListAsync();

            // 클라이언트 쪽에서 행 번호를 추가
            InternalMemo = query.Select((x, index) => new InternalMemos
            {
                RowNumber = index + 1, // 행 번호는 1부터 시작
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Writer = x.Writer
            }).ToList(); //메모리안에서
            */

            IQueryable<InternalMemo> data = _context.TBL_InternalMemos.OrderByDescending(x => x.CreatedDate).Take(5);

            var InternalMemoList = await data.ToListAsync(); //비동기 사용

            InternalMemos = InternalMemoList.AsEnumerable().Select((x, index) => new InternalMemo
            {
                RowNumber = index + 1, // 행 번호는 1부터 시작
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Writer = x.Writer
            }).ToList(); //IQueryable을 사용하여 지연 로드를 함. ToList() 또는 ToListAsync()에 올때 DB에서 돌아가 대용량에 장점

            //콘솔에 JOSN 확인용
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
            // 서버에서 데이터를 동기적으로 가져옵니다.
            var defectRates = await _context.TBL_DefectRates
                .Select(dr => new { dr.ID, dr.Rate, dr.DateRecorded })  // 원하는 필드만 선택
                .ToListAsync();

            //var defectRates = await _context.TBL_DefectRates.ToListAsync();
            return new JsonResult(defectRates);

        }


        // 예시로 고정된 데이터 반환
        //public async Task<IActionResult> OnGetDefectRatesData444()
        //{
        //    // 더미 불량률 데이터 생성 (실제로는 데이터베이스에서 가져와야 함)
        //    var random = new Random();
        //    var labels = new List<string> { "January", "February", "March", "April", "May", "June" };
        //    var defectRates = new List<int>();

        //    foreach (var label in labels)
        //    {
        //        defectRates.Add(random.Next(1, 100)); // 임의의 불량률 생성 (1부터 100까지)
        //    }

        //    var data = new { labels, defectRates };
        //    return Json(data); // JSON 형식으로 데이터 반환

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
