using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioFixer.WinApi.Audio
{
    [Guid("F4B1A599-7266-4319-A8CA-E70ACB11E8CD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAudioSessionControl
    {
        [PreserveSig]
        int GetDisplayName([Out] [MarshalAs(UnmanagedType.LPWStr)] out string displayName);

        [PreserveSig]
        int SetDisplayName([In] [MarshalAs(UnmanagedType.LPWStr)] string displayName, [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        [PreserveSig]
        int GetIconPath([Out] [MarshalAs(UnmanagedType.LPWStr)] out string iconPath);

        [PreserveSig]
        int SetIconPath([In] [MarshalAs(UnmanagedType.LPWStr)] string iconPath, [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        [PreserveSig]
        int GetGroupingParam([Out] out Guid groupingId);

        [PreserveSig]
        int SetGroupingParam([In] [MarshalAs(UnmanagedType.LPStruct)] Guid groupingId, [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

    }

}
