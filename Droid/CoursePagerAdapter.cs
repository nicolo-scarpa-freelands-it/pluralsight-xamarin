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
    }
}
