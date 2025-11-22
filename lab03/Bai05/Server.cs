using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using lab03.Bai05.Models;

namespace lab03.Bai05
{
    public class Server
    {
        private TcpListener _listener;
        private List<Food> foods = new List<Food>();
        private int nextId = 1;

        public Server()
        {
            // khởi tạo một số món ăn mặc định
            foods.Add(new Food { IDMA = nextId++, TenMonAn = "Phở", IDNCC = 1, HinhAnh = "", Gia = "40000", PhanLoai = "Món chính" });
            foods.Add(new Food { IDMA = nextId++, TenMonAn = "Bún chả", IDNCC = 2, HinhAnh = "", Gia = "35000", PhanLoai = "Món chính" });
        }

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, 9000);
            _listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                var stream = client.GetStream();

                byte[] buffer = new byte[4096];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string req = Encoding.UTF8.GetString(buffer, 0, bytes);

                string res = HandleRequest(req);
                byte[] data = Encoding.UTF8.GetBytes(res);
                stream.Write(data, 0, data.Length);

                client.Close();
            }
        }

        private string HandleRequest(string req)
        {
            if (req.StartsWith("GET_ALL_FOODS"))
            {
                return JsonConvert.SerializeObject(foods);
            }
            else if (req.StartsWith("ADD_FOOD"))
            {
                // cú pháp: ADD_FOOD|ten|base64|userId|gia|phanloai
                string[] parts = req.Split('|');
                var f = new Food
                {
                    IDMA = nextId++,
                    TenMonAn = parts[1],
                    HinhAnh = parts[2],
                    IDNCC = int.Parse(parts[3]),
                    Gia = parts.Length > 4 ? parts[4] : "",
                    PhanLoai = parts.Length > 5 ? parts[5] : ""
                };
                foods.Add(f);
                return "OK";
            }
            else if (req.StartsWith("DELETE_FOOD"))
            {
                string[] parts = req.Split('|');
                int id = int.Parse(parts[1]);
                foods.RemoveAll(f => f.IDMA == id);
                return "OK";
            }
            else if (req.StartsWith("RANDOM_ALL"))
            {
                if (foods.Count == 0) return "";
                Random r = new Random();
                int index = r.Next(foods.Count);
                return JsonConvert.SerializeObject(foods[index]);
            }

            return "UNKNOWN_COMMAND";
        }
    }
}
