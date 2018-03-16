﻿using DAL.Repositories_HC;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IPostManager
    {
        Double getHuidigeWaarde(DataConfig dataConfig);
        List<Tweet> updatePosts();
        int getNextPostId();
        void addPosts(List<Post> list);
    }
}
