//Nhập danh sách đơn hàng của 1 siêu thị với thông tin về tên hàng, giá tiền, tên nhân viên bán. 
    //Tìm kiếm nhân viên bán được nhiều hàng nhất, nhân viên bán được nhiều tiền hàng nhất, hàng bán chạy nhất, hàng bán nhiều tiền nhất. 
    //Cố định 5 nhân viên và 5 mặt hàng.

    //một struct Đơn Hàng để lưu thông tin của một đơn hàng, bao gồm tên hàng, giá tiền và nhân viên bán
    public struct DonHang
    {
        public string MatHang;
        public double Gia;
        public string NhanVien;
        public DonHang(string mathang, double gia, string nhanvien)
        {
            MatHang = mathang;
            Gia = gia;
            NhanVien = nhanvien;
        }
    }
    
    class Class1
    {
        public static void Main()
        {
            string[] cacNhanVien =            //sử dụng string[] để lưu danh sách nhân viên và mặt hàng cố định.
            {
                "Ech",
                "Frog",
                "Wibu",
                "Coc",
                "Kaoru"
            };
            string[] cacMatHang =
            {
                "Coca",
                "Pepsi",
                "C2",
                "Olong",
                "DrThanh"
            };
            List<DonHang> donHang = new List<DonHang>();   //sử dụng một list Đơn Hàng để lưu danh sách các đơn hàng
            Write("Nhap so luong don hang: ");
            int n = Convert.ToInt32(ReadLine());
            for (int i = 0; i < n; i++)
            {
                Write("Nhap mat hang cho don hang thu {0}", i+1 + " : ");
                string mathang = ReadLine();

                Write("Nhap gia cho don hang thu {0}", i + 1 + " : ");
                double gia = double.Parse(ReadLine());

                Write("Nhap ten nguoi ban cho don hang thu {0}", i + 1 + " : ");
                string nhanvien = ReadLine();
                WriteLine();

                donHang.Add(new DonHang(mathang, gia, nhanvien));
            }

            //sử dụng các dictionary Dictionary để lưu trữ số lượng đơn hàng  và doanh số của các nhân viên hoặc mặt hàng tương ứng. 
            //Sau đó duyệt qua danh sách đơn hàng và cập nhật dictionary tương ứng. 
            
            // Tìm kiếm nhân viên bán được nhiều hàng nhất
            Dictionary<string, int> so_don_hang_cua_moi_nhan_vien = new Dictionary<string, int>();
            foreach (string nhanvien in cacNhanVien)
            {
                so_don_hang_cua_moi_nhan_vien[nhanvien] = 0;
            }
            foreach (DonHang item in donHang)
            {
                so_don_hang_cua_moi_nhan_vien[item.NhanVien]++;
            }
            string NhanVien_BanDuoc_NhieuHangNhat = "";
            int max = 0;
            foreach (KeyValuePair<string, int> entry in so_don_hang_cua_moi_nhan_vien)
            {
                if (entry.Value > max)
                {
                    max = entry.Value;
                    NhanVien_BanDuoc_NhieuHangNhat = entry.Key;
                }
            }

            // Tìm kiếm NHÂN VIÊN BÁN ĐƯỢC NHIỀU TIỀN NHẤT
            Dictionary<string, double> revenuePerPerson = new Dictionary<string, double>();
            foreach (string person in cacNhanVien)
            {
                revenuePerPerson[person] = 0;
            }
            foreach (DonHang dh in donHang)
            {
                revenuePerPerson[dh.NhanVien] += dh.Gia;
            }
            string bestSaler = "";
            double max1 = 0;
            foreach (KeyValuePair<string, double> entry in revenuePerPerson)
            {
                if (entry.Value > max1 )
                {
                    max1 = entry.Value;
                    bestSaler = entry.Key;
                }
            }

            //Tạo dictionary để lưu thông tin của 2 đơn hàng có lợi nhuận cao nhất
            Dictionary<string, int> salesByItemName = new Dictionary<string, int>();
            Dictionary<string, double> revenueByItemName = new Dictionary<string, double>();
            foreach (string item in cacMatHang)
            {
                salesByItemName[item] = 0;
                revenueByItemName[item] = 0;
            }
            foreach (DonHang order in donHang)
            {
                salesByItemName[order.MatHang]++;
                revenueByItemName[order.MatHang] += order.Gia;
            }
            string bestSellingItem = "";
            int maxSalesByItem = 0;
            string bestRevenueItem = "";
            double maxRevenueByItem = 0;
            foreach (KeyValuePair<string, int> entry in salesByItemName)
            {
                if (entry.Value > maxSalesByItem)
                {
                    maxSalesByItem = entry.Value;
                    bestSellingItem = entry.Key;
                }
            }
            foreach (KeyValuePair<string, double> entry in revenueByItemName)
            {
                if (entry.Value > maxRevenueByItem)
                {
                    maxRevenueByItem = entry.Value;
                    bestRevenueItem = entry.Key;
                }
            }

            WriteLine("Nhan vien ban duoc nhieu hang nhat: " + NhanVien_BanDuoc_NhieuHangNhat );
            WriteLine("Nhan vien co nhieu loi nhuan nhat: " + bestSaler + ", " + max1);
            WriteLine("Mat hang ban chay nhat la: " + bestSellingItem + ", " + maxSalesByItem);   
            WriteLine("Mat hang thu nhieu loi nhuan nhat: " + bestRevenueItem + ", "+ maxRevenueByItem);
   }
