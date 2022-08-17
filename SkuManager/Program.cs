using SkuManager;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        SqlConnection conn = new SqlConnection("Server=tcp:AjServer\\\\MSSQLSERVER;Initial Catalog = ECPLMaster2022;Persist Security Info=False;User ID=sa;Password=******; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=True;Connection Timeout=60;");
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT SkuCode, PluCode FROM (SELECT SkuCode, PluCode, COUNT(*) OVER (PARTITION BY PluCode) AS cnt FROM Sheet1$) AS t WHERE t.cnt > 1;", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        IList<PluMaster> pluList = new List<PluMaster>();
        if (reader.HasRows)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            foreach (DataRow dr in dt.Rows)
            {
                PluMaster plu = new PluMaster
                {
                    SkuCode = MakeSafe.ToSafeString(dr["SkuCode"]),
                    PluCode = MakeSafe.ToSafeString(dr["PluCode"])
                };
                pluList.Add(plu);
            }
        }
        
        Console.WriteLine("before count : " + pluList.Count);

        var result = pluList.GroupBy(x => x.PluCode.ToUpper().Trim())
                .Select(x => new PluMaster
                {
                    SkuCode = x.FirstOrDefault().SkuCode,
                    PluCode = x.FirstOrDefault().PluCode,
                }).ToList();

        Console.WriteLine("after count : " + result.Count);

        foreach (var plu in result)
        {
            SqlCommand upd = new SqlCommand("UPDATE Sheet1$ SET SkuCode = '" + plu.SkuCode + "' WHERE PluCode = '" + plu.PluCode + "'", conn);
            var response = upd.ExecuteNonQuery();
            Console.WriteLine(plu.PluCode);
        }
        Console.WriteLine("Completed");

        conn.Close();

    }


}