﻿using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Instructor
{
    public class CourseRepo : IRepository<Cours, int>
    {
            //try {

            //return true;
            //}
            //catch (Exception)
            //{

            //    return false;
            //}
        AskNLearnEntities db;
        public CourseRepo(AskNLearnEntities db)
        {
            this.db = db;
        }
        public bool Add(Cours obj)
        {
            try
            {
                db.Courses.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int coid)
        {
            try {
            var data = db.Courses.Find(coid);
            db.Courses.Remove(data);
            db.SaveChanges();

            return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(Cours obj)
        {
            try
            {
                var data = db.Courses.Find(obj.coid);
                data.title = obj.title;
                data.details = obj.details;
                data.price = obj.price;
                data.thumbnail = obj.thumbnail;
                data.dateTime = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Cours Get(int id)
        {
            var course = db.Courses.Find(id);
            return course;
        }

        public List<Cours> Get()
        {
            var courses = db.Courses.ToList();
            return courses;
        }
    }
}
