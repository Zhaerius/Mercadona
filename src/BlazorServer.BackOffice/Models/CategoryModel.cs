using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.BackOffice.Models
{
    public class CategoryModel {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ArticleEntity>? Articles { get; set; }
    }

}
