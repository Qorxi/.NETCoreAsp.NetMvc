using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreKnowledge.Domain.Services.Interfaces;
using CoreKnowledge.Models;
using CoreKnowledge.Models.ViewModels;
using System.Text;

namespace CoreKnowledge.Domain.Services.Components
{
    public class LocalSearchEngineService : ISeacrhService
    {
        private readonly AppDbContext _contex;

        public LocalSearchEngineService(AppDbContext context)
        {
            _contex = context;
        }

        public SearchViewModel Search(string term)
        {
            var search = new SearchViewModel
            {
                Provider = "Local Provider"
            };

            StringBuilder sb = new StringBuilder();

            _contex.LocalSearchable.Where(item => item.SearchLocal.Contains(term)).ToList().ForEach(item =>
            {
                sb.AppendLine(item.SearchLocal.TrimEnd().TrimStart());
            });
            search.ResultText = sb.ToString();

            return search;
        }
    }
}
