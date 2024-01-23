## Generate buttons with dispose

You code could be improved by qualifying with `OfType<RadioButton()` when querying the `Controls` collection for buttons to dispose, and supplying a `Name` property to the generated button to identify the intended buttons to dispose with precision. You may also want to limit the characters that the textbox will accept so that a non-empty value for `textBox1.Text` is always parseable by int.

Your spec states that the number of buttons should be between 2 and 4. Consider using a `NumericUpDown` control where you can set min and max values. 


