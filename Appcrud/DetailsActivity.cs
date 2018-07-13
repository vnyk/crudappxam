using System.IO;
using System.Linq;

using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;

namespace Appcrud
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
        TextView IDView;
        TextView nmdetailView;
        TextView placedetailView;
        TextView numdetailView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);
            IDView = FindViewById<TextView>(Resource.Id.IDView);
            nmdetailView = FindViewById<TextView>(Resource.Id.nmdetailView);
            placedetailView = FindViewById<TextView>(Resource.Id.placedetailView);
            numdetailView = FindViewById<TextView>(Resource.Id.numdetailView);

            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "my1db.db3");
            var db = new SQLiteConnection(path);

            var data = db.Table<tablemodel>();
            int id = 3;
            var tabldata = (from values in data
                            where values.Id == id
                            select new tablemodel
                            {
                                Name = values.Name,
                                Place = values.Place,
                                Phone = values.Phone
                            }).ToList<tablemodel>();
            foreach (var val in tabldata)
            {
                IDView.Text = val.Id.ToString();
                nmdetailView.Text = val.Name.ToString();
                placedetailView.Text = val.Place;
                numdetailView.Text = val.Phone.ToString();
            }


            // Create your application here
        }
    }
}