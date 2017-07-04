using System;
using UIKit;

namespace Courses.iOS
{
    public class CoursePagerViewControllerDataSource : UIPageViewControllerDataSource
	{
		CourseManager courseManager;

		public CoursePagerViewControllerDataSource(CourseManager courseManager)
		{
			this.courseManager = courseManager;
		}

        public CourseViewController GetFirstViewController() {
            courseManager.MoveFirst();

            return CreateCourseViewController();
        }

		private CourseViewController CreateCourseViewController()
		{
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
			CourseViewController courseViewController = (CourseViewController)storyboard.InstantiateViewController("CourseViewController");

			courseViewController.Course = courseManager.Current;
			courseViewController.CoursePosition = courseManager.CurrentPosition;

			return courseViewController;
		}

		public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			CourseViewController nextViewController = null;

			CourseViewController referenceCourseViewController = referenceViewController as CourseViewController;
			if (referenceCourseViewController != null)
			{
				courseManager.MoveTo(referenceCourseViewController.CoursePosition);
				if (courseManager.CanMoveNext)
				{
					courseManager.MoveNext();
					nextViewController = CreateCourseViewController();
				}
			}

			return nextViewController;
		}

		public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			CourseViewController previousViewController = null;

			CourseViewController referenceCourseViewController = referenceViewController as CourseViewController;
			if (referenceCourseViewController != null)
			{
				courseManager.MoveTo(referenceCourseViewController.CoursePosition);
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
