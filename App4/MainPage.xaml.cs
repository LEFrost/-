using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace App4
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }
        void myAdd(Button x)
        {
            if (expression.Text == "0")
                expression.Text = x.Content.ToString();
            else
                expression.Text = expression.Text + x.Content.ToString();
        }


        bool ifDot = false;

        #region 增加数字
        private void one_Click(object sender, RoutedEventArgs e)
        {
            myAdd(one);
        }
        private void two_Click(object sender, RoutedEventArgs e)
        {
            myAdd(two);
        }
        private void three_Click(object sender, RoutedEventArgs e)
        {
            myAdd(three);
        }
        private void four_Click(object sender, RoutedEventArgs e)
        {
            myAdd(four);
        }
        private void five_Click(object sender, RoutedEventArgs e)
        {
            myAdd(five);
        }
        private void six_Click(object sender, RoutedEventArgs e)
        {
            myAdd(six);
        }
        private void seven_Click(object sender, RoutedEventArgs e)
        {
            myAdd(seven);
        }
        private void eight_Click(object sender, RoutedEventArgs e)
        {
            myAdd(eight);
        }
        private void nine_Click(object sender, RoutedEventArgs e)
        {
            myAdd(nine);
        }
        private void zero_Click(object sender, RoutedEventArgs e)
        {
            myAdd(zero);
        }
        #endregion
        Stack st = new Stack();
        double temp1, temp2, result;
        char mark;


        private void dot_Click(object sender, RoutedEventArgs e)
        {
            if (ifDot == true)
                expression.Text = expression.Text;
            else
            {
                expression.Text = expression.Text + ".";
                ifDot = true;
            }

        }

        private void mul_Click(object sender, RoutedEventArgs e)
        {
            st.Push(expression.Text);
            if (st.Count >= 3)
            {
                temp2 = Convert.ToDouble(st.Pop());
                mark = Convert.ToChar(st.Pop());
                temp1 = Convert.ToDouble(st.Pop());
                switch (mark)
                {
                    case '+':
                    case '-':
                        st.Push(temp1);
                        st.Push(mark);
                        st.Push(temp2);
                        break;
                    case '*':
                        result = temp1 * temp2;
                        st.Push(result);
                        break;
                    case '/':
                        result = temp1 / temp2;
                        st.Push(result);
                        break;

                }
            }
            st.Push('*');
            expression.Text = "0";
        }

        private void count_Click(object sender, RoutedEventArgs e)
        {
            st.Push(expression.Text);
            temp2 = Convert.ToDouble(st.Pop());
            mark = Convert.ToChar(st.Pop());
            temp1 = Convert.ToDouble(st.Pop());
            switch (mark)
            {

                case '+':
                    result = temp1 + temp2;
                    break;
                case '-':
                    result = temp1 - temp2;
                    break;
                case '*':
                    result = temp1 * temp2;
                    if (st.Count > 0)
                    {
                        mark = Convert.ToChar(st.Pop());
                        temp1 = Convert.ToDouble(st.Pop());
                        if (mark == '+')
                            result += temp1;
                        else if (mark == '-')
                            result = temp1 - result;
                    }
                    break;
                case '/':
                    result = temp1 / temp2;
                    if (st.Count > 0)
                    {
                        mark = Convert.ToChar(st.Pop());
                        temp1 = Convert.ToDouble(st.Pop());
                        if (mark == '+')
                            result += temp1;
                        else if (mark == '-')
                            result = temp1 - result;
                    }
                    break;
            }
            Input.Text = result.ToString();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            st.Push(expression.Text);
            if (st.Count >= 3)
            {
                temp2 = Convert.ToDouble(st.Pop());
                mark = Convert.ToChar(st.Pop());
                temp1 = Convert.ToDouble(st.Pop());
                switch (mark)
                {
                    case '+':
                        result = temp1 + temp2;
                        break;
                    case '-':
                        result = temp1 - temp2;
                        break;
                    case '*':
                        result = temp1 * temp2;
                        break;
                    case '/':
                        result = temp1 / temp2;
                        break;
                }
                st.Push(result);
            }
            st.Push('-');
            expression.Text = "0";
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            st.Push(expression.Text);
            if (st.Count >= 3)
            {
                temp2 = Convert.ToDouble(st.Pop());
                mark = Convert.ToChar(st.Pop());
                temp1 = Convert.ToDouble(st.Pop());
                switch (mark)
                {
                    case '+':
                        result = temp1 + temp2;
                        break;
                    case '-':
                        result = temp1 - temp2;
                        break;
                    case '*':
                        result = temp1 * temp2;
                        break;
                    case '/':
                        result = temp1 / temp2;
                        break;
                }
                st.Push(result);
            }
            st.Push('+');
            expression.Text = "0";
        }
    }


}
