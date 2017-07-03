using System;

using UIKit;

namespace Courses.iOS
{
    public partial class CourseViewController : UIViewController
    {
        public Course Course { get; set; }
        public int CoursePosition { get; set; } // TODO: this doesn't convince me here (maybe put it in the pager view controller?)

        public CourseViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            UpdateUI();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void UpdateUI()
        {
            labelTitle.Text = Course.Title;
            textDescription.Text = Course.Description;
            imageCourse.Image = UIImage.FromBundle(Course.Image);
        }
    }
}

