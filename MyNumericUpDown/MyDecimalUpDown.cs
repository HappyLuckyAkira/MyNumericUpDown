using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace MyNumericUpDown
{
    class MyDecimalUpDown:DecimalUpDown
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            InputValidationError += MyDecimalUpDown_InputValidationError;

            DataObject.AddPastingHandler(this, textbox_PastingHandler);
            var textBox = this.Template.FindName("PART_TextBox", this) as WatermarkTextBox;
            if (null != textBox)
            {
                InputMethod.SetIsInputMethodSuspended(textBox, true);
            }
        }

        private void MyDecimalUpDown_InputValidationError(object sender, Xceed.Wpf.Toolkit.Core.Input.InputValidationErrorEventArgs e)
        {
            StringBuilder errmsgStringBuilder = new StringBuilder("入力値は");
            errmsgStringBuilder.AppendFormat("{0:F2}", this.Minimum);
            errmsgStringBuilder.Append("-");
            errmsgStringBuilder.AppendFormat("{0:F2}", this.Maximum);
            errmsgStringBuilder.Append("を入力してください");
            //MessageBox("aaa");
            System.Windows.MessageBox.Show(errmsgStringBuilder.ToString());
        }

        private static bool IsAllNumber(string text)
        {
            return text.All(char.IsNumber);
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (!IsAllNumber(e.Text))
            {
                e.Handled = true;
            }
        }

        private static void textbox_PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
                if (!IsAllNumber(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
