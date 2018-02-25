// Decompiled with JetBrains decompiler
// Type: Emulator.ProgramLogic
// Assembly: Emulator, Version=1.0.3072.15671, Culture=neutral, PublicKeyToken=null
// MVID: 2D14D142-75FF-4DBB-9D56-6B1C926FB47E
// Assembly location: C:\НавчанняБуфер\МПТ\Емулятор Мікролаб К580-20171009T132029Z-001\Емулятор Мікролаб К580\Emulator.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Emulator
{
  public class ProgramLogic : Form
  {
    public CIndicator LeftIAR = new CIndicator();
    public CIndicator RightIRD = new CIndicator();
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private TabPage tabPage4;
    private TabPage tabPage5;
    private TabPage tabPage6;
    private TabControl TabLabsControl;
    private Button ButtonNumC;
    private Button ButtonNumD;
    private Button ButtonNumE;
    private Button ButtonNumA;
    private Button ButtonNum9;
    private Button ButtonNumB;
    private Button ButtonNum8;
    private Button ButtonNum6;
    private Button ButtonNum3;
    private Button ButtonNum4;
    private Button ButtonNum7;
    private Button ButtonNum0;
    private Button ButtonNum5;
    private Button ButtonNum1;
    private Button ButtonNum2;
    private Button ButtonNumF;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private CDigit cDigit6;
    private CDigit cDigit7;
    private CDigit cDigit8;
    private CDigit cDigit9;
    public CDigit IAR_D0;
    public CDigit IAR_D1;
    public CDigit IAR_D2;
    public CDigit IAR_D3;
    public CDigit IRD_D1;
    public CDigit IRD_D0;
    public CDigit IRD_D2;
    public CDigit IRD_D3;
    private Button But_UST_ADR;
    private Button But_ZP;
    private Button But_PUSK;
    private Button But_VOZVRAT;
    private Button But_VUVOD;
    private Button But_AD_MINUS;
    private Button But_VVOD;
    private Button But_AD_PLUS;
    private Button But_SBROS;
    private RichTextBox TBLab1;
    public ToolTip toolTip1111;
    private Label LR1SoundLabel;
    private TextBox TBRegisterVals;
    private Label label1;
    private Label label2;
    private TextBox TBFlags;
    public CPPI PPI;
        public TextBox analogIn0;
        public TextBox analogIn1;
        public TextBox analogIn2;
        public TextBox analogIn3;
    private RichTextBox TBLab3;
    private RichTextBox TBLab4;
    private RichTextBox TBLab5;
    private RichTextBox TBLab6;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private RichTextBox TBLab2;
    private IContainer components;
    private CMemory memory;
    private CInterpreter interpreter;
    private OpenFileDialog openFileDialog1;
    private String IntelHEX;
   //     private Thread CInterpreterT;

    public ProgramLogic()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.TabLabsControl = new TabControl();
      this.tabPage1 = new TabPage();
      this.LR1SoundLabel = new Label();
      this.TBLab1 = new RichTextBox();
      this.tabPage2 = new TabPage();
      this.TBLab2 = new RichTextBox();
      this.tabPage3 = new TabPage();
      this.TBLab3 = new RichTextBox();
      this.tabPage4 = new TabPage();
      this.TBLab4 = new RichTextBox();
      this.tabPage5 = new TabPage();
      this.TBLab5 = new RichTextBox();
      this.tabPage6 = new TabPage();
      this.label3 = new Label();
      this.TBLab6 = new RichTextBox();
      this.analogIn0 = new TextBox();
      this.analogIn1 = new TextBox();
      this.analogIn2 = new TextBox();
      this.analogIn3 = new TextBox();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.ButtonNumC = new Button();
      this.ButtonNumD = new Button();
      this.ButtonNumE = new Button();
      this.ButtonNumF = new Button();
      this.ButtonNumA = new Button();
      this.ButtonNum9 = new Button();
      this.ButtonNumB = new Button();
      this.ButtonNum8 = new Button();
      this.ButtonNum6 = new Button();
      this.ButtonNum3 = new Button();
      this.ButtonNum4 = new Button();
      this.ButtonNum7 = new Button();
      this.ButtonNum0 = new Button();
      this.ButtonNum5 = new Button();
      this.ButtonNum1 = new Button();
      this.ButtonNum2 = new Button();
      this.But_UST_ADR = new Button();
      this.But_ZP = new Button();
      this.But_PUSK = new Button();
      this.But_VOZVRAT = new Button();
      this.But_VUVOD = new Button();
      this.But_AD_MINUS = new Button();
      this.But_VVOD = new Button();
      this.But_AD_PLUS = new Button();
      this.But_SBROS = new Button();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.IAR_D0 = new CDigit();
      this.IAR_D1 = new CDigit();
      this.IAR_D2 = new CDigit();
      this.IAR_D3 = new CDigit();
      this.IRD_D1 = new CDigit();
      this.IRD_D0 = new CDigit();
      this.IRD_D2 = new CDigit();
      this.IRD_D3 = new CDigit();
      this.cDigit8 = new CDigit();
      this.cDigit9 = new CDigit();
      this.cDigit6 = new CDigit();
      this.cDigit7 = new CDigit();
      this.toolTip1111 = new ToolTip(this.components);
      this.TBRegisterVals = new TextBox();
      this.TBFlags = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.PPI = new CPPI(this);
      this.TabLabsControl.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.tabPage6.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.TabLabsControl.Controls.Add((Control) this.tabPage1);
      this.TabLabsControl.Controls.Add((Control) this.tabPage2);
      this.TabLabsControl.Controls.Add((Control) this.tabPage3);
      this.TabLabsControl.Controls.Add((Control) this.tabPage4);
      this.TabLabsControl.Controls.Add((Control) this.tabPage5);
      this.TabLabsControl.Controls.Add((Control) this.tabPage6);
      this.TabLabsControl.Location = new Point(0, 16);
      this.TabLabsControl.Name = "TabLabsControl";
      this.TabLabsControl.SelectedIndex = 0;
      this.TabLabsControl.Size = new Size(488, 488);
      this.TabLabsControl.TabIndex = 0;
      this.tabPage1.Controls.Add((Control) this.LR1SoundLabel);
      this.tabPage1.Controls.Add((Control) this.TBLab1);
      ((Control) this.tabPage1).Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new Size(480, 462);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Лаб. Роб. №1";
      this.LR1SoundLabel.BackColor = SystemColors.ControlText;
      this.LR1SoundLabel.BorderStyle = BorderStyle.FixedSingle;
      this.LR1SoundLabel.Location = new Point(368, 336);
      this.LR1SoundLabel.Name = "LR1SoundLabel";
      this.LR1SoundLabel.Size = new Size(64, 64);
      this.LR1SoundLabel.TabIndex = 1;
      this.LR1SoundLabel.Text = "Відтворення звуку";
      this.LR1SoundLabel.Visible = false;
      this.TBLab1.Cursor = Cursors.IBeam;
      this.TBLab1.Location = new Point(16, 24);
      this.TBLab1.Name = "TBLab1";
      this.TBLab1.ReadOnly = true;
      this.TBLab1.Size = new Size(432, 248);
      this.TBLab1.TabIndex = 0;
      this.TBLab1.Text = "\t\tЗавдання до лабораторної роботи.\n\n1. Дослідити вміст пам'яті мікроЕВМ. Для цього завантажити програму і натиснути клавішу СБРОС. Встановити адресу ОЗУ 8000 - область користувача, після чого на дисплеї з'явиться його вміст.Натисненням клавіші АД+ інкрементувати адресу і проглянути вміст комірок до досягнення адреси 8010. Перевести в десяткову систему числення два числа: за адресою 8005 і 8010. Переконатися в можливості декременту лічильника адреси при багатократному нажиманні клавіші АД--. Проглянути елементи пам'яті в зворотній послідовності з адреси 8010 по 8000, Скласти таблицю вмісту комірок пам'яті з 83Е0 по 83ЕВ.\n2. Записати числа в пам'ять мікроЕОМ.  Набрати на цифровій клавіатурі адресу області користувача і записати в комірки ряд послідовно зростаючих шістнадцяткових чисел, починаючи з 8300Н з кроком 1. Проглянути записані числа в зворотному порядку. Зробити спробу запису даних в комірки,  починаючи з адреси 0000Н. Результат спроби записати в звіт.\n3. Дослідити вміст регістрів ЦП. Записати вміст регістрів ЦП після виконання програми - музичний фрагмент, Змініть вміст регістрів, ввівши в них довільні дані.\n\n-----------------------------------------------\nПримітки до емулятора\nВся робота виконується згідно методичних вказівок, без жодних змін.\n";
      this.tabPage2.Controls.Add((Control) this.TBLab2);
      ((Control) this.tabPage2).Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new Size(480, 462);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Лаб. Роб. №2";
      this.TBLab2.Location = new Point(24, 24);
      this.TBLab2.Name = "TBLab2";
      this.TBLab2.Size = new Size(432, 408);
      this.TBLab2.ReadOnly = true;
      this.TBLab2.TabIndex = 0;
      this.TBLab2.Text = "\t\tЗавдання до лабораторної роботи.\n\n1.\tДослідити програму 2.1. Ввести її в пам'ять мікро ЕОМ і здійснити її пуск з адреси 8000Н. Перевірити результат виконання шляхом дослідження вмісту регістра А і комірки пам'яті 8300Н.\n2.\tРозробити алгоритм, програму запису в елементи пам'яті з адреси 8200Н ряду послідовно зростаючих шістнадцяткових чисел (00-FF) з кроком 1. Дослідити виконання програми. 3. Розробити алгоритми і дослідити виконання програм:\n-\tскладання чисел, записаних по адресам 8200Н і 8201Н, і запис результату за адресою 8210H;\n-\tпорівняння чисел за адресами 8300Н і 8301Н і запис більшого з них в регістр D;\n-\tперетворення двійкового числа, записаного за адресою 8300H, в двійково-десяткове і запис результату за адресою 8301H;\n-\tзнаходження максимального елементу масиву,  розташованого в пам'яті 8200Н-8203Н, і записі його в елемент пам'яті 8204Н.\n\n-----------------------------------------------\nПримітки до емулятора\nВся робота виконується згідно методичних вказівок, без жодних змін.\n";
      this.tabPage3.Controls.Add((Control) this.PPI);
      this.tabPage3.Controls.Add((Control) this.TBLab3);
      ((Control) this.tabPage3).Location = new Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new Size(480, 462);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Лаб. Роб. №3";
      this.TBLab3.Location = new Point(16, 320);
      this.TBLab3.Name = "TBLab3";
      this.TBLab3.Size = new Size(448, 120);
      this.TBLab3.ReadOnly = true;
      this.TBLab3.TabIndex = 0;
      this.TBLab3.Text = "\t\tЗавдання до лабораторної роботи.\n\n1. Дизасемблюйте (перекладіть мовою асемблера) програму «бігуча цифра», приведену на рис.9(методичні вказівки рос. мовою). Поясніть суть програми. Ввести програму в пам'ять мікро ЕОМ і здійснити її запуск. Змініть вміст комірки 8003 на 0F9H. Перевірте результат виконання програми.\n2. Розробити алгоритм, програму циклічного опиту датчиків і виведення отриманої інформації на індикатори. Дослідити виконання програми. Розробити алгоритм, програму опиту датчиків і формування керуючих дій (канал В в ППІ), відповідно до таблиці (методичка).\n\n-----------------------------------------------\nПримітки до емулятора\nУ звя’язку з відсутністю в програмному емуляторі ППІ, були зроблені наступні припущення: канал А порта знаходиться за адресою 00FAH, В - 00FВH, С - 00FСH. Базовою адресою портів є 00FAH. Це означає, що каналу A відповідає нульовий порт, B – перший, C – другий. На вкладці «Лаб. Робота №3» присутні 3 двопозиційні елементи, що емулюють тумблери під’єднані до порта С, та 8 індикаторів, що емулюють лампи під’єднані до порта В.\n\nПриклад програми для послідовного засвітлення індикаторів під’єднанних до каналу В:\n8000  -  MVI  A, 0\n8002  -  INR  A\n8003  -  OUT  1\n8005  -  JMP  8002\n\n";
      this.tabPage4.Controls.Add((Control) this.TBLab4);
      ((Control) this.tabPage4).Location = new Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new Size(480, 462);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Лаб. Роб. №4";
      this.TBLab4.Location = new Point(24, 24);
      this.TBLab4.Name = "TBLab4";
      this.TBLab4.Size = new Size(432, 408);
      this.TBLab4.ReadOnly = true;
      this.TBLab4.TabIndex = 0;
      this.TBLab4.Text = "\t\tЗавдання до лабораторної роботи.\n1. Скласти програму читання ряду ключів, реалізовуючу описаний раніше процес читання.\n2. Розробити алгоритм і програму для перевірки стану датчика (кнопки 2). Якщо кнопка 2 натиснута, генерується звуковий сигнал. Наберіть на \"Мікролаб\" і перевірте її роботу. \n3. Розробити алгоритм і програму для перевірки стану датчиків (по вибору викладача). Якщо кнопка… натиснута, генерується звуковий сигнал.  Наберіть на \"Мікролаб\" і перевірте її роботу.\n\n-----------------------------------------------\nПримітки до емулятора\nДивись коментарі до ЛР №3.\nПриклад програми, що опитує клавіші 0-7 і записує код з каналу А ППІ в регістр А:\n8000  -  MVI   A, 9F\n8002  -  OUT   02\n8004  -  IN    00\n8006  -  JMP   8004\n";
      this.tabPage5.Controls.Add((Control) this.TBLab5);
      ((Control) this.tabPage5).Location = new Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Size = new Size(480, 462);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "Лаб. Роб. №5";
      this.TBLab5.Location = new Point(24, 24);
      this.TBLab5.Name = "TBLab5";
      this.TBLab5.Size = new Size(432, 408);
      this.TBLab5.ReadOnly = true;
      this.TBLab5.TabIndex = 0;
      this.TBLab5.Text = "\t\tЗавдання до лабораторної роботи\n\n1. Дослідити програму, приведену в табл.1. Введіть програму та перевірте її роботу.  Зафіксуйте результати виконання.\n2. Розробіть та дослідіть програму,  що виводить на два правих індикатора значення натиснутої кнопки. Використовуйте  при цьому моніторну підпрограму SEGGG.\n3. Розробіть та продемонструйте виконання програми яка виводить на індикатори напис \"ЗАЧЕТ\".  Підпрограму монітора не використовувати.\n\n-----------------------------------------------\nПримітки до емулятора\nВся робота виконується згідно методичних вказівок, без жодних змін.\n";
      this.tabPage6.Controls.Add((Control) this.label3);
      this.tabPage6.Controls.Add((Control) this.TBLab6);
      this.tabPage6.Controls.Add((Control) this.analogIn0);
      this.tabPage6.Controls.Add((Control) this.analogIn1);
      this.tabPage6.Controls.Add((Control) this.analogIn2);
      this.tabPage6.Controls.Add((Control) this.analogIn3);
      this.tabPage6.Controls.Add((Control) this.label4);
      this.tabPage6.Controls.Add((Control) this.label5);
      this.tabPage6.Controls.Add((Control) this.label6);
      ((Control) this.tabPage6).Location = new Point(4, 22);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Size = new Size(480, 462);
      this.tabPage6.TabIndex = 5;
      this.tabPage6.Text = "Лаб. Роб. №6";
      this.label3.Location = new Point(48, 24);
      this.label3.Name = "label3";
      this.label3.Size = new Size(56, 23);
      this.label3.TabIndex = 6;
      this.label3.Text = "Датчик 1";
      this.TBLab6.Location = new Point(24, 184);
      this.TBLab6.Name = "TBLab6";
      this.TBLab6.Size = new Size(432, 256);
      this.TBLab6.ReadOnly = true;
      this.TBLab6.TabIndex = 5;
      this.TBLab6.Text = "\t\tЗавдання до лабораторної роботи.\n1. Організувати опитування датчиків, визначити значення вимірюваних величин по показам датчиків і в зручній для оператора формі представити результати опитування на пристрій індикації (номер каналу та значення вимірюваного параметра).\nРежим отримання даних з об'єкту реалізувати за допомогою адресного опитування датчиків. Визначити роздільну здатність та відносну погрішність n/# перетворювача.\n\n-----------------------------------------------\nПримітки до емулятора\nЗа функції аналогових давачів відповідають текстові поля розміщені на вкладці «Лаб. Робота №6». Для того щоб встановити значення, що буде зчитуватися з давача досить вписати його в відповідне поле( верхнє поле відповідає нульовому давачу, нижнє – третьому). Керуюче слово аналогового комутатора потрібно записувати в 3-й порт, в цьому випадку молодші два біти вкажуть номер давача, що опитується, а решта можуть мати будь-який стан. Результат опитування буде записаний в 4-й порт.\nПриклад програми циклічного опитування нульового давача і запису його значення в регістр А:\n8000  -  MVI   A, 00\n8002  -  OUT   03\n8004  -  IN       04\n8006  -  JMP    8004\n";
      this.analogIn0.Location = new Point(120, 24);
      this.analogIn0.MaxLength = 7;
      this.analogIn0.Name = "analogIn0";
      this.analogIn0.ScrollBars = ScrollBars.Vertical;
      this.analogIn0.Size = new Size(96, 20);
      this.analogIn0.TabIndex = 4;
      this.analogIn0.Text = "";
      this.analogIn1.Location = new Point(120, 64);
      this.analogIn1.MaxLength = 7;
      this.analogIn1.Name = "analogIn1";
      this.analogIn1.ScrollBars = ScrollBars.Vertical;
      this.analogIn1.Size = new Size(96, 20);
      this.analogIn1.TabIndex = 4;
      this.analogIn1.Text = "";
      this.analogIn2.Location = new Point(120, 104);
      this.analogIn2.MaxLength = 7;
      this.analogIn2.Name = "analogIn2";
      this.analogIn2.ScrollBars = ScrollBars.Vertical;
      this.analogIn2.Size = new Size(96, 20);
      this.analogIn2.TabIndex = 4;
      this.analogIn2.Text = "";
      this.analogIn3.Location = new Point(120, 144);
      this.analogIn3.MaxLength = 7;
      this.analogIn3.Name = "analogIn3";
      this.analogIn3.ScrollBars = ScrollBars.Vertical;
      this.analogIn3.Size = new Size(96, 20);
      this.analogIn3.TabIndex = 4;
      this.analogIn3.Text = "";
      this.label4.Location = new Point(48, 64);
      this.label4.Name = "label4";
      this.label4.Size = new Size(56, 23);
      this.label4.TabIndex = 6;
      this.label4.Text = "Датчик 2";
      this.label5.Location = new Point(48, 104);
      this.label5.Name = "label5";
      this.label5.Size = new Size(56, 23);
      this.label5.TabIndex = 6;
      this.label5.Text = "Датчик 3";
      this.label6.Location = new Point(48, 144);
      this.label6.Name = "label6";
      this.label6.Size = new Size(56, 23);
      this.label6.TabIndex = 6;
      this.label6.Text = "Датчик 4";
      this.ButtonNumC.Location = new Point(208, 32);
      this.ButtonNumC.Name = "ButtonNumC";
      this.ButtonNumC.Size = new Size(48, 40);
      this.ButtonNumC.TabIndex = 1;
      this.ButtonNumC.Text = "C";
      this.ButtonNumC.Click += new EventHandler(this.ButtonNumC_Click);
      this.ButtonNumD.Location = new Point(256, 32);
      this.ButtonNumD.Name = "ButtonNumD";
      this.ButtonNumD.Size = new Size(48, 40);
      this.ButtonNumD.TabIndex = 1;
      this.ButtonNumD.Text = "D";
      this.ButtonNumD.Click += new EventHandler(this.ButtonNumD_Click);
      this.ButtonNumE.Location = new Point(304, 32);
      this.ButtonNumE.Name = "ButtonNumE";
      this.ButtonNumE.Size = new Size(48, 40);
      this.ButtonNumE.TabIndex = 1;
      this.ButtonNumE.Text = "E";
      this.ButtonNumE.Click += new EventHandler(this.ButtonNumE_Click);
      this.ButtonNumF.Location = new Point(352, 32);
      this.ButtonNumF.Name = "ButtonNumF";
      this.ButtonNumF.Size = new Size(48, 40);
      this.ButtonNumF.TabIndex = 1;
      this.ButtonNumF.Text = "F";
      this.ButtonNumF.Click += new EventHandler(this.ButtonNumF_Click);
      this.ButtonNumA.Location = new Point(304, 72);
      this.ButtonNumA.Name = "ButtonNumA";
      this.ButtonNumA.Size = new Size(48, 40);
      this.ButtonNumA.TabIndex = 1;
      this.ButtonNumA.Text = "A";
      this.ButtonNumA.Click += new EventHandler(this.ButtonNumA_Click);
      this.ButtonNum9.Location = new Point(256, 72);
      this.ButtonNum9.Name = "ButtonNum9";
      this.ButtonNum9.Size = new Size(48, 40);
      this.ButtonNum9.TabIndex = 1;
      this.ButtonNum9.Text = "9";
      this.ButtonNum9.Click += new EventHandler(this.ButtonNum9_Click);
      this.ButtonNumB.Location = new Point(352, 72);
      this.ButtonNumB.Name = "ButtonNumB";
      this.ButtonNumB.Size = new Size(48, 40);
      this.ButtonNumB.TabIndex = 1;
      this.ButtonNumB.Text = "B";
      this.ButtonNumB.Click += new EventHandler(this.ButtonNumB_Click);
      this.ButtonNum8.Location = new Point(208, 72);
      this.ButtonNum8.Name = "ButtonNum8";
      this.ButtonNum8.Size = new Size(48, 40);
      this.ButtonNum8.TabIndex = 1;
      this.ButtonNum8.Text = "8";
      this.ButtonNum8.Click += new EventHandler(this.ButtonNum8_Click);
      this.ButtonNum6.Location = new Point(304, 112);
      this.ButtonNum6.Name = "ButtonNum6";
      this.ButtonNum6.Size = new Size(48, 40);
      this.ButtonNum6.TabIndex = 1;
      this.ButtonNum6.Text = "6";
      this.ButtonNum6.Click += new EventHandler(this.ButtonNum6_Click);
      this.ButtonNum3.Location = new Point(352, 152);
      this.ButtonNum3.Name = "ButtonNum3";
      this.ButtonNum3.Size = new Size(48, 40);
      this.ButtonNum3.TabIndex = 1;
      this.ButtonNum3.Text = "3";
      this.ButtonNum3.Click += new EventHandler(this.ButtonNum3_Click);
      this.ButtonNum4.Location = new Point(208, 112);
      this.ButtonNum4.Name = "ButtonNum4";
      this.ButtonNum4.Size = new Size(48, 40);
      this.ButtonNum4.TabIndex = 1;
      this.ButtonNum4.Text = "4";
      this.ButtonNum4.Click += new EventHandler(this.ButtonNum4_Click);
      this.ButtonNum7.Location = new Point(352, 112);
      this.ButtonNum7.Name = "ButtonNum7";
      this.ButtonNum7.Size = new Size(48, 40);
      this.ButtonNum7.TabIndex = 1;
      this.ButtonNum7.Text = "7";
      this.ButtonNum7.Click += new EventHandler(this.ButtonNum7_Click);
      this.ButtonNum0.Location = new Point(208, 152);
      this.ButtonNum0.Name = "ButtonNum0";
      this.ButtonNum0.Size = new Size(48, 40);
      this.ButtonNum0.TabIndex = 1;
      this.ButtonNum0.Text = "0";
      this.ButtonNum0.Click += new EventHandler(this.ButtonNum0_Click);
      this.ButtonNum5.Location = new Point(256, 112);
      this.ButtonNum5.Name = "ButtonNum5";
      this.ButtonNum5.Size = new Size(48, 40);
      this.ButtonNum5.TabIndex = 1;
      this.ButtonNum5.Text = "5";
      this.ButtonNum5.Click += new EventHandler(this.ButtonNum5_Click);
      this.ButtonNum1.Location = new Point(256, 152);
      this.ButtonNum1.Name = "ButtonNum1";
      this.ButtonNum1.Size = new Size(48, 40);
      this.ButtonNum1.TabIndex = 1;
      this.ButtonNum1.Text = "1";
      this.ButtonNum1.Click += new EventHandler(this.ButtonNum1_Click);
      this.ButtonNum2.Location = new Point(304, 152);
      this.ButtonNum2.Name = "ButtonNum2";
      this.ButtonNum2.Size = new Size(48, 40);
      this.ButtonNum2.TabIndex = 1;
      this.ButtonNum2.Text = "2";
      this.ButtonNum2.Click += new EventHandler(this.ButtonNum2_Click);
      this.But_UST_ADR.Location = new Point(32, 72);
      this.But_UST_ADR.Name = "But_UST_ADR";
      this.But_UST_ADR.Size = new Size(72, 40);
      this.But_UST_ADR.TabIndex = 1;
      this.But_UST_ADR.Text = "УСТ АД";
      this.But_UST_ADR.Click += new EventHandler(this.But_UST_ADR_Click);
      this.But_ZP.Location = new Point(104, 72);
      this.But_ZP.Name = "But_ZP";
      this.But_ZP.Size = new Size(72, 40);
      this.But_ZP.TabIndex = 1;
      this.But_ZP.Text = "ЗП";
      this.But_ZP.Click += new EventHandler(this.But_ZP_Click);
      this.But_PUSK.Location = new Point(104, 32);
      this.But_PUSK.Name = "But_PUSK";
      this.But_PUSK.Size = new Size(72, 40);
      this.But_PUSK.TabIndex = 1;
      this.But_PUSK.Text = "ПУСК";
      this.But_PUSK.Click += new EventHandler(this.But_PUSK_Click);
      this.But_VOZVRAT.Location = new Point(32, 32);
      this.But_VOZVRAT.Name = "But_VOZVRAT";
      this.But_VOZVRAT.Size = new Size(72, 40);
      this.But_VOZVRAT.TabIndex = 1;
      this.But_VOZVRAT.Text = "ВОЗВРАТ";
      this.But_VOZVRAT.Click += new EventHandler(this.But_VOZVRAT_Click);
      this.But_VUVOD.Cursor = Cursors.Default;
      //this.But_VUVOD.Enabled = false;
      //this.But_VUVOD.FlatStyle = FlatStyle.Flat;
      this.But_VUVOD.Location = new Point(104, 152);
      this.But_VUVOD.Name = "But_VUVOD";
      this.But_VUVOD.Size = new Size(72, 24);
      this.But_VUVOD.TabIndex = 1;
      this.But_VUVOD.Text = "ВЫВОД";
      this.But_VUVOD.Click += new EventHandler(this.But_VUVOD_Click);
      this.But_AD_MINUS.Location = new Point(104, 112);
      this.But_AD_MINUS.Name = "But_AD_MINUS";
      this.But_AD_MINUS.Size = new Size(72, 40);
      this.But_AD_MINUS.TabIndex = 1;
      this.But_AD_MINUS.Text = "АД--";
      this.But_AD_MINUS.Click += new EventHandler(this.But_AD_MINUS_Click);
      //this.But_VVOD.Enabled = false;// re purpose for reading Intel HEX into memory ASAP!!! 
      //this.But_VVOD.FlatStyle = FlatStyle.Flat;
      this.But_VVOD.Location = new Point(32, 152);
      this.But_VVOD.Name = "But_VVOD";
      this.But_VVOD.Size = new Size(72, 24);
      this.But_VVOD.TabIndex = 1;
      this.But_VVOD.Text = "ВВОД";
      this.But_VVOD.Click += new EventHandler(this.But_VVOD_Click);
      this.But_AD_PLUS.Location = new Point(32, 112);
      this.But_AD_PLUS.Name = "But_AD_PLUS";
      this.But_AD_PLUS.Size = new Size(72, 40);
      this.But_AD_PLUS.TabIndex = 1;
      this.But_AD_PLUS.Text = "АД++";
      this.But_AD_PLUS.Click += new EventHandler(this.But_AD_PLUS_Click);
      this.But_SBROS.Location = new Point(32, 176);
      this.But_SBROS.Name = "But_SBROS";
      this.But_SBROS.Size = new Size(144, 24);
      this.But_SBROS.TabIndex = 1;
      this.But_SBROS.Text = "СБРОС";
      this.But_SBROS.Click += new EventHandler(this.But_SBROS_Click);
      this.groupBox1.Controls.Add((Control) this.ButtonNumB);
      this.groupBox1.Controls.Add((Control) this.ButtonNum9);
      this.groupBox1.Controls.Add((Control) this.ButtonNumA);
      this.groupBox1.Controls.Add((Control) this.ButtonNumF);
      this.groupBox1.Controls.Add((Control) this.ButtonNumE);
      this.groupBox1.Controls.Add((Control) this.ButtonNumD);
      this.groupBox1.Controls.Add((Control) this.ButtonNumC);
      this.groupBox1.Controls.Add((Control) this.But_SBROS);
      this.groupBox1.Controls.Add((Control) this.But_VVOD);
      this.groupBox1.Controls.Add((Control) this.ButtonNum7);
      this.groupBox1.Controls.Add((Control) this.But_VUVOD);
      this.groupBox1.Controls.Add((Control) this.But_VOZVRAT);
      this.groupBox1.Controls.Add((Control) this.But_AD_PLUS);
      this.groupBox1.Controls.Add((Control) this.But_PUSK);
      this.groupBox1.Controls.Add((Control) this.But_ZP);
      this.groupBox1.Controls.Add((Control) this.But_UST_ADR);
      this.groupBox1.Controls.Add((Control) this.But_AD_MINUS);
      this.groupBox1.Controls.Add((Control) this.ButtonNum2);
      this.groupBox1.Controls.Add((Control) this.ButtonNum1);
      this.groupBox1.Controls.Add((Control) this.ButtonNum5);
      this.groupBox1.Controls.Add((Control) this.ButtonNum0);
      this.groupBox1.Controls.Add((Control) this.ButtonNum4);
      this.groupBox1.Controls.Add((Control) this.ButtonNum3);
      this.groupBox1.Controls.Add((Control) this.ButtonNum6);
      this.groupBox1.Controls.Add((Control) this.ButtonNum8);
      this.groupBox1.Location = new Point(496, 288);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(416, 216);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Клавіатура";
      this.groupBox2.Controls.Add((Control) this.IAR_D0);
      this.groupBox2.Controls.Add((Control) this.IAR_D1);
      this.groupBox2.Controls.Add((Control) this.IAR_D2);
      this.groupBox2.Controls.Add((Control) this.IAR_D3);
      this.groupBox2.Controls.Add((Control) this.IRD_D1);
      this.groupBox2.Controls.Add((Control) this.IRD_D0);
      this.groupBox2.Controls.Add((Control) this.IRD_D2);
      this.groupBox2.Controls.Add((Control) this.IRD_D3);
      this.groupBox2.Location = new Point(496, 8);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(416, 136);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Індикатори";
      this.groupBox2.Enter += new EventHandler(this.groupBox2_Enter);
      this.IAR_D0.Location = new Point(8, 32);
      this.IAR_D0.Name = "IAR_D0";
      this.IAR_D0.Size = new Size(40, 88);
      this.IAR_D0.TabIndex = 0;
      this.IAR_D1.Location = new Point(56, 32);
      this.IAR_D1.Name = "IAR_D1";
      this.IAR_D1.Size = new Size(40, 88);
      this.IAR_D1.TabIndex = 0;
      this.IAR_D2.Location = new Point(104, 32);
      this.IAR_D2.Name = "IAR_D2";
      this.IAR_D2.Size = new Size(40, 88);
      this.IAR_D2.TabIndex = 0;
      this.IAR_D3.Location = new Point(152, 32);
      this.IAR_D3.Name = "IAR_D3";
      this.IAR_D3.Size = new Size(40, 88);
      this.IAR_D3.TabIndex = 0;
      this.IRD_D1.Location = new Point(272, 32);
      this.IRD_D1.Name = "IRD_D1";
      this.IRD_D1.Size = new Size(40, 88);
      this.IRD_D1.TabIndex = 0;
      this.IRD_D0.Location = new Point(224, 32);
      this.IRD_D0.Name = "IRD_D0";
      this.IRD_D0.Size = new Size(40, 88);
      this.IRD_D0.TabIndex = 0;
      this.IRD_D2.Location = new Point(320, 32);
      this.IRD_D2.Name = "IRD_D2";
      this.IRD_D2.Size = new Size(40, 88);
      this.IRD_D2.TabIndex = 0;
      this.IRD_D3.Location = new Point(368, 32);
      this.IRD_D3.Name = "IRD_D3";
      this.IRD_D3.Size = new Size(40, 88);
      this.IRD_D3.TabIndex = 0;
      this.cDigit8.Location = new Point(0, 0);
      this.cDigit8.Name = "cDigit8";
      this.cDigit8.Size = new Size(40, 88);
      this.cDigit8.TabIndex = 0;
      this.cDigit9.Location = new Point(0, 0);
      this.cDigit9.Name = "cDigit9";
      this.cDigit9.Size = new Size(40, 88);
      this.cDigit9.TabIndex = 0;
      this.cDigit6.Location = new Point(0, 0);
      this.cDigit6.Name = "cDigit6";
      this.cDigit6.Size = new Size(48, 88);
      this.cDigit6.TabIndex = 0;
      this.cDigit7.Location = new Point(0, 0);
      this.cDigit7.Name = "cDigit7";
      this.cDigit7.Size = new Size(48, 88);
      this.cDigit7.TabIndex = 0;
      this.TBRegisterVals.Location = new Point(712, 168);
      this.TBRegisterVals.Multiline = true;
      this.TBRegisterVals.Name = "TBRegisterVals";
      this.TBRegisterVals.ReadOnly = true;
      this.TBRegisterVals.ScrollBars = ScrollBars.Vertical;
      this.TBRegisterVals.Size = new Size(176, 112);
      this.TBRegisterVals.TabIndex = 4;
      this.TBRegisterVals.Text = "";
      this.TBFlags.Location = new Point(512, 168);
      this.TBFlags.Multiline = true;
      this.TBFlags.Name = "TBFlags";
      this.TBFlags.ReadOnly = true;
      this.TBFlags.ScrollBars = ScrollBars.Vertical;
      this.TBFlags.Size = new Size(176, 112);
      this.TBFlags.TabIndex = 4;
      this.TBFlags.Text = "";
      this.label1.Location = new Point(752, 152);
      this.label1.Name = "label1";
      this.label1.Size = new Size(88, 16);
      this.label1.TabIndex = 5;
      this.label1.Text = "Вміст регістрів";
      this.label2.Location = new Point(560, 152);
      this.label2.Name = "label2";
      this.label2.Size = new Size(64, 16);
      this.label2.TabIndex = 5;
      this.label2.Text = "Прапорці";
      this.PPI.Location = new Point(16, 16);
      this.PPI.Name = "PPI";
      this.PPI.Size = new Size(216, 296);
      this.PPI.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(912, 518);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.TBRegisterVals);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.TabLabsControl);
      this.Controls.Add((Control) this.TBFlags);
      this.Controls.Add((Control) this.label2);
      this.Name = nameof (ProgramLogic);
      this.Text = "Емулятор Мікролаб КР580ИК80";
      this.Load += new EventHandler(this.Form1_Load);
      this.TabLabsControl.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.tabPage4.ResumeLayout(false);
      this.tabPage5.ResumeLayout(false);
      this.tabPage6.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
 
    }


    [STAThread]
    private static void Main()
    {
      Application.Run((Form) new ProgramLogic());
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.memory = new CMemory(ref this.PPI);
      this.interpreter = new CInterpreter(ref this.memory);
      this.PPI.setMemory(ref this.memory);
      this.LeftIAR.reset();
      this.RightIRD.reset();
      this.redrawDigits();
      //Timer timer = new Timer();
      //timer.Interval = 100;
      //timer.Tick += new EventHandler(this.OnTimerTick);
      //timer.Start();
      this.showRegsAndFlags();
      interpreter.PLRoutine = this;
      CLabWorks.Init();
      openFileDialog1 = new OpenFileDialog();
      //memory.setMemoryValue(0x8200, 0xF, 0xA);
    }
    
        public void OuputMemory()
        {
            
            //OFForm.Close();

            string Message = "";
            //int iMemStart = Convert.ToInt32(this.LeftIAR.ToString(), 16);
            int iMemStart = CMemory.HexToInt( this.LeftIAR.getHexString());
            int iMemEnd = iMemStart + 15;
            int S = new int();
            int L = new int();
            for (;iMemStart<=iMemEnd;iMemStart++)
            {
                memory.getMemoryValue(iMemStart, ref S, ref L);
                Message += (iMemStart.ToString("X4") + " - " + S.ToString("X") + L.ToString("X") + "\r\n");

            }
            MessageBox.Show(Message);

        }

    private void OnTimerTick(object obj, EventArgs ea)
    {
            //this.interpreter.interpretCurCommand();
            //this.showRegsAndFlags();


            //string text;
            //switch (this.interpreter.getMemory(253) & 3)
            //{
            //    case 0:
            //        text = this.analogIn0.Text;
            //        break;
            //    case 1:
            //        text = this.analogIn1.Text;
            //        break;
            //    case 2:
            //        text = this.analogIn2.Text;
            //        break;
            //    default:
            //        text = this.analogIn3.Text;
            //        break;
            //}
            //string[] strArray = text.Split('.');
            //double num = strArray.Length != 1 ? (strArray[0].Length != 0 ? Convert.ToDouble(strArray[0]) : 0.0) + (strArray[1].Length != 0 ? Convert.ToDouble(strArray[1]) * Math.Pow(10.0, (double)-strArray[1].Length) : 0.0) : (text.Length != 0 ? Convert.ToDouble(text) : 0.0);
            //if (num > 10.0)
            //    num = 10.0;
            //if (num < 0.0)
            //    num = 0.0;
            //this.interpreter.setMemory(254, (int)(num * (double)byte.MaxValue / 10.0));
        }

    private void ButtonNum0_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(0);
      this.RightIRD.addDigit(0);
      this.redrawDigits();
    }

    private void ButtonNum1_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(1);
      this.RightIRD.addDigit(1);
      this.redrawDigits();
    }

    private void ButtonNum2_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(2);
      this.RightIRD.addDigit(2);
      this.redrawDigits();
    }

    private void ButtonNum3_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(3);
      this.RightIRD.addDigit(3);
      this.redrawDigits();
    }

    private void ButtonNum4_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(4);
      this.RightIRD.addDigit(4);
      this.redrawDigits();
    }

    private void ButtonNum5_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(5);
      this.RightIRD.addDigit(5);
      this.redrawDigits();
    }

    private void ButtonNum6_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(6);
      this.RightIRD.addDigit(6);
      this.redrawDigits();
    }

    private void ButtonNum7_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(7);
      this.RightIRD.addDigit(7);
      this.redrawDigits();
    }

    private void ButtonNum8_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(8);
      this.RightIRD.addDigit(8);
      this.redrawDigits();
    }

    private void ButtonNum9_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(9);
      this.RightIRD.addDigit(9);
      this.redrawDigits();
    }

    private void ButtonNumA_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(10);
      this.RightIRD.addDigit(10);
      this.redrawDigits();
    }

    private void ButtonNumB_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(11);
      this.RightIRD.addDigit(11);
      this.redrawDigits();
    }

    private void ButtonNumC_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(12);
      this.RightIRD.addDigit(12);
      this.redrawDigits();
    }

    private void ButtonNumD_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(13);
      this.RightIRD.addDigit(13);
      this.redrawDigits();
    }

    private void ButtonNumE_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(14);
      this.RightIRD.addDigit(14);
      this.redrawDigits();
    }

    private void ButtonNumF_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(15);
      this.RightIRD.addDigit(15);
      this.redrawDigits();
    }

    private void But_VOZVRAT_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(17);
      this.interpreter.bProgExecuted = false;
    }

    private void But_PUSK_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(16);
      this.LeftIAR.getHexString().Equals("0001");
      if (this.LeftIAR.getHexString().Equals("0300"))
      {
        this.LR1SoundLabel.Visible = true;
        CLabWorks.Lab1_StartSound();
        this.memory.randomiseRegisters();
        this.LR1SoundLabel.Visible = false;
      }
      else if (this.LeftIAR.getHexString().Equals("0400"))
      {
       interpreter.Delay();
      }
      else
      {
        this.interpreter.bProgExecuted = true;
        // g  
        this.interpreter.run(CMemory.HexToInt(this.LeftIAR.getHexString()));
                this.interpreter.interpretCurCommand();
                //if (CInterpreterT != null)
                //{
                //    if (!CInterpreterT.IsAlive)
                //    {
                //        CInterpreterT = new Thread(interpreter.interpretCurCommand);
                //        CInterpreterT.Start();
                //    }
                //}
                //else
                //{
                //    CInterpreterT = new Thread(interpreter.interpretCurCommand);
                //    CInterpreterT.Start();
                //}
                //string text;
                //switch (this.interpreter.getMemory(253) & 3)
                //{
                //    case 0:
                //        text = this.analogIn0.Text;
                //        break;
                //    case 1:
                //        text = this.analogIn1.Text;
                //        break;
                //    case 2:
                //        text = this.analogIn2.Text;
                //        break;
                //    default:
                //        text = this.analogIn3.Text;
                //        break;
                //}
                //string[] strArray = text.Split('.');
                //double num = strArray.Length != 1 ? (strArray[0].Length != 0 ? Convert.ToDouble(strArray[0]) : 0.0) + (strArray[1].Length != 0 ? Convert.ToDouble(strArray[1]) * Math.Pow(10.0, (double)-strArray[1].Length) : 0.0) : (text.Length != 0 ? Convert.ToDouble(text) : 0.0);
                //if (num > 10.0)
                //    num = 10.0;
                //if (num < 0.0)
                //    num = 0.0;
                //this.interpreter.setMemory(254, (int)(num * (double)byte.MaxValue / 10.0));
            }
      this.showRegsAndFlags();
    }
       
    public void showRegsAndFlags()
    {
      this.TBRegisterVals.Text = "A = " + this.memory.getRegister(7).ToString("X2");
      TextBox tbRegisterVals1 = this.TBRegisterVals;
      string str1 = tbRegisterVals1.Text + "\r\nB = " + this.memory.getRegister(0).ToString("X2");
      tbRegisterVals1.Text = str1;
      TextBox tbRegisterVals2 = this.TBRegisterVals;
      string str2 = tbRegisterVals2.Text + "\r\nC = " + this.memory.getRegister(1).ToString("X2");
      tbRegisterVals2.Text = str2;
      TextBox tbRegisterVals3 = this.TBRegisterVals;
      string str3 = tbRegisterVals3.Text + "\r\nD = " + this.memory.getRegister(2).ToString("X2");
      tbRegisterVals3.Text = str3;
      TextBox tbRegisterVals4 = this.TBRegisterVals;
      string str4 = tbRegisterVals4.Text + "\r\nE = " + this.memory.getRegister(3).ToString("X2");
      tbRegisterVals4.Text = str4;
      TextBox tbRegisterVals5 = this.TBRegisterVals;
      string str5 = tbRegisterVals5.Text + "\r\nH = " + this.memory.getRegister(4).ToString("X2");
      tbRegisterVals5.Text = str5;
      TextBox tbRegisterVals6 = this.TBRegisterVals;
      string str6 = tbRegisterVals6.Text + "\r\nL = " + this.memory.getRegister(5).ToString("X2");
      tbRegisterVals6.Text = str6;
      TextBox tbRegisterVals7 = this.TBRegisterVals;
      string str7 = tbRegisterVals7.Text + "\r\nM = " + this.memory.getRegister(6).ToString("X2");
      tbRegisterVals7.Text = str7;
      this.TBFlags.Text = "AC= " + (object) this.memory.flagReg.AC;
      TextBox tbFlags1 = this.TBFlags;
      string str8 = tbFlags1.Text + "\r\nC  = " + (object) this.memory.flagReg.C;
      tbFlags1.Text = str8;
      TextBox tbFlags2 = this.TBFlags;
      string str9 = tbFlags2.Text + "\r\nP  = " + (object) this.memory.flagReg.P;
      tbFlags2.Text = str9;
      TextBox tbFlags3 = this.TBFlags;
      string str10 = tbFlags3.Text + "\r\nS  = " + (object) this.memory.flagReg.S;
      tbFlags3.Text = str10;
      TextBox tbFlags4 = this.TBFlags;
      string str11 = tbFlags4.Text + "\r\nZ  = " + (object) this.memory.flagReg.Z;
      tbFlags4.Text = str11;
    }

    private void But_UST_ADR_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(18);
      this.LeftIAR.copyIndicator(this.RightIRD);
      string hexString = this.RightIRD.getHexString();
      int signifDigit = 0;
      int loverDigit = 0;
      this.memory.getMemoryValue(hexString, ref signifDigit, ref loverDigit);
      this.RightIRD.addTwoDigits(signifDigit, loverDigit);
      this.redrawDigits();
    }

    private void But_ZP_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(21);
      if (!this.memory.isClientRegion(this.LeftIAR.getHexString()))
      {
        this.Alert("Не можна записувати дані в ПЗП.");
      }
      else
      {
        int signifDigit = 0;
        int loverDigit = 0;
        this.RightIRD.getValue(ref signifDigit, ref loverDigit);
        this.memory.setMemoryValue(this.LeftIAR.getHexString(), signifDigit, loverDigit);
        this.LeftIAR.incrementAddress();
        this.redrawDigits();
      }
    }

    private void But_AD_PLUS_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(20);
      this.LeftIAR.incrementAddress();
      string hexString = this.LeftIAR.getHexString();
      int signifDigit = 0;
      int loverDigit = 0;
      this.memory.getMemoryValue(hexString, ref signifDigit, ref loverDigit);
      this.RightIRD.addTwoDigits(signifDigit, loverDigit);
      this.redrawDigits();
    }

    private void But_AD_MINUS_Click(object sender, EventArgs e)
    {
      this.PPI.onBtnPressed(19);
      this.LeftIAR.decrementAddress();
      string hexString = this.LeftIAR.getHexString();
      int signifDigit = 0;
      int loverDigit = 0;
      this.memory.getMemoryValue(hexString, ref signifDigit, ref loverDigit);
      this.RightIRD.addTwoDigits(signifDigit, loverDigit);
      this.redrawDigits();
    }

    private void But_VVOD_Click(object sender, EventArgs e)
    {
            //openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                // MessageBox.Show(sr.ReadToEnd());
                IntelHEX = sr.ReadToEnd();
                sr.Close();
                //memory.setMemoryValue(0x8200, 0xF, 0xA);
                int iLenghtMAX = IntelHEX.Length;
                int iMemPosHex = 0;
                int iLenght = 0;
                String sTempHexValue;
                int iStringStart = 0;
                bool bStringEnd = false;
                while (!bStringEnd)
                {
                    if (IntelHEX[iStringStart] == ':')
                    {
                        iStringStart++;

                            sTempHexValue = IntelHEX.Substring(iStringStart, 2);

                            iLenght = Convert.ToInt32(sTempHexValue, 16);


                        iStringStart+= 2;
                        sTempHexValue = IntelHEX.Substring(iStringStart, 4);
                        iMemPosHex = Convert.ToInt32(sTempHexValue, 16);
                    
                        iStringStart += 6;
                        sTempHexValue = IntelHEX.Substring(iStringStart, iLenght * 2);
                        
                        iStringStart += iLenght * 2 + 1;
                        if (iStringStart + 1 < IntelHEX.Length)
                        {

                            iStringStart++;
                        }
                        else
                        {
                            bStringEnd = true;
                        }
                        if (iLenght == 0)
                        {
                            bStringEnd = true;
                            continue;
                        }
                        for (int index = 0; index < iLenght; index++)
                        {
                           
                            memory.setMemoryValue(iMemPosHex+index, Convert.ToInt32(sTempHexValue[index * 2].ToString(), 16), Convert.ToInt32(sTempHexValue[index * 2 + 1].ToString(), 16));
                        }


                    }
                    else
                    {
                        bStringEnd = true;
                    }
                }
                string hexString = this.LeftIAR.getHexString();
                int signifDigit = 0;
                int loverDigit = 0;
                this.memory.getMemoryValue(hexString, ref signifDigit, ref loverDigit);
                this.RightIRD.addTwoDigits(signifDigit, loverDigit);
                this.redrawDigits();
            }
        }

    private void But_VUVOD_Click(object sender, EventArgs e)
    {
            this.OuputMemory();
    }

    private void But_SBROS_Click(object sender, EventArgs e)
    {
            //CLabWorks.SPPlayer.Stop();
      this.interpreter.bProgExecuted = false;
      this.LeftIAR.reset();
      this.RightIRD.reset();
      this.redrawDigits();
    }

    public void redrawDigits()
    {
      this.DrawLeftIAR();
      this.DrawRightIRD();
    }

    private void DrawLeftIAR()
    {
      this.IAR_D0.setDigit(this.LeftIAR.digit0);
      this.IAR_D1.setDigit(this.LeftIAR.digit1);
      this.IAR_D2.setDigit(this.LeftIAR.digit2);
      this.IAR_D3.setDigit(this.LeftIAR.digit3);
      this.showRegsAndFlags();
    }

    private void DrawRightIRD()
    {
      this.IRD_D0.setDigit(this.RightIRD.digit0);
      this.IRD_D1.setDigit(this.RightIRD.digit1);
      this.IRD_D2.setDigit(this.RightIRD.digit2);
      this.IRD_D3.setDigit(this.RightIRD.digit3);
      this.showRegsAndFlags();
    }

    private void Alert(string message)
    {
      int num = (int) MessageBox.Show(message, "Emulator.ProgramLogic.AlertMessage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void groupBox2_Enter(object sender, EventArgs e)
    {
    }
  }
}
