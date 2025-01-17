﻿using DAL.Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class UnitOfWorkManager
    {
        private UnitOfWork uof;

        internal UnitOfWork UnitOfWork
        {
            get
            {  
                if (uof == null) uof = new UnitOfWork();
                return uof;
            }
        }

        public void Save()
        {
            UnitOfWork.CommitChanges();
        }
    }
}
