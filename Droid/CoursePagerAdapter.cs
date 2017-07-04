using System;
using Android.Support.V4.App;

namespace Courses.Droid
{
    public class CoursePagerAdapter : FragmentStatePagerAdapter
    {
        CourseManager courseManager;

        public CoursePagerAdapter(FragmentManager fm, CourseManager courseManager) : base(fm)
        {
            this.courseManager = courseManager;
        }

        public override int Count => courseManager.Length;

        public override Fragment GetItem(int position)
        {
            courseManager.MoveTo(position);

            CourseFragment courseFragment = new CourseFragment();
            courseFragment.Course = courseManager.Current;

            return courseFragment;
        }

        public CourseManager CourseManager
        {
            set
            {
                courseManager = value;

                // This is used to notify the base class that the Fragments needs to be recreated beacus data has changed
                NotifyDataSetChanged();
            }
        }

        public override int GetItemPosition(Java.Lang.Object objectValue)
        {
            return PositionNone; // no matter which one it tries to reuse don't reuse that one, which causes the GetItem to be triggered and create a new fragment
        }
    }
}
