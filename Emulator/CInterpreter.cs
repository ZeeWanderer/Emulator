// Decompiled with JetBrains decompiler
// Type: Emulator.CInterpreter
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Emulator
{
    public class CInterpreter
    {
        public ProgramLogic PLRoutine;
        public const int REG_B = 0;
        public const int REG_C = 1;
        public const int REG_D = 2;
        public const int REG_E = 3;
        public const int REG_H = 4;
        public const int REG_L = 5;
        public const int REG_M = 6;
        public const int REG_A = 7;
        private const int REGP_BC = 0;
        private const int REGP_DE = 1;
        private const int REGP_HL = 2;
        private const int REGP_SP = 3;
        private CMemory memory;
        private int curAddr;
        public bool bProgExecuted;
        public bool bMainAllertActive=true;

        public class callStackElement
        {
            public FlagReg FlagReg;
            public UInt16 []REG =new UInt16[8];
            public Int32 iRetAddres;
        }
        public Stack<callStackElement> ScallStack = new Stack<callStackElement>();

        public callStackElement cSEElement; 
        public CInterpreter(ref CMemory _memory)
        {
            this.memory = _memory;
            this.bProgExecuted = false;
        }

        public void updateFlags(int val)
        {
            this.memory.flagReg.Z = val % 256 == 0;
            if (val < 0 || val > (int)byte.MaxValue)
                this.memory.flagReg.C = true;
            else
                this.memory.flagReg.C = false;
            //if (val > 0x7F /*&& val <= 0xFF*/)
            //     this.memory.flagReg.S = true; //check if this flag is set when C = true 
            //if (/*val > 0 &&*/val !=0 && val <= 0x7F)
            //     this.memory.flagReg.S = false;
            //if (val < 0 || val > 0x7F && val <= 0xFF || val > 0x17F)//0x17E?
            //    this.memory.flagReg.S = true; //check if this flag is set when C = true 
            //if ((val > 0 && val <= 0x7F)|| val > 0xFF && val <=0x17F)//0x17E?
            //    this.memory.flagReg.S = false;
            if ((val & 128) == 128)//0x17E?
                this.memory.flagReg.S = true; //check if this flag is set when C = true 
           else
                this.memory.flagReg.S = false;
        }

    public void setRegister(int regNum, int val, bool bSetFlags = true)
    {
      if (bSetFlags)
       this.updateFlags(val);
      this.memory.setRegister(regNum, (val + 256) % 256);
    }

    public int getRegister(int regNum)
    {
      return this.memory.getRegister(regNum);
    }

    public void setRegPair(int regPaigNum, int sign, int low, bool bSetFlags = true)
    {
      this.setRegister(regPaigNum * 2, sign, bSetFlags);
      this.setRegister(regPaigNum * 2 + 1, low, bSetFlags);
    }

    public void setRegPair(int regPaigNum, int val, bool bSetFlags = true)
    {
      this.setRegPair(regPaigNum, val >> 4, val & 15, bSetFlags);
    }

    public int getRegPair(int regPaigNum)
    {
      return this.getRegister(regPaigNum) << 8 | this.getRegister(regPaigNum + 1);
    }

    public int getMemory(int addr)
    {
      int signifDigit = 0;
      int loverDigit = 0;
      this.memory.getMemoryValue(addr, ref signifDigit, ref loverDigit);
      return signifDigit << 4 | loverDigit;
    }

    public int getWordFromTwoBytes(int sign, int low)
    {
      return sign << 8 | low;
    }

    public void setMemory(int addr, int val)
    {
      int signifDigit = val >> 4;
      int loverDigit = val & 15;
      this.memory.setMemoryValue(addr, signifDigit, loverDigit);
      ProgramLogic logic = this.memory.PPI.logic;
      if (addr < 33784 || addr > 33791)
        return;
      CDigit cdigit;
      switch (addr)
      {
        case 33784:
          cdigit = logic.IAR_D0;
          break;
        case 33785:
          cdigit = logic.IAR_D1;
          break;
        case 33786:
          cdigit = logic.IAR_D2;
          break;
        case 33787:
          cdigit = logic.IAR_D3;
          break;
        case 33788:
          cdigit = logic.IRD_D0;
          break;
        case 33789:
          cdigit = logic.IRD_D1;
          break;
        case 33790:
          cdigit = logic.IRD_D2;
          break;
        default:
          cdigit = logic.IRD_D3;
          break;
      }
      cdigit.turnOffDigit();
      for (int segment = 0; segment < 8; ++segment)
      {
        if ((val & (int) Math.Pow(2.0, (double) segment)) != 0)
          cdigit.onSegment(segment);
      }
    }

    public void setCurAddr(int addr)
    {
      if (addr == 768)
      {
        CLabWorks.Lab1_StartSound();
        addr = this.curAddr + 3;
      }
      this.curAddr = addr;
    }

    public void run(int addr)
    {
      this.curAddr = addr;
    }

    public void Alert(String message)
        {
            MessageBox.Show("Emulator.Exception.message:\r\n"+message);
        }

        public void interpretCurCommand()
    {
            //if (!this.bProgExecuted)
            //  return;
            bool test = true;
            while (this.bProgExecuted == true)
            {
                test = this.interpretCommand(this.getMemory(this.curAddr), this.getMemory(this.curAddr + 1), this.getMemory(this.curAddr + 2));
                if (test == false)
                {
                    
                    this.bProgExecuted = false;
                    //MessageBox.Show("Unsupported command:\r\n Address = " + this.curAddr.ToString("X4") + "\r\n Command = " + this.getMemory(this.curAddr).ToString("X2"));
                    if (bMainAllertActive)
                    {
                        Alert("Unsupported command:\r\n Address = " + this.curAddr.ToString("X4") + "\r\n Command = " + this.getMemory(this.curAddr).ToString("X2"));
                    }
                    else
                    {
                        bMainAllertActive = true;
                    }
                }
                //PLRoutine.showRegsAndFlags();
                string text;
                switch (this.getMemory(253) & 3)
                {
                    case 0:
                        text = PLRoutine.analogIn0.Text;
                        break;
                    case 1:
                        text = PLRoutine.analogIn1.Text;
                        break;
                    case 2:
                        text = PLRoutine.analogIn2.Text;
                        break;
                    default:
                        text = PLRoutine.analogIn3.Text;
                        break;
                }
                string[] strArray = text.Split('.');
                double num = strArray.Length != 1 ? (strArray[0].Length != 0 ? Convert.ToDouble(strArray[0]) : 0.0) + (strArray[1].Length != 0 ? Convert.ToDouble(strArray[1]) * Math.Pow(10.0, (double)-strArray[1].Length) : 0.0) : (text.Length != 0 ? Convert.ToDouble(text) : 0.0);
                if (num > 10.0)
                    num = 10.0;
                if (num < 0.0)
                    num = 0.0;
                this.setMemory(254, (int)(num * (double)byte.MaxValue / 10.0));
                //curAddr = curAddr;
            }
    }

    public bool interpretCommand(int curCmd, int curOp1, int curOp2)
    {
      for (int regNum = 0; regNum <= 7; ++regNum)//MOV // check
            {
        int num1 = 64 + regNum * 8;
        int num2 = num1 + 7;
        if (curCmd >= num1 && curCmd <= num2 && curCmd != 118) //check
                {
          this.setRegister(regNum, this.getRegister(curCmd - num1));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
      }
      for (int regNum = 0; regNum <= 7; ++regNum)
      {
        if (curCmd == 6 + regNum * 8)//MVI // check
                {
          this.setRegister(regNum, curOp1);
          this.setCurAddr(this.curAddr + 2);
          return true;
        }
      }
      for (int regPaigNum = 0; regPaigNum <= 3; ++regPaigNum)
      {
        if (curCmd == 16 * regPaigNum + 1)//LXI // check
                {
          this.setRegPair(regPaigNum, curOp2, curOp1);
          this.setCurAddr(this.curAddr + 3);
          return true;
        }
      }
      for (int regPaigNum = 0; regPaigNum <= 1; ++regPaigNum)
      {
        if (curCmd == 16 * regPaigNum + 10)//LDAX // check
                {
          this.setRegister(7, this.getMemory(this.getRegPair(regPaigNum)));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
        if (curCmd == 16 * regPaigNum + 2)//STAX // check
                {
          this.setMemory(this.getRegPair(regPaigNum), this.getRegister(7));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
      }
      for (int index = 2; index <= 3; ++index)
      {
        if (curCmd == 16 * index + 10)//LHLD // check
                {
          if (index == 2)
            this.setRegPair(2, 0, this.getMemory(this.getWordFromTwoBytes(curOp2, curOp1)));
          else
            this.setRegister(7, this.getMemory(this.getWordFromTwoBytes(curOp2, curOp1)));
          this.setCurAddr(this.curAddr + 3);
          return true;
        }
        if (curCmd == 16 * index + 2)//SHLD // check
                {
          if (index == 2)
            this.setMemory(this.getWordFromTwoBytes(curOp2, curOp1), this.getRegPair(2));
          else
            this.setMemory(this.getWordFromTwoBytes(curOp2, curOp1), this.getRegister(7));
          this.setCurAddr(this.curAddr + 3);
          return true;
        }
      }
      if (curCmd == 235)//XCHG // check
            {
        int regPair = this.getRegPair(1);
        this.setRegPair(1, this.getRegPair(2));
        this.setRegPair(2, regPair);
        this.setCurAddr(this.curAddr + 1);
        return true;
      }
      for (int regNum = 0; regNum <= 7; ++regNum)
      {
        if (curCmd == 8 * regNum + 4)//INR // check
                {
          this.setRegister(regNum, this.getRegister(regNum) + 1); 
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
        if (curCmd == 8 * regNum + 5)//DCR // check
                {
          this.setRegister(regNum, this.getRegister(regNum) - 1);
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
      }
      for (int regPaigNum = 0; regPaigNum <= 3; ++regPaigNum)
      {
        if (curCmd == 16 * regPaigNum + 3) //INX
        {
                    this.setRegister(regPaigNum * 2 + 1, this.getRegister(regPaigNum * 2 + 1) + 1);
                    if (this.memory.flagReg.C == true)
                    {
                        this.setRegister(regPaigNum * 2, this.getRegister(regPaigNum * 2) + 1);
                    }
                    this.clearFags(); //no flags should be set!!!

                    //this.setRegPair(regPaigNum, this.getRegPair(regPaigNum) + 1); //previous solution, retarded in some irreversible way. Very hard to debug.
                    this.setCurAddr(this.curAddr + 1);
                    return true;
        }
        if (curCmd == 16 * regPaigNum + 11) //DCX
        {
                    this.setRegister(regPaigNum * 2 + 1, this.getRegister(regPaigNum * 2 + 1) - 1);
                    if (this.memory.flagReg.C == true)
                    {
                        this.setRegister(regPaigNum * 2, this.getRegister(regPaigNum * 2) - 1);
                    }
                    this.clearFags(); //no flags should be set!!!

                    //this.setRegPair(regPaigNum, this.getRegPair(regPaigNum) - 1);//previous solution, retarded in some irreversible way. Very hard to debug.
                    this.setCurAddr(this.curAddr + 1);
          return true;
        }

      }
      for (int regNum = 0; regNum <= 7; ++regNum)
      {
        if (curCmd == 128 + regNum)//ADD // check
                {
          this.setRegister(REG_A, this.getRegister(regNum) + this.getRegister(REG_A));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
        if (curCmd == 144 + regNum)//SUB // check
                {
          this.setRegister(REG_A, this.getRegister(REG_A) - this.getRegister(regNum));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
      }
      for (int regPaigNum = 0; regPaigNum <= 3; ++regPaigNum)
      {
        if (curCmd == 16 * regPaigNum + 9)//DAD // check
                {
          this.setRegPair(regPaigNum, this.getRegPair(regPaigNum) + this.getRegPair(2));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
      }
      for (int regNum = 0; regNum <= 7; ++regNum)
      {
        if (curCmd == 160 + regNum)//ANA // check
                {
          this.setRegister(REG_A, this.getRegister(REG_A) & this.getRegister(regNum));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
        if (curCmd == 168 + regNum)//XRA // check
                {
          this.setRegister(REG_A, this.getRegister(REG_A) ^ this.getRegister(regNum));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
        if (curCmd == 176 + regNum)//ORA // check
                {
          this.setRegister(REG_A, this.getRegister(REG_A) | this.getRegister(regNum));
          this.setCurAddr(this.curAddr + 1);
          return true;
        }
        if (curCmd == 184 + regNum) // CMP // check
                {
                    int num = (UInt16) this.getRegister(REG_A) - (UInt16)this.getRegister(regNum);
                    this.updateFlags(num); // 
                    this.setCurAddr(this.curAddr + 1);
                    return true;
        }
      }
      if (curCmd == 195)//JMP // check
            {
        this.setCurAddr(curOp2 << 8 | curOp1);
        return true;
      }
      if (curCmd == 194)//JNZ // check
            {
        if (!this.memory.flagReg.Z)
          this.setCurAddr(curOp2 << 8 | curOp1);
        else
          this.setCurAddr(this.curAddr + 3);
        return true;
      }
      if (curCmd == 202)//JZ // check
            {
        if (this.memory.flagReg.Z)
          this.setCurAddr(curOp2 << 8 | curOp1);
        else
          this.setCurAddr(this.curAddr + 3);
        return true;
      }
      if (curCmd == 210)//JNC
      {
        if (!this.memory.flagReg.C)
          this.setCurAddr(curOp2 << 8 | curOp1);
        else
          this.setCurAddr(this.curAddr + 3);
        return true;
      }
      if (curCmd == 218)//JC
            {
        if (this.memory.flagReg.C)
          this.setCurAddr(curOp2 << 8 | curOp1);
        else
          this.setCurAddr(this.curAddr + 3);
        return true;
      }

      if (curCmd == 0xFA)//JM // check
            {
        if (this.memory.flagReg.S)//
          this.setCurAddr(curOp2 << 8 | curOp1);
        else
          this.setCurAddr(this.curAddr + 3);
        return true;
      }

      if (curCmd == 0xF2)//JP // check
            {
        if (!this.memory.flagReg.S)
          this.setCurAddr(curOp2 << 8 | curOp1);
        else
          this.setCurAddr(this.curAddr + 3);
        return true;
      }
      if (curCmd == 216)//RC // check
            {
        this.setRegister(7, this.getMemory(250 + curOp1));
        this.setCurAddr(this.curAddr + 2);
        return true;
      }
      if (curCmd == 211)//OUT // check
            {
        this.setMemory(250 + curOp1, this.getRegister(7));
        this.setCurAddr(this.curAddr + 2);
        return true;
      }
      if (curCmd == 118)//HLT // check
            {
        this.bProgExecuted = false;
        return true;
      }

      //if (curCmd != 205)// if unrecognized command
      //  return false;
      //this.callFunc(this.getWordFromTwoBytes(curOp2, curOp1));
      //this.setCurAddr(this.curAddr + 3);
      //return true;
      if (curCmd == 0xC9)//RET
      {
             if (ScallStack.Count > 0)
                {
                    cSEElement = ScallStack.Pop();
                    for (int iRegIndex = REG_B; iRegIndex <= REG_A; iRegIndex++)
                    {
                        setRegister(iRegIndex, (int)cSEElement.REG[iRegIndex],false);
                    }
                    this.memory.flagReg = cSEElement.FlagReg;
                    this.setCurAddr(cSEElement.iRetAddres);
                    return true;
                }
             else
                {
                    bMainAllertActive = false;
                    Alert("unable to execute command RET\r\nReason: callStack is empty, no functions were called before this RET");
                }
                return false;

      }
    

      if (curCmd == 205)//CALL // check
      {
                if (callFunc(this.getWordFromTwoBytes(curOp2, curOp1)))
                {
                    this.setCurAddr(this.curAddr + 3);
                }
                else
                {
                    //this.setCurAddr(this.curAddr + 3);
                    cSEElement = new callStackElement
                    {
                        FlagReg = this.memory.flagReg,
                        iRetAddres = this.curAddr + 3
                    };
                    for (int iRegIndex = REG_B; iRegIndex <= REG_A; iRegIndex++)
                    {
                        cSEElement.REG[iRegIndex] = (UInt16)getRegister(iRegIndex);
                    }
     
                    ScallStack.Push(cSEElement);
                    this.setCurAddr(this.getWordFromTwoBytes(curOp2, curOp1));
                }
        return true;
      }
      return false;
            
    }

    public bool callFunc(int addr)
    {
      if (addr == 768)
      {
        CLabWorks.Lab1_StartSound();
                return true;
      }
      else
      {
                if (addr == 256)
                {
                    this.seggg();
                    return true;
                }
      }
            return false;
    }
        public void clearFags() // this should be called after executing operations such as INX, DCX that don't impact flags
        {
            this.memory.flagReg.AC = false;
            this.memory.flagReg.Z = false;
            this.memory.flagReg.C = false;
            this.memory.flagReg.P = false;
            this.memory.flagReg.S = false;

        }

    public void seggg()
    {
      int[] numArray = new int[16]
      {
        64,
        6,
        91,
        79,
        102,
        109,
        125,
        7,
        128,
        111,
        119,
        124,
        57,
        94,
        121,
        113
      };
      for (int index1 = 0; index1 < 4; ++index1)
      {
        int memory = this.getMemory(33780 + index1);
        int index2 = memory >> 4;
        int index3 = memory & 15;
        this.setMemory(33784 + index1 * 2, numArray[index2]);
        this.setMemory(33784 + index1 * 2 + 1, numArray[index3]);
      }
    }
  }
}
