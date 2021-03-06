﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioFixer.WinApi.Audio
{
    [Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISimpleAudioVolume
    {
        [PreserveSig]
        int SetMasterVolume([In] [MarshalAs(UnmanagedType.R4)] float levelNorm, [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        [PreserveSig]
        int GetMasterVolume([Out] [MarshalAs(UnmanagedType.R4)] out float levelNorm);

        [PreserveSig]
        int SetMute([In] [MarshalAs(UnmanagedType.Bool)] bool isMuted, [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        [PreserveSig]
        int GetMute([Out] [MarshalAs(UnmanagedType.Bool)] out bool isMuted);
    }
}
