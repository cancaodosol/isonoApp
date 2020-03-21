﻿using IssWebRazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssWebRazorApp.Data
{
    public interface IPlaybookRepository
    {
        public Playbook Find(int id);
        public IList<Playbook> FindAll();
        public void Add(Playbook playbook,string bucketPath);
        public void Edit(Playbook playbook, string bucketPath);
        public IList<Category> GetCategoryList(String session);
    }
}
