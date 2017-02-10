using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FieldWorksApp
{
    public partial class Preview : ContentPage
    {
        Button btn = new Button()
        {
            Text = "Edit"
        };
        Button btnn = new Button()
        {
            Text = "Edit"
        };
        Button btn2 = new Button()
        {
            Text = "Delete"
        };
        StackLayout editDeleteButtons = new StackLayout()
        {
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.End
        };
        public Image myImage = new Image()
        {
            Aspect = Aspect.AspectFill,
            Source = "sketch.png"
        };

        RelativeLayout layout;
        public Preview()
        {
            InitializeComponent();
            editDeleteButtons.Children.Add(btn);
            editDeleteButtons.Children.Add(btn2);
            layout = new RelativeLayout();
            layout.Children.Add(myImage,
            Constraint.Constant(0),
            Constraint.Constant(0),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; }));

            layout.Children.Add(editDeleteButtons,
                Constraint.Constant(1),
                Constraint.Constant(1),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            Content = layout;
        }
        public void PopulateContent(Image image, string temp)
        {
            editDeleteButtons.Children.Add(btn);
            editDeleteButtons.Children.Add(btn2);
            var myimg = image;
            myimg.Source = temp;
            layout = new RelativeLayout();
            layout.Children.Add(myimg,
            Constraint.Constant(0),
            Constraint.Constant(0),
            Constraint.RelativeToParent((parent) => { return parent.Width; }),
            Constraint.RelativeToParent((parent) => { return parent.Height; }));
            layout.Children.Add(editDeleteButtons,
                Constraint.Constant(1),
                Constraint.Constant(1),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            Content = layout;
        }
    }
}
