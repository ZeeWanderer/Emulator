// Decompiled with JetBrains decompiler
// Type: Emulator.CMemory
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

using System;
using System.Text;

namespace Emulator
{
  public class CMemory
  {
    private static int MEM_SIZE = 0;
    public static int USER_MEM_ST = 0;
    public static int USER_MEM_END = 0;
    private const string regA = "83EB";
    private const string regF = "83EA";
    private const string regB = "83E9";
    private const string regC = "83E8";
    private const string regD = "83E7";
    private const string regE = "83E6";
    private const string regH = "83E5";
    private const string regL = "83E4";
    private const int RANDOM_SEED = 54321;
    public FlagReg flagReg;
    private Random random;
    private Cell[] memory;
    public CPPI PPI;
        public int CDigitValue =0 ;

    public CMemory(ref CPPI _PPI)
    {
      this.PPI = _PPI;
      this.flagReg.S = false;
      this.flagReg.Z = false;
      this.flagReg.AC = false;
      this.flagReg.P = false;
      this.flagReg.C = false;
      CMemory.MEM_SIZE = CMemory.HexToInt("FFFF") + 1;
      CMemory.USER_MEM_ST = CMemory.HexToInt("8000");
      CMemory.USER_MEM_END = CMemory.HexToInt("83C6");
      this.memory = new Cell[CMemory.MEM_SIZE];
      this.random = new Random(54321);
      this.randomiseMemory();
    }

    private void randomiseMemory()
    {
      for (int index = 0; index < CMemory.MEM_SIZE; ++index)
      {
        this.memory[index].signifBit = (byte) this.random.Next(15);
        this.memory[index].lowerBit = (byte) this.random.Next(15);
      }
    }

    public bool isClientRegion(string hex)
    {
      int num = CMemory.HexToInt(hex);
      return num >= CMemory.USER_MEM_ST && num <= CMemory.USER_MEM_END || num >= CMemory.HexToInt("83E4") && num <= CMemory.HexToInt("83EB");
    }

    public void getMemoryValue(string memPos, ref int signifDigit, ref int loverDigit)
    {
      int index = CMemory.HexToInt(memPos);
      if (index == 250)
      {
        int aword = this.PPI.getAword();
        signifDigit = aword >> 4;
        loverDigit = aword & 15;
        this.PPI.setAword((int) byte.MaxValue);
      }
      else
      {
        signifDigit = (int) this.memory[index].signifBit;
        loverDigit = (int) this.memory[index].lowerBit;
      }
    }

    public void setMemoryValue(string memPos, int signifDigit, int loverDigit)
    {
      int index1 = CMemory.HexToInt(memPos);
      this.memory[index1].signifBit = (byte) signifDigit;
      this.memory[index1].lowerBit = (byte) loverDigit;
      int val = signifDigit << 4 | loverDigit;
      if (index1 == 251)
      {
        string bit = CMemory.IntToBit((long) val);
        for (int index2 = 0; index2 < 8; ++index2)
          this.PPI.setLamp(7 - index2, index2 < bit.Length && (int) bit[bit.Length - index2 - 1] == 49);
      }
      if (index1 != 252)
        return;
      this.PPI.setCword(val);
    }

    public void getMemoryValue(int memPos, ref int signifDigit, ref int loverDigit)
    {
      int index = memPos;
      if (index == 250)
      {
        int aword = this.PPI.getAword();
        signifDigit = aword >> 4;
        loverDigit = aword & 15;
        this.PPI.setAword((int) byte.MaxValue);
      }
      else
      {
        signifDigit = (int) this.memory[index].signifBit;
        loverDigit = (int) this.memory[index].lowerBit;
      }
    }

    public void setMemoryValue(int memPos, int signifDigit, int loverDigit)
    {
      int index1 = memPos;
      this.memory[index1].signifBit = (byte) signifDigit;
      this.memory[index1].lowerBit = (byte) loverDigit;
      int val = signifDigit << 4 | loverDigit;
      if (index1 == 251)
      {
                CDigitValue = val;
                string bit = CMemory.IntToBit((long) val);
        for (int index2 = 0; index2 < 8; ++index2)
          this.PPI.setLamp(7 - index2, index2 < bit.Length && (int) bit[bit.Length - index2 - 1] == 49);
      }
      if (index1 != 252)
        return;
      this.PPI.setCword(val);
    }

    public void randomiseRegisters()
    {
      for (int index = CMemory.HexToInt("83E4"); index <= CMemory.HexToInt("83EB"); ++index)
      {
        this.memory[index].signifBit = (byte) this.random.Next(15);
        this.memory[index].lowerBit = (byte) this.random.Next(15);
      }
    }

    public void setRegister(int regNum, int val)
    {
      int sigDigit = val >> 4;
      int lowDigit = val & 15;
      this.changeRegEntry(regNum, sigDigit, lowDigit);
    }

    public int getRegister(int regNum)
    {
      int sigDigit = 0;
      int lowDigit = 0;
      this.getRegEntry(regNum, ref sigDigit, ref lowDigit);
      return sigDigit << 4 | lowDigit;
    }

