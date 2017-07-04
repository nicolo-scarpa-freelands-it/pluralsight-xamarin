using System;
using Foundation;
using UIKit;

namespace Courses.iOS
{
    public class CategoryTableViewSource : UITableViewSource
    {
        private const string CELL_ID = "CategoryCell";

        CourseCategoryManager courseCategoryManager;

        public CategoryTableViewSource(CourseCategoryManager courseCategoryManager)
        {
            this.courseCategoryManager = courseCategoryManager;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CELL_ID);
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CELL_ID);    
            }

            courseCategoryManager.MoveTo(indexPath.Row);
            cell.TextLabel.Text = courseCategoryManager.Current.Title;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return courseCategoryManager.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            courseCategoryManager.MoveTo(indexPath.Row);
            String categoryTitle = courseCategoryManager.Current.Title;
            CoursePagerViewController coursePagerViewController = new CoursePagerViewController(categoryTitle);

            RootNavigationController rootNavigationController = UIApplication.SharedApplication.Delegate.GetWindow().RootViewController as RootNavigationController;

            rootNavigationController.PushViewController(coursePagerViewController, true);
        }
    }
}
