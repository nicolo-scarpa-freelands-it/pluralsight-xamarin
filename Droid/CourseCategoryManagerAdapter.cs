using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Courses.Droid
{
	public class CourseCategoryManagerAdapter : BaseAdapter<CourseCategory>
	{
		Context context;
		int layoutResourceId;
		CourseCategoryManager courseCategoryManager;

		public CourseCategoryManagerAdapter(Context context, int layoutResourceId, CourseCategoryManager courseCategoryManager)
		{
			this.context = context;
			this.layoutResourceId = layoutResourceId;
			this.courseCategoryManager = courseCategoryManager;
		}

		public override CourseCategory this[int position]
		{
			get
			{
				courseCategoryManager.MoveTo(position);

				return courseCategoryManager.Current;
			}
		}

		public override int Count => courseCategoryManager.Length;

		public override long GetItemId(int position)
		{
			// In our case items are identified by their position
			return position;
		}

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // Must create a new view
            if (view == null)
            {
                // Inflate the layout with LayoutInflaterService object
                LayoutInflater inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

                view = inflater.Inflate(layoutResourceId, null);
            }

            // This is an Android preset for SimpleListItem1 view
            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            // I can use the indexer method of this same class
            textView.Text = this[position].Title;

            return view;
        }
    }
}
