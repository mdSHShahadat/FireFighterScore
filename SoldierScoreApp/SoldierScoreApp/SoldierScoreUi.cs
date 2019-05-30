using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoldierScoreApp
{
    public partial class SoldierScoreUi : Form
    {
        List<string> soldierNos = new List<string>();
        List<string> soldierNames = new List<string>();
        List<double> target1s = new List<double>();
        List<double> target2s = new List<double>();
        List<double> target3s = new List<double>();
        List<double> target4s = new List<double>();
        List<double> averages = new List<double>();
        List<double> totals = new List<double>();
        public SoldierScoreUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(soldierNoTextBox.Text))
                {
                    MessageBox.Show("Soldier no field Empty");
                    return;
                } else if (IsExist(soldierNoTextBox.Text))
                {
                    MessageBox.Show("Soldier no alrady exist");
                    return;
                }
                if (string.IsNullOrEmpty(soldierNameTextBox.Text))
                {
                    MessageBox.Show("Soldier name field Empty");
                    return;
                }
                if (string.IsNullOrEmpty(target1TextBox.Text))
                {
                    MessageBox.Show("Soldier target 1 field Empty");
                    return;
                }
                if (string.IsNullOrEmpty(target2TextBox.Text))
                {
                    MessageBox.Show("Soldier target 2 field Empty");
                    return;
                }
                if (string.IsNullOrEmpty(target3TextBox.Text))
                {
                    MessageBox.Show("Soldier target 3 field Empty");
                    return;
                }
                if (string.IsNullOrEmpty(target4TextBox.Text))
                {
                    MessageBox.Show("Soldier target 4 field Empty");
                    return;
                }

                soldierNos.Add(soldierNoTextBox.Text);
                soldierNames.Add(soldierNameTextBox.Text);
                target1s.Add(Convert.ToDouble(target1TextBox.Text));
                target2s.Add(Convert.ToDouble(target2TextBox.Text));
                target3s.Add(Convert.ToDouble(target3TextBox.Text));
                target4s.Add(Convert.ToDouble(target4TextBox.Text));
                averages.Add(Average(Convert.ToDouble(target1TextBox.Text), Convert.ToDouble(target2TextBox.Text), Convert.ToDouble(target3TextBox.Text), Convert.ToDouble(target4TextBox.Text)));
                totals.Add(Total(Convert.ToDouble(target1TextBox.Text), Convert.ToDouble(target2TextBox.Text), Convert.ToDouble(target3TextBox.Text), Convert.ToDouble(target4TextBox.Text)));

                MessageBox.Show("Successfully Saved");
                Clear();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private bool IsExist(string soldier)
        {
            foreach (var soldierNo in soldierNos)
            {
                if (soldierNo == soldier) return true;

            }
            return false;
        }

        private double Average(double t1, double t2, double t3, double t4)
        {
            double result=0;
            result = ((t1 + t2 + t3 + t3) / 4);
          return result;
        }
        private double Total(double t1, double t2, double t3, double t4)
        {
            double result=0;
            result = (t1 + t2 + t3 + t3);
            return result;
        }

        private string Display()
        {
            string message = "Soldier No. \tSoldier Name \tAverage Score \tTotal Score \n";
            int index = 0;
            foreach (var soldier in soldierNos)
            {
                message = message + soldier + "\t" + soldierNames[index] + "\t" + averages[index] + "\t" +
                          totals[index]+"\n";
                index++;
            }
            

            return message;
        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                dispalyRichTextBox.Text = Display();
                int index = 0;
                foreach (double topaverage in averages)
                {
                    if (averages.Max() == topaverage) averageTextBox.Text = soldierNames[index];
                    index++;
                }
                int index1 = 0;
                foreach (double toptotal in totals)
                {
                    if (totals.Max() == toptotal) topTotalTextBox.Text = soldierNames[index1];
                    index1++;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            
        }

        private void Clear()
        {
            soldierNoTextBox.Clear();
            soldierNameTextBox.Clear();
            target1TextBox.Clear();
            target2TextBox.Clear();
            target3TextBox.Clear();
            target4TextBox.Clear();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            dispalyRichTextBox.Clear();
            averageTextBox.Clear();
            topTotalTextBox.Clear();
            try
            {
                string message = "Soldier No. \tSoldier Name \tAverage Score \tTotal Score \n";
                if (SoldierNoRadioButton.Checked)
                {
                    int index = 0;
                    foreach (var soldierNo in soldierNos)
                    {
                        if (searchTextBox.Text == soldierNos[index])
                        {
                            dispalyRichTextBox.Text = message + soldierNo + "\t" + soldierNames[index] + "\t" + averages[index] + "\t" +
                                                     totals[index] + "\n";
                        }
                        
                        index++;
                    }

                     
                }
                if (SoldierNameRadioButton.Checked)
                {
                    int index = 0;
                    foreach (var soldiername in soldierNames)
                    {
                        if (searchTextBox.Text == soldierNames[index])
                        {
                            dispalyRichTextBox.Text = message + soldierNos[index] + "\t" + soldiername + "\t" + averages[index] + "\t" +
                                                      totals[index] + "\n";

                        }

                        index++;
                    }
                    
                    
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
    }
}
