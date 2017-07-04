using System;

using UIKit;

namespace Courses.iOS
{
    public partial class CoursePagerViewController : UIViewController
    {
        UIPageViewController pageViewController;
        CoursePagerViewControllerDataSource pageViewControllerDataSource;

        public CoursePagerViewController(String categoryTitle)
        {
            CourseManager courseManager = new CourseManager(categoryTitle);
			pageViewControllerDataSource = new CoursePagerViewControllerDataSource(courseManager);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            pageViewController = new UIPageViewController(UIPageViewControllerTransitionStyle.PageCurl, UIPageViewControllerNavigationOrientation.Horizontal, UIPageViewControllerSpineLocation.Min);
            pageViewController.View.Frame = View.Bounds;

            this.View.AddSubview(pageViewController.View);

            CourseViewController firstCourseViewController = pageViewControllerDataSource.GetFirstViewController();
            pageViewController.SetViewControllers(new UIViewController[] { firstCourseViewController }, UIPageViewControllerNavigationDirection.Forward, false, null);
            // Assign the delegate instance of CoursePagerViewControllerDataSource which extends UIPageViewControllerDataSource abstract class
            // Objective-C protocols are implemented in C# as Abstract Classes
			pageViewController.DataSource = pageViewControllerDataSource;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

