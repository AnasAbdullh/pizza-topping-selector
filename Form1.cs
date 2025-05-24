using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PizzaOrderApp
{
    public partial class Form1 : Form
    {
       
        private List<CheckBox> toppingCheckBoxes;

        public Form1()
        {
            InitializeComponent();
            InitializeToppingsList();
        }

        
        private void InitializeToppingsList()
        {
            toppingCheckBoxes = new List<CheckBox>
            {
                chkCheese,
                chkMushroom,
                chkTomatose,
                chkOlives,
                chkOnions,
                chkGreenPeppers
            };
        }

     
        private void UpdateTopping()
        {
            var selected = toppingCheckBoxes.Where(cb => cb.Checked).Select(cb => cb.Text);

            lblSelectedToppings.Text = string.Join(", ", selected);
            if (selected.Count() == 0)
            {
                lblSelectedToppings.Text = "No Topping";
            }

            UpdateTotalPrice();
        }

       
        private int ClacluteToppingPrice()
        {
            int total = 0;

            foreach (var checkBox in toppingCheckBoxes)
            {
                if (checkBox.Checked && int.TryParse(checkBox.Tag?.ToString(), out int price))
                {
                    total += price;
                }
            }

            return total;
        }

        
        private int GetSelectSizePrice()
        {
            if (rbSmall.Checked) return int.Parse(rbSmall.Tag.ToString());
            if (rbMedium.Checked) return int.Parse(rbMedium.Tag.ToString());
            if (rbLarge.Checked) return int.Parse(rbLarge.Tag.ToString());
            return 0;
        }

       
        private int GetSelectCrustPrice()
        {
            if (rbThinCrust.Checked) return int.Parse(rbThinCrust.Tag.ToString());
            if (rbThickCrust.Checked) return int.Parse(rbThickCrust.Tag.ToString());
            return 0;
        }

      
        private int ClacluteTotalPrice()
        {
            return GetSelectSizePrice() + GetSelectCrustPrice() + ClacluteToppingPrice();
        }

      
        private void UpdateTotalPrice()
        {
            lblTotalPrice.Text = $"${ClacluteTotalPrice()}";
        }

     
        private void rbSize_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();

            if (rbSmall.Checked) label4.Text = "Small";
            if (rbMedium.Checked) label4.Text = "Meduim";
            if (rbLarge.Checked) label4.Text = "Large";


        }

        private void rbCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();

            if (rbThinCrust.Checked)
                label8.Text = "Thin Crust";

            else if(rbThickCrust.Checked)
                label8.Text = "Think Crust";
        }

        private void chkTopping_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) 
        {
            label10.Text = "Take Out";
        }

        private void OrderPizza()
        {

            if (MessageBox.Show("Confirm Order", "Confirm",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                button1.Enabled = false;

            }
            else

                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           
        }

        private void ResetForm()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            button1.Enabled = true;
        }                       

      

        private void button2_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderPizza();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label10.Text = "Eat In";
        }

        
    }
}
