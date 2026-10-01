using System;

namespace hoccsharp
{
    public class XeMayPhanII : PhuongTienPhanII
    {
        private int _dungTichXylanh;

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích xi-lanh phải lớn hơn 0!");
                _dungTichXylanh = value;
            }
        }

        public XeMayPhanII(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        public override decimal TinhGiaLanBanh()
        {
            if (DungTichXylanh < 175)
            {
                return GiaGoc + (0.02m * GiaGoc);
            }
            else
            {
                return GiaGoc + (0.05m * GiaGoc);
            }
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} | Loại: Xe máy | Dung tích xilanh: {DungTichXylanh}cc";
        }
    }
}