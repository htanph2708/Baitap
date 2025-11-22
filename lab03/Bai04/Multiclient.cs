// File: TicketMessage.cs

using System;

// Định nghĩa các loại hành động
public enum ActionType
{
    RequestBooking,      // Yêu cầu đặt vé (Client -> Server)
    UpdateSeatStatus     // Cập nhật trạng thái ghế (Server -> All Clients)
}

// Lớp chứa dữ liệu truyền qua mạng (phải có [Serializable])
[Serializable]
public class TicketMessage
{
    public ActionType Action { get; set; }
    public int SeatIndex { get; set; }        // Chỉ số ghế (0-8)
    public bool IsBooked { get; set; }        // Trạng thái (True: Đã đặt)
    public string Message { get; set; }       // Thông báo lỗi/thành công
}