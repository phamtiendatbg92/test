using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhDiem
{
    public class ChiSo
    {
        public double EPS { get; set; } // Thu nhập trên mỗi cổ phần
        public double BVPS { get; set; } // giá trị sổ sách của cổ phiếu
        public double PE { get; set; }  // Price/earning
        public double PB { get; set; }  // Chỉ số giá thị trường trên giá trị sổ sách
        public double PS { get; set; }  // Chỉ số giá trị trường trên doanh thu thuần
        public double tySuatCoTuc { get; set; } // tỷ suất cổ tức
        public double Beta { get; set; } // Hệ số Beta
        public double EV_EBIT { get; set; } // Giá trị doanh nghiệp trên lợi nhuận trước thuế và lãi vay
        public double EV_EBITDA { get; set; } // Giá trị doanh nghiệp trên lợi nhuận trước thuế, khấu hao và lãi vay
        public double tySuatLoiNhuanGopBien { get; set; } // Tỷ suất lợi nhuận gộp biên
        public double EBIT { get; set; } // Tỷ lệ lãi EBIT
        public double EBITDA { get; set; } // Tỷ lệ lãi EBITDA
        public double tySuatSinhLoiTrenDoanhThuThuan { get; set; } // Tỷ suất sinh lợi trên doanh thu thuần
        public double ROEA { get; set; } // Tỷ suất lợi nhuận trên vốn chủ sở hữu bình quân
        public double ROCE { get; set; } // Tỷ suất sinh lợi trên vốn dài hạn bình quân
        public double ROAA { get; set; } // Tỷ suất sinh lợi trên tổng tài sản bình quân
        // Hệ số tăng trưởng
        public double tangTruongDoanhThuThuan { get; set; }  //Tăng trưởng  doanh thu thuần
        public double tangTruongLoiNhuanGop { get; set; } //Tăng trưởng  lợi nhuận gộp
        public double tangTruongLoiNhuanTruocThue { get; set; } //Tăng trưởng lợi nhuận trước thuế
        public double tangTruongLoiNhuanSauThueCuaCDCtyMe { get; set; } //Tăng trưởng lợi nhuận sau thuế của CĐ công ty mẹ
        public double tangTruongTongTaiSan { get; set; } //Tăng trưởng tổng tài sản
        public double tangTruongNoDanHan { get; set; } //Tăng trưởng nợ dài hạn
        public double tangTruongNoPhaiTra { get; set; } //Tăng trưởng nợ phải trả
        public double tangTruongVonChuSoHuu { get; set; } //Tăng trưởng vốn chủ sở hữu
        public double tangTruongVonDieuLe { get; set; } //Tăng trưởng vốn điều lệ
        public double tySoThanhToanBangTienMat { get; set; } //Tỷ số thanh toán bằng tiền mặt
        public double tySoThanhToanNhanh { get; set; } //Tỷ số thanh toán nhanh
        public double tySoThanhToanNhanh2 { get; set; } //Tỷ số thanh toán nhanh(Đã loại trừ HTK, Phải thu ngắn hạn - Tham khảo)
        public double tySoThanhToanHienHanh { get; set; } //Tỷ số thanh toán hiện hành
        public double khaNangThanhToanLaiVay { get; set; } //Khả năng thanh toán lãi vay
        //Nhóm chỉ số Hiệu quả hoạt động
        public double vongQuayPhaiThuKhachHang { get; set; } //Vòng quay phải thu khách hàng
        public double thoiGianThuTienKhachHangBinhQuan { get; set; } //Thời gian thu tiền khách hàng bình quân
        public double vongQuayHangTonKho { get; set; } //Vòng quay hàng tồn kho
        public double thoiGianTonKhoBinhQuan { get; set; } //Thời gian tồn kho bình quân
        public double vongQuayPhaiTraChoNhaCungCap { get; set; } //Vòng quay phải trả nhà cung cấp
        public double thoiGianTraTienKhachHangBinhQuan { get; set; } //Thời gian trả tiền khách hàng bình quân
        public double vongQuayTaiSanCodinh { get; set; } //Vòng quay tài sản cố định (Hiệu suất sử dụng tài sản cố định)
        public double vongQuayTongTaiSan { get; set; } //Vòng quay tổng tài sản (Hiệu suất sử dụng toàn bộ tài sản)
        public double vongQuayVonChuSoHuu { get; set; } //Vòng quay vốn chủ sở hữu
        //Nhóm chỉ số Đòn bẩy tài chính
        public double noNganHan_TongTaiSan { get; set; } //Tỷ số Nợ ngắn hạn trên Tổng nợ phải trả
        public double noVay_TongTaiSan { get; set; } //Tỷ số Nợ vay trên Tổng tài sản
        public double no_TongTaiSan { get; set; } //Tỷ số Nợ trên Tổng tài sản
        public double vonChuSoHuu_TongTaiSan { get; set; } //Tỷ số Vốn chủ sở hữu trên Tổng tài sản
        public double noNganHan_vonChuSoHuu { get; set; } //Tỷ số Nợ ngắn hạn trên Vốn chủ sở hữu
        public double novay_vonChuSoHuu { get; set; } //Tỷ số Nợ vay trên Vốn chủ sở hữu
        public double no_vonChuSoHuu { get; set; } //Tỷ số Nợ trên Vốn chủ sở hữu
        //Nhóm chỉ số Dòng tiền
        public double dongTienHDKD_DoanhThuThuan { get; set; } //Tỷ số dòng tiền HĐKD trên doanh thu thuần
        public double a { get; set; } //Khả năng chi trả nợ ngắn hạn từ dòng tiền HĐKD
        public double b { get; set; } //Khả năng chi trả nợ ngắn hạn từ lưu chuyển tiền thuần trong kỳ
        public double c { get; set; } //Tỷ lệ dồn tích (Phương pháp Cân đối kế toán)
        public double d { get; set; } //Tỷ lệ dồn tích (Phương pháp Dòng tiền)
        public double e { get; set; } //Dòng tiền từ HĐKD trên Tổng tài sản
        public double f { get; set; } //Dòng tiền từ HĐKD trên Vốn chủ sở hữu
        public double g { get; set; } //Dòng tiền từ HĐKD trên Lợi nhuận thuần từ HĐKD
        public double h { get; set; } //Khả năng thanh toán nợ từ dòng tiền HĐKD
        public double i { get; set; } //Dòng tiền từ HĐKD trên mỗi cổ phần (CPS)

        //Cơ cấu Chi phí
        public double giaVon_doanhThuThuan { get; set; } //Giá vốn hàng bán/Doanh thu thuần
        public double chiPhiHangBan_DoanhThuThuan { get; set; } //Chi phí bán hàng/Doanh thu thuần
        public double chiPhiQLDN_doanhThuThuan { get; set; } //Chi phí quản lý doanh nghiệp/Doanh thu thuần
        public double chiPhiLaiVay_doanhThuThuan { get; set; } //Chi phí lãi vay/Doanh thu thuần
        //Cơ cấu Tài sản ngắn hạn
        public double taiSanNganHan_TongTaiSan { get; set; } //Tài sản ngắn hạn/Tổng tài sản  
        public double tien_TaiSanNganHan { get; set; } //Tiền/Tài sản ngắn hạn
        public double dauTuTaiChinhNganHan_TaiSanNganHan { get; set; } //Đầu tư tài chính ngắn hạn/Tài sản ngắn hạn
        public double phaiThuNganHan_TaiSanNganHan { get; set; } //Phải thu ngắn hạn/Tài sản ngắn hạn
        public double hangTonKho_TaiSanNganHan { get; set; } //Hàng tồn kho/Tài sản ngắn hạn
        public double taiSanNganHanKhac_taiSanNganHan { get; set; } //Tài sản ngắn hạn khác/Tài sản ngắn hạn
        //Cơ cấu Tài sản dài hạn
        public double taiSanDaiHan_TongTaiSan { get; set; } //Tài sản dài hạn/Tổng tài sản
        public double taiSanCoDinh_TongTaiSan { get; set; } //Tài sản cố định/Tổng tài sản
        public double taiSanCoDinhHH_TaiSanCoDinh { get; set; } //Tài sản cố định hữu hình/Tài sản cố định
        public double taiSanThueTaiChinh_TaiSanCoDinh { get; set; } //Tài sản thuê tài chính/Tài sản cố định
        public double taiSanVoHinh_TaiSanCoDinh { get; set; } //Tài sản vô hình/Tài sản cố định
        public double XDCBDD_TaiSanCoDinh { get; set; } //XDCBDD/Tài sản cố định

    }
}
