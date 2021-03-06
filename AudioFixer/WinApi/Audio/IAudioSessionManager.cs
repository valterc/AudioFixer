﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioFixer.WinApi.Audio
{
    [Guid("BFA971F1-4D5E-40BB-935E-967039BFBEE4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAudioSessionManager
    {
        [PreserveSig]
        int GetAudioSessionControl([In, Optional] [MarshalAs(UnmanagedType.LPStruct)] Guid sessionId, [In] [MarshalAs(UnmanagedType.U4)] UInt32 streamFlags, [Out] [MarshalAs(UnmanagedType.Interface)] out IAudioSessionControl sessionControl);

        [PreserveSig]
        int GetSimpleAudioVolume([In, Optional] [MarshalAs(UnmanagedType.LPStruct)] Guid sessionId, [In] [MarshalAs(UnmanagedType.U4)] UInt32 streamFlags, [Out] [MarshalAs(UnmanagedType.Interface)] out ISimpleAudioVolume audioVolume);
    }
}
