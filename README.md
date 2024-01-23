## Generate buttons with dispose



Your code could be improved by qualifying with `OfType<RadioButton()` when querying the `Controls` collection for buttons to dispose, and supplying a `Name` property to the generated buttons to additionally qualify the intended targets for disposal with precision. 

Since your spec states that the number of buttons should be between 2 and 4, consider using a `NumericUpDown` control where you can set min and max values (something I haven't limited here...). If in the future you find there are more buttons than will fit in a single row, integer division works for calculating row and the modulo operator is good for column.

[![screenshot][1]][1]

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        numericUpDown.ValueChanged += (sender, e) =>
        {
            foreach (
                var genTextBox in
                Controls.OfType<RadioButton>()                      // Only Radio Buttons
                .Where(_ => _.Name.IndexOf("radioButtonGen") == 0)  // Only matching name
                .ToArray())                                         // Insulate from collection changes
            {
                genTextBox.Dispose();   // Properly dispose of buttons handles
            }
            var count = Convert.ToInt32(numericUpDown.Value);
            for (var index = 0; index < count; index++)
            {
                var row = index / 4;
                var column = index % 4;
                var radioButtonGen = new RadioButton
                {
                    Name = $"radioButtonGen{index + 1}",
                    Text = $"RadioButton{index + 1}",
                    Location = new Point
                    {
                        X = numericUpDown.Left + (column * (MARGIN + WIDTH)),
                        Y = numericUpDown.Bottom + ((row + 1) * MARGIN) + (row * HEIGHT),
                    },
                    Size = new Size(WIDTH, HEIGHT)
                };
                Controls.Add(radioButtonGen);
            }
        };
        numericUpDown.KeyDown += (sender, e) =>
        {
            if(e.KeyData == Keys.Return)
            {
                e.SuppressKeyPress = true;  // Avoid unwanted alert sounds
            }
        };
    }
    const int
        MAX_BUTTONS_PER_ROW = 4,
        MARGIN = 10,
        HEIGHT = 24,
        WIDTH = 180;
}
```


  [1]: https://i.stack.imgur.com/OwhZG.png
