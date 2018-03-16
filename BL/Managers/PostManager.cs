using BL.Interfaces;
using DAL;
using DAL.Repositories_HC;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using MathNet.Numerics.Interpolation;

namespace BL.Managers
{
    public class PostManager : IPostManager
    {
        IPostRepository postRepository;

        public PostManager()
        {
            this.postRepository = new PostRepository_HC();
        }

        public void addPosts(List<Post> list)
        {
            postRepository.addPosts(list);
        }

        public double getHuidigeWaarde(DataConfig dataConfig)
        {
            List<Post> posts = postRepository.getDataConfigPosts(dataConfig);
            Console.WriteLine(calculateTrend(posts));
            switch (dataConfig.DataType)
            {
                case DataType.TOTAAL:
                    return posts.Count;
                case DataType.TREND:
                    //Kijken naar de tijdstippen en de trend berekenen
                    double trend = calculateTrend(posts);
                    return 0.0;
                default:
                    return 0.0;
            }

        }

        public double calculateTrend(List<Post> posts)
        {
            //We hebben 2 arrays nodig => Datums & waardes
            //We zouden de posts moeten sorteren op datum => loopen & waarde ++
            double[] dateVector = new double[posts.Count];
            double[] waardeVector = new double[posts.Count];
            int i = 0;
            foreach (Post post in posts)
            {
                dateVector[i] = post.Date.Ticks;
                waardeVector[i] = i+1;
                i++;
            }
            CubicSpline cs = CubicSpline.InterpolateNatural(dateVector, waardeVector);

            return cs.Differentiate(posts.Count);
            
        }

        public int getNextPostId()
        {
            return postRepository.getPosts().Count;
        }

        public List<Tweet> updatePosts()
        {
            //PostsUpdaten
            this.postRepository.updatePosts();
            return this.postRepository.readJSON();
        }
    }
}
