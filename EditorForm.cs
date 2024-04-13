using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MyCreate
{
    public enum Color_Num
    {
        WHITE = 0,
        BLUE = 1,
        YELLOW = 2,
        GREEN = 3,
        RED = 4,
    }



    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

        }
        //string moji;
        public Dictionary<Color_Num, System.Drawing.Color> ColorList;
       

        string[] alph = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        
        string[] Alph = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        Dictionary<string, int> alph_List;
        Dictionary<string, int> Alph_List;
      
        Dictionary<string, string> SplitAry;

        string[] txtList;

        #region -------------【 ロード   】---------------------------------------//
        private void Form1_Load(object sender, EventArgs e)
        {
            txtList = new string[3];
            SplitAry = new Dictionary<string, string>();

            alph_List = new Dictionary<string, int>(){{ "a", 0 },{ "b",1 },{ "c", 2 },{ "d",3 },{ "e" ,4}, {"f",5 },{ "g" ,6}, {"h",7 },{ "i", 8}, {"j",9 }, { "k" ,10},
                                                                            { "l",11 }, { "m", 12 },{ "n",13 }, { "o", 14 }, {"p",15 }, { "q",16 }, {"r",17 }, { "s",18 }, {"t",19 }, { "u", 20 },
                                                                            {"v",21 }, { "w",22 }, {"x",23 }, { "y",24 }, {"z",25 }
                                                        };

            Alph_List = new Dictionary<string, int>(){{ "A", 0 },{ "B",1 },{ "C", 2 },{ "D",3 },{ "E" ,4}, {"F",5 },{ "G" ,6}, {"H",7 },{ "I", 8}, {"J",9 }, { "K" ,10},
                                                                            { "L",11 }, { "M", 12 },{ "N",13 }, { "O", 14 }, {"P",15 }, { "Q",16 }, {"R",17 }, { "S",18 }, {"T",19 }, { "U", 20 },
                                                                            {"V",21 }, { "W",22 }, {"X",23 }, { "Y",24 }, {"Z",25 }
                                                        };

            ColorList = new Dictionary<Color_Num, System.Drawing.Color>();
            ColorList.Add(Color_Num.WHITE, System.Drawing.Color.White);
            ColorList.Add(Color_Num.BLUE, System.Drawing.Color.Blue);
            ColorList.Add(Color_Num.YELLOW, System.Drawing.Color.Yellow);
            ColorList.Add(Color_Num.GREEN, System.Drawing.Color.Green);
            ColorList.Add(Color_Num.RED, System.Drawing.Color.Red);

            dataGridView1.AutoResizeColumns();
            dataGridView2.AutoResizeColumns();
            dataGridView3.AutoResizeColumns();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView_sub.AllowUserToAddRows = false;
            dataGridView_sub.AutoResizeColumns();

            dataGridView_sub.ColumnHeadersVisible = false;

            comboBox1.SelectedIndex = 4;
            comboBox2.SelectedIndex = 4;
            comboBox3.SelectedIndex = 4;

            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView_sub.RowHeadersVisible = false;
        }   
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 Showイベント   】---------------------------------------//
        private void EditorForm_Shown(object sender, EventArgs e) {
            string[] ary = Text_IO.TextListRead(Exe_Path.exe_Path() + @"split\split.txt");

            comboSplit.Items.Add("  none");

            foreach(string s in ary) {
                char[] ch = new char[] { '@' };
                string[] coulm = s.Split(ch);

                comboSplit.Items.Add("  "+coulm[0]+"  "+coulm[1]);
                SplitAry.Add("  " + coulm[0] + "  " + coulm[1], coulm[0]);
            }
            comboSplit.SelectedIndex = comboSplit.Items.Count - 1;
        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region -------------【 ボタンクリック 貼り付け  】---------------------------------------//
        #region -------------【  貼り付けボタン1  】---------------------------------------//
        private void buttonPASTE1_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null)
            {

                if (data.GetDataPresent(typeof(string)))
                {
                    txtList[0] = Clipboard.GetText();//クリップボードゲット
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("String型に変換出来ません");
                    return;
                }
            }

            int count = txtList[0].Length;


            dataGridView1.ColumnCount=count;

            for (int i=0;i<count;i++) 
            {
                dataGridView1.Rows[0].Cells[i].Value = txtList[0][i].ToString();
                dataGridView1.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.White;
            }

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dataGridView1.RowCount > 0) { button_Enter1.Enabled = true; }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 貼り付けボタン2   】---------------------------------------//
        private void button_PASTE2_Click(object sender, EventArgs e) {
           string moji = "";
         

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null) {

                if (data.GetDataPresent(typeof(string))) {
                    moji = Clipboard.GetText();//クリップボードゲット
                } else {
                    System.Windows.Forms.MessageBox.Show("String型に変換出来ません");
                    return;
                }
            }

            int count = moji.Length;


            dataGridView2.ColumnCount = count;

            for (int i = 0; i < count; i++) {
                dataGridView2.Rows[0].Cells[i].Value = moji[i].ToString();
                dataGridView2.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.White;
            }

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dataGridView2.RowCount > 0) { buttonEnter2.Enabled = true; }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  貼り付けボタン3  】---------------------------------------//
        private void button_PASTE3_Click(object sender, EventArgs e) {
           string moji = "";

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null) {

                if (data.GetDataPresent(typeof(string))) {
                    moji = Clipboard.GetText();//クリップボードゲット
                    
                } else {
                    System.Windows.Forms.MessageBox.Show("String型に変換出来ません");
                    return;
                }
            }

            TextBox textBox1 = new TextBox();
            textBox1.Text = moji;

            int textBox_LineCount = textBox1.Lines.Length;

            string[] textLines = textBox1.Lines;

            int MaxLength = textLines[0].Length;
            foreach (string s in textLines) {
                if(MaxLength< s.Length) {
                    MaxLength = s.Length;
                }
            }

            if (MaxLength >= 655) {
                MessageBox.Show("文字数が655を超えています(FillWidthを65535超えている)");
                return;
            }

            dataGridView3.ColumnCount = MaxLength;
            dataGridView3.RowCount = textBox_LineCount;

            for (int i = 0; i < textBox_LineCount; i++) {
                for (int j=0;j<textLines[i].Length;j++) {
                    dataGridView3.Rows[i].Cells[j].Value = textLines[i][j].ToString();
                    dataGridView3.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                }
            }



            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

             if (dataGridView3.RowCount > 0&& dataGridView_sub.RowCount>0) { buttonEnter3.Enabled = true; }
        }
        //-------------------------------//

        private void btn_Cripbtn3_Click(object sender, EventArgs e) {
           string moji = "";

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null) {

                if (data.GetDataPresent(typeof(string))) {
                    moji = Clipboard.GetText();//クリップボードゲット

                } else {
                    System.Windows.Forms.MessageBox.Show("String型に変換出来ません");
                    return;
                }
            }

            int count = moji.Length;


            dataGridView_sub.ColumnCount = count;

            for (int i = 0; i < count; i++) {
                dataGridView_sub.Rows[0].Cells[i].Value = moji[i].ToString();
                dataGridView_sub.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.White;
            }

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            dataGridView_sub.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            dataGridView_sub.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dataGridView3.RowCount > 0 && dataGridView_sub.RowCount > 0) { buttonEnter3.Enabled = true; }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (button_Right_Left.Text == "右側") {
                button_Right_Left.Text = "左側";
                button_Right_Left.BackColor = Color.Olive;
            } else {
                button_Right_Left.Text = "右側";
                button_Right_Left.BackColor = Color.Plum;
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        //------------    【   末尾  】     ----------------//
        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();//選択解除
        }



        #region -------------【  実行 ボタン  】---------------------------------------//
        #region -------------【  ボタン１  】---------------------------------------//
        private void buttonEnter1_Click(object sender, EventArgs e){
            if (dataGridView1.RowCount <= 0) { return; }

            int count = dataGridView1.Columns.Count;
            int num = (int)numericUpDown1.Value;


            dataGridView1.RowCount = num;


            //------------------------------------------------//
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[j].Style.BackColor;
                    dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[j].Value.ToString();
                }
            }
            //-------------------------------------------------//

            

            for (int i = 0; i < num; i++)
            {

                for (int j = 0; j < count; j++)
                {
                    #region -------------【  白色  】---------------------------------------//
                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.WHITE])
                    {

                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion

                    #region -------------【  青色　小文字　アルファベット  】---------------------------------------//

                    else if (dataGridView1.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.BLUE])
                    {
                        dataGridView1.Rows[i].Cells[j].Value = alphabet(txtList[0][j].ToString(), i);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion


                    #region -------------【  黄色 大文字　アルファベット  】---------------------------------------//
                    else if (dataGridView1.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.YELLOW])
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Alphabet(txtList[0][j].ToString(), i);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion


                    #region -------------【  緑色 数値　デクリメント 】---------------------------------------//
                    else if (dataGridView1.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.GREEN])
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Number_str(txtList[0][j].ToString(), -i, j);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion

                    #region -------------【  赤色 数値　インクリメント 】---------------------------------------//
                    else if (dataGridView1.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.RED])
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Number_str(txtList[0][j].ToString(), i, j);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion
                }
            }

            sum_text(dataGridView1,1);
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  ボタン2  】---------------------------------------//
        private void buttonEnter2_Click(object sender, EventArgs e) {

            if (dataGridView2.RowCount <= 0) { return; }

            int count = dataGridView2.Columns.Count;
            int num = (int)numericUpDown2.Value;

            dataGridView2.RowCount = num;

            //------------------------------------------------//
            for (int i = 0; i < num; i++) {
                for (int j = 0; j < count; j++) {
                    dataGridView2.Rows[i].Cells[j].Style.BackColor = dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[j].Style.BackColor;
                    dataGridView2.Rows[i].Cells[j].Value = dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[j].Value.ToString();
                }
            }
            //-------------------------------------------------//
            for (int i = 0; i < num; i++) {

                for (int j = 0; j < count; j++) {
                    #region -------------【  白色  】---------------------------------------//
                    if (dataGridView2.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.WHITE]) {
                        //dataGridView2.Rows[i].Cells[j].Value = dataGridView2.Rows[i].Cells[j].ToString();
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion

                    #region -------------【  青色　小文字　アルファベット  】---------------------------------------//

                    else if (dataGridView2.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.BLUE]) {
                        dataGridView2.Rows[i].Cells[j].Value = alphabet(dataGridView2.Rows[i].Cells[j].ToString(), i);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion


                    #region -------------【  黄色 大文字　アルファベット  】---------------------------------------//
                    else if (dataGridView2.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.YELLOW]) {
                        dataGridView2.Rows[i].Cells[j].Value = Alphabet(dataGridView2.Rows[i].Cells[j].ToString(), i);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion


                    #region -------------【  緑色 数値　デクリメント 】---------------------------------------//
                    else if (dataGridView2.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.GREEN]) {
                        dataGridView2.Rows[i].Cells[j].Value = Number_str(dataGridView2.Rows[i].Cells[j].ToString(), -i, j);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion

                    #region -------------【  赤色 数値　インクリメント 】---------------------------------------//
                    else if (dataGridView2.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.RED]) {
                        dataGridView2.Rows[i].Cells[j].Value = Number_str(dataGridView2.Rows[i].Cells[j].ToString(), i, j);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion
                }
            }
            sum_text(dataGridView2,2);

        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  ボタン3  】---------------------------------------//
        private void buttonEnter3_Click(object sender, EventArgs e) {
            if (dataGridView3.RowCount <= 0) { return; }
            ResultBox3.Text = "";
            int count = dataGridView3.Columns.Count;

            for (int i = 0; i <dataGridView3.Rows.Count; i++) {

                string Line = "";

                if (button_Right_Left.Text == "右側") {
                    //MessageBox.Show("右側");
                    Line += DataGrid_HANTEI(dataGridView_sub, i);
                }
                //MessageBox.Show(Line);

                for (int j = 0; j < count; j++) {
                    #region -------------【  白色  】---------------------------------------//
                    if (dataGridView3.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.WHITE]) {
                        Line+=dataGridView3.Rows[i].Cells[j].Value.ToString();
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion

                    #region -------------【  青色　小文字　アルファベット  】---------------------------------------//

                    else if (dataGridView3.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.BLUE]) {
                        Line+= alphabet(dataGridView3.Rows[i].Cells[j].Value.ToString(), i);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion


                    #region -------------【  黄色 大文字　アルファベット  】---------------------------------------//
                    else if (dataGridView3.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.YELLOW]) {
                        Line+= Alphabet(dataGridView3.Rows[i].Cells[j].Value.ToString(), i);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion


                    #region -------------【  緑色 数値　デクリメント 】---------------------------------------//
                    else if (dataGridView3.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.GREEN]) {
                        Line+= Number_str(dataGridView3.Rows[i].Cells[j].Value.ToString(), -i, j);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion

                    #region -------------【  赤色 数値　インクリメント 】---------------------------------------//
                    else if (dataGridView3.Rows[i].Cells[j].Style.BackColor == ColorList[Color_Num.RED]) {
                        Line += Number_str(dataGridView3.Rows[i].Cells[j].Value.ToString(), i, j);
                    }
                    //------------    【   末尾  】     ----------------//
                    #endregion
                }

                if (button_Right_Left.Text == "左側") {
                    //MessageBox.Show("左側");
                    Line += DataGrid_HANTEI(dataGridView_sub, i);
                }

                if (i == dataGridView3.RowCount) {
                    ResultBox3.Text += Line;
                } else {
                    ResultBox3.Text += (System.Environment.NewLine + Line);
                }
            }

            tabControl3.SelectedIndex = 1;
            //sum_text(dataGridView3,3);
        }
        //------------    【   末尾  】     ----------------//
        #endregion
        //------------    【   末尾  】     ----------------//
        #endregion


        private string Number_str(string moji,int Row_num,int Colum_num)
        {
            int num;
            //MessageBox.Show(moji);
            if (int.TryParse(moji, out num))
            {
                //MessageBox.Show(Row_num+":Row");
                num +=Row_num;
                return num.ToString();
            }
            else 
            {
                return moji;
            }
        }


        private void Is_Number(int Row_num, int Colum_num)
        {
            int num;

            if (int.TryParse(dataGridView1.Rows[Row_num].Cells[Colum_num].Value.ToString(), out num) &&
             dataGridView1.Rows[Row_num].Cells[Colum_num].Style.BackColor == System.Drawing.Color.Red)
            {

            }
            else
            {
                
            }
        }



        private string Alphabet(string moji,int Row_num) 
        {
                if (Alph_List.ContainsKey(moji)) {
                    int reslt = Alph_List[moji] + Row_num;

                    while (reslt >= 26) {
                        reslt = reslt % 26;
                    }

                return Alph[reslt];
                }
            return moji;
        }

        private string alphabet(string moji,int Row_num)
        {
                if (alph_List.ContainsKey(moji))
                {
                    int reslt = alph_List[moji]+Row_num;

                    while (reslt >= 26) {
                        reslt = reslt % 26;
                    }
                    return alph[reslt];
                }

            return moji;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string moji = InputBox1.Text;

            int count = moji.Length;


            dataGridView1.ColumnCount = count;

            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = moji[i].ToString();
                dataGridView1.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.White;
            }

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            tabControl1.SelectedIndex = 0;
            if (dataGridView1.RowCount > 0) { button_Enter1.Enabled = true; }
        }


        #region -------------【  文字の集計メソッド  】---------------------------------------//
        private void sum_text(DataGridView dataGrid,int num)
        {
            string moji_sum = "";

            switch (num) {

                case 1:
                    for (int i = 0; i < dataGrid.RowCount; i++) {
                        for (int j = 0; j < dataGrid.ColumnCount; j++) {
                            moji_sum += dataGrid.Rows[i].Cells[j].Value.ToString();
                        }

                        if ((dataGrid.RowCount-1) > i) {
                            moji_sum += System.Environment.NewLine;
                        }
                    }

                    ResultBox1.Text = moji_sum;
                    tabControl1.SelectedIndex = 1;
                    break;

                case 2:
                    //MessageBox.Show(dataGrid.RowCount+"個");
                    ResultBox2.Text = "";
                    for (int i = 0; i < dataGrid.RowCount; i++) {
                        string row_ = "";

                        for (int j = 0; j < dataGrid.ColumnCount; j++) {
                            row_ += dataGrid.Rows[i].Cells[j].Value.ToString();
                        }
                        //MessageBox.Show(row_);

                        if ((dataGrid.RowCount-1) > i) {

                            switch (comboSplit.SelectedIndex) {
                                case 0:
                                    break;
                                default:
                                    row_ +=(SplitAry[comboSplit.Text]);
                                    break;
                            }
                        }
                        ResultBox2.Text += row_;
                    }

                    tabControl2.SelectedIndex = 1;
                    break;
            }

        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region -------------【  クリアボタン  】---------------------------------------//
        private void buttonClear1_Click(object sender, EventArgs e) {
            dataGridView1.Rows.Clear();
            button_Enter1.Enabled = false;
        }

        private void buttonClear2_Click(object sender, EventArgs e) {
            dataGridView2.Rows.Clear();
            buttonEnter2.Enabled = false;
        }

        private void buttonClear3_Click(object sender, EventArgs e) {
            dataGridView3.Rows.Clear();
            buttonEnter3.Enabled = false;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  コピーボタン  】---------------------------------------//
        private void buttonCopy1_Click(object sender, EventArgs e) {
            if (ResultBox1.Text == "") { return; }
            #region
            string memo = ResultBox1.Text;

            //クリップボードに文字列をコピーする
            Clipboard.SetText(memo);
            MessageBox.Show("コピー完了");
            #endregion
        }

        private void buttonCopy2_Click(object sender, EventArgs e) {
            if (ResultBox2.Text == "") { return; }
            #region
            string memo = ResultBox2.Text;

            //クリップボードに文字列をコピーする
            Clipboard.SetText(memo);
            MessageBox.Show("コピー完了");
            #endregion
        }


        private void buttonCopy3_Click(object sender, EventArgs e) {
            if (ResultBox3.Text == "") { return; }
            #region
            string memo = ResultBox3.Text;

            //クリップボードに文字列をコピーする
            Clipboard.SetText(memo);
            MessageBox.Show("コピー完了");
            #endregion
        }  //------------    【   末尾  】     ----------------//
        #endregion


        #region -------------【  DataGridViewのセルクリック  】---------------------------------------//
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView c = (DataGridView)sender;

            if(dataGridView1.CurrentCell.RowIndex<0|| dataGridView1.CurrentCell.ColumnIndex < 0) {
                return;
            }

            switch (comboBox1.SelectedIndex) {

                case 0:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.WHITE];
                    break;

                case 1:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.BLUE];
                    break;


                case 2:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.YELLOW];
                    break;

                case 3:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.GREEN];
                    break;

                case 4:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.RED];
                    break;
            }

            //(c.CurrentCell.Style.BackColor==Color.Red)? Color.White: Color.Red;
            dataGridView1.ClearSelection();
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView c = (DataGridView)sender;

            if (dataGridView2.CurrentCell.RowIndex < 0 || dataGridView2.CurrentCell.ColumnIndex < 0) {
                return;
            }

            switch (comboBox2.SelectedIndex) {

                case 0:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.WHITE];
                    break;

                case 1:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.BLUE];
                    break;


                case 2:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.YELLOW];
                    break;

                case 3:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.GREEN];
                    break;

                case 4:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.RED];
                    break;
            }

            //(c.CurrentCell.Style.BackColor==Color.Red)? Color.White: Color.Red;
            dataGridView2.ClearSelection();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView c = (DataGridView)sender;

            if (dataGridView3.CurrentCell.RowIndex < 0 || dataGridView3.CurrentCell.ColumnIndex < 0) {
                return;
            }

            //switch (comboBox3.SelectedIndex) {

            //    case 0:
            //        c.CurrentCell.Style.BackColor = ColorList[Color_Num.WHITE];
            //        break;

            //    case 1:
            //        c.CurrentCell.Style.BackColor = ColorList[Color_Num.BLUE];
            //        break;


            //    case 2:
            //        c.CurrentCell.Style.BackColor = ColorList[Color_Num.YELLOW];
            //        break;

            //    case 3:
            //        c.CurrentCell.Style.BackColor = ColorList[Color_Num.GREEN];
            //        break;

            //    case 4:
            //        c.CurrentCell.Style.BackColor = ColorList[Color_Num.RED];
            //        break;
            //}

            //(c.CurrentCell.Style.BackColor==Color.Red)? Color.White: Color.Red;
           // dataGridView3.ClearSelection();
        }
        //------------    【   末尾  】     ----------------//
        #endregion



        #region -------------【  コンテンツText  】---------------------------------------//

        private void 列削除ToolStripMenuItem_Click(object sender, EventArgs e) {

            dataGridView1.Columns.RemoveAt(dataGridView1.CurrentCell.ColumnIndex);

        }

        private void 列複製ToolStripMenuItem3_Click(object sender, EventArgs e) {

           int ColumnIndex=  dataGridView3.CurrentCell.ColumnIndex;

            for(int i = 0; i < dataGridView3.Rows.Count; i++) {
                for (int j=0;j<dataGridView3.ColumnCount;j++) {

                }
            }
        }  //------------    【   末尾  】     ----------------//
        #endregion

        private void dataGridView_sub_CellClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView c = (DataGridView)sender;

            if (dataGridView_sub.CurrentCell.RowIndex < 0 || dataGridView_sub.CurrentCell.ColumnIndex < 0) {
                return;
            }

            switch (comboBox3.SelectedIndex) {

                case 0:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.WHITE];
                    break;

                case 1:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.BLUE];
                    break;


                case 2:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.YELLOW];
                    break;

                case 3:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.GREEN];
                    break;

                case 4:
                    c.CurrentCell.Style.BackColor = ColorList[Color_Num.RED];
                    break;
            }

            //(c.CurrentCell.Style.BackColor==Color.Red)? Color.White: Color.Red;
            dataGridView_sub.ClearSelection();
        }

        public string DataGrid_HANTEI(DataGridView dataGrid,int num) {

            string Line = "";

            for (int sub = 0; sub < dataGrid.ColumnCount; sub++) {
                #region -------------【  白色  】---------------------------------------//
                if (dataGrid.Rows[0].Cells[sub].Style.BackColor == ColorList[Color_Num.WHITE]) {
                    Line += dataGrid.Rows[0].Cells[sub].Value.ToString();
                    //MessageBox.Show(Line);
                }
                //------------    【   末尾  】     ----------------//
                #endregion

                #region -------------【  青色　小文字　アルファベット  】---------------------------------------//

                else if (dataGrid.Rows[0].Cells[sub].Style.BackColor == ColorList[Color_Num.BLUE]) {
                    Line += alphabet(dataGrid.Rows[0].Cells[sub].Value.ToString(), num);
                }
                        //------------    【   末尾  】     ----------------//
                #endregion


                #region -------------【  黄色 大文字　アルファベット  】---------------------------------------//
                else if (dataGrid.Rows[0].Cells[sub].Style.BackColor == ColorList[Color_Num.YELLOW]) {
                    Line += Alphabet(dataGrid.Rows[0].Cells[sub].Value.ToString(), num);
                }
                        //------------    【   末尾  】     ----------------//
                #endregion


                #region -------------【  緑色 数値　デクリメント 】---------------------------------------//
                else if (dataGrid.Rows[0].Cells[sub].Style.BackColor == ColorList[Color_Num.GREEN]) {
                    Line+= Number_str(dataGrid.Rows[0].Cells[sub].Value.ToString(), -num, sub);
                }
                        //------------    【   末尾  】     ----------------//
                #endregion

                #region -------------【  赤色 数値　インクリメント 】---------------------------------------//
                else if (dataGrid.Rows[0].Cells[sub].Style.BackColor == ColorList[Color_Num.RED]) {
                    Line+= Number_str(dataGrid.Rows[0].Cells[sub].Value.ToString(), num, sub);
                }
                //------------    【   末尾  】     ----------------//
                #endregion

            }
            return Line;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if(toolStripMenuItem1 is ToolStripMenuItem) {

                if (ResultBox1.Text == "") { return; }
                Dialogs dialogs = new Dialogs();

                string save= dialogs.SaveFile_Dialog(Exe_Path.DownLoad_path(), "保存名", @"*.txt");

                if (save == "") { return; }

                Text_IO.TextFileReWrite(save,ResultBox1.Text);

            } else if(toolStripMenuItem2 is ToolStripMenuItem) {
                if (ResultBox2.Text == "") { return; }

                Dialogs dialogs = new Dialogs();

                string save = dialogs.SaveFile_Dialog(Exe_Path.DownLoad_path(), "保存名", @"*.txt");

                if (save == "") { return; }

                Text_IO.TextFileReWrite(save, ResultBox2.Text);

            } else {
                if (ResultBox3.Text == "") { return; }

                Dialogs dialogs = new Dialogs();

                string save = dialogs.SaveFile_Dialog(Exe_Path.DownLoad_path(), "保存名", @"*.txt");

                if (save == "") { return; }

                Text_IO.TextFileReWrite(save, ResultBox3.Text);
            }
        }
    }

    class DataGrid_string {

       public DataGridView Get_DataGrid {
            get;set;
       }

       public string Get_moji {
            get; set;
        }

       public DataGrid_string(DataGridView data,string moji) {
            this.Get_DataGrid = data;
            this.Get_moji = moji;
        }
    }
}
//https://dobon.net/vb/dotnet/datagridview/cellcolor.html
//https://propg.ee-mall.info/%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0/c/c-datagridview-%E3%81%99%E3%81%B9%E3%81%A6%E9%81%B8%E6%8A%9E%E3%81%99%E3%82%8B%E8%A7%A3%E9%99%A4%E3%81%99%E3%82%8B/