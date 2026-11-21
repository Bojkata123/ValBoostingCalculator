using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BoostingCalculator
{
    public partial class Form1 : Form
    {
        double i1_i2 = 3.0 / 100;
        double i2_i3 = 3.0 / 100;
        double i3_b1 = 3.5 / 100;
        double b1_b2 = 4.0 / 100;
        double b2_b3 = 4.0 / 100;
        double b3_s1 = 4.5 / 100;
        double s1_s2 = 5.0 / 100;
        double s2_s3 = 5.0 / 100;
        double s3_g1 = 5.5 / 100;
        double g1_g2 = 6.0 / 100;
        double g2_g3 = 6.5 / 100;
        double g3_p1 = 7.0 / 100;
        double p1_p2 = 7.5 / 100;
        double p2_p3 = 8.0 / 100;
        double p3_d1 = 9.0 / 100;
        double d1_d2 = 10.0 / 100;
        double d2_d3 = 13.0 / 100;
        double d3_asc1 = 15.0 / 100;
        double asc1_asc2 = 17.5 / 100;
        double asc2_asc3 = 19.5 / 100;
        double asc3_immo1 = 25.0 / 100;
        double immo1_immo2 = 32.0 / 100;
        double immo2_immo3 = 40.0 / 100;



        List<string> ranks = new List<string>
            {
                "Iron 1", "Iron 2", "Iron 3", "Bronze 1", "Bronze 2", "Bronze 3", "Silver 1", "Silver 2",
                "Silver 3", "Gold 1", "Gold 2", "Gold 3", "Plat 1", "Plat 2", "Plat 3", "Diamond 1", "Diamond 2",
                "Diamond 3", "Ascendant 1", "Ascendant 2", "Ascendant 3", "Immortal 1", "Immortal 2", "Immortal 3"
            };

        public Form1()
        {
            InitializeComponent();

        }

        List<RankInfo> rankPrice;
        private void Form1_Load(object sender, EventArgs e)
        {
            rankPrice = new List<RankInfo>
            {
                new RankInfo("Iron 1", i1_i2), new RankInfo("Iron 2", i2_i3), new RankInfo("Iron 3", i3_b1), new RankInfo("Bronze 1", b1_b2),
                new RankInfo("Bronze 2", b2_b3), new RankInfo("Bronze 3", b3_s1), new RankInfo("Silver 1", s1_s2), new RankInfo("Silver 2", s2_s3),
                new RankInfo("Silver 3", s3_g1), new RankInfo("Gold 1", g1_g2), new RankInfo("Gold 2", g2_g3), new RankInfo("Gold 3", g3_p1),
                new RankInfo("Plat 1", p1_p2), new RankInfo("Plat 2", p2_p3), new RankInfo("Plat 3", p3_d1), new RankInfo("Diamond 1", d1_d2),
                new RankInfo("Diamond 2", d2_d3), new RankInfo("Diamond 3", d3_asc1), new RankInfo("Ascendant 1", asc1_asc2),
                new RankInfo("Ascendant 2", asc2_asc3), new RankInfo("Ascendant 3", asc3_immo1), new RankInfo("Immortal 1", immo1_immo2),
                new RankInfo("Immortal 2", immo2_immo3)
            };

            listBox1.Items.AddRange(ranks.ToArray());
            listBox2.Items.AddRange(ranks.ToArray());

            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string currentRank = listBox1.SelectedItem.ToString();
            string targetRank = listBox2.SelectedItem.ToString();
            double currentRR = double.Parse(textBox1.Text);
            double targetRR = double.Parse(textBox2.Text);

            if (ranks.IndexOf(currentRank) > ranks.IndexOf(targetRank))
            {
                MessageBox.Show("Current rank must be lower than the target rank.");
                return;
            }

            double totalCost = 0;

            bool currentRankReached = false;

            foreach (var rank in rankPrice)
            {
                if (rank.RankName == currentRank)
                {
                    totalCost = totalCost + ((100 - currentRR) * rank.RankPrice);
                    currentRankReached = true;
                    continue;
                }
                if (currentRankReached == false)
                {
                    continue;
                }
                if (rank.RankName != targetRank)
                {
                    totalCost = totalCost + (100 * rank.RankPrice);
                }
                else
                {
                    totalCost = totalCost + (targetRR * rank.RankPrice);
                    break;
                }
            }
           label3.Text = $"Total Price: \n[{totalCost.ToString()} €]";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

    }
}
