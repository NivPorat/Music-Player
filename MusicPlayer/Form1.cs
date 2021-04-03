using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class MusicPlayerApp : Form
    {
        public MusicPlayerApp()
        {
            InitializeComponent();
        }

        string[] paths, files;

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true; //select multiple songs
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames;// save file names 
                paths = ofd.FileNames;// save file path

                //display song titles in list box
                for(int i = 0; i < files.Length; i++)
                    listBoxSongs.Items.Add(files[i]);
            }

        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.URL = paths[listBoxSongs.SelectedIndex];
        }


        /// <summary>
        /// close the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
