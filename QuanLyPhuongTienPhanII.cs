using System;
using System.Collections.Generic;
using System.Linq;

namespace hoccsharp
{
    public class QuanLyPhuongTienPhanII
    {
        private readonly List<PhuongTienPhanII> _danhSach = new List<PhuongTienPhanII>();

        public void AddPhuongTien(PhuongTienPhanII pt)
        {
            if (pt != null)
            {
                _danhSach.Add(pt);
            }
        }

        public void DisplayAll()
        {
            Console.WriteLine("--- DANH SÁCH TOÀN BỘ PHƯƠNG TIỆN ---");
            foreach (var pt in _danhSach)
            {
                Console.WriteLine($"{pt.GetInfo()} => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            }
        }

        public PhuongTienPhanII? FindMaxGiaLanBanh()
        {
            if (_danhSach.Count == 0) return null;
            return _danhSach.OrderByDescending(pt => pt.TinhGiaLanBanh()).FirstOrDefault();
        }

        public List<PhuongTienPhanII> SearchByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<PhuongTienPhanII>();

            return _danhSach
                .Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}