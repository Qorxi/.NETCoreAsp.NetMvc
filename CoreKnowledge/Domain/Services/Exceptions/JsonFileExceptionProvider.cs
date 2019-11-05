using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CoreKnowledge.Domain.Services.Interfaces;
using CoreKnowledge.Models.ViewModels;
using Newtonsoft.Json;
using System.IO;

namespace CoreKnowledge.Domain.Services.Exceptions
{
    public class JsonFileExceptionProvider : IExceptionProvider
    {
        public void Write(Exception exception)
        {
            var st = new StringBuilder();
            st.AppendLine($"Message     : {exception.Message   }");
            st.AppendLine($"Stack trace : {exception.StackTrace}");

            var json = JsonConvert.SerializeObject(st);

            File.WriteAllText($@"D:\Core\{DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day}.json", json);
        }
    }
}
