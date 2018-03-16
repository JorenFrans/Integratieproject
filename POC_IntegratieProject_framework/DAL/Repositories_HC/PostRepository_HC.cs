using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain;
using Domain.Elementen;
using Domain.Posts;
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

        public List<Tweet> readJSON()
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
                Keywords = new List<PostKeyword>(),
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
                Keywords = new List<PostKeyword>(),
                Parameters = new List<Parameter>()
            };
            this.Posts.Add(post5);
        }

        public List<Post> getDataConfigPosts(DataConfig dataConfig, Element element)
        {
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
            foreach (ThemaKeyword tkw in thema.Keywords)
            {
                foreach (PostKeyword pkw in post.Keywords)
                {
                    if (tkw.Keyword.Equals(pkw.word))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public List<Post> getPosts()
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
