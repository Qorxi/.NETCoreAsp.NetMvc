using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreKnowledge.Models.ViewModels;

namespace CoreKnowledge.Domain.Services.Interfaces
{
    public interface ISeacrhService
    {
        SearchViewModel Search(string term);
    }
}
