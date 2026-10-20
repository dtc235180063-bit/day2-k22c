using Microsoft.AspNetCore.Mvc;
using Day2.Models;

namespace Day2.ViewComponents
{
    /// <summary>
    /// View Component hiển thị danh sách phim nổi bật hoặc lọc theo thể loại.
    /// View Component có class C# riêng để xử lý logic, không phụ thuộc vào Controller cha.
    /// </summary>
    public class TopMoviesViewComponent : ViewComponent
    {
        // Danh sách dữ liệu giả lập (thay cho Database hoặc Service tiêm qua Dependency Injection)
        private static readonly List<Movie> _movies = new()
        {
            new Movie { Id = 1, Title = "Avatar: The Way of Water", ReleaseDate = new DateTime(2022, 12, 16), Genre = "Khoa học viễn tưởng", Price = 95000 },
            new Movie { Id = 2, Title = "Oppenheimer", ReleaseDate = new DateTime(2023, 7, 21), Genre = "Lịch sử / Chính kịch", Price = 110000 },
            new Movie { Id = 3, Title = "Spider-Man: Across the Spider-Verse", ReleaseDate = new DateTime(2023, 6, 2), Genre = "Hoạt hình / Hành động", Price = 85000 },
            new Movie { Id = 4, Title = "Interstellar", ReleaseDate = new DateTime(2014, 11, 7), Genre = "Khoa học viễn tưởng", Price = 90000 },
            new Movie { Id = 5, Title = "Dune: Part Two", ReleaseDate = new DateTime(2024, 3, 1), Genre = "Khoa học viễn tưởng / Phiêu lưu", Price = 120000 },
            new Movie { Id = 6, Title = "Mai", ReleaseDate = new DateTime(2024, 2, 10), Genre = "Tâm lý / Tình cảm", Price = 100000 }
        };

        /// <summary>
        /// Phương thức thực thi bất đồng bộ khi View Component được gọi trên Razor View.
        /// </summary>
        /// <param name="count">Số lượng phim cần lấy</param>
        /// <param name="genre">Lọc theo thể loại (tùy chọn)</param>
        public async Task<IViewComponentResult> InvokeAsync(int count = 4, string? genre = null)
        {
            var query = _movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(genre))
            {
                query = query.Where(m => m.Genre != null && m.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
            }

            var result = query.Take(count).ToList();

            // Giả lập tác vụ async (như truy vấn DB qua EF Core)
            await Task.Yield();

            // Trả về view mặc định (Default.cshtml) của View Component
            return View(result);
        }
    }
}
