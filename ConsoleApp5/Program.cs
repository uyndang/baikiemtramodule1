﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baithimodule1 
{

    public class SoNguyen
    {
        public int ThuTu { get; set; }
        public int GiaTri { get; set; }
    }
    internal class Program
    {
        static List<CongViec> listCV = new List<CongViec>();
        static void Main(string[] args)
        {
            while (true)
            {
                HienThiThongBao();
                Console.Write("Chon chuc nang can thuc hien: ");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        KhaiBaoThongTinCV();
                        break;
                    case 2:
                        XoaThongTinCV();
                        break;
                    case 3:
                        CapNhatTrangThaiCV();
                        break;
                    case 4:
                        TimKiemTheoTenCV();
                        break;
                    case 5:
                        DanhSachCVGiamDan();
                        break;
                    
                    case 7:
                        HienThiDanhSach();
                        break;
                    default:
                        Console.WriteLine("Chuc nang khong ton tai");
                        break;
                }
                
                Console.WriteLine("Nhan Y de thoat!");
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.Key == ConsoleKey.Y)
                {
                    break;
                }
                Console.Clear();
            }
           
        }

        public static void HienThiThongBao()
        {
            Console.WriteLine("1. Nhap thong tin sinh vien");
            Console.WriteLine("2. Xoa thong tin sinh vien");
            Console.WriteLine("3. Cap nhat thong tin sinh vien");
            Console.WriteLine("4. Xem danh sach thong tin sinh vien");
            Console.WriteLine("5. Tim kiem sinh vien theo MSSV");
            Console.WriteLine("6. Hien thi danh sach sinh vien theo nam sinh tang dan");
            Console.WriteLine("7. Hien thi danh sach sinh vien theo nam sinh giam dan");
        }

        public static void KhaiBaoThongTinCV()
        {
            Console.Write("Tên việc cần làm: ");
            string ten = Console.ReadLine();

            Console.Write(":Độ ưu tiên ");
            int so = int.Parse(Console.ReadLine());

            Console.Write(" Mô tả thông tin việc cần làm: ");
            string mota = Console.ReadLine();

            Console.Write("Trạng thái của việc cần làm: ");
            string trangthai = Console.ReadLine();

            CongViec cv = new CongViec(ten,so,mota,trangthai);
            listCV.Add(cv);
        }

        public static void XoaThongTinCV()
        {
            Console.Write("Nhap ten can xoa: ");
            string ten = Console.ReadLine();
            int douutien = int.Parse(Console.ReadLine());
            string mota = Console.ReadLine();
            string trangthai = Console.ReadLine();
            listCV.RemoveAll(c => c.TenCongViec.ToLower().Contains(ten.ToLower()));
            listCV.RemoveAll(_ => _.DoUuTien == douutien);
            listCV.RemoveAll(c => c.MoTaCongViec.ToLower().Contains(mota.ToLower()));
            listCV.RemoveAll(c => c.TrangThaiCongViec.ToLower().Contains(trangthai.ToLower()));
        }

        public static void TimKiemTheoTenCV()
        {
            Console.Write("Nhap ten viec can tim: ");
           string ten= string.Empty;
            var item = listCV.FirstOrDefault(c => c.tenvieclam == ten );
            if(item is null)
            {
                Console.WriteLine(" ten can tim khong hop le!");
            }
            else
            {
                Console.WriteLine("Ten Cong Viec: {0}", item.TenCongViec);
                Console.WriteLine("Do Uu Tien: {0}", item.DoUuTien);
                Console.WriteLine("Mo Ta: {0}", item.MoTa);
                Console.WriteLine("Trang Thai: {0}", item.TrangThai);
                Console.WriteLine();
            }
        }

        
        public static void DanhSachCVGiamDan()
        {
            var dut = listCV.OrderByDescending(c => c.DoUuTien).ToList();

            foreach (var item in dut)
            {
                Console.WriteLine("Ten Cong Viec: {0}", item.TenCongViec);
                Console.WriteLine("Do Uu Tien: {0}", item.DoUuTien);
                Console.WriteLine("Mo Ta: {0}", item.MoTa);
                Console.WriteLine("Trang Thai: {0}", item.TrangThai);
                Console.WriteLine();
            }
        }
        public static void CapNhatTrangThaiCV()
        {
            Console.Write("Cap Nhat Trang Thai CV: ");
            int trangthai = int.Parse(Console.ReadLine());
            
            listCV.Add(_ => _.TRANGTHAI == trangthai);
        }

        public static void HienThiDanhSach()
        {
            foreach (var item in listCV)
            {
                Console.WriteLine("Ten Cong Viec: {0}", item.TenCongViec);
                Console.WriteLine("Do Uu Tien: {0}", item.DoUuTien);
                Console.WriteLine("Mo Ta: {0}", item.MoTa);
                Console.WriteLine("Trang Thai: {0}", item.TrangThai);
                Console.WriteLine();
            }
        }

    }
}
