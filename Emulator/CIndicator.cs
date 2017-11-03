// Decompiled with JetBrains decompiler
// Type: Emulator.CIndicator
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

using System.Text;

namespace Emulator
{
  public class CIndicator
  {
    public int digit0;
    public int digit1;
    public int digit2;
    public int digit3;

    public CIndicator()
    {
      this.reset();
    }

    public void reset()
    {
      this.digit0 = 0;
      this.digit1 = 0;
      this.digit2 = 0;
      this.digit3 = 0;
    }

    public void copyIndicator(CIndicator from)
    {
      this.digit0 = from.digit0;
      this.digit1 = from.digit1;
      this.digit2 = from.digit2;
      this.digit3 = from.digit3;
    }

    public void addTwoDigits(int signDigit, int lowDigit)
    {
      this.digit0 = this.digit2;
      this.digit1 = this.digit3;
      this.digit2 = signDigit;
      this.digit3 = lowDigit;
    }

    public void addDigit(int digit)
    {
      this.digit0 = this.digit1;
      this.digit1 = this.digit2;
      this.digit2 = this.digit3;
      this.digit3 = digit;
    }

    public void incrementAddress()
    {
      if (this.digit3 < 15)
      {
        ++this.digit3;
      }
      else
      {
        this.digit3 = 0;
        if (this.digit2 < 15)
        {
          ++this.digit2;
        }
        else
        {
          this.digit2 = 0;
          if (this.digit1 < 15)
          {
            ++this.digit1;
          }
          else
          {
            this.digit1 = 0;
            if (this.digit0 < 15)
              ++this.digit0;
            else
              this.digit0 = 0;
          }
        }
      }
    }

    public void decrementAddress()
    {
      if (this.digit3 > 0)
      {
        --this.digit3;
      }
      else
      {
        this.digit3 = 15;
        if (this.digit2 > 0)
        {
          --this.digit2;
        }
        else
        {
          this.digit2 = 15;
          if (this.digit1 > 0)
          {
            --this.digit1;
          }
          else
          {
            this.digit1 = 15;
            if (this.digit0 > 0)
              --this.digit0;
            else
              this.digit0 = 15;
          }
        }
      }
    }

    public void getValue(ref int signifDigit, ref int loverDigit)
    {
      signifDigit = this.digit2;
      loverDigit = this.digit3;
    }

    public string getHexString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      char ch1 = this.digit0 < 10 ? (char) (48 + this.digit0) : (char) (65 + this.digit0 - 10);
      stringBuilder.Append(ch1);
      char ch2 = this.digit1 < 10 ? (char) (48 + this.digit1) : (char) (65 + this.digit1 - 10);
      stringBuilder.Append(ch2);
      char ch3 = this.digit2 < 10 ? (char) (48 + this.digit2) : (char) (65 + this.digit2 - 10);
      stringBuilder.Append(ch3);
      char ch4 = this.digit3 < 10 ? (char) (48 + this.digit3) : (char) (65 + this.digit3 - 10);
      stringBuilder.Append(ch4);
      return stringBuilder.ToString();
    }
  }
}
