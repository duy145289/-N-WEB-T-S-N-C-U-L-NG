using BadmintonBooking.DAL;

namespace BadmintonBooking.GUI
{
    public static class Session
    {
        public static bool IsLoggedIn => CurrentUser != null;
        public static NguoiDung? CurrentUser { get; set; }
    }
}
