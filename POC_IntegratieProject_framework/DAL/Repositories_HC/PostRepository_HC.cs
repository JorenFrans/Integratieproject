using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain;
using Domain.Elementen;
using Newtonsoft.Json;

namespace DAL.Repositories_HC
{
    public class PostRepository_HC : IPostRepository
    {

        private List<Post> Posts;


        public PostRepository_HC()
        {
            Posts = new List<Post>();
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
            Post post4 = new Post()
            {
                Source = "Twitter",
                PostId = 4,
                Persoon = new Persoon()
                {
                    Id = 2,
                    Naam = "Bart de Wever",
                    Organisatie = new Organisatie()
                    {
                        Id = 1,
                        Naam = "NVA",
                    }
                },
                Keywords = new List<Keyword>(),
                Parameters = new List<Parameter>()
            };
            this.Posts.Add(post4);

            Post post5 = new Post()
            {
                Source = "Twitter",
                PostId = 5,
                Persoon = new Persoon()
                {
                    Id = 2,
                    Naam = "Bart de Wever",
                    Organisatie = new Organisatie()
                    {
                        Id = 1,
                        Naam = "NVA",
                    }
                },
                Keywords = new List<Keyword>(),
                Parameters = new List<Parameter>()
            };
            this.Posts.Add(post5);
        }

        public IEnumerable<Post> getDataConfigPosts(DataConfig dataConfig)
        {
            Element element = dataConfig.Element;
            List<Post> dataConfigPosts = new List<Post>();
            foreach (Post post in this.Posts)
            {
                bool isPost = false;
                if (dataConfig.Element.GetType().Equals(typeof(Persoon)))
                {
                    if (post.Persoon.Naam == dataConfig.Element.Naam)
                        isPost = true;
                }
                else if (dataConfig.Element.GetType().Equals(typeof(Organisatie)))
                {
                    if (post.Persoon.Organisatie != null && post.Persoon.Organisatie.Naam == dataConfig.Element.Naam)
                        isPost = true;
                }
                else if (dataConfig.Element.GetType().Equals(typeof(Thema))
                    && element.GetType().Equals(typeof(Thema)))
                {
                    if (checkKeywords(post, (Thema)element))
                    {
                        isPost = true;
                    }
                }
                if (isPost)
                {
                    dataConfigPosts.Add(post);
                }
            }
            return dataConfigPosts;
        }

        private bool checkKeywords(Post post, Thema thema)
        {
            foreach (Keyword kw in post.Keywords)
            {
                foreach (Keyword tkw in thema.Keywords)
                {
                    if (tkw.KeywordNaam.Equals(kw.KeywordNaam))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public IEnumerable<Post> getPosts()
        {
            return this.Posts;
        }

        public void addPosts(List<Post> list)
        {
            foreach (Post post in list)
            {
                if (Posts.Find(p => p.PostId == post.PostId) == null)
                {
                    Posts.Add(post);
                }
            }
        }
    }
}
