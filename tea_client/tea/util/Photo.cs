using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using System.Runtime.InteropServices.WindowsRuntime;
using System.IO;

namespace tea.util
{
    class Photo
    {
        public static async Task<SoftwareBitmap> CaptureAsync()
        {
            // Shoot photo.
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null)
            {
                // User cancelled photo capture
                return null;
            }

            //// Move photo to a folder.
            //StorageFolder destinationFolder =
            //await ApplicationData.Current.LocalFolder.CreateFolderAsync("ProfilePhotoFolder",
            //    CreationCollisionOption.OpenIfExists);

            //await photo.CopyAsync(destinationFolder, "ProfilePhoto.jpg", NameCollisionOption.ReplaceExisting);
            //await photo.DeleteAsync();

            // Convert to SoftwareBitmap for later use.
            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

            //// Use the image.
            //SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
            //    BitmapPixelFormat.Bgra8,
            //    BitmapAlphaMode.Premultiplied);

            //SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            //await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

            return softwareBitmap;

            // <Image x:Name="imageControl" Width="200" Height="200"/>
            // imageControl.Source = bitmapSource;
        }

        public static async Task<ImageSource> FromBase64(string base64)
        {
            // read stream
            var bytes = Convert.FromBase64String(base64);
            var image = bytes.AsBuffer().AsStream().AsRandomAccessStream();

            // decode image
            var decoder = await BitmapDecoder.CreateAsync(image);
            image.Seek(0);

            // create bitmap
            var output = new WriteableBitmap((int)decoder.PixelHeight, (int)decoder.PixelWidth);
            await output.SetSourceAsync(image);
            return output;
        }

        public static async Task<string> ToBase64(SoftwareBitmap soft, Guid encoderId)
        {
            byte[] array = null;

            // First: Use an encoder to copy from SoftwareBitmap to an in-mem stream (FlushAsync)
            // Next:  Use ReadAsync on the in-mem stream to get byte[] array

            using (var ms = new InMemoryRandomAccessStream())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, ms);
                encoder.SetSoftwareBitmap(soft);

                try
                {
                    await encoder.FlushAsync();
                }
                catch (Exception ex)
                {
                    return "";
                }

                array = new byte[ms.Size];
                await ms.ReadAsync(array.AsBuffer(), (uint)ms.Size, InputStreamOptions.None);
            }

            string base64String = Convert.ToBase64String(array);
            return base64String;
        }
    }
}
