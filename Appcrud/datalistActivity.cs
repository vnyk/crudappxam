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
    [Activity(Label = "datalistActivity")]
    public class datalistActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.datalist);
            
            var lv = (ListView)FindViewById(Resource.Id.listView);
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");
            var db = new SQLiteConnection(path);

            var data =db.Table<tablemodel>();

            var tblist = (from values in data
                          select new tablemodel
                          {
                              Name = values.Name,
                           });
            var itemlist = new List<string>();
            foreach(var val in tblist)
            {
                itemlist.Add(val.Name);
            }

            lv.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1,
                Android.Resource.Id.Text1, itemlist.ToArray());
            // Create your application here
        }
    }
}