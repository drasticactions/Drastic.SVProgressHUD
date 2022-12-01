using ObjCRuntime;

namespace Drastic.SVProgressHUD
{
    [Native]
    public enum SVProgressHUDStyle : long
    {
        Light,
        Dark,
        Custom
    }

    [Native]
    public enum SVProgressHUDMaskType : ulong
    {
        None = 1,
        Clear,
        Black,
        Gradient,
        Custom
    }

    [Native]
    public enum SVProgressHUDAnimationType : ulong
    {
        Flat,
        Native
    }
}
