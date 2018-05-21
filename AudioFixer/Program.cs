using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using AudioFixer.WinApi;
using AudioFixer.WinApi.Audio;

namespace AudioFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayResourceAudioFileLooping();
            MuteApplication();

            try
            {
                Thread.Sleep(100);
                Process.GetCurrentProcess().Suspend();
            }
            catch (Exception)
            {
                // ignore
            }

            while (true)
            {
                Thread.Sleep(-1);
            }
        }

        private static void PlayResourceAudioFileLooping()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = typeof(Program).Namespace + ".Resources.noise_low_volume.wav";

            Stream stream = assembly.GetManifestResourceStream(resourceName);

            SoundPlayer player = new SoundPlayer
            {
                Stream = stream
            };
            player.PlayLooping();
        }

        private static void MuteApplication()
        {
            IMMDeviceEnumerator deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
            deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia, out IMMDevice device);

            Guid guid = typeof(IAudioSessionManager).GUID;
            device.Activate(ref guid, 0, IntPtr.Zero, out Object interfacePointer);

            IAudioSessionManager audioSessionManager = (IAudioSessionManager)interfacePointer;
            audioSessionManager.GetSimpleAudioVolume(Guid.Empty, 0, out ISimpleAudioVolume simpleAudioVolume);
            Marshal.ThrowExceptionForHR(simpleAudioVolume.SetMute(true, Guid.Empty));

            audioSessionManager.GetAudioSessionControl(Guid.Empty, 0, out IAudioSessionControl audioSessionControl);
            Marshal.ThrowExceptionForHR(audioSessionControl.SetDisplayName("Audio Fixer", Guid.Empty));

            Marshal.ReleaseComObject(audioSessionControl);
            Marshal.ReleaseComObject(simpleAudioVolume);
            Marshal.ReleaseComObject(audioSessionManager);
            Marshal.ReleaseComObject(device);
            Marshal.ReleaseComObject(deviceEnumerator);
        }
    }

}
