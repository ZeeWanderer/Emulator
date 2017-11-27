// Decompiled with JetBrains decompiler
// Type: Emulator.CDigit
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Emulator
{
  public class CDigit : UserControl
  {
    private Container components = (Container) null;
    private PictureBox UP;
    private PictureBox CENTER;
    private PictureBox DOWN;
    private PictureBox UPRIGHT;
    private PictureBox UPLEFT;
    private PictureBox DOWNLEFT;
    private PictureBox DOWNRIGHT;
        public int value;

    public CDigit()
    {
      this.InitializeComponent();
    }
        public int getvalue()
        {
            return value;
        }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.UP = new PictureBox();
      this.CENTER = new PictureBox();
      this.DOWN = new PictureBox();
      this.UPRIGHT = new PictureBox();
      this.UPLEFT = new PictureBox();
      this.DOWNLEFT = new PictureBox();
      this.DOWNRIGHT = new PictureBox();
      this.SuspendLayout();
      this.UP.BackColor = Color.Black;
      this.UP.Location = new Point(0, 0);
      this.UP.Name = "UP";
      this.UP.Size = new Size(40, 8);
      this.UP.TabIndex = 0;
      this.UP.TabStop = false;
      this.CENTER.BackColor = Color.Black;
      this.CENTER.Location = new Point(0, 40);
      this.CENTER.Name = "CENTER";
      this.CENTER.Size = new Size(40, 8);
      this.CENTER.TabIndex = 0;
      this.CENTER.TabStop = false;
      this.DOWN.BackColor = Color.Black;
      this.DOWN.Location = new Point(0, 80);
      this.DOWN.Name = "DOWN";
      this.DOWN.Size = new Size(40, 8);
      this.DOWN.TabIndex = 0;
      this.DOWN.TabStop = false;
      this.UPRIGHT.BackColor = Color.Black;
      this.UPRIGHT.Location = new Point(32, 8);
      this.UPRIGHT.Name = "UPRIGHT";
      this.UPRIGHT.Size = new Size(8, 32);
      this.UPRIGHT.TabIndex = 0;
      this.UPRIGHT.TabStop = false;
      this.UPLEFT.BackColor = Color.Black;
      this.UPLEFT.Location = new Point(0, 8);
      this.UPLEFT.Name = "UPLEFT";
      this.UPLEFT.Size = new Size(8, 32);
      this.UPLEFT.TabIndex = 0;
      this.UPLEFT.TabStop = false;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWNLEFT.Location = new Point(0, 48);
      this.DOWNLEFT.Name = "DOWNLEFT";
      this.DOWNLEFT.Size = new Size(8, 32);
      this.DOWNLEFT.TabIndex = 0;
      this.DOWNLEFT.TabStop = false;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.DOWNRIGHT.Location = new Point(32, 48);
      this.DOWNRIGHT.Name = "DOWNRIGHT";
      this.DOWNRIGHT.Size = new Size(8, 32);
      this.DOWNRIGHT.TabIndex = 0;
      this.DOWNRIGHT.TabStop = false;
      this.Controls.Add((Control) this.UP);
      this.Controls.Add((Control) this.CENTER);
      this.Controls.Add((Control) this.DOWN);
      this.Controls.Add((Control) this.UPRIGHT);
      this.Controls.Add((Control) this.UPLEFT);
      this.Controls.Add((Control) this.DOWNLEFT);
      this.Controls.Add((Control) this.DOWNRIGHT);
      this.Name = nameof (CDigit);
      this.Size = new Size(40, 88);
      this.ResumeLayout(false);
    }

    public void onSegment(int segment)
    {
      switch (segment)
      {
        case 0:
          this.UP.BackColor = Color.Black;
          break;
        case 1:
          this.UPRIGHT.BackColor = Color.Black;
          break;
        case 2:
          this.DOWNRIGHT.BackColor = Color.Black;
          break;
        case 3:
          this.DOWN.BackColor = Color.Black;
          break;
        case 4:
          this.DOWNLEFT.BackColor = Color.Black;
          break;
        case 5:
          this.UPLEFT.BackColor = Color.Black;
          break;
        case 6:
          this.CENTER.BackColor = Color.Black;
          break;
      }
    }

    public void offSegment(int segment)
    {
      switch (segment)
      {
        case 0:
          this.UP.BackColor = Color.White;
          break;
        case 1:
          this.UPLEFT.BackColor = Color.White;
          break;
        case 2:
          this.DOWNLEFT.BackColor = Color.White;
          break;
        case 3:
          this.DOWN.BackColor = Color.White;
          break;
        case 4:
          this.DOWNRIGHT.BackColor = Color.White;
          break;
        case 5:
          this.UPRIGHT.BackColor = Color.White;
          break;
        case 6:
          this.CENTER.BackColor = Color.White;
          break;
      }
    }

    public void setDigit(string digit)
    {
      this.turnOffDigit();
      digit.ToUpper();
      switch (digit)
      {
        case "A":
          this.lightA();
          break;
        case "B":
          this.lightB();
          break;
        case "C":
          this.lightC();
          break;
        case "D":
          this.lightD();
          break;
        case "E":
          this.lightE();
          break;
        case "F":
          this.lightF();
          break;
        case "1":
          this.light1();
          break;
        case "2":
          this.light2();
          break;
        case "3":
          this.light3();
          break;
        case "4":
          this.light4();
          break;
        case "5":
          this.light5();
          break;
        case "6":
          this.light6();
          break;
        case "7":
          this.light7();
          break;
        case "8":
          this.light8();
          break;
        case "9":
          this.light9();
          break;
      }
    }

    public void setDigit(int digit)
    {
      this.turnOffDigit();
      switch (digit)
      {
        case 0:
          this.light0();
          break;
        case 1:
          this.light1();
          break;
        case 2:
          this.light2();
          break;
        case 3:
          this.light3();
          break;
        case 4:
          this.light4();
          break;
        case 5:
          this.light5();
          break;
        case 6:
          this.light6();
          break;
        case 7:
          this.light7();
          break;
        case 8:
          this.light8();
          break;
        case 9:
          this.light9();
          break;
        case 10:
          this.lightA();
          break;
        case 11:
          this.lightB();
          break;
        case 12:
          this.lightC();
          break;
        case 13:
          this.lightD();
          break;
        case 14:
          this.lightE();
          break;
        case 15:
          this.lightF();
          break;
      }
    }

    public void drawByteSegments(byte segms)
    {
    }

    public void turnOffDigit()
    {
      this.UP.BackColor = Color.White;
      this.UPLEFT.BackColor = Color.White;
      this.DOWNLEFT.BackColor = Color.White;
      this.DOWN.BackColor = Color.White;
      this.DOWNRIGHT.BackColor = Color.White;
      this.UPRIGHT.BackColor = Color.White;
      this.CENTER.BackColor = Color.White;
    }

    private void lightA()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void lightB()
    {
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void lightC()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
    }

    private void lightD()
    {
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void lightE()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void lightF()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light1()
    {
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
    }

    private void light2()
    {
      this.UP.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light3()
    {
      this.UP.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light4()
    {
      this.UPRIGHT.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light5()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light6()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light7()
    {
      this.UP.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
    }

    private void light8()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light9()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
      this.CENTER.BackColor = Color.Black;
    }

    private void light0()
    {
      this.UP.BackColor = Color.Black;
      this.UPLEFT.BackColor = Color.Black;
      this.DOWNLEFT.BackColor = Color.Black;
      this.DOWN.BackColor = Color.Black;
      this.DOWNRIGHT.BackColor = Color.Black;
      this.UPRIGHT.BackColor = Color.Black;
    }
  }
}
