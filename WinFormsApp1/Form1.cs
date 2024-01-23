namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown.KeyDown += (sender, e) =>
            {
                if(e.KeyData == Keys.Return)
                {
                    e.SuppressKeyPress = true;  // Avoid unwanted alert sounds
                }
            };
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
        }
        const int
            MAX_BUTTONS_PER_ROW = 4,
            MARGIN = 10,
            HEIGHT = 24,
            WIDTH = 180;
    }
}
