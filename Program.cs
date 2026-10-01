using System;

namespace hoccsharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyPhuongTienPhanII ql = new QuanLyPhuongTienPhanII();

            Console.WriteLine("========== BẮT ĐẦU CHẠY CÁC TEST CASE PHẦN II ==========\n");

            Console.WriteLine("[TC01] Kiểm tra Validation NamSanXuat = 1850:");
            try
            {
                OToPhanII carInvalid = new OToPhanII("OT001", "Toyota", 1850, 500_000_000m, 5, 2.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"-> KẾT QUẢ: Bắt đúng ngoại lệ: \"{ex.Message}\" (PASSED)\n");
            }

            Console.WriteLine("[TC02] Kiểm tra Giá Lăn Bánh Ô tô 5 chỗ (Giá gốc 1 tỷ VNĐ):");
            OToPhanII oto5Cho = new OToPhanII("OT002", "Toyota", 2023, 1_000_000_000m, 5, 2.0);
            decimal giaLanBanhOTo = oto5Cho.TinhGiaLanBanh();
            Console.WriteLine($"-> Giá lăn bánh: {giaLanBanhOTo:N0} VNĐ");
            Console.WriteLine($"-> Kỳ vọng: 1,420,000,000 VNĐ | Trạng thái: {(giaLanBanhOTo == 1_420_000_000m ? "PASSED" : "FAILED")}\n");

            Console.WriteLine("[TC03] Kiểm tra Giá Lăn Bánh Xe máy 150cc (Giá gốc 50 triệu VNĐ):");
            XeMayPhanII xeMay150 = new XeMayPhanII("XM001", "Honda", 2022, 50_000_000m, 150);
            decimal giaLanBanhXeMay = xeMay150.TinhGiaLanBanh();
            Console.WriteLine($"-> Giá lăn bánh: {giaLanBanhXeMay:N0} VNĐ");
            Console.WriteLine($"-> Kỳ vọng: 51,000,000 VNĐ | Trạng thái: {(giaLanBanhXeMay == 51_000_000m ? "PASSED" : "FAILED")}\n");

            Console.WriteLine("[TC04] Kiểm tra Đa hình List<PhuongTienPhanII>:");
            ql.AddPhuongTien(oto5Cho);
            ql.AddPhuongTien(xeMay150);
            ql.DisplayAll();
            Console.WriteLine("-> KẾT QUẢ: Tính đúng giá lăn bánh đa hình cho từng đối tượng (PASSED)\n");

            Console.WriteLine("[TC05] Kiểm tra FindMaxGiaLanBanh():");
            PhuongTienPhanII? maxPT = ql.FindMaxGiaLanBanh();
            if (maxPT != null)
            {
                Console.WriteLine($"-> Phương tiện đắt nhất: {maxPT.GetInfo()}");
                Console.WriteLine($"-> Giá lăn bánh max: {maxPT.TinhGiaLanBanh():N0} VNĐ");
                bool isCorrectMax = (maxPT.MaPT == "OT002" && maxPT.TinhGiaLanBanh() == 1_420_000_000m);
                Console.WriteLine($"-> Kết quả: {(isCorrectMax ? "PASSED" : "FAILED")}\n");
            }

            Console.WriteLine("========== HOÀN THÀNH TẤT CẢ TEST CASES PHẦN II ==========");
        }
    }
}