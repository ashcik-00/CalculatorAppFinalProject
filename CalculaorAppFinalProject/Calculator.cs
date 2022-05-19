namespace CalculaorAppFinalProject
{
    public partial class Form1 : Form
    {

        string StoredOperand;
        string StoredOperation;
        string type = "dec";

        public Form1()
        {
            InitializeComponent();
        }
        

        // This method displays on the CalculatorDisplay whatever values buttons have in their text property.
        // This method diplays text on the CalculatorDisplay for those buttons which contain the Input_CLick click event listener.
        private void Input_Click(object sender, EventArgs e)
        {
            Button input = (Button)sender;
            if(CalculatorDislay.Text == "0")
            {
                if(input.Text == ".")
                {
                    CalculatorDislay.Text = "0" + input.Text;
                } else
                {
                    CalculatorDislay.Text = input.Text;
                }
            } else
            {
                if (input.Text == "." && !CalculatorDislay.Text.Contains("."))
                {
                    CalculatorDislay.Text += input.Text;
                } else if(input.Text != ".")
                {
                    CalculatorDislay.Text += input.Text;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // This method displays the numbers pressed on keyboard and it also invokes the result method whenever the EqualButton is clicked.
        // It is a global keypress event whenever any key is pressed on the keyboard this method gets invoked.
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 || (int)e.KeyChar >= 96 && (int)e.KeyChar <= 105 || (int)e.KeyChar == 46)
            {
                if (CalculatorDislay.Text == "0")
                {
                    if (e.KeyChar.ToString() == ".")
                    {
                        CalculatorDislay.Text = "0" + e.KeyChar.ToString();
                    }
                    else
                    {
                        CalculatorDislay.Text = e.KeyChar.ToString();
                    }
                }
                else
                {
                    if (e.KeyChar.ToString() == "." && !CalculatorDislay.Text.Contains("."))
                    {
                        CalculatorDislay.Text += e.KeyChar.ToString();
                    }
                    else if (e.KeyChar.ToString() != ".")
                    {
                        CalculatorDislay.Text += e.KeyChar.ToString();
                    }
                }
            }
            if(e.KeyChar.ToString() == "=")
            {
                Result();
            }

            if(e.KeyChar.ToString() == "+" || e.KeyChar.ToString() == "-" || e.KeyChar.ToString() == "*" || e.KeyChar.ToString() == "/")
            {
                if (CalculatorDislay.Text != "")
                {
                    StoredOperand = CalculatorDislay.Text;
                    CalculatorDislay.Text = "";
                    StoredOperation = e.KeyChar.ToString();
                    label1.Text = StoredOperand;
                    label2.Text = StoredOperation;
                }
            }

            if((int)e.KeyChar == 8)
            {
                if(CalculatorDislay.Text != "")
                    CalculatorDislay.Text = CalculatorDislay.Text.Substring(0, CalculatorDislay.Text.Length - 1);
            }
        }

        // This function returns sum of two number when called.
        // It invokes the Operation method.
        private double Add(double num1, double num2)
        {
            double result = num1 + num2;
            return result;
        }

        // This function returns difference of two number when called.
        // It is called by the Operation method
        private double Subtract(double num1, double num2)
        {
            double result = num1 - num2;
            return result;
        }

        // This function returns multiplication result of two number when called.
        // It is called by the Operation method.
        private double Multiply(double num1, double num2)
        {
            double result = num1 * num2;
            return result;
        }

        // This function returns division result of two number when called.
        // It is called the Operation method.
        private double Divide(double num1, double num2)
        {
            double result = num1 / num2;
            return result;
        }

        // This function returns a string when passed two number and a operation
        // This method invokes the Add, Subtract, Multiply and Divide method when needed.
        private string Operation(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return Add(num1, num2).ToString();
                case "-":
                    return Subtract(num1, num2).ToString();
                case "*":
                    return Multiply(num1, num2).ToString();
                case "/":
                    return Divide(num1, num2).ToString();
                default:
                    return "Invalid";
            }
        }

        /* Whenever any operation button get pressed this method gets the values from the CalculatorDisplay and shows the
        values on label1 and the operation that is being performed on label2. It also stores CalculatorDisplay values in StoredOperand
        variable and stors the operation in StoredOperation variable.*/
        // This method invokes all the buttons who have Operation_Click click event listener.
        private void Operation_Click(object sender, EventArgs e) {
            Button input = (Button)sender;
            if(CalculatorDislay.Text != "") {
                StoredOperand = CalculatorDislay.Text;
                CalculatorDislay.Text = "";
                StoredOperation = input.Text;
                label1.Text = StoredOperand;
                label2.Text = StoredOperation;
            }
        }

        /* This function gets the first number from StoredOperand variable and the second
         from the CalculatorDisplay then perform the operation that is stored in the StoredOperation variable.
        It also uses Operation method to get the result and stores it into StoredOperand variable then shows it in label1.*/
        // It clears label2 and CalculatorDispaly. It is invoked by Result_Click event listener or .
        private void Result() {
            if(StoredOperand != null && StoredOperation != null && StoredOperand != "" && StoredOperation != "")
            {
                double num1 = double.Parse(StoredOperand);
                double num2 = double.Parse(CalculatorDislay.Text);
                string result = Operation(num1, num2, StoredOperation);
                StoredOperand = result;
                label1.Text = result;
                label2.Text = "";
                CalculatorDislay.Text = "0";
            }
        }


        // This method is a event listener and it calls Result method.
        private void Result_Click(object sender, EventArgs e) 
        {
            Result();
        }

        // This function clears all the labels, display and labels to default clears the values from StoredOperation, StoredOperand, CalculatorDisplay variables and all the labels.
        // It is invoked by A/C button.
        private void AllClear_Click(object sender, EventArgs e)
        {
            StoredOperation = "";
            StoredOperand = "";
            label1.Text = "";
            label2.Text = "";
            CalculatorDislay.Text = "";
            type = "dec";
        }

        Dictionary<char, int> alphaNum = new()
        {
            { 'a', 0 },
            { 'b', 1 },
            { 'c', 2 },
            { 'd', 3 },
            { 'e', 4 },
            { 'f', 5 },
            { 'g', 6 },
            { 'h', 7 },
            { 'i', 8 },
            { 'j', 9 },
            { 'k', 10 },
            { 'l', 11 },
            { 'm', 12 },
            { 'n', 13 },
            { 'o', 14 },
            { 'p', 15 },
            { 'q', 16 },
            { 'r', 17 },
            { 's', 18 },
            { 't', 19 },
            { 'u', 20 },
            { 'v', 21 },
            { 'w', 22 },
            { 'x', 23 },
            { 'y', 24 },
            { 'z', 25 }
        };
        
        
        // This metod gets the value from CalculatorDispaly and check if it is Binary or LOC and then convert it to Decimal number and show it to the Calculator Display.
        // It is invoked by the DEC button.
        private void ConvertToDecimal(object sender, EventArgs e)
        {
            if(type == "bin")
            {
                CalculatorDislay.Text = Convert.ToInt32(CalculatorDislay.Text, 2).ToString();
            }
            if(type == "loc")
            {
                int result = 0;
                string locValue = CalculatorDislay.Text;
                foreach(var l in locValue)
                {
                    int num = Convert.ToInt32(Math.Pow(2, alphaNum[l]));
                    result += num;
                }
                CalculatorDislay.Text = result.ToString();
            }
            type = "dec";
        }


        // This method converts a decimal number to a binary number and show the result on CalculatorDisplay.
        // This is invoked by the BIN button.

        
        private void ConvertToBinary(object sender, EventArgs e)
        {
            if(type == "dec")
            {
                int n = int.Parse(CalculatorDislay.Text), i;
                string result = "";
                for (i = 0; n > 0; i++)
                {
                    result = Convert.ToString(n % 2) + result;
                    n = n / 2;
                }
                CalculatorDislay.Text = result;
            }
            if(type == "loc")
            {
                int result = 0;
                string locValue = CalculatorDislay.Text;
                foreach (var l in locValue)
                {
                    int num = Convert.ToInt32(Math.Pow(2, alphaNum[l]));
                    result += num;
                }
                int n = result, i;
                string resultbin = "";
                for (i = 0; n > 0; i++)
                {
                    resultbin = Convert.ToString(n % 2) + resultbin;
                    n = n / 2;
                }
                CalculatorDislay.Text = resultbin;
            }
            type = "bin";
        }
        
        // Converts binary and decimal numbers into locational number. It first gets the value from CalculatorDisplay and check if it is decimal or binary number and then converts into locational number.
        // It is invoked by the LOC button.
        private void ConvertToLOC(object sender, EventArgs e)
        {
            if(type == "dec")
            {
                int dec = Convert.ToInt32(CalculatorDislay.Text);
                List<int> numbers = new() { 0 };
                int num = 1;
                while(dec > 0)
                {
                    numbers.Add(Convert.ToInt32(Math.Sqrt(num)));
                    dec = dec - num;
                    num *= 2;
                    MessageBox.Show(dec.ToString());
                }
                string result = "";
                foreach (var n in numbers)
                {
                    MessageBox.Show(n.ToString());
                    result += alphaNum.FirstOrDefault(x => x.Value == n).Key;
                }
                CalculatorDislay.Text = result;
            }
            type = "loc";
        }

    }
}
