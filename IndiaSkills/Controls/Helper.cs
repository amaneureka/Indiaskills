using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace IndiaSkills.Controls
{
    public delegate User LoginHelper(string aUsername, string aPassword);

    /// <summary>
    /// Database relations handler
    /// </summary>
    public static class Helper
    {
        public static void CreateFakeDatabase()
        {
            if (File.Exists(Config.UserDatabasePath))
                File.Delete(Config.UserDatabasePath);

            if (File.Exists(Config.SiteDatabasePath))
                File.Delete(Config.SiteDatabasePath);

            if (File.Exists(Config.TheaterDatabasePath))
                File.Delete(Config.TheaterDatabasePath);

            if (File.Exists(Config.PlanDatabasePath))
                File.Delete(Config.PlanDatabasePath);

            // create fake users table
            using (var SW = new StreamWriter(File.Open(Config.UserDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedUsers = new List<User>();

                FakedUsers.Add(new User { Username = "amaneureka", Password = "amaneureka", UserLevel = 0 });
                FakedUsers.Add(new User { Username = "admin", Password = "admin", UserLevel = 1 });

                SW.WriteLine(JsonConvert.SerializeObject(FakedUsers));

                SW.Flush();
                SW.Close();
            }

            // create fake site details table
            using (var SW = new StreamWriter(File.Open(Config.SiteDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedDetails = new List<Site>();

                FakedDetails.Add(new Site { Code = "00001", Address = "Rohini", City = "New Delhi", State = "Delhi", PinCode = "110089" });
                FakedDetails.Add(new Site { Code = "00002", Address = "Shalimar Bagh", City = "New Delhi", State = "Delhi", PinCode = "110088" });
                FakedDetails.Add(new Site { Code = "00003", Address = "Dwarka", City = "New Delhi", State = "Delhi", PinCode = "110000" });
                FakedDetails.Add(new Site { Code = "00004", Address = "Noida", City = "New Delhi", State = "Delhi", PinCode = "110000" });
                FakedDetails.Add(new Site { Code = "00005", Address = "America", City = "---", State = "--", PinCode = "---" });

                SW.WriteLine(JsonConvert.SerializeObject(FakedDetails));

                SW.Flush();
                SW.Close();
            }

            // create fake theater details table
            using (var SW = new StreamWriter(File.Open(Config.TheaterDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedDetails = new List<Theater>();

                FakedDetails.Add(new Theater { SiteCode = "00001", HallCode = "ABC", PlanLayout = "xyz" });
                FakedDetails.Add(new Theater { SiteCode = "00002", HallCode = "ABC2", PlanLayout = "xyz2" });

                SW.WriteLine(JsonConvert.SerializeObject(FakedDetails));

                SW.Flush();
                SW.Close();
            }

            // create fake plan layouts table
            using (var SW = new StreamWriter(File.Open(Config.PlanDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedDetails = new List<PlanDetails>();

                FakedDetails.Add(new PlanDetails { LayoutName = "Plan A", EncodedString = "00000", Rows = 15, Columns = 5 });
                FakedDetails.Add(new PlanDetails { LayoutName = "Plan B", EncodedString = "11111", Rows = 10, Columns = 10});

                SW.WriteLine(JsonConvert.SerializeObject(FakedDetails));

                SW.Flush();
                SW.Close();
            }

            // create fake movies table
            using (var SW = new StreamWriter(File.Open(Config.MovieDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedDetails = new List<Movies>();

                FakedDetails.Add(new Movies { MovieName = "mov1", Introduction = "intro1", Casting = "casting1", Genre = "genre1" });
                FakedDetails.Add(new Movies { MovieName = "mov2", Introduction = "intro2", Casting = "casting2", Genre = "genre2" });
                FakedDetails.Add(new Movies { MovieName = "mov3", Introduction = "intro3", Casting = "casting3", Genre = "genre3" });

                SW.WriteLine(JsonConvert.SerializeObject(FakedDetails));

                SW.Flush();
                SW.Close();
            }

            // create fake snack table
            using (var SW = new StreamWriter(File.Open(Config.SnackDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedDetails = new List<Snack>();

                FakedDetails.Add(new Snack { Name = "snack1", Price = 12.23 });
                FakedDetails.Add(new Snack { Name = "snack2", Price = 12.3 });
                FakedDetails.Add(new Snack { Name = "snack3", Price = 2.23 });
                FakedDetails.Add(new Snack { Name = "snack4", Price = 2.3 });
                
                SW.WriteLine(JsonConvert.SerializeObject(FakedDetails));

                SW.Flush();
                SW.Close();
            }

            // create fake Show table
            using (var SW = new StreamWriter(File.Open(Config.ShowDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedDetails = new List<Show>();

                FakedDetails.Add(new Show { MovieName = "MovieName1", StartTiming = "StartTime1", EndTiming = "EndTime1", MovieHall = "01", Price = 1.23 });
                FakedDetails.Add(new Show { MovieName = "MovieName2", StartTiming = "StartTime2", EndTiming = "EndTime2", MovieHall = "01", Price = 0.23 });
                FakedDetails.Add(new Show { MovieName = "MovieName3", StartTiming = "StartTime3", EndTiming = "EndTime3", MovieHall = "01", Price = 2.43 });
                
                SW.WriteLine(JsonConvert.SerializeObject(FakedDetails));

                SW.Flush();
                SW.Close();
            }

            // create fake Booking details
            using (var SW = new StreamWriter(File.Open(Config.BookingDatabasePath, FileMode.OpenOrCreate)))
            {
                var FakedDetails = new List<BookingDetail>();
                                
                SW.WriteLine(JsonConvert.SerializeObject(FakedDetails));

                SW.Flush();
                SW.Close();
            }
        }

        public static User DataBaseLogin(string aUsername, string aPassword)
        {
            using (var SR = new StreamReader(File.OpenRead(Config.UserDatabasePath)))
            {
                var Data = SR.ReadToEnd();

                var Users = JsonConvert.DeserializeObject<List<User>>(Data);
                foreach(var usr in Users)
                {
                    if (usr.Username == aUsername &&
                        usr.Password == aPassword)
                        return usr;
                }
                SR.Close();
            }
            return null;
        }

        private static List<T> DatabaseDetails<T>(string aDatabaseName)
        {
            using (var SR = new StreamReader(File.OpenRead(aDatabaseName)))
            {
                var Data = SR.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(Data);
            }
        }

        public static List<Theater> DatabaseTheaterDetails()
        {
            return DatabaseDetails<Theater>(Config.TheaterDatabasePath);
        }

        public static List<Movies> DatabaseMoviesDetails()
        {
            return DatabaseDetails<Movies>(Config.MovieDatabasePath);
        }

        public static List<Site> DatabaseSiteDetails()
        {
            return DatabaseDetails<Site>(Config.SiteDatabasePath);
        }

        public static List<PlanDetails> DatabasePlanDetails()
        {
            return DatabaseDetails<PlanDetails>(Config.PlanDatabasePath);
        }

        public static List<Snack> DatabaseSnackDetails()
        {
            return DatabaseDetails<Snack>(Config.SnackDatabasePath);
        }

        public static List<Show> DatabaseShowDetails()
        {
            return DatabaseDetails<Show>(Config.ShowDatabasePath);
        }

        public static List<BookingDetail> DatabaseBookingDetails()
        {
            return DatabaseDetails<BookingDetail>(Config.BookingDatabasePath);
        }

        private static bool DatabaseDetails<T>(string aDatabaseName, List<T> aDetails)
        {
            if (File.Exists(aDatabaseName))
                File.Delete(aDatabaseName);

            using (var SW = new StreamWriter(File.OpenWrite(aDatabaseName)))
            {
                SW.WriteLine(JsonConvert.SerializeObject(aDetails));
                SW.Flush();
                SW.Close();
            }
            return true;
        }

        public static bool UpdateSiteDetails(List<Site> aDetails)
        {
            return DatabaseDetails<Site>(Config.SiteDatabasePath, aDetails);
        }

        public static bool UpdateSnackDetails(List<Snack> aDetails)
        {
            return DatabaseDetails<Snack>(Config.SnackDatabasePath, aDetails);
        }

        public static bool UpdateMovieDetails(List<Movies> aDetails)
        {
            return DatabaseDetails<Movies>(Config.MovieDatabasePath, aDetails);
        }

        public static bool UpdatePlanDetails(List<PlanDetails> aDetails)
        {
            return DatabaseDetails<PlanDetails>(Config.PlanDatabasePath, aDetails);
        }

        public static bool UpdateTheaterDetails(List<Theater> aDetails)
        {
            return DatabaseDetails<Theater>(Config.TheaterDatabasePath, aDetails);
        }

        public static bool UpdateShowsDetails(List<Show> aDetails)
        {
            return DatabaseDetails<Show>(Config.ShowDatabasePath, aDetails);
        }

        public static bool UpdateBookingDetails(List<BookingDetail> aDetails)
        {
            return DatabaseDetails<BookingDetail>(Config.BookingDatabasePath, aDetails);
        }

        public static bool DataBaseLoginUpdatePassword(string aUsername, string aNewPassword)
        {
            List<User> Users;
            using (var SR = new StreamReader(File.OpenRead(Config.UserDatabasePath)))
            {
                var Data = SR.ReadToEnd();

                Users = JsonConvert.DeserializeObject<List<User>>(Data);
                foreach (var usr in Users)
                {
                    if (usr.Username == aUsername)
                    {
                        usr.Password = aNewPassword;
                        break;
                    }
                }
                SR.Close();
            }

            if (Users == null)
                return false;

            if (File.Exists(Config.UserDatabasePath))
                File.Delete(Config.UserDatabasePath);

            using (var SW = new StreamWriter(File.OpenWrite(Config.UserDatabasePath)))
            {
                SW.WriteLine(JsonConvert.SerializeObject(Users));
                SW.Flush();
                SW.Close();
            }

            return true;
        }
    }
}
