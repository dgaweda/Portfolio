﻿using Portfolio.Models;
using Portfolio.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Portfolio.DAL
{
    public class DataBaseSeedInit : MigrateDatabaseToLatestVersion<PortfolioContext, Migrations.Configuration>
    {
        public static void SeedData(PortfolioContext context)
        {
            var Menu = new List<Menu>
            {
                new Menu() { MenuId = 1, Name = "MAIN", ControllerAction = "Index", ControllerName = "Home", Blank = null },
                new Menu() { MenuId = 2, Name = "GITHUB", Reference = "https://github.com/dgaweda", Blank = "_blank" },
                new Menu() { MenuId = 3, Name = "SLIGHT EDGE", ControllerAction = "SlightEdge", ControllerName = "SlightEdge", Blank = null },
                new Menu() { MenuId = 4, Name = "ABOUT ME", ControllerAction = "AboutMe", ControllerName = "AboutMe", Blank = null },
                new Menu() { MenuId = 5, Name = "NOTES", ControllerAction = "Index", ControllerName = "Home", Blank = null }
            };
            Menu.ForEach(menu => context.Menus.AddOrUpdate(menu));
            context.SaveChanges();

            var General = "Since couple of months i'm interested in some kind of philosophy of human brain and common problems which everyone of us met like procrastination. Every day i try to fight those problems connecting it with my everyday work. Even now i'm making 60 min work session with this project... <br /> (btw.it's my 46th minute)";
            var People = new List<Person>
            {
                new Person() {PersonId = 1, Name = "Darek", Lastname = "Gawęda", GeneralInfo = General, Logged = true, Picture = "Me.jpg"}
            };
            People.ForEach(person => context.People.AddOrUpdate(person));
            context.SaveChanges();

            var Technologies = new List<Technology>()
            {
                new Technology() { TechnologyId = 1, Name = "MVC Pattern", Purpose = (Purpose) 0, PersonId = 1 },
                new Technology() { TechnologyId = 2, Name = "Entity Framework", Purpose = (Purpose) 1, PersonId = 1 },
                new Technology() { TechnologyId = 3, Name = ".NET Framework", Purpose = (Purpose) 1, PersonId = 1},
                new Technology() { TechnologyId = 4, Name = "Razor", Purpose = (Purpose)2, PersonId = 1},
                new Technology() { TechnologyId = 5, Name = "MS SQL Server", Purpose = (Purpose) 3, PersonId = 1},
                new Technology() { TechnologyId = 6, Name = "CSS + HTML5", Purpose = (Purpose) 2, PersonId = 1},
                new Technology() { TechnologyId = 7, Name = "NUnit", Purpose = (Purpose) 5, PersonId = 1},
                new Technology() { TechnologyId = 8, Name = "IdentityUser", Purpose = (Purpose) 4, PersonId = 1},
                new Technology() { TechnologyId = 9, Name = "Swagger", Purpose = (Purpose) 5, PersonId = 1},
                new Technology() { TechnologyId = 10, Name = "Postman", Purpose = (Purpose) 5, PersonId = 1}
            };
            Technologies.ForEach(technology => context.Technologies.AddOrUpdate(technology));
            context.SaveChanges();

            var SchoolList = new List<Education>()
            {
                new Education() { EducationId = 1, Name = "University of Gdansk", Major = "Computer Science", From = "2017", To = "Present" },
                new Education() { EducationId = 2, Name = "Technical college in Działdowo", Major = "IT Technician", From = "2013", To = "2017"}
            };
            SchoolList.ForEach(school => context.Educations.AddOrUpdate(school));
            context.SaveChanges();

            var HobbyList = new List<Hobby>()
            {
                new Hobby() { HobbyId = 1, Name = "Computer/board games - particularly the newest titles"},
                new Hobby() { HobbyId = 2, Name = "Volleyball"},
                new Hobby() { HobbyId = 3, Name = "Manual works with computer"},
                new Hobby() { HobbyId = 4, Name = "And recently programming in C#"}
            };
            HobbyList.ForEach(hobby => context.Hobbies.AddOrUpdate(hobby));
            context.SaveChanges();

            var Note = new List<Note>()
            {
                new Note() { NoteId = 1,  Title = "xyz", Objectives = "xyz", Date = DateTime.Now, Hidden = false, PersonId = 1}
            };
            Note.ForEach(note => context.Notes.AddOrUpdate(note));
            context.SaveChanges();

            var EducationToPerson = new List<EducationToPerson>()
            {
                new EducationToPerson() {PersonId = 1, EducationId = 1 },
                new EducationToPerson() {PersonId = 1, EducationId = 2 }
            };
            EducationToPerson.ForEach(x => context.EducationToPeople.AddOrUpdate(x));
            context.SaveChanges();

            var HobbyToPerson = new List<HobbyToPerson>()
            {
                new HobbyToPerson() {PersonId = 1,HobbyId = 1 },
                new HobbyToPerson() {PersonId = 1,HobbyId = 2 },
                new HobbyToPerson() {PersonId = 1,HobbyId = 3 },
                new HobbyToPerson() {PersonId = 1,HobbyId = 4 }
            };
            HobbyToPerson.ForEach(x => context.HobbyToPeople.AddOrUpdate(x));
            context.SaveChanges();

        }
    }

    public enum Purpose
    {
        General,
        Backend,
        Frontend,
        Database,
        Logging,
        Testing
    };



}


