using Microsoft.Data.SqlClient;
using Printing_Service.Models;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Printing_Service.Data
{
    public class StudentData : DataAccess
    {
        public StudentData(IConfiguration configuration) : base(configuration)
        {

        }
        public Student GetStudentbyID(string ID)
        {
            // Example of querying data using the username (using ADO.NET, Entity Framework, etc.)
            // For example, using ADO.NET
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Student WHERE Student_ID  = @ID", connection);
                command.Parameters.AddWithValue("@ID", ID);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Return data from the database
                    return new Student
                    {
                        ID = reader["Student_ID"].ToString(),
                        name = reader["SName"].ToString(),
                        Remain_page = (int)reader["Remain_page"],
                        SPSO_ID = reader["SPSO_ID"].ToString()
                    };
                }
            }

            return null;
        }
        public List<PaperTransaction> GetBuyPaper(string ID)
        {
            // Example of querying data using the username (using ADO.NET, Entity Framework, etc.)
            // For example, using ADO.NET
            var ListB = new List<PaperTransaction>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Paper_transaction WHERE Student_ID  = @ID", connection);
                command.Parameters.AddWithValue("@ID", ID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListB.Add(new PaperTransaction
                        {
                            Transaction_ID = reader["Transaction_ID"].ToString(),
                            NumberPage = (int)reader["NumberPage"],
                            BuyTime = reader["BuyTime"].ToString(),
                            Student_ID = reader["Student_ID"].ToString()
                        });
                    }
                }
            }
            return ListB;
        }
        public List<Printer> GetPrinter()
        {
            // Example of querying data using the username (using ADO.NET, Entity Framework, etc.)
            // For example, using ADO.NET
            var ListB = new List<Printer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Printer", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListB.Add(new Printer
                        {
                            PrinterID = reader["Printer_ID"].ToString(),
                            Paper_exist = (int)reader["Paper_exist"],
                            PlaceAt = reader["PlaceAt"].ToString(),
                            isDisable = ((int)reader["isDisable"] == 0) ? "Available" : "Not Available"
                        });
                    }
                }
            }
            return ListB;
        }
        public List<Print_List> GetPrinting(string ID)
        {
            // Example of querying data using the username (using ADO.NET, Entity Framework, etc.)
            // For example, using ADO.NET
            var ListP = new List<Print_List>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("exec get_document @SID = @ID", connection);
                command.Parameters.AddWithValue("@ID", ID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListP.Add(new Print_List
                        {
                            SID = reader["Student_ID"].ToString(),
                            DName = reader["DName"].ToString(),
                            pages = (int)reader["pages"],
                            Date = (DateTime)reader["printtime"],
                            Printer_Id = reader["printer_id"].ToString(),
                            Place = reader["placeat"].ToString()
                        });
                    }
                }
            }
            return ListP;
        }
        public List<PrintHistory> GetPri(string ID)
        {
            // Example of querying data using the username (using ADO.NET, Entity Framework, etc.)
            // For example, using ADO.NET
            var ListP = new List<PrintHistory>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("exec get_document_date @SID = @ID", connection);
                command.Parameters.AddWithValue("@ID", ID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListP.Add(new PrintHistory
                        {

                            FileName = reader["DName"].ToString(),
                            PageA4 = reader["A3page"].ToString(),
                            Date = (DateTime)reader["printtime"],
                            Printer_Id = reader["printer_id"].ToString(),
                            Orient = (string)reader["Orient"],
                            Ratio = reader["Ratio"].ToString(),
                            Side = (int)reader["Pages"]
                        });
                    }
                }
                return ListP;
            }
        }
        public SumBuy GetSumBuy(string ID)
        {
            // Example of querying data using the username (using ADO.NET, Entity Framework, etc.)
            // For example, using ADO.NET
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("exec get_transaction @SID = @ID", connection);
                command.Parameters.AddWithValue("@ID", ID);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Return data from the database
                    return new SumBuy
                    {
                        count = (int)reader["Bcount"],
                        sum = (int)reader["BSum"],
                        money = (int)reader["BSum"] * 1000,
                        buypaper = 0
                    };

                }
            }
            return null;
        }
        public string ConvertToCustomFormat(int number, string prefix = "TR", int totalSize = 6)
        {
            // Calculate the padding size
            int numberSize = totalSize - prefix.Length;

            // Convert the number to a string and pad it
            string paddedNumber = number.ToString().PadLeft(numberSize, '0');

            // Prefix with the given string and return
            return prefix + paddedNumber;
        }
        public string GetList()
        {
            int Scount = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("select count(*) as SCount from Paper_Transaction", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Return data from the database
                    Scount = (int)reader["SCount"]+1;

                }
            }
            return ConvertToCustomFormat(Scount);
        }

        public void CreateTransaction(int paper, string ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Paper_transaction (Transaction_ID, NumberPage, BuyTime, Student_ID) VALUES (@TID, @pages, GETDATE(), @SID)", connection);
                command.Parameters.AddWithValue("@TID", GetList());
                command.Parameters.AddWithValue("@pages", paper);
                command.Parameters.AddWithValue("@SID", ID);
                command.ExecuteReader();
            }
        }
        
        public List<SumPrint> GetPrint()
        {
            // Example of querying data using the username (using ADO.NET, Entity Framework, etc.)
            // For example, using ADO.NET
            var ListP = new List<SumPrint>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("exec GetPrinterPrintStatistics", connection);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListP.Add(new SumPrint
                        {
                            printer_id = reader["Printer_ID"].ToString(),

                            placeat = reader["PlaceAt"].ToString(),
                            isdisable = ((int)reader["isdisable"] == 0)?"Enable":"Disable",
                            totalprints = reader["totalprints"].ToString(),
                            printtoday = reader["printstoday"].ToString()
                        });
                    }
                }
                return ListP;
            }
            return null;
        }
        public string GetListDocument()
        {
            int Scount = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("select count(*) as SCount from Document", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Return data from the database
                    Scount = (int)reader["SCount"] + 1;

                }
            }
            return ConvertToCustomFormat(Scount);
        }
        public void CreatePrint(Document addDoc, string ID, string printer_ID)
        {
            string doc_ID = GetListDocument();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Document (Document_ID, A3Page, Pages, Type, Ratio, Orient, Side, DName) VALUES (@DID, @A3,@pages, @type, @ratio, @orient,@side , @Name)", connection);
                
                command.Parameters.AddWithValue("@DID", doc_ID);
                command.Parameters.AddWithValue("@pages", addDoc.Page);
                command.Parameters.AddWithValue("@type", addDoc.Type);
                command.Parameters.AddWithValue("@ratio", addDoc.Ratio);
                command.Parameters.AddWithValue("@side", addDoc.Side);
                command.Parameters.AddWithValue("@Name", addDoc.Name);
                command.Parameters.AddWithValue("@A3", addDoc.A3page);
                command.Parameters.AddWithValue("@orient", addDoc.Orient);
                command.ExecuteReader();
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Printing (Printer_ID, Student_ID, Document_ID, PrintTime) VALUES (@PID, @SID, @DID, GETDATE())", connection);
                command.Parameters.AddWithValue("@DID", doc_ID);
                command.Parameters.AddWithValue("@SID", ID);
                command.Parameters.AddWithValue("@PID", printer_ID);
                //DateTime now = DateTime.Now;
                //string formattedTime = now.ToString("yyyy-MM-dd HH:mm:ss");
                //command.Parameters.AddWithValue("@time", now);
                command.ExecuteReader();
            }
        }

    }
}
