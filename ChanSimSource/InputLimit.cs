/************************************************************
 * @Description:尝试使用装饰者模式实现对控件textBox的输入限制
 * @Author:zhuMQ
 * @Version:
 * @Date: 2018/1/22
*************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChanSimSource
{
    //装饰者与被装饰者共同的基类
    public abstract class InputLimit
    {
        protected Object controlObject;
       // protected char newChar;

        public Object getObject()
        {
            return controlObject;
        }

        public abstract bool InputCheck(char inChar);
    }

    //装饰者抽象类
    public abstract class RestrictiveCondition : InputLimit
    {
        //public abstract void getObject(Object obj);
    }
   
    //被装饰者
    public class TextBoxInputLimit : InputLimit
    {

        public TextBoxInputLimit(Object sender)
        {
            controlObject = sender as TextBox;
        }


        override public bool InputCheck(char inChar)
        {
            TextBox txtBox = controlObject as TextBox;
            float getData = 0;

            String startStr = txtBox.Text.Substring(0, txtBox.SelectionStart);
            String endStr = txtBox.Text.Substring(txtBox.SelectionStart + txtBox.SelectionLength, txtBox.TextLength - txtBox.SelectionLength - startStr.Length);

            if (!float.TryParse(startStr + inChar + endStr, out getData) && (startStr + endStr) != "")
            {
                return false;
            }
            return true;
        }
    }

    //装饰者
    public class NumberType : RestrictiveCondition
    {
        InputLimit inputLimit;

        public NumberType(InputLimit inLimit)
        {
            this.inputLimit = inLimit;
            this.controlObject = inputLimit.getObject();
        }

       override public bool InputCheck(char inChar)
        {
            if (Char.IsDigit(inChar) || inChar == '.' || inChar == '-')
            {
                return inputLimit.InputCheck(inChar);
            }
            return false;
        }
    }

    public class PositiveType : RestrictiveCondition
    {
         InputLimit inputLimit;

         public PositiveType(InputLimit inLimit)
        {
            this.inputLimit = inLimit;
            this.controlObject = inputLimit.getObject();
        }

        public override bool InputCheck(char inChar)
         {
             if (inChar == '-')
             {
                 return false;
             }
             return inputLimit.InputCheck(inChar);
        }
    }
    public class IntegerType : RestrictiveCondition
    {

        InputLimit inputLimit;
        public IntegerType(InputLimit inLimit)
        {
            this.inputLimit = inLimit;
            this.controlObject = inputLimit.getObject();
        }
        public override bool InputCheck(char inChar)
        {
            if (inChar == '.')
            {
                return false;
            }
            return inputLimit.InputCheck(inChar);
        }
    }
}
