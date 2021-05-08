using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        public Random rnd = new Random();
        public const int TeamCount = 8;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Team> teams = new List<Team>();
            teams = initTeam(teams);
            Game(teams);
        }

        public void Game(List<Team> teams)
        {
            resultLabel.Text = "";
            resultLabel2.Text = "";
            int winScore = 0;
            for (var i = 0; i < TeamCount - 1; i++)
            {
                if (i < 3)
                {
                    resultLabel.Text += "Team " + (i + 1);
                    for (var j = i + 1; j < TeamCount; j++)
                    {
                        resultLabel.Text += " vs Team" + (j + 1) + ": " + match(teams[i], teams[j]) + "\n            ";
                    }
                    resultLabel.Text += "\n";
                }
                else
                {
                    resultLabel2.Text += "Team " + (i + 1);
                    for (var j = i + 1; j < TeamCount; j++)
                    {
                        resultLabel2.Text += " vs Team" + (j + 1) + ": " + match(teams[i], teams[j]) + "\n            ";
                    }
                    resultLabel2.Text += "\n";
                }
                if (winScore < teams[i].goals)
                {
                    winScore = teams[i].goals;
                }
            }
            showWinners(teams, winScore);
        }

        public void showWinners(List<Team> teams, int winScore)
        {
            winnerLabel.Text = "";
            for (var i = 0; i < teams.Count; i++)
            {
                if (teams[i].goals == winScore)
                {
                    winnerLabel.Text += "Team " + (i + 1) + "\n";
                }
            }
        }


        public string match(Team t, Team s)
        {
            int goalsT, goalsS; double sum = 0;
            for (goalsT = -1; sum >= -t.lambda; goalsT++)
                sum += Math.Log(rnd.NextDouble());
            t.goals += goalsT; sum = 0;
            for (goalsS = -1; sum >= -s.lambda; goalsS++)
            {
                sum += Math.Log(rnd.NextDouble());
            }
            s.goals += goalsS;
            var ans = goalsT.ToString() + " : " + goalsS.ToString();
            return ans;
        }


        private List<Team> initTeam(List<Team> t)
        {
            t.Add(new Team() { lambda = (int)lambda1.Value, goals = 0 });
            t.Add(new Team() { lambda = (int)lambda2.Value, goals = 0 });
            t.Add(new Team() { lambda = (int)lambda3.Value, goals = 0 });
            t.Add(new Team() { lambda = (int)lambda4.Value, goals = 0 });
            t.Add(new Team() { lambda = (int)lambda5.Value, goals = 0 });
            t.Add(new Team() { lambda = (int)lambda6.Value, goals = 0 });
            t.Add(new Team() { lambda = (int)lambda7.Value, goals = 0 });
            t.Add(new Team() { lambda = (int)lambda8.Value, goals = 0 });
            return t;
        }
    }

    public class Team
    {
        public int lambda, goals;
    }

}
