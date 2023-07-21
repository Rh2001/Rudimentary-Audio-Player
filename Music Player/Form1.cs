
namespace Music_Player
{
    public partial class Form1 : Form
    {
        //Only one instance of the factory should be created to avoid the bug of overlaying audio files, this is due to the way NAudio works.
        MusicPlayerFactory factory = new MusicPlayerFactory();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                }
                catch (IOException)
                {
                }
                textBox1.Text = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    IMusicPlayer music = factory.CreateMusicPlayer(filePath);
                    music.Play(filePath);
                    Console.WriteLine($"Playing {filePath}");
                }

                catch
                {
                    MessageBox.Show("Error Playing Music File!");
                }
            }

        }

    }
}