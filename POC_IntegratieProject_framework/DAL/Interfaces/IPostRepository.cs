using DAL.Repositories_HC;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IPostRepository
    {
        List<Post> getDataConfigPosts(DataConfig dataConfig, Element element);
        void updatePosts();
        List<Tweet> readJSON();

        List<Post> getPosts();
        void addPosts(List<Post> list);
    }
}
