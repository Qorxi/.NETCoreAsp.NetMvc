using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreKnowledge.Domain.Services.Interfaces;
using CoreKnowledge.Models;
using CoreKnowledge.Models.ViewModels;

namespace CoreKnowledge.Domain.Services.Components
{
    public class SqlSearchEngineService : ISeacrhService
    {
        private readonly AppDbContext db;

        public SqlSearchEngineService(AppDbContext context)
        {
            db = context;
        }

        public SearchViewModel Search(string term)
        {
            var searcModel = new SearchViewModel
            {
                Provider = "Sql Search"
            };

            StringBuilder sb = new StringBuilder();

            db.ProdSearchable.Where(item => item.SearhColumn.Contains(term)).ToList().ForEach(item =>
            {
                sb.AppendLine(item.SearhColumn);
            });

            searcModel.ResultText = sb.ToString();

            return searcModel;
        }
    }
}
