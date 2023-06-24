using System;
using System.Windows.Forms;

namespace finalProject {
    public partial class LoadingScreenForm : Form {
        public LoadingScreenForm() {
            InitializeComponent();
        }

        private void LoadingScreenForm_Load(object sender, EventArgs e) {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            int maxProgressBarValue = 100;

            if (progressBar1.Value < maxProgressBarValue) {
                progressBar1.Value += 1;
                labelProgress.Text = "Loading in progress: " + progressBar1.Value.ToString() + " %";
            } else {
                openMdiParentAndHideLoadingForm();
                timer1.Stop();
            }
        }

        private void openMdiParentAndHideLoadingForm() {
            MDIParent1 mDIParent1 = new MDIParent1();
            mDIParent1.Show();
            this.Hide();
        }
    }
}
