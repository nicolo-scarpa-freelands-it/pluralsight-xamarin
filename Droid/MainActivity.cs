using Android.App;
using Android.Widget;
using Android.OS;

namespace Courses.Droid
{
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Button buttonPrev;
        Button buttonNext;
        TextView textTitle;
        ImageView imageCourse;
        TextView textDescription;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Wire up UI controls to code
            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            imageCourse = FindViewById<ImageView>(Resource.Id.imageCourse);
            textDescription = FindViewById<TextView>(Resource.Id.textDescription);

            // Add delegates to UI controls
            buttonPrev.Click += ButtonPrev_Click;
            buttonNext.Click += ButtonNext_Click;
        }

        void ButtonPrev_Click(object sender, System.EventArgs e)
        {
            textTitle.Text = "Prev Clicked";
            textDescription.Text = "The description that appears when Prev is clicked";
            imageCourse.SetImageResource(Resource.Drawable.ps_top_card_01);
        }

        void ButtonNext_Click(object sender, System.EventArgs e)
        {
            textTitle.Text = "Next Clicked";
            textDescription.Text = "The description that appears when Next is clicked";
            imageCourse.SetImageResource(Resource.Drawable.ps_top_card_02);
        }
    }
}

