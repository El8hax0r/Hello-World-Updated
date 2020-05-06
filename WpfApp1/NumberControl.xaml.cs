using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorldUpdated
{
    /// <summary>
    /// Interaction logic for NumberControl.xaml
    /// </summary>
    public partial class NumberControl : UserControl
    {
        public NumberControl()
        {
            InitializeComponent();
        }

        public int Value
        {
            get;
            private set;
        }

        private void uxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e) //'paste' will still bypass this
        {
            //e.Handled = true; //don't process this data
            if (!IsValidNumber(e.Text))
            {
                e.Handled = true;
            }

            //e.Handled = IsValidNumber(e.Text);
        }

        //this is the 'paste' fix (not implemented yet) https://karlhulme.wordpress.com/2007/02/15/masking-input-to-a-wpf-textbox/
        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsValidNumber(text))
                {
                    e.CancelCommand();
                    //This doesn't work: e.Handled
                }
            }
            else e.CancelCommand();
        }

        //and the bool for the previous
        private Boolean IsTextAllowed(String text) //now IsValidNumber
        {
            return Array.TrueForAll<Char>(text.ToCharArray(),
                delegate (Char c) { return Char.IsDigit(c) || Char.IsControl(c); });
        }

        private bool IsValidNumber(string text)
        {
            foreach (var ch in text) 
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            int result;
            if (!int.TryParse(uxNumber.Text + text, out result))
            {
                return false;
            }

            Value = result;

            return true;
        }
    }
}
