using System;

using UIKit;

namespace Courses.iOS
{
    public partial class CourseViewController : UIViewController
    {
        CourseManager courseManager;

		public CourseViewController(IntPtr handle) : base(handle)
        {
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // Add event handlers
            buttonPrev.TouchUpInside += ButtonPrev_TouchUpInside;
            buttonNext.TouchUpInside += ButtonNext_TouchUpInside;

			courseManager = new CourseManager();
			courseManager.MoveFirst();

            UpdateUI();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void ButtonPrev_TouchUpInside(object sender, EventArgs e)
        {
            courseManager.MovePrev();

            UpdateUI();
        }

        void ButtonNext_TouchUpInside(object sender, EventArgs e)
        {
            courseManager.MoveNext();

            UpdateUI();
        }

		private void UpdateUI()
		{
			labelTitle.Text = courseManager.Current.Title;
			textDescription.Text = courseManager.Current.Description;
            imageCourse.Image = UIImage.FromBundle(courseManager.Current.Image);

            buttonPrev.Enabled = courseManager.CanMovePrev;
            buttonNext.Enabled = courseManager.CanMoveNext;
		}
    }
}

