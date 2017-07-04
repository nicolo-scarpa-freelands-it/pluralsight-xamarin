using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Widget;

namespace Courses.Droid
{
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@mipmap/icon")]
    public class CourseActivity : FragmentActivity
    {
        private const String DEFAULT_CATEGORY_TITLE = "Android";

        CourseCategoryManager courseCategoryManager;

        CoursePagerAdapter coursePagerAdapter;
        ViewPager coursePager;

        DrawerLayout drawerLayout;
        ListView categoryDrawerListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.CourseActivity);

            // Drawer Layout
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

            // Drawer Category ListView
			categoryDrawerListView = FindViewById<ListView>(Resource.Id.categoryDrawerListView);

			courseCategoryManager = new CourseCategoryManager();
			courseCategoryManager.MoveFirst();

            categoryDrawerListView.Adapter = new CourseCategoryListAdapter(this, Resource.Layout.CourseCategoryItem, courseCategoryManager);

            categoryDrawerListView.SetItemChecked(0, true);
            categoryDrawerListView.ItemClick += CategoryDrawerListView_ItemClick;

            // Setup Course View
            String categoryTitle = courseCategoryManager.Current.Title;

            CourseManager courseManager = new CourseManager(categoryTitle);

            coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, courseManager);

            coursePager = FindViewById<ViewPager>(Resource.Id.coursePager);
            coursePager.Adapter = coursePagerAdapter;
        }

        void CategoryDrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            courseCategoryManager.MoveTo(e.Position);

            String categoryTitle = courseCategoryManager.Current.Title;
            CourseManager courseManager = new CourseManager(categoryTitle);

            coursePagerAdapter.CourseManager = courseManager;

            coursePager.CurrentItem = 0;

            drawerLayout.CloseDrawer(categoryDrawerListView);
        }
    }
}
