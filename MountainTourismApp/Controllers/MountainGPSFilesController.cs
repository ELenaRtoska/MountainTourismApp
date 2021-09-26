using MountainTourismApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MountainTourismApp.Controllers
{
    public class MountainGPSFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        List<Mountain> mountain = new List<Mountain>();
        List<GPSFile> gPSFile = new List<GPSFile>();

        public ActionResult Index()
        {
            insertDummyData();
            var mountainGPSFile = from s in mountain
                                   join st in gPSFile on s.Id equals st.mountainId into st2
                                   from st in st2.DefaultIfEmpty()
                                   select new MountainGPSFiles { mountain = s, gPSFile = st };
            return View(mountainGPSFile);
        }

        public ActionResult IndexByMountainId(int id)
        {
            return View();
        }


        public void insertDummyData()
        {
            //--- Insert Dummy data into Student
           /* student.Add(new Student { Id = 1, StudentName = "Max", StudentStream = "Computer Science" });
            student.Add(new Student { Id = 2, StudentName = "Tony", StudentStream = "Life Sciences" });
            student.Add(new Student { Id = 3, StudentName = "Jhon", StudentStream = "Robotics" });
            student.Add(new Student { Id = 4, StudentName = "Jack", StudentStream = "Computer Science" });
            student.Add(new Student { Id = 5, StudentName = "Dominic", StudentStream = "Avaiation" });
            
            //---- Insert Dummy data into StudentAdditionalInfo
            studentAdditionalInfo.Add(new StudentAdditionalInfo { Id = 100, StudentId = 1, FavourateFruit = "Apple", Hobby = "Driving" });
            studentAdditionalInfo.Add(new StudentAdditionalInfo { Id = 101, StudentId = 2, FavourateFruit = "Mango", Hobby = "Hunting" });
            studentAdditionalInfo.Add(new StudentAdditionalInfo { Id = 102, StudentId = 3, FavourateFruit = "Bannana", Hobby = "Fishing" });
            studentAdditionalInfo.Add(new StudentAdditionalInfo { Id = 103, StudentId = 4, FavourateFruit = "Pine Apple", Hobby = "Sailing" });
            studentAdditionalInfo.Add(new StudentAdditionalInfo { Id = 104, StudentId = 5, FavourateFruit = "Grapes", Hobby = "Street Racing" });
            */
        }
    }





}