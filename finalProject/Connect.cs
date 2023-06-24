using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace finalProject {
    public partial class Connect : Form {
        public Connect() {
            InitializeComponent();
        }

        private void buttonChooseColor_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                pictureBoxPreviewColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            bool isfirstNameNull = testAndSetErrorIfFirstNameIsEmptyOrNot();
            bool isLastNameNull = testAndSetErrorIfLastNameIsEmptyOrNot();
            bool isBirthDayNull = testAndSetErrorIfBirthDayIsEmptyOrNot();
            bool isCountryNull = testAndSetErrorIfCountryIsEmptyOrNot();
            bool isColorNotChosen = testAndSetErrorIfColorIsChosenOrNot();


            if (!isLastNameNull && !isfirstNameNull && !isBirthDayNull && !isCountryNull && !isColorNotChosen) {
                MessageBox.Show("Everything is saved correctly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool testAndSetErrorIfFirstNameIsEmptyOrNot() {
            if (textBoxFirstName.Text == "") {
                errorProviderFirstName.SetError(textBoxFirstName, "Please enter your first name");
                return true;
            } else {
                errorProviderFirstName.Clear();
                return false;
            }
        }

        private bool testAndSetErrorIfLastNameIsEmptyOrNot() {
            if (textBoxLastName.Text == "") {
                errorProviderLastName.SetError(textBoxLastName, "Please enter your last name");
                return true;
            } else {
                errorProviderLastName.Clear();
                return false;
            }
        }

        private bool testAndSetErrorIfBirthDayIsEmptyOrNot() {
            string format = "dd/MM/yyyy";
            bool isDateInputCorrect = DateTime.TryParseExact(maskedTextBoxBirthDay.Text, format, CultureInfo.InvariantCulture, 
                System.Globalization.DateTimeStyles.None, out DateTime dateTime);

            if (!isDateInputCorrect) {
                errorProviderBirthday.SetError(maskedTextBoxBirthDay, "Please enter your birthday in the format dd/MM/yyyy");
                return true;
            } else {
                errorProviderBirthday.Clear();
                return false;
            }
        }

        private bool testAndSetErrorIfCountryIsEmptyOrNot() {
            if (comboBoxCountries.Text == "") {
                errorProviderCountry.SetError(comboBoxCountries, "Please select your country");
                return true;
            } else {
                errorProviderCountry.Clear();
                return false;
            }
        }

        private bool testAndSetErrorIfColorIsChosenOrNot() {
            if (pictureBoxPreviewColor.BackColor == SystemColors.Control) {
                errorProviderColor.SetError(pictureBoxPreviewColor, "Please select your favorite color");
                return true;
            } else {
                errorProviderColor.Clear();
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Image Files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}
