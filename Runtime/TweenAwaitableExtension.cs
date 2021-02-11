
namespace SAS.TweenManagment
{
    public static class TweenAwaitableExtension
    {
        public static TweenAwaiter GetAwaiter(this ITween itween)
        {
            return new TweenAwaiter(itween);
        }
    }
}
