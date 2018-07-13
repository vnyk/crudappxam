using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System;
using SQLite;

namespace Appcrud
{
    [Activity(Label = "Appcrud", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //Button InsertButton;
        //Button updateButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            FindViewById<Button>(Resource.Id.InsertButton).Click += delegate { StartActivity(typeof(insertActivity)); };
            FindViewById<Button>(Resource.Id.updateButton).Click += delegate { StartActivity(typeof(UpdateActivity)); };
            FindViewById<Button>(Resource.Id.ListBtn).Click += delegate { StartActivity(typeof(datalistActivity)); };
            //CreateDb();
        }

        public string CreateDb()
        {
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");
            var db = new SQLiteConnection(dbpath);
            return ("database created.........");
        }
    }
}

