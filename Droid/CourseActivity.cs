
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

namespace Courses.Droid
{
    [Activity(Label = "Courses")]
    public class CourseActivity : FragmentActivity
    {
        public const String DISPLAY_CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private const String DEFAULT_CATEGORY_TITLE = "Android";

        CourseManager courseManager;
        CoursePagerAdapter coursePagerAdapter;
        ViewPager coursePager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CourseActivity);

            String categoryTitle = DEFAULT_CATEGORY_TITLE;

            Intent startupIntent = this.Intent;
            if (startupIntent != null) 
            {
                String displayCategoryTitleExtra = startupIntent.GetStringExtra(DISPLAY_CATEGORY_TITLE_EXTRA);
                if (displayCategoryTitleExtra != null) 
                {
                    categoryTitle = displayCategoryTitleExtra;
                }
            }

            courseManager = new CourseManager(categoryTitle);
            courseManager.MoveFirst();

            coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, courseManager);

            coursePager = FindViewById<ViewPager>(Resource.Id.coursePager);
            coursePager.Adapter = coursePagerAdapter;
        }
    }
}
