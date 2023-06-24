using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace finalProject {
    public partial class Market : Form {
        private Dictionary<string, float> smartphones;
        private Dictionary<string, float> laptops;
        private Dictionary<string, float> televisions;
        public Market() {
            InitializeComponent();
        }

        private void Market_Load(object sender, EventArgs e) {
            populateSmartphonesComboBox();
            populateLaptopsComboBox();
            populateTelevisionComboBox();
        }

        private void populateSmartphonesComboBox() {
            smartphones = new Dictionary<string, float>();

            smartphones.Add("Salsung galaxy S23", 639.50f);
            smartphones.Add("Appli iPhone 14", 799.99f);
            smartphones.Add("OnePlus 11", 689f);
            smartphones.Add("Asus ROG Phone 7", 663f);
            smartphones.Add("Google Pixel 7a", 431f);

            comboBoxSmartphones.DataSource = smartphones.ToArray();
            comboBoxSmartphones.DisplayMember = "Key";
            comboBoxSmartphones.ValueMember = "Value";
        }

        private void populateLaptopsComboBox() {
            laptops = new Dictionary<string, float>();

            laptops.Add("Dell XPS 13", 1299.99f);
            laptops.Add("MacBook Pro 16", 2399.99f);
            laptops.Add("Lenovo ThinkPad X1 Carbon", 1499.99f);
            laptops.Add("HP Spectre x360", 1299.99f);
            laptops.Add("Asus ROG Zephyrus G14", 1299.99f);

            comboBoxLaptops.DataSource = laptops.ToArray();
            comboBoxLaptops.DisplayMember = "Key";
            comboBoxLaptops.ValueMember = "Value";
        }

        private void populateTelevisionComboBox() {
            televisions = new Dictionary<string, float>();

            televisions.Add("Samsung QN900A Neo QLED 8K", 5499.99f);
            televisions.Add("LG C1 OLED 4K TV", 2499.99f);
            televisions.Add("Sony A8H OLED TV", 2299.99f);
            televisions.Add("TCL 6-Series Roku TV", 799.99f);
            televisions.Add("Vizio P-Series Quantum X", 1499.99f);

            comboBoxTelevisions.DataSource = televisions.ToArray();
            comboBoxTelevisions.DisplayMember = "Key";
            comboBoxTelevisions.ValueMember = "Value";
        }

        private void buttonAddToCart_Click(object sender, EventArgs e) {
            string smartphone = "NaN";
            string laptop = "NaN";
            string television = "NaN";
            float totalPrice = 0.0f;

            if (checkBoxSmartphone.Checked) {
                smartphone = comboBoxSmartphones.Text;
                totalPrice += (float) comboBoxSmartphones.SelectedValue;
            }

            if (checkBoxLaptop.Checked) {
                laptop = comboBoxLaptops.Text;
                totalPrice += (float) comboBoxLaptops.SelectedValue;
            }

            if (checkBoxTelevision.Checked) {
                television = comboBoxTelevisions.Text;
                totalPrice += (float) comboBoxTelevisions.SelectedValue;
            }

            dataGridView1.Rows.Add(smartphone, laptop, television, totalPrice);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK) {
                string fileName = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(fileName, "Smartphone\tLaptop\tTelevision\tTotal price\n");

                int counter = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows) {
                    System.IO.File.AppendAllText(
                        fileName, 
                        row.Cells[0].Value.ToString() + "\t" + 
                        row.Cells[1].Value.ToString() + "\t" + 
                        row.Cells[2].Value.ToString() + "\t" +
                        row.Cells[3].Value.ToString() + "\n"
                    );

                    counter++;
                    if (counter == dataGridView1.Rows.Count) {
                        break;
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e) {
            dataGridView1.Rows.Clear();
        }

        private void buttonTotalPrice_Click(object sender, EventArgs e) {
            float shoppingCartTotalPrice = 0.0f;

            foreach (DataGridViewRow row in dataGridView1.Rows) {
                if (row.Cells[3].Value != null)
                    shoppingCartTotalPrice += (float) row.Cells[3].Value;
            }

            labelTotalPrice.Text = "Total price: " + shoppingCartTotalPrice.ToString() + " $";
        }
    }
}