    public void getRegEntry(int regEntr, ref int sigDigit, ref int lowDigit)
    {
      string strHex = "";
      switch (regEntr)
      {
        case 0:
          strHex = "83E9";
          break;
        case 1:
          strHex = "83E8";
          break;
        case 2:
          strHex = "83E7";
          break;
        case 3:
          strHex = "83E6";
          break;
        case 4:
          strHex = "83E5";
          break;
        case 5:
          strHex = "83E4";
          break;
        case 6:
          strHex = this.getRegPair("83E5", "83E4");
          break;
        case 7:
          strHex = "83EB";
          break;
        case 8:
          strHex = "83EA";
          break;
      }
      int index = CMemory.HexToInt(strHex);
      sigDigit = (int) this.memory[index].signifBit;
      lowDigit = (int) this.memory[index].lowerBit;
    }

    public string getRegPair(string signReg, string lowReg)
    {
      int sigDigit1 = 0;
      int lowDigit1 = 0;
      int sigDigit2 = 0;
      int lowDigit2 = 0;
      this.getRegEntry(signReg, ref sigDigit1, ref lowDigit1);
      this.getRegEntry(lowReg, ref sigDigit2, ref lowDigit2);
      StringBuilder stringBuilder = new StringBuilder();
      char ch1 = sigDigit1 < 10 ? (char) (48 + sigDigit1) : (char) (65 + sigDigit1 - 10);
      stringBuilder.Append(ch1);
      char ch2 = lowDigit1 < 10 ? (char) (48 + lowDigit1) : (char) (65 + lowDigit1 - 10);
      stringBuilder.Append(ch2);
      char ch3 = sigDigit2 < 10 ? (char) (48 + sigDigit2) : (char) (65 + sigDigit2 - 10);
      stringBuilder.Append(ch3);
      char ch4 = lowDigit2 < 10 ? (char) (48 + lowDigit2) : (char) (65 + lowDigit2 - 10);
      stringBuilder.Append(ch4);
      return stringBuilder.ToString();
    }

    public void getRegEntry(string regEntr, ref int sigDigit, ref int lowDigit)
    {
      regEntr.ToUpper();
      string strHex;
      switch (regEntr)
      {
        case "A":
          strHex = "83EB";
          break;
        case "F":
          strHex = "83EA";
          break;
        case "B":
          strHex = "83E9";
          break;
        case "C":
          strHex = "83E8";
          break;
        case "D":
          strHex = "83E7";
          break;
        case "E":
          strHex = "83E6";
          break;
        case "H":
          strHex = "83E5";
          break;
        case "L":
          strHex = "83E4";
          break;
        default:
          strHex = regEntr;
          break;
      }
      int index = CMemory.HexToInt(strHex);
      sigDigit = (int) this.memory[index].signifBit;
      lowDigit = (int) this.memory[index].lowerBit;
    }

    public void changeRegEntry(int regEntr, int sigDigit, int lowDigit)
    {
      string strHex = "";
      switch (regEntr)
      {
        case 0:
          strHex = "83E9";
          break;
        case 1:
          strHex = "83E8";
          break;
        case 2:
          strHex = "83E7";
          break;
        case 3:
          strHex = "83E6";
          break;
        case 4:
          strHex = "83E5";
          break;
        case 5:
          strHex = "83E4";
          break;
        case 6:
          strHex = this.getRegPair("83E5", "83E4");
          break;
        case 7:
          strHex = "83EB";
          break;
        case 8:
          strHex = "83EA";
          break;
      }
      int index = CMemory.HexToInt(strHex);
      this.memory[index].signifBit = (byte) sigDigit;
      this.memory[index].lowerBit = (byte) lowDigit;
    }

    public void changeRegEntry(string regEntr, int sigDigit, int lowDigit)
    {
      regEntr.ToUpper();
      string strHex = "";
      switch (regEntr)
      {
        case "A":
          strHex = "83EB";
          break;
        case "F":
          strHex = "83EA";
          break;
        case "B":
          strHex = "83E9";
          break;
        case "C":
          strHex = "83E8";
          break;
        case "D":
          strHex = "83E7";
          break;
        case "E":
          strHex = "83E6";
          break;
        case "H":
          strHex = "83E5";
          break;
        case "L":
          strHex = "83E4";
          break;
      }
      int index = CMemory.HexToInt(strHex);
      this.memory[index].signifBit = (byte) sigDigit;
      this.memory[index].lowerBit = (byte) lowDigit;
    }

    public static int HexToInt(string strHex)
    {
      return Convert.ToInt32(strHex, 16);
    }

    public static string IntToHex(long number)
    {
      int num1 = 16;
      StringBuilder stringBuilder = new StringBuilder();
      while (number > 0L)
      {
        long num2 = number % (long) num1;
        if (num2 > 9L)
          stringBuilder.Insert(0, (char) (65UL + (ulong) (num2 - 10L)));
        else
          stringBuilder.Insert(0, number % (long) num1);
        number /= (long) num1;
      }
      return stringBuilder.ToString();
    }

    public static string IntToBit(long number)
    {
      int num1 = 2;
      StringBuilder stringBuilder = new StringBuilder();
      while (number > 0L)
      {
        long num2 = number % (long) num1;
        if (num2 > 9L)
          stringBuilder.Insert(0, (char) (65UL + (ulong) (num2 - 10L)));
        else
          stringBuilder.Insert(0, number % (long) num1);
        number /= (long) num1;
      }
      return stringBuilder.ToString();
    }
  }
}
