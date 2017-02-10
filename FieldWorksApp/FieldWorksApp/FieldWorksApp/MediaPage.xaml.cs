using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FieldWorksApp
{
    public class MediaController
    {
        readonly Image image = new Image();
        //= //() => { };
        public Button pictureButton;//
        public StackLayout loadedContent;
        public static MediaController instance;
        StackLayout thumpNailsList;
        public MediaPage MediaPage { get; internal set; }
        public ScrollView scrl { get; private set; }
        public Action ShouldTakePicture, ShouldTakeVideo, ShouldTakeAudio;
        public static void CreateInstance()
        {
            if (instance == null)
            {
                instance = new MediaController();
            }
        }

        internal StackLayout GetContent()
        {
            Dev();
            Label header = new Label
            {
                Text = "Media",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            var buttons = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal
            };
            //buttons.Children.Add(pictureButton);
            buttons.Children.Add(new Button
            {
                Text = "Pics",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Command = new Command(ShouldTakePicture)
            });
            buttons.Children.Add(new Button
            {
                Text = "Video",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Command = new Command(ShouldTakeVideo)
            });
            buttons.Children.Add(new Button
            {
                Text = "Audio",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Command = new Command(ShouldTakeAudio)
            });
            loadedContent = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    header,
                    buttons,
                }
            };

            for (int i = 0; i < 5; i++)
            {
                thumpNailsList.Children.Add(CreateMediaThumpnailItem());//First save image, then get a thumpnail + name representation 
            }
            scrl = new ScrollView
            {
                IsClippedToBounds = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = thumpNailsList
            };
            loadedContent.Children.Add(scrl);
            return loadedContent;
        }

        private void Dev()
        {
            thumpNailsList = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            ShouldTakeAudio += () => { };
            ShouldTakeVideo += () =>
            {
                thumpNailsList.Children.Add(CreateMediaThumpnailItem());
            };
        }

        public void CreateMediaThumpnailItem(Image img, string f)
        {
            var name = new Label
            {
                Text = "<Stub Media Item>",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            var btn = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.End,
            };
            var content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Spacing = 15,
                //VerticalOptions = LayoutOptions.FillAndExpand,
            };
            content.Children.Add(img);
            content.Children.Add(name);
            content.Children.Add(btn);
            var newBaby = new Frame()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //OutlineColorColor = Color.Accent,
                Padding = new Thickness(5),
                Content = content,
            };
            var tabGestureRecognizer = new TapGestureRecognizer();
            //tabGestureRecognizer.Tapped += (sender, e) => PreviewPageLoadUp(sender, e, img.Source.ToString(), img, f);

            newBaby.GestureRecognizers.Add(tabGestureRecognizer);
            thumpNailsList.Children.Add(newBaby);
            scrl.Content = thumpNailsList;
        }

        public void ShowImage(string filepath)
        {
            image.Source = ImageSource.FromFile(filepath);
        }

        public View CreateMediaThumpnailItem()
        {
            var placeHolder = new BoxView
            {
                Color = Xamarin.Forms.Color.Gray,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            var name = new Label
            {
                Text = "<Stub Media Item>",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            var btn = new Button
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.End,
            };
            var content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Spacing = 15,
                //VerticalOptions = LayoutOptions.FillAndExpand,
            };
            content.Children.Add(placeHolder);
            content.Children.Add(name);
            content.Children.Add(btn);
            var x = new Frame
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //OutlineColorColor = Color.Accent,
                Padding = new Thickness(5),
                Content = content,

            };
            var tabGestureRecognizer = new TapGestureRecognizer();
            //tabGestureRecognizer.Tapped += PreviewPageLoadUp;
            //x.GestureRecognizers.Add(tabGestureRecognizer);
            return x;
        }
        /*private async void PreviewPageLoadUp(object sender, EventArgs e)
        {
            var prevPage = new Preview();
            await MediaPage.Navigation.PushModalAsync(prevPage);
        }
        private async void PreviewPageLoadUp(object sender, EventArgs e, string src, Image img, string t)
        {
            var prevPage = new Preview();
            prevPage.PopulateContent(img, t);
            await MediaPage.Navigation.PushModalAsync(prevPage);
        }*/


    }

    public partial class MediaPage : ContentPage
    {
        public MediaPage()
        {
            Button AddMediaButton = new Button();
            AddMediaButton.HorizontalOptions = LayoutOptions.End;
            AddMediaButton.Text = "Add New Media";
            StackLayout layout = new StackLayout();
            layout.Children.Add(AddMediaButton);
            InitializeComponent();
        }
    }
}
