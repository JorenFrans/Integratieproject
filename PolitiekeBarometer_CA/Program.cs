using BL.Interfaces;
using BL.Managers;
using DAL.Repositories_HC;
using Domain;
using Domain.Platformen;
using Domain.Posts;
using System;
using System.Collections.Generic;

namespace PolitiekeBarometer_CA
{
    class Program
    {

        private static IElementManager elementManager;
        private static IPostManager postManager;
        private static IDashboardManager dashboardManager;
        private static IPlatformManager platformManager;
        static void Main(string[] args)
        {
            elementManager = new ElementManager();
            postManager = new PostManager();
            dashboardManager = new DashboardManager();
            platformManager = new PlatformManager();
            Console.WriteLine("Politieke Barometer");
            bool afsluiten = false;
            while (!afsluiten)
            {
                showMenu();
            }
        }

        private static void showMenu()
        {
            Console.WriteLine("1. Update Posts");
            Console.WriteLine("2. Quit");


            DetectMenuAction();


        }

        private static void DetectMenuAction()
        {
            bool inValidAction = false;
            do
            {
                Console.Write("Keuze: ");
                string input = Console.ReadLine();
                int action;
                if (Int32.TryParse(input, out action))
                {
                    switch (action)
                    {
                        case 1:
                            updatePosts();
                            break;

                        default:
                            Console.WriteLine("Foute optie");
                            inValidAction = true;
                            break;
                    }
                }
            } while (inValidAction);
        }

        private static void updatePosts()
        {

            bool melding = false;
            //Posts updaten
            List<Tweet> tweets = postManager.updatePosts();

            //TODO: Verderparsen en toevoegen
            List<Post> postsToAdd = new List<Post>();
            postsToAdd = ParseTweetsToPost(tweets);
            postManager.addPosts(postsToAdd);
            //Actieve Alerts ophalen
            List<Alert> actieveAlerts = dashboardManager.getActiveAlerts();

            foreach (Alert alert in actieveAlerts)
            {
                DataConfig dataConfig = dashboardManager.getAlertDataConfig(alert);
                double waarde = postManager.getHuidigeWaarde(dataConfig);

                switch (alert.Operator)
                {
                    
                    case ">":
                        if (alert.Waarde > waarde)
                        {
                            melding = true;
                        }
                        break;
                    case "<":
                        if (alert.Waarde < waarde)
                        {
                            melding = true;
                        }
                        break;
                    default:
                        Console.WriteLine("ongeldige operator"); break;
                }

                if (melding)
                {
                    Gebruiker gebruiker = dashboardManager.getAlertGebruiker(alert);
                    if (alert.ApplicatieMelding)
                    {
                        Console.WriteLine("Applicatiemelding naar " + gebruiker.Naam);
                        Console.WriteLine("De waarde van " + alert.DataConfig.Element.Naam + " is " + waarde);
                        Console.WriteLine();
                    }
                    if (alert.BrowserMelding)
                    {
                        Console.WriteLine("Applicatiemelding naar " + gebruiker.Naam);
                        Console.WriteLine("De waarde van " + alert.DataConfig.Element.Naam + " is " + waarde);
                        Console.WriteLine();
                    }
                    if (alert.EmailMelding)
                    {
                        Console.WriteLine("Emailmelding naar " + gebruiker.Email);
                        Console.WriteLine("De waarde van " + alert.DataConfig.Element.Naam + " is " + waarde);
                        Console.WriteLine();
                    }
                }
            }
        }

        private static List<Post> ParseTweetsToPost(List<Tweet> tweets)
        {
            int index = 0;
            List<Post> posts = new List<Post>();
            foreach (Tweet tweet in tweets)
            {
                Post post = new Post();
                post.PostId = tweet.TweetId;
                post.Keywords = new List<PostKeyword>();
                foreach (string word in tweet.Words)
                {
                    post.Keywords.Add(new PostKeyword()
                    {
                        Post = post,
                        PostKeywordId = index,
                        word = word
                    });
                    index++;
                }

                post.Persoon = elementManager.getPersoon(tweet.Politician[0]+ " " + tweet.Politician[1] );
                post.Source = "Twitter";
                post.Date = tweet.Date;
                posts.Add(post);
                #region parameters
                //    List<Waarde> waardenUrls = new List<Waarde>();
                //    index = 0;
                //    foreach (string url in tweet.Urls)
                //    {
                //        Waarde waarde = new Waarde()
                //        {
                //            Value = url,
                //            Parameter = ElementManager.getParameter("urls"),
                //            WaardeId = index

                //        };
                //        index++;
                //    }
                //    post.Parameters.Add(new Parameter()
                //    {
                //        Naam = "urls",
                //        ParameterId = 1,
                //        ParameterType = ParameterType.STRING,
                //        Post = post,
                //        Waarden = waardenUrls

                //    };

                //    List<Waarde> waardenHashtags = new List<Waarde>();
                //    index = 0;
                //    foreach (string hashtag in tweet.Hashtags)
                //    {
                //        Waarde waarde = new Waarde()
                //        {
                //            Value = hashtag,
                //            Parameter = ElementManager.getParameter("hashtags"),
                //            WaardeId = index
                //        };
                //        index++;
                //    }

                //    post.Parameters.Add(new Parameter()
                //    {
                //        Naam = "hashtags",
                //        ParameterId = 2,
                //        ParameterType = ParameterType.STRING,
                //        Post = post,
                //        Waarden = waardenHashtags
                //    });

                //    List<Waarde> waardenMentions = new List<Waarde>();
                //    index = 0;
                //    foreach (string waarde in tweet.Mentions)
                //    {
                //        Waarde waarde = new Waarde()
                //        {
                //            Value = waarde,
                //            Parameter = ElementManager.getParameter("hashtags"),
                //            WaardeId = index
                //        };
                //        index++;
                //    }

                //    post.Parameters.Add(new Parameter()
                //    {
                //        Naam = "hashtags",
                //        ParameterId = 2,
                //        ParameterType = ParameterType.STRING,
                //        Post = post,
                //        Waarden = waardenMentions
                //    });
                //};
                #endregion
            }

            return posts;
        }


    }
}

