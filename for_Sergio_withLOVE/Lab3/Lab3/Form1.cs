using System;
using System.Windows.Forms;
using System.Windows.Media;



namespace Lab3
{
    public partial class Form1 : Form
    {
        string filename;
        MediaPlayer player = new MediaPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            // get the address of the file
            var dialog = new OpenFileDialog();

            dialog.InitialDirectory = "c:\\";

            dialog.Filter = "Windows Media Audio (*.wma)|*.wma|All files (*.*)|*.*";
            dialog.FilterIndex = 1;


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filename = dialog.FileName;
            }

            var file = TagLib.File.Create(filename);

            // tegs to Form
            title.Text = file.Tag.Title;
            artist.Text = file.Tag.FirstPerformer;
            album.Text = file.Tag.Album;
            year.Text = file.Tag.Year.ToString();
            comment.Text = file.Tag.Comment;

            // audio to Db
            var db = new AeroDataContext();
            var data = new Audio
            {
                Filename = filename,
                Title = file.Tag.Title,
                Singer = file.Tag.FirstPerformer,
                Album = file.Tag.Album,
                Year = (int)file.Tag.Year,
                Comment = file.Tag.Comment
            };
            db.Audio.InsertOnSubmit(data);
            db.SubmitChanges();
        }

        private void play_Click(object sender, EventArgs e)
        {
            var uri = new Uri("file://" + filename);
            player.Open(uri);
            player.Play();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            player.Stop();
            player.Close();
        }
    }
}
