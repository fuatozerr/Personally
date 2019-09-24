using Microsoft.EntityFrameworkCore;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personally.DataAccess.Concrete
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new PersonallyContext();

            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Categories.Count()==0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Notes.Count() == 0)
                {
                    context.Notes.AddRange(Notes);
                }
            }
        }

        private static Category[] Categories = {
            new Category(){ Title="Bilişim"},
            new Category(){ Title="Ulaşım"},
            new Category(){ Title="Yapay Zeka"},
            new Category(){ Title="Web Teknolojileri"}
        };

        private static Note[] Notes= {
            new Note(){ Title="Bilişim", Owner="Fuat",ImageUrl="localhos",IsDraft=false,LikeCount=30,Description="Açıklama"},

            new Note(){ Title="Ulaşım", Owner="Fuat",ImageUrl="localhos",IsDraft=false,LikeCount=50,Description="UlaşımAçıklama"},
            new Note(){ Title="Yapay Zeka", Owner="Fuat",ImageUrl="localhos",IsDraft=false,LikeCount=100,Description="Yapay Zeka Açıklama"},
            new Note(){ Title="CSharp", Owner="Fuat",ImageUrl="localhos",IsDraft=false,LikeCount=30,Description="CSharpAçıklama"},

        };
    }
}
