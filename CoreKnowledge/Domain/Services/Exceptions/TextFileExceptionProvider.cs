using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreKnowledge.Domain.Services.Interfaces;

namespace CoreKnowledge.Domain.Services.Exceptions
{
    public class TextFileExceptionProvider : CoreKnowledge.Domain.Services.Interfaces.IExceptionProvider
    {
        public void Write(Exception exception)
        {
            var st = new StringBuilder();
            st.AppendLine($"Message : {exception.Message}");
            st.AppendLine($"Stack trace: {exception.StackTrace}");


            File.WriteAllText($@"D:\Core\{DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day}.txt", st.ToString());
        }
    }
}
