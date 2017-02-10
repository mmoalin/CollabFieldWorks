using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.IO;
using Android.Content;
using Android.Provider;
using Android.Support.V4.Content;
using Android.Graphics;
using Xamarin.Forms;

namespace FieldWorksApp.Droid
{
    [Activity(Label = "FieldWorksApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public File newfile { get; private set; }
        public string mCurrentPhotoPath { get; private set; }
        public Intent intent { get; private set; }
        public App thisApp { get; private set; }
        public Image img { get; private set; }

        const int pictureRequestCode = 0;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            string timeStamp = DateTime.Now.Hour + "h" + DateTime.Now.Minute + "s" + DateTime.Now.Second;

            CreateImageFile(timeStamp);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            SetUpMediaButtons();

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok && requestCode == pictureRequestCode)
            {
                Bundle extras = data.Extras;
                Bitmap imageBitmap = (Bitmap)extras.Get("data");

                thisApp = (Xamarin.Forms.Application.Current as App);

                //imageBitmap = (Bitmap)extras.Get("data");
                //thisApp.mediacontroller.ShouldTakeVideo();
                //img = new Xamarin.Forms.Image();
                //img.Source = ImageSource.FromStream(() => imageStream(imageBitmap));
                System.Action action = new Action(displayStuff);
                Xamarin.Forms.Device.BeginInvokeOnMainThread(action);//Put into list of items, new picture shrinked & thumpnailed
                base.OnActivityResult(requestCode, resultCode, data);
            }
        }

        public void displayStuff()
        {
            img = new Image();
            img.Source = ImageSource.FromFile(newfile.AbsoluteFile.AbsolutePath);
            thisApp.mediacontroller.CreateMediaThumpnailItem(img, newfile.AbsolutePath);
            //Save file & add to thumpnails. 
        }
        private void SetUpMediaButtons()
        {
            (Xamarin.Forms.Application.Current as App).mediacontroller.ShouldTakePicture += () =>
            {
                intent = new Intent(MediaStore.ActionImageCapture);
                //Android.Net.Uri photoURI = FileProvider.GetUriForFile(this, "com.mydomain.fileprovider", newfile);
                intent.PutExtra(MediaStore.ExtraOutput, newfile);
                StartActivityForResult(intent, pictureRequestCode);
            };
            (Xamarin.Forms.Application.Current as App).mediacontroller.ShouldTakeVideo += () =>
            {
                Intent pickImageIntent = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.ExternalContentUri);
                if (pickImageIntent.ResolveActivity(PackageManager) != null)
                    StartActivityForResult(pickImageIntent, pictureRequestCode);
            };
            (Xamarin.Forms.Application.Current as App).mediacontroller.ShouldTakeAudio += () =>
            {
                Intent anotherIntent = new Intent(MediaStore.ActionImageCapture);
                if (anotherIntent.ResolveActivity(PackageManager) != null)
                {
                    StartActivityForResult(anotherIntent, pictureRequestCode);
                }
            };
        }

        private void CreateImageFile(string timeStamp)
        {
            newfile = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                                               Android.OS.Environment.DirectoryPictures), "cfw" + timeStamp + ".jpg");
            mCurrentPhotoPath = newfile.AbsolutePath;
            if (!newfile.Exists())
            {
                newfile.Mkdir();
                if (!newfile.Exists())
                    throw new Exception("FIle error!");
            }
            bool setWritable = false;

            setWritable = newfile.SetWritable(true, false);
        }
    }
}

