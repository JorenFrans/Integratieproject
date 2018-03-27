using DAL;
using DAL.Repositories_HC;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IPostManager
    {
        Double getHuidigeWaarde(DataConfig dataConfig);
        IEnumerable<Tweet> updatePosts();
        int getNextPostId();
        void addPosts(List<Post> list);
        double calculateTrend(DataConfig dataConfig, Element element);
        IEnumerable<Post> getDataConfigPosts(DataConfig dataConfig);
    }
}
