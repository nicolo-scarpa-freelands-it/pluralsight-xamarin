using System;

using UIKit;

namespace Courses.iOS
{
    public partial class CourseViewController : UIViewController
    {
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
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void ButtonPrev_TouchUpInside(object sender, EventArgs e)
        {
            imageCourse.Image = UIImage.FromBundle("ps_top_card_01");
            labelTitle.Text = "Prev clicked";
            textDescription.Text = "This is the description that displays when Prev is clicked";
        }

        void ButtonNext_TouchUpInside(object sender, EventArgs e)
        {
            imageCourse.Image = UIImage.FromBundle("ps_top_card_02");
            labelTitle.Text = "Next clicked";
            textDescription.Text = "This is the description that displays when Next is clicked";
        }
    }
}

