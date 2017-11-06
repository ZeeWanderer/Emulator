// Decompiled with JetBrains decompiler
// Type: Emulator.CLabWorks
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

using System.Runtime.InteropServices;
using System.Threading;
using System.Media;
using System.IO;
using System.Reflection;

namespace Emulator
{
  public static class CLabWorks
  {
        public static Assembly _assembly;
        public static Stream _audioStreamReader;
        public static SoundPlayer SPPlayer;
    [DllImport("Kernel32.dll")]
    private static extern bool Beep(uint frequency, uint duration);

        public static void Init()
        {
            //_assembly = Assembly.GetExecutingAssembly();
            //_audioStreamReader = _assembly.GetManifestResourceStream("Emulator.KONGOSHeyIDontKnow.wav");
            //SPPlayer = new SoundPlayer(_audioStreamReader);
        }

        public static void Lab1_StartSound()
    {
            CLabWorks.Beep(1000U, 300U);
            Thread.Sleep(100);
            CLabWorks.Beep(500U, 300U);
            Thread.Sleep(100);
            CLabWorks.Beep(3000U, 300U);
            Thread.Sleep(100);
            CLabWorks.Beep(3100U, 400U);
            Thread.Sleep(100);
            CLabWorks.Beep(3000U, 300U);
            Thread.Sleep(100);
            CLabWorks.Beep(3100U, 400U);
            Thread.Sleep(100);
            CLabWorks.Beep(1000U, 200U);
            Thread.Sleep(100);
            CLabWorks.Beep(500U, 200U);
            Thread.Sleep(100);



            //SPPlayer.Play();
        }
    }
}
