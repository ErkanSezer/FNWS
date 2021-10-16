using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace FNWS.Controllers
{
    public class FileNetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public FileNetResponse getIdfromDB([FromBody] FileNetRequest req)
        {

            FileNetResponse fnResponse = new FileNetResponse();
            try
            {
                string connString = @"Server = bbs-v-ibm03.bilgibirikim.com; Database = RiskMerkezi; User Id = sa; Password = Bbs@2019; Integrated Security = false; MultipleActiveResultSets = true;";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    String sql = "SELECT Aciklama from BasvuruSekli where BS_id= " + Convert.ToInt32(req.sourceFileNetID);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fnResponse.obJectID = reader.GetString(0);
                                fnResponse.message = "OK";
                                fnResponse.request_Id = req.sourceFileNetID.ToString();
                            }
                        }
                    }

                }
                return fnResponse;

            }
            catch (Exception Exc)
            {
                fnResponse.request_Id = req.sourceFileNetID.ToString();
                fnResponse.message = "Error : " + Exc.Message;
                return fnResponse;
            }
        }

        public string Get(int id)
        {
            return "value" + id.ToString();
        }
    }

    public class FileNetResponse
    {
        public string request_Id { get; set; }
        public string obJectID { get; set; }
        public string message { get; set; }

    }

    public class FileNetRequest
    {
        public string sourceFileNetID { get; set; }
    }
}
