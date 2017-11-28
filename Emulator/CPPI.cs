// Decompiled with JetBrains decompiler
// Type: Emulator.CPPI
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Emulator
{
  public class CPPI : UserControl
  {
    private Container components = (Container) null;
    private PictureBox Pic1;
    public CheckBox CB1;
    private PictureBox Pic2;
    private PictureBox Pic3;
    private PictureBox Pic4;
    private PictureBox Pic5;
    private PictureBox Pic6;
    private PictureBox Pic7;
    private PictureBox Pic8;
        public CheckBox CB2;
        public CheckBox CB3;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private CMemory memory;
    public ProgramLogic logic;
    private int aWord;
    private int cWord;

    public CPPI(ProgramLogic _logic)
    {
      this.InitializeComponent();
      this.logic = _logic;
      this.resetLamps();
      this.setCword((int) byte.MaxValue);
      this.aWord = (int) byte.MaxValue;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.Pic1 = new PictureBox();
      this.CB1 = new CheckBox();
      this.CB2 = new CheckBox();
      this.CB3 = new CheckBox();
      this.Pic2 = new PictureBox();
      this.Pic3 = new PictureBox();
      this.Pic4 = new PictureBox();
      this.Pic5 = new PictureBox();
      this.Pic6 = new PictureBox();
      this.Pic7 = new PictureBox();
      this.Pic8 = new PictureBox();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.Pic1.BackColor = Color.Red;
      this.Pic1.Location = new Point(32, 24);
      this.Pic1.Name = "Pic1";
      this.Pic1.Size = new Size(16, 16);
      this.Pic1.TabIndex = 10;
      this.Pic1.TabStop = false;
      this.CB1.Location = new Point(24, 16);
      this.CB1.Name = "CB1";
      this.CB1.Size = new Size(32, 24);
      this.CB1.TabIndex = 4;
      this.CB1.Text = "1";
      this.CB1.CheckedChanged += new EventHandler(this.CB1_CheckedChanged);
      this.CB2.Location = new Point(24, 40);
      this.CB2.Name = "CB2";
      this.CB2.Size = new Size(32, 24);
      this.CB2.TabIndex = 2;
      this.CB2.Text = "2";
      this.CB2.CheckedChanged += new EventHandler(this.CB2_CheckedChanged);
      this.CB3.Location = new Point(24, 64);
      this.CB3.Name = "CB3";
      this.CB3.Size = new Size(32, 24);
      this.CB3.TabIndex = 3;
      this.CB3.Text = "3";
      this.CB3.CheckedChanged += new EventHandler(this.CB3_CheckedChanged);
      this.Pic2.BackColor = Color.Red;
      this.Pic2.Location = new Point(32, 56);
      this.Pic2.Name = "Pic2";
      this.Pic2.Size = new Size(16, 16);
      this.Pic2.TabIndex = 9;
      this.Pic2.TabStop = false;
      this.Pic3.BackColor = Color.Red;
      this.Pic3.Location = new Point(32, 88);
      this.Pic3.Name = "Pic3";
      this.Pic3.Size = new Size(16, 16);
      this.Pic3.TabIndex = 12;
      this.Pic3.TabStop = false;
      this.Pic4.BackColor = Color.Red;
      this.Pic4.Location = new Point(32, 120);
      this.Pic4.Name = "Pic4";
      this.Pic4.Size = new Size(16, 16);
      this.Pic4.TabIndex = 11;
      this.Pic4.TabStop = false;
      this.Pic5.BackColor = Color.Red;
      this.Pic5.Location = new Point(32, 152);
      this.Pic5.Name = "Pic5";
      this.Pic5.Size = new Size(16, 16);
      this.Pic5.TabIndex = 6;
      this.Pic5.TabStop = false;
      this.Pic6.BackColor = Color.Red;
      this.Pic6.Location = new Point(32, 184);
      this.Pic6.Name = "Pic6";
      this.Pic6.Size = new Size(16, 16);
      this.Pic6.TabIndex = 5;
      this.Pic6.TabStop = false;
      this.Pic7.BackColor = Color.Red;
      this.Pic7.Location = new Point(32, 216);
      this.Pic7.Name = "Pic7";
      this.Pic7.Size = new Size(16, 16);
      this.Pic7.TabIndex = 8;
      this.Pic7.TabStop = false;
      this.Pic8.BackColor = Color.Red;
      this.Pic8.Location = new Point(32, 248);
      this.Pic8.Name = "Pic8";
      this.Pic8.Size = new Size(16, 16);
      this.Pic8.TabIndex = 7;
      this.Pic8.TabStop = false;
      this.groupBox1.Controls.Add((Control) this.CB1);
      this.groupBox1.Controls.Add((Control) this.CB2);
      this.groupBox1.Controls.Add((Control) this.CB3);
      this.groupBox1.Location = new Point(8, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(80, 100);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Тумблери";
      this.groupBox2.Controls.Add((Control) this.Pic8);
      this.groupBox2.Controls.Add((Control) this.Pic1);
      this.groupBox2.Controls.Add((Control) this.Pic2);
      this.groupBox2.Controls.Add((Control) this.Pic3);
      this.groupBox2.Controls.Add((Control) this.Pic4);
      this.groupBox2.Controls.Add((Control) this.Pic5);
      this.groupBox2.Controls.Add((Control) this.Pic6);
      this.groupBox2.Controls.Add((Control) this.Pic7);
      this.groupBox2.Location = new Point(112, 8);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(80, 280);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Індикатори";
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Name = nameof (CPPI);
      this.Size = new Size(208, 304);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public bool getCB(int cbIndex)
    {
      switch (cbIndex)
      {
        case 0:
          return this.CB1.Checked;
        case 1:
          return this.CB2.Checked;
        case 2:
          return this.CB3.Checked;
        default:
          return false;
      }
    }

    public int getCWord()
    {
      return this.cWord & ((((0 | (this.CB3.Checked ? 1 : 0)) << 1 | (this.CB2.Checked ? 1 : 0)) << 1 | (this.CB1.Checked ? 1 : 0)) << 1 | 241);
    }

    public void setCword(int val)
    {
      this.cWord = val;
    }

    public void setAword(int val)
    {
      this.aWord = val;
    }

    public int getAword()
    {
      return this.aWord;
    }

    public void onBtnPressed(int index)
    {
      int num1 = (int) Math.Floor((double) (index / 8));
      int num2 = index % 8;
      int cword = this.getCWord();
      if (((int) Math.Pow(2.0, (double) (num1 + 4)) & cword) == 0)
        return;
      this.aWord = (int) byte.MaxValue ^ (int) Math.Pow(2.0, (double) num2);
      this.memory.setMemoryValue(250, this.aWord >> 4, this.aWord & 15);
    }

    public void updateMemory()
    {
      int cword = this.getCWord();
      this.memory.setMemoryValue(252, cword >> 4, cword & 15);
      string hexString = this.logic.LeftIAR.getHexString();
      int signifDigit = 0;
      int loverDigit = 0;
      this.memory.getMemoryValue(hexString, ref signifDigit, ref loverDigit);
      this.logic.RightIRD.addTwoDigits(signifDigit, loverDigit);
      this.logic.redrawDigits();
    }

    public void setMemory(ref CMemory _memory)
    {
      this.memory = _memory;
    }

    public void resetLamps()
    {
      this.Pic1.BackColor = Color.White;
      this.Pic2.BackColor = Color.White;
      this.Pic3.BackColor = Color.White;
      this.Pic4.BackColor = Color.White;
      this.Pic5.BackColor = Color.White;
      this.Pic6.BackColor = Color.White;
      this.Pic7.BackColor = Color.White;
      this.Pic8.BackColor = Color.White;
    }

    public void setLamp(int lampIndex, bool bHighlighted)
    {
      Color color = bHighlighted ? Color.Red : Color.White;
      switch (lampIndex)
      {
        case 0:
          this.Pic1.BackColor = color;
          break;
        case 1:
          this.Pic2.BackColor = color;
          break;
        case 2:
          this.Pic3.BackColor = color;
          break;
        case 3:
          this.Pic4.BackColor = color;
          break;
        case 4:
          this.Pic5.BackColor = color;
          break;
        case 5:
          this.Pic6.BackColor = color;
          break;
        case 6:
          this.Pic7.BackColor = color;
          break;
        case 7:
          this.Pic8.BackColor = color;
          break;
      }
    }

    private void CB1_CheckedChanged(object sender, EventArgs e)
    {
      this.updateMemory();
    }

    private void CB2_CheckedChanged(object sender, EventArgs e)
    {
      this.updateMemory();
    }

    private void CB3_CheckedChanged(object sender, EventArgs e)
    {
      this.updateMemory();
    }
  }
}
