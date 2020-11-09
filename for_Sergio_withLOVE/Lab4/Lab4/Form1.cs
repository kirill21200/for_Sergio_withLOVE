using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Windows Media Audio (*.wmw)|*.wmw|All files (*.*)|*.*",
                FilterIndex = 1
            };


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filename = dialog.FileName;
                var file = TagLib.File.Create(filename);
                var width = file.Properties.VideoWidth;
                var height = file.Properties.VideoHeight;

                files.Items.Add(filename);

                player.URL = filename;

                var db = new DataClasses1DataContext();
                var data = new Video
                {
                    Filename = filename,
                    Width = width,
                    Height = height
                };

                db.Video.InsertOnSubmit(data);
                db.SubmitChanges();
            }

        }

        private void playAll_Click(object sender, EventArgs e)
        {
            var playlist = player.newPlaylist("Playlist", "");

            foreach (var selected in files.Items)
            {
                string s = selected.ToString();
                var temp = player.newMedia(s);
                playlist.appendItem(temp);
            }
            player.currentPlaylist = playlist;
        }
    }
}
