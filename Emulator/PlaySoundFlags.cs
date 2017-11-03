// Decompiled with JetBrains decompiler
// Type: Emulator.PlaySoundFlags
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

namespace Emulator
{
  public enum PlaySoundFlags
  {
    SND_SYNC = 0,
    SND_ASYNC = 1,
    SND_NODEFAULT = 2,
    SND_MEMORY = 4,
    SND_LOOP = 8,
    SND_NOSTOP = 16,
    SND_NOWAIT = 8192,
    SND_ALIAS = 65536,
    SND_FILENAME = 131072,
    SND_RESOURCE = 262148,
    SND_ALIAS_ID = 1114112,
  }
}
