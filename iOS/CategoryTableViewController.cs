using System;

using UIKit;

namespace Courses.iOS
{
    public partial class CategoryTableViewController : UITableViewController
    {
        public CategoryTableViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Categories";

            CourseCategoryManager courseCategoryManager = new CourseCategoryManager();
            TableView.Source = new CategoryTableViewSource(courseCategoryManager);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

