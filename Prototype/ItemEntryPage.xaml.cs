using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.Models;
using Xamarin.Essentials;
using System.IO;
using Prototype;


namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemEntryPage : ContentPage
    {
        public ItemEntryPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;

            // adding of image
            if (item.ImageFile != null && item.ImageFile.Id == 0)
            {
                //ImageFile object is not null and id is 0 which means it's a new image, so we need to add it
                var image = await App.DataService.InsertAsync(item.ImageFile);
                if (image is null) throw new NullReferenceException (nameof(image));
                
                // we nullify the ImageFile object and only keep the inserted Image's Id
                // as otherwise the ImageFile child object gets serialised and sent with
                // the Movie object resuling in a much larger than necessary payload to the server
                item.ImageFile = null;
                item.ImageFileId = image.Id;
            }

            if (item.Id == 0) await App.DataService.InsertAsync(item);
            
            else await App.DataService.UpdateAsync(item, item.Id); await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            await App.DataService.DeleteAsync(new Image(), item.ImageFileId);
            await App.DataService.DeleteAsync(item, item.Id);
            await Navigation.PopAsync();
        }
        async void OnTakePictureButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);

                Console.WriteLine($"CapturePhotoAsync COMPLETED");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync: {ex.Message}");
            }
        }
        async void OnChoosePictureButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"PickPhotoAsync COMPLETED:");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PickPhotoAsync THREW: {ex.Message}");
            }
        }
        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo is null) return;
            
            var item = (Item)BindingContext;
            using (var ms = new MemoryStream())
            {
                using (var inputStream = await photo.OpenReadAsync())
                {
                    await inputStream.CopyToAsync(ms);
                    var image = new ImageFile()
                    {
                        Data = ms.ToArray(),
                        ContentType = photo.ContentType,
                        Name = photo.FileName
                    };
                    if (image is null) throw new NullReferenceException(nameof(image)); item.ImageFile = image;
                }
            }

        }
        async void OnScanClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null) item.ProductReference = result.Text;
            
        }

        async void OnReviewClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            ReviewEntryPage x = new ReviewEntryPage();
            x.User = new User() { Id = 3 };
            await Navigation.PushAsync(new ReviewEntryPage() { User = x.User, productID = item.Id });
        }
    }
}