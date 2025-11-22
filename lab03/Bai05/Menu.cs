using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using lab03.Bai05.Models;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace lab03.Bai05
{
    public class Server
    {
        private TcpListener listener;
        private const int port = 9000;
        private const string connectionString = "Server=Admin\\SQLEXPRESS; Database=QuanLyQuanNetDB; Integrated Security=True;";

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Server đang chạy...");

            listener.BeginAcceptTcpClient(AcceptClient, null);
        }

        private void AcceptClient(IAsyncResult ar)
        {
            TcpClient client = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("Client kết nối!");
            listener.BeginAcceptTcpClient(AcceptClient, null);

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string req = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            string res = HandleRequest(req);
            byte[] respBytes = Encoding.UTF8.GetBytes(res);
            stream.Write(respBytes, 0, respBytes.Length);
            client.Close();
        }

        private string HandleRequest(string req)
        {
            string[] parts = req.Split('|');
            string command = parts[0];

            switch (command)
            {
                case "GET_ALL_FOODS":
                    return JsonConvert.SerializeObject(GetAllFoods());
                case "ADD_FOOD":
                    return AddFood(parts);
                case "DELETE_FOOD":
                    return DeleteFood(parts);
                default:
                    return "UNKNOWN_COMMAND";
            }
        }

        private List<Food> GetAllFoods()
        {
            List<Food> foods = new List<Food>();
            string query = "SELECT MonAnID, TenMon, DanhMuc, Gia, HinhAnhPath FROM ThucDon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foods.Add(new Food
                    {
                        IDMA = reader.GetInt32(0),
                        TenMonAn = reader.GetString(1),
                        PhanLoai = reader.GetString(2),
                        Gia = reader.GetDecimal(3).ToString(),
                        HinhAnh = reader.GetString(4)
                    });
                }
            }
            return foods;
        }

        private string AddFood(string[] parts)
        {
            // parts: ADD_FOOD|TenMon|Base64|UserId|Gia|PhanLoai
            try
            {
                string ten = parts[1];
                string base64 = parts[2];
                int userId = int.Parse(parts[3]);
                decimal gia = decimal.Parse(parts[4]);
                string phanLoai = parts[5];

                // Lưu ảnh vào folder
                string fileName = $"{Guid.NewGuid()}.png";
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", fileName);
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64));

                // Thêm vào database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ThucDon(TenMon, DanhMuc, Gia, HinhAnhPath) VALUES(@Ten, @DM, @Gia, @Path)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Ten", ten);
                    cmd.Parameters.AddWithValue("@DM", phanLoai);
                    cmd.Parameters.AddWithValue("@Gia", gia);
                    cmd.Parameters.AddWithValue("@Path", "Images\\" + fileName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return "ERROR|" + ex.Message;
            }
        }

        private string DeleteFood(string[] parts)
        {
            try
            {
                int id = int.Parse(parts[1]);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM ThucDon WHERE MonAnID=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return "ERROR|" + ex.Message;
            }
        }
    }
}
