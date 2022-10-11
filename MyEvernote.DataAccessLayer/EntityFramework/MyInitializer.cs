using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernote.Entities;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            // Adding admin user..
            EvernoteUser admin = new EvernoteUser()
            {
                Name = "Sedat",
                Surname = "Emre",
                Email = "admin@sedatemre.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "sedatemre",
                Password = "sedoishere",
                ProfileImageFilename = "pic00.jpg",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "sedatemre"

            };

            // Adding standart user..
            EvernoteUser standartUser = new EvernoteUser()
            {
                Name = "Sinan",
                Surname = "Berk",
                Email = "thesedo@outlook.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "sinanberk",
                Password = "sedoishere",
                ProfileImageFilename = "pic00.jpg",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "sinanberk"

            };
            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(standartUser);

            // Adding fake users.. 

            for (int i = 0; i < 8; i++)
            {
                EvernoteUser user = new EvernoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ProfileImageFilename = "pic00.jpg",
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = true,
                    Username = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}"

                };
                context.EvernoteUsers.Add(user);
            }

            context.SaveChanges();

            // User list for using..
            List<EvernoteUser> userList = context.EvernoteUsers.ToList();

            // Adding Fake Categories..

            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "sedatemre"
                };

                context.Categories.Add(cat);

                //Adding fake notes..
                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    EvernoteUser owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];

                    string title = FakeData.TextData.GetSentence();
                    if (title.Length > 60)
                    {
                        title = title.Substring(0, 50);
                    }
                    Note note = new Note()
                    {
                        Title = title,
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        //Category = cat,
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1,9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.Username
                    };
                    cat.Notes.Add(note);

                    //Adding Fake Comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3,5); j++)
                    {
                        EvernoteUser comment_owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];

                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            //Note=note,
                            Owner = comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username
                        };

                        note.Comments.Add(comment);
                    }
                    // Adding fake likes..
                   
                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        Liked liked = new Liked()
                        {
                            LikedUser = userList[m]
                        };
                    note.Likes.Add(liked);
                    }

                }
            }

            context.SaveChanges();
        }
    }
}
