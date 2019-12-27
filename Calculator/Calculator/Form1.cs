using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculate;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _testbox;
        private string _firstNum = "";
        private bool _inset = false;
        private double _memory = 0;
        private string _lastoper = "";
        private bool _equal = false;
        private double _secondNum = 0;
        private string output;

        private bool Inset//输入布尔判定
        {
            get
            {
                return _inset;

            }
            set
            {
                _inset = value;
            }
        }
        private string Testbox
        {
            get
            {
                return _testbox;

            }
            set
            {
                _testbox = value;
            }
        }

        private Double Memory//记忆
        {
            get
            {
                if (_memory == 0)
                    return 0;
                else
                    return _memory;
            }
            set
            {
                _memory = (0);
            }
        }



        private void DigitBtn_Click(object sender, EventArgs e)
        {
            string s = ((Button)sender).Text.ToString();
            char[] ids = s.ToCharArray();
            ProcessKey(ids[0]);
        }

        private void ProcessKey(char c)//处理重输入
        {
            if (Inset == false)
            {
                Testbox = string.Empty;
                Inset = true;
            }
            AddToDisplay(c);
        }

        private void AddToDisplay(char c)
        {
            if (_equal == true)
                _firstNum = "";
            _equal = false;
            if (c == '.')
            {
                if (Testbox.IndexOf('.', 0) >= 0)  //存在多个小数点则报错
                    MessageBox.Show("输入了多个小数点");
                Testbox = Testbox + c;
            }
            else
            {
                if (c >= '0' && c <= '9')
                {
                    if (labelInput.Text == "0" || _inset == false)
                        Testbox = String.Empty;
                    Testbox = Testbox + c;
                    _inset = true;
                    _equal = false;
                }
                else
                    if (c == '\b')  //退格
                {
                    if (Testbox.Length <= 1)
                        Testbox = String.Empty;
                    else
                    {
                        int i = Testbox.Length;
                        Testbox = Testbox.Remove(i - 1, 1);  //移除最后一位
                    }
                }

            }

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (Testbox == String.Empty)
                labelInput.Text = "0";
            else
               labelInput.Text = Testbox;
        }


        private void OperBtn_Click(object sender, EventArgs e)//运算符类按钮输入
        {
            ProcessOperation(((Button)sender).Name.ToString());
        }


        private void OutputUpdate()
        {
            labelOutput.Text = output;
        }


        private void ProcessOperation(string s)
        {
            switch (s)
            {

                case "buttonAdd"://加号按钮
                    _inset = false;
                    if (_equal == true)
                    {
                        _lastoper = "buttonAdd";
                        _equal = false;
                    }
                    else
                    {
                        _equal = false;
                        if (_firstNum == "")
                        {
                            _firstNum = labelInput.Text;
                            _lastoper = "buttonAdd";
                        }
                        else
                        {
                            ProcessOperation("buttonEqual");
                            _firstNum = labelInput.Text;
                            _lastoper = "buttonAdd";
                            _equal = false;
                        }
                    }
                    break;
                case "buttonMinus"://减号按钮
                    _inset = false;
                    if (_equal == true)
                    {
                        _lastoper = "buttonMinus";
                        _equal = false;
                    }
                    else
                    {
                        _equal = false;
                        if (_firstNum == "")
                        {
                            _firstNum = labelInput.Text;
                            _lastoper = "buttonMinus";
                        }
                        else
                        {
                            ProcessOperation("buttonEqual");
                            _firstNum = labelInput.Text;
                            _lastoper = "buttonMinus";
                            _equal = false;
                        }
                    }
                    break;
                case "buttonTimes"://乘法按钮
                    _inset = false;
                    if (_equal == true)
                    {
                        _lastoper = "buttonTimes";
                        _equal = false;
                    }
                    else
                    {
                        _equal = false;
                        if (_firstNum == "")
                        {
                            _firstNum = labelInput.Text;
                            _lastoper = "buttonTimes";
                        }
                        else
                        {
                            ProcessOperation("buttonEqual");
                            _firstNum = labelInput.Text;
                            _lastoper = "buttonTimes";
                            _equal = false;
                        }
                    }
                    break;
                case "buttonDivide"://除法按钮
                    _inset = false;
                    if (_equal == true)
                    {
                        _lastoper = "buttonDivide";
                        _equal = false;
                    }
                    else
                    {
                        _equal = false;
                        if (_firstNum == "")
                        {
                            _firstNum = labelInput.Text;
                            _lastoper = "buttonDivide";
                        }
                        else
                        {
                            if (Convert.ToDouble(labelInput.Text) == 0)//判别除数是否为0
                               MessageBox.Show ( "错误！除数不能为0！");
                                
                            else
                            {
                                ProcessOperation("buttonEqual");
                                _firstNum = labelInput.Text;
                                _lastoper = "buttonDivide";
                                _equal = false;
                            }
                        }
                    }
                    break;
                case "buttonEqual"://等号按钮
                    _inset = false;
                    if (_equal == true)
                        labelInput.Text = Convert.ToString(_secondNum);
                    else
                        _secondNum = Convert.ToDouble(labelInput.Text);
                    _equal = true;
                    switch (_lastoper)//运算
                    {

                        case "buttonAdd":
                            Operate op1 = new Operate();
                         //   output = Convert.ToString(op1.add(Convert.ToDouble(_firstNum), Convert.ToDouble(labelInput.Text)));
                            labelInput.Text = Convert.ToString(op1.add(Convert.ToDouble(_firstNum), Convert.ToDouble(labelInput.Text)));
                            output = labelInput.Text;
                            OutputUpdate();
                           _firstNum = labelInput.Text;
                            break;
                        case "buttonMinus":
                            Operate op2 = new Operate();
                            labelInput.Text = Convert.ToString(op2.minus(Convert.ToDouble(_firstNum) , Convert.ToDouble(labelInput.Text)));
                            output = labelInput.Text;
                            OutputUpdate();
                           _firstNum = labelInput.Text;
                            break;
                        case "buttonTimes":
                            Operate op3 = new Operate();
                            labelInput.Text = Convert.ToString(op3.times(Convert.ToDouble(_firstNum) ,Convert.ToDouble(labelInput.Text)));
                            output = labelInput.Text;
                            OutputUpdate();
                            _firstNum = labelInput.Text;
                            break;
                        case "buttonDivide":
                            if (Convert.ToInt16(labelInput.Text) == 0)
                            {
                                MessageBox.Show("错误！除数不能为0！请重新输入！");
                                ProcessOperation("buttonClear");
                            }
                            else
                            {
                                Operate op4 = new Operate();
                                labelInput.Text = Convert.ToString(op4.divide(Convert.ToDouble(_firstNum), Convert.ToDouble(labelInput.Text)));
                                output = labelInput.Text;
                                OutputUpdate();
                                _firstNum = labelInput.Text;
                            }
                            break;
                        default:

                            break;
                    }
                    break;
                case "buttonClear"://清除按钮
                    labelInput.Text = "0";
                    _inset = false;
                    _firstNum = "";
                    _lastoper = "";
                    _equal = false;
                    _secondNum = 0;
                    output = "0";
                    OutputUpdate();
                    break;
                case "buttonDelete"://退格按钮
                    AddToDisplay('\b');
                    break;

            }

        }


    }
}
