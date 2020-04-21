using Microsoft.Win32;

namespace Alpaca_Telescope_DotNetStandard
{
    public static class ResponseTypes
    {
        // Enum to describe Camera.ImageArray and ImageArrayVCariant array types
        public enum ImageArrayElementTypes
        {
            Unknown = 0,
            Short = 1,
            Int = 2,
            Double = 3
        }
    }
}
