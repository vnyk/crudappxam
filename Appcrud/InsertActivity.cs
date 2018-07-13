using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Appcrud
{
    [Activity(Label = "insertActivity")]
    public class insertActivity : Activity
    {
        EditText sname;
        EditText splace;
        EditText sphone;
        Button save;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Insert);
            // Create your application here
            sname = FindViewById<EditText>(Resource.Id.nameInput);
            splace = FindViewById<EditText>(Resource.Id.placeInput);
            sphone = FindViewById<EditText>(Resource.Id.phoneInput);
            save = FindViewById<Button>(Resource.Id.saveButton);
            FindViewById<Button>(Resource.Id.cancelButton).Click += cancel_Click;
            save.Click += Oninsertclick;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Oninsertclick(object sender, EventArgs e)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "my1db.db3");
            var db = new SQLiteConnection(path);
            db.CreateTable<tablemodel>();
            try
            {
                tablemodel tb = new tablemodel
                {
                    Name = sname.Text,
                    Place = splace.Text,
                    Phone = int.Parse(sphone.Text)
                };
                db.Insert(tb);
                Toast.MakeText(this, "Inserted", ToastLength.Long);
                Finish();
            }
            catch (Exception) { Toast.MakeText(this, "Please check the values", ToastLength.Long); }
        }
    }


}