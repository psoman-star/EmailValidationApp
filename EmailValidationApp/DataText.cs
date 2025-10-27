using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace EmailValidationApp
{
    public class DataText 
    {
        public void ExprotData(string path, List<EmailModel> list)
        {
            var strList = list.Select(e => e.Email + " " + e.Status + "  " + e.IsValid + " " + e.Result).ToList();
            File.WriteAllLines(path, strList);
        }

        public List<EmailModel> ImportData(string path)
        {
            var rList = new List<EmailModel>();
            var list = File.ReadAllLines(path).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                var model = new EmailModel
                {
                    Id = i + 1,
                    Email = list[i] != null ? list[i].ToString().TrimEnd(new char[] { ',', ';', '.' }) : string.Empty,
                    Status = "Incomplete"
                };
                rList.Add(model);
            }
            return rList;
        }
    }
}
