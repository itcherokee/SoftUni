using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApplication.Models
{
    class Articles : IEnumerable<Article>
    {
        public Articles()
        {
            articles = new Article[0];
        }

        public Article[] articles { get; set; }


        public IEnumerator<Article> GetEnumerator()
        {
            foreach (var article in this.articles)
             yield return article;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
