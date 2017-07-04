using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace Courses.Droid
{
    [Activity(Label = "Courses Categories", MainLauncher = true, Icon = "@mipmap/icon")]
    public class CategoryActivity : ListActivity
    {
        CourseCategoryManager courseCategoryManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            courseCategoryManager = new CourseCategoryManager();
            CourseCategoryManagerAdapter courseCategoryManagerAdapter = new CourseCategoryManagerAdapter(this, Android.Resource.Layout.SimpleListItem1, courseCategoryManager);

            ListAdapter = courseCategoryManagerAdapter;
        }

        protected override void OnListItemClick(Android.Widget.ListView l, Android.Views.View v, int position, long id)
        {
			courseCategoryManager.MoveTo(position);
			String categoryTitle = courseCategoryManager.Current.Title;

            Intent intent = new Intent(this, typeof(CourseActivity));
            intent.PutExtra(CourseActivity.DISPLAY_CATEGORY_TITLE_EXTRA, categoryTitle);

            StartActivity(intent);
        }
    }
}
