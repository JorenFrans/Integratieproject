using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Repositories_HC;
using Domain;
using Domain.Elementen;
using Newtonsoft.Json;

namespace DAL.Repositories_EF
{
    public class PostRepository_EF : IPostRepository
    {
        PolitiekeBarometerContext context;

        public PostRepository_EF()
        {
            context = new PolitiekeBarometerContext();
        }
        public PostRepository_EF(UnitOfWork unitOfWork)
        {
            context = unitOfWork.Context;
        }

        public void addPosts(List<Post> list)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> getDataConfigPosts(DataConfig dataConfig)
        {
            Element element = dataConfig.Element;

            if (element.GetType().Equals(typeof(Persoon)))
            {
                return context.Posts.Where(p => p.Persoon.Naam == element.Naam);
            }
            else if (element.GetType().Equals(typeof(Organisatie)))
            {
                return context.Posts.Where(p => p.Persoon.Organisatie != null && p.Persoon.Organisatie.Id == element.Id);
            }
            else if (element.GetType().Equals(typeof(Thema)))
            {
                return context.Posts.Where(p => checkKeywords(p, element));
            }
            else return null;
        }

        private bool checkKeywords(Post post, Element element)
        {
            foreach (Keyword kw in post.Keywords)
            {
                if (kw.Themas.Contains(element))
                {
                    return true;
                }
            }
            return false;

        }

        public IEnumerable<Post> getPosts()
        {
            return context.Posts;
        }

        public IEnumerable<Tweet> readJSON()
        {
            string json = "";
            try
            {
                using (StreamReader r = new StreamReader("textgaindump.json"))
                {
                    json = r.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            TweetDump tweetDump = JsonConvert.DeserializeObject<TweetDump>(json);
            List<Tweet> tweets = new List<Tweet>(tweetDump.Tweet);
            return tweets;
        }

        public void updatePosts()
        {
            
        }
    }
}
