BadmintonBooking (EF Core + App.config)
- Chuỗi kết nối nằm trong BadmintonBooking.GUI/App.config (name=BadmintonBooking), trỏ đến NHU-NHU\SQLEXPRESS.
- DAL đọc chuỗi kết nối qua ConfigurationManager.
- Chức năng: Đăng ký/Đăng nhập/Đặt sân (kiểm tra trùng lịch)/Lịch sử/Thanh toán.
Cách chạy:
1) Mở BadmintonBooking.sln, đặt BadmintonBooking.GUI làm Startup Project.
2) Build → VS sẽ restore NuGet (EF Core + ConfigurationManager).
3) F5: lần đầu tự EnsureCreated + seed.
Tài khoản test: user@badminton.local / 123456
