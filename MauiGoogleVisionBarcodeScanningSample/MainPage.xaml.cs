using BarcodeScanner.Mobile;

namespace MauiGoogleVisionBarcodeScanningSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode | BarcodeScanner.Mobile.BarcodeFormats.Code39);

            InitializeComponent();

            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        }

        private void Camera_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
        {
            List<BarcodeResult> obj = e.BarcodeResults;

            string result = string.Empty;
            for (int i = 0; i < obj.Count; i++)
            {
                result += $"Type : {obj[i].BarcodeType}, Value : {obj[i].DisplayValue}{Environment.NewLine}";
            }

            Dispatcher.Dispatch(async () =>
            {
                await DisplayAlert("Result", result, "OK");
                // If you want to start scanning again
                Camera.IsScanning = true;
            });
        }
    }
}