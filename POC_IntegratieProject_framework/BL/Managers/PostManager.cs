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
using DAL.Repositories;

namespace BL.Managers
{
    public class PostManager : IPostManager
    {
        IPostRepository postRepository;

        public PostManager()
        {
            this.postRepository = new PostRepository_EF();
        }

        public void addPosts(List<Post> list)
        {
            postRepository.addPosts(list);
        }
        public List<Post> getDataConfigPosts(DataConfig dataConfig, Element element)
        {
            return postRepository.getDataConfigPosts(dataConfig, element);
        }
        public double getHuidigeWaarde(DataConfig dataConfig, Element element)
        {
            List<Post> posts = getDataConfigPosts(dataConfig, element);
            switch (dataConfig.DataType)
            {
                case DataType.TOTAAL:
                    return posts.Count;
                case DataType.TREND:
                    //Kijken naar de tijdstippen en de trend berekenen
                    double trend = calculateTrend(dataConfig, element);
                    return trend;
                default:
                    return 0.0;
            }

        }

        public double calculateTrend(DataConfig dataConfig, Element element)
        {
            List<Post> posts = getDataConfigPosts(dataConfig, element);
            //We hebben 2 arrays nodig => Datums & waardes
            //We zouden de posts moeten sorteren op datum => loopen & waarde ++
            double[] dateVector = new double[posts.Count];
            double[] waardeVector = new double[posts.Count];
            int i = 0;
            foreach (Post post in posts)
            {
                dateVector[i] = post.Date.Ticks;
                waardeVector[i] = i + 1;
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
