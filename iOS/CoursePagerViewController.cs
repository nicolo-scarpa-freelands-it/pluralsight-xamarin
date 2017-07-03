using System;

using UIKit;

namespace Courses.iOS
{
    public partial class CoursePagerViewController : UIViewController
    {
        UIPageViewController pageViewController;
        CourseManager courseManager;

        public CoursePagerViewController(IntPtr handle) : base(handle)
        { 
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            pageViewController = new UIPageViewController(UIPageViewControllerTransitionStyle.PageCurl, UIPageViewControllerNavigationOrientation.Horizontal, UIPageViewControllerSpineLocation.Min);
            pageViewController.View.Frame = View.Bounds;

            this.View.AddSubview(pageViewController.View);

            courseManager = new CourseManager();
            courseManager.MoveFirst();

            CourseViewController firstCourseViewController = CreateCourseViewController();

            pageViewController.SetViewControllers(new UIViewController[] { firstCourseViewController }, UIPageViewControllerNavigationDirection.Forward, false, null);
            // Set delegates methods
            pageViewController.GetNextViewController = GetNextViewController;
            pageViewController.GetPreviousViewController = GetPreviousViewController;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        CourseViewController CreateCourseViewController() 
        {
            CourseViewController courseViewController = (CourseViewController)Storyboard.InstantiateViewController("CourseViewController");

            courseViewController.Course = courseManager.Current;
            courseViewController.CoursePosition = courseManager.CurrentPosition;

            return courseViewController;
        }

        // Delegates
        public UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController currentlyDisplayedViewController)
        {
            CourseViewController nextViewController = null;

            CourseViewController currentlyDisplayedCourseViewController = currentlyDisplayedViewController as CourseViewController;
            if (currentlyDisplayedCourseViewController != null) 
            {
                courseManager.MoveTo(currentlyDisplayedCourseViewController.CoursePosition);
                if (courseManager.CanMoveNext) 
                {
                    courseManager.MoveNext();
                    nextViewController = CreateCourseViewController();
                }
            }

            return nextViewController;
        }

        public UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController currentlyDisplayedViewController)
        {
            CourseViewController previousViewController = null;

			CourseViewController currentlyDisplayedCourseViewController = currentlyDisplayedViewController as CourseViewController;
			if (currentlyDisplayedCourseViewController != null)
			{
                courseManager.MoveTo(currentlyDisplayedCourseViewController.CoursePosition);
                if (courseManager.CanMovePrev)
				{
                    courseManager.MovePrev();
                    previousViewController = CreateCourseViewController();
				}
			}

			return previousViewController;
        }
    }
}

