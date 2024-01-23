namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Constrain to numeric only input.
            textBox1.KeyPress += (sender, e) =>
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };
            textBox1.KeyDown += (sender, e) =>
            {
                if (textBox1.Text.Length > 0) switch (e.KeyData)
                    {
                        case Keys.Return:
                            e.Handled =
                                e.SuppressKeyPress =    // Avoid unwanted beeps.
                                true;
                            foreach (
                                var genTextBox in
                                Controls.OfType<RadioButton>()                      // Only Radio Buttons
                                .Where(_ => _.Name.IndexOf("radioButtonGen") == 0)  // Only matching name
                                .ToArray())                                         // Insulate from collection changes
                            {
                                genTextBox.Dispose();   // Properly dispose of buttons handles
                            }
                            var count = int.Parse(textBox1.Text);
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
                                        X = textBox1.Left + (column * (MARGIN + WIDTH)),
                                        Y = textBox1.Bottom + ((row + 1) * MARGIN) + (row * HEIGHT),
                                    },
                                    Size = new Size(WIDTH, HEIGHT)
                                };
                                Controls.Add(radioButtonGen);
                            }
                            textBox1.BeginInvoke(() => textBox1.SelectAll());
                            break;
                    }
            };
        }
        const int
            MAX_BUTTONS_PER_ROW = 4,
            MARGIN = 10,
            HEIGHT = 24,
            WIDTH = 180;
    }
}
