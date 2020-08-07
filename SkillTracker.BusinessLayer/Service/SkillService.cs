﻿using SkillTracker.BusinessLayer.Interface;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillTracker.BusinessLayer.Service.Repository;

namespace SkillTracker.BusinessLayer.Service
{
    public class SkillService : ISkillService
    {
        /// <summary>
        /// skillrepository type of reference
        /// </summary>
        private readonly ISkillRepository _skillRepository;

        /// <summary>
        /// Inject SkillRepository object
        /// </summary>
        /// <param name="skillRepository"></param>
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }


        /// <summary>
        /// call repository method to Save new skill upgarded by full stack engineer into database
        /// </summary>
        /// <returns>list of skills</returns>
      public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            //Business Logic goes here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save new skill upgarded by full stack engineer into database
        /// </summary>
        /// <param name="skill"></param>
        /// <returns>New Skill Added</returns>
     public async Task<string> AddNewSkill(Skill skill)
        {
            //Business Logic goes here
            throw new NotImplementedException();
        }

        /// <summary>
        /// call repository method to delete skill of full stack engineer from database
        /// </summary>
        /// <param name="skillname"></param>
        /// <returns>delete count 1</returns>

        public async Task<int> DeleteSkill(string skillname)
        {
            //Business Logic goes here
            throw new NotImplementedException();
        }


        /// <summary>
        /// update skill upgarded by full stack engineer from database
        /// </summary>
        /// <param name="skill"></param>
        /// <returns>edit count 1</returns>
       public async Task<int> EditSkill(Skill skill)
        {
            //Business Logic goes here
            throw new NotImplementedException();
        }
    }
}
