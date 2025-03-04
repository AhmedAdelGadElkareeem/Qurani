
namespace WytSky.Mobile.Maui.Skoola.Services
{
    public interface ICopmressImage
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
    }
}
