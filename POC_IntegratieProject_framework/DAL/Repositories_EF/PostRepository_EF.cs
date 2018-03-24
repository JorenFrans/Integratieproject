using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories_EF;
using DAL.Repositories_HC;
using Domain;

namespace DAL.Repositories
{
    public class PostRepository_EF : IPostRepository
    {

        private readonly EF.PolitiekeBarometerContext ctx;

        public PostRepository_EF()
        {
            ctx = new EF.PolitiekeBarometerContext();
        }

        public PostRepository_EF(UnitOfWork uow)
        {
            ctx = uow.Context;
        }

        public void addPosts(List<Post> list)
        {
            throw new NotImplementedException();
        }

        public List<Post> getDataConfigPosts(DataConfig dataConfig, Element element)
        {
            throw new NotImplementedException();
        }

        public List<Post> getPosts()
        {
            throw new NotImplementedException();
        }

        public List<Tweet> readJSON()
        {
            throw new NotImplementedException();
        }

        public void updatePosts()
        {
            throw new NotImplementedException();
        }
    }
}
