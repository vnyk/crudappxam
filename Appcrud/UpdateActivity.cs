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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.update);
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Call Database  
            var db = new SQLiteConnection(dpPath);

            var data = db.Table<tablemodel>();

            var datarow = (from values in data where id == idtxt.Text() select values).Single();

            datarow.Name = txt.Text();
            .
            .
            .
            db.Update(datarow);

            // DELETe

            var data1 = data.Where(x => x.id == idvalue).FirstOrDefault();
            if (data1.id != null)
            {
                db.Delete(data1);
                Toast.MakeText(this, "Delete Successfully", ToastLength.Short).Show();
                txt_delete_id.Text = "";
            }
        }
    }
}