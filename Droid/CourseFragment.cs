
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Courses.Droid
{
    public class CourseFragment : Fragment
    {
		TextView textTitle;
		ImageView imageCourse;
		TextView textDescription;

		public Course Course { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			// Just inflate the view up, like it's going to be attached to the acitvity but don't actually do that.
			// The reason we're not attaching is because we're returning the view and the activity is going to do that on its own.
			View rootView = inflater.Inflate(Resource.Layout.CourseFragment, container, false);

            // In the case of fragments, the view structure is not not implicitily associated. 
            // Must specify the view in which to search other views:
			textTitle = rootView.FindViewById<TextView>(Resource.Id.textTitle);
			imageCourse = rootView.FindViewById<ImageView>(Resource.Id.imageCourse);
			textDescription = rootView.FindViewById<TextView>(Resource.Id.textDescription);

            // Init the views
			textTitle.Text = Course.Title;
			textDescription.Text = Course.Description;
			imageCourse.SetImageResource(ResourceHelper.TranslateDrawableWithReflection(Course.Image));

            return rootView;
        }
    }
}
