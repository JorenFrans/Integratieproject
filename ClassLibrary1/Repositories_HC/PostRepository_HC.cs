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
            addPosts();
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

        private void addPosts()
        {
            Post post1 = new Post()
            {
                Source = "Twitter",
                PostId = 1,
                Persoon = new Persoon()
                {
                    Id = 1,
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
            this.Posts.Add(post1);

            Post post2 = new Post()
            {
                Source = "Twitter",
                PostId = 2,
                Persoon = new Persoon()
                {
                    Id = 1,
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
            this.Posts.Add(post2);

            Post post3 = new Post()
            {
                Source = "Twitter",
                PostId = 3,
                Persoon = new Persoon()
                {
                    Id = 1,
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
            this.Posts.Add(post3);
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

        public List<Post> getDataConfigPosts(DataConfig dataConfig)
        {
            List<Post> dataConfigPosts = new List<Post>();
            foreach (Post post in this.Posts)
            {
                if (dataConfig.Element.GetType() == typeof(Persoon))
                {
                    if (post.Persoon.Naam == dataConfig.Element.Naam)
                        dataConfigPosts.Add(post);
                }
                else if (dataConfig.Element.GetType() == typeof(Organisatie))
                {
                    if (post.Persoon.Organisatie.Naam == dataConfig.Element.Naam)
                        dataConfigPosts.Add(post);
                }
                else if (dataConfig.Element.GetType() == typeof(Thema))
                {
                    if (checkKeywords())
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            return dataConfigPosts;
        }

        private bool checkKeywords()
        {
            throw new NotImplementedException();
        }

        public List<Post> getPosts()
        {
            return this.Posts;
        }

        public void addPosts(List<Post> list)
        {
            foreach (Post post in list)
            {
                if (Posts.Find(p=>p.PostId == post.PostId) == null)
                {
                    Posts.Add(post);
                }
            }
        }
    }
}
