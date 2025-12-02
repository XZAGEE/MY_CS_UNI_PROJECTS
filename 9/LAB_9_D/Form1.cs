using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LAB_9_D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Team
        {
            public string LeaguePrefix { get; set; }
            public string Name { get; set; }
            public string City { get; set; }

            public Team(string leaguePrefix, string name, string city)
            {
                this.LeaguePrefix = leaguePrefix;
                this.Name = name;
                this.City = city;
            }

            public override string ToString()
            {
                return $"{LeaguePrefix} - {City} {Name}";
            }
        }

        public class TeamCollection
        {
            private struct LeaguePrefix
            {
                public string Prefix;
                public string Sport;
            }

            private LeaguePrefix[] validPrefixes;
            private Team[] teams;

            public int Length;
            public int ErrorCode;

            public TeamCollection(int size)
            {
                teams = new Team[size];
                Length = size;
                SetupPrefixes();
            }

            private void SetupPrefixes()
            {
                validPrefixes = new LeaguePrefix[4];
                validPrefixes[0].Prefix = "NBA"; validPrefixes[0].Sport = "Basketball";
                validPrefixes[1].Prefix = "NFL"; validPrefixes[1].Sport = "Football";
                validPrefixes[2].Prefix = "MLB"; validPrefixes[2].Sport = "Baseball";
                validPrefixes[3].Prefix = "NHL"; validPrefixes[3].Sport = "Hockey";
            }

            private bool IsValidIndex(int i)
            {
                return (i >= 0 && i < Length);
            }

            private bool IsValidPrefix(string prefix)
            {
                return validPrefixes.Any(p => p.Prefix.Equals(prefix, StringComparison.OrdinalIgnoreCase));
            }

            public Team this[int index]
            {
                get
                {
                    if (IsValidIndex(index))
                    {
                        ErrorCode = 0;
                        return teams[index];
                    }
                    else
                    {
                        ErrorCode = 1;
                        return null;
                    }
                }
                set
                {
                    if (!IsValidIndex(index))
                    {
                        ErrorCode = 1;
                        return;
                    }

                    if (!IsValidPrefix(value.LeaguePrefix))
                    {
                        ErrorCode = 2;
                        return;
                    }

                    teams[index] = value;
                    ErrorCode = 0;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Operation Log:\n";
            label2.Text = "Team Roster (Filtered):\n";
            StringBuilder log = new StringBuilder();

            TeamCollection leagueRoster = new TeamCollection(5);

            Team team1 = new Team("NBA", "Lakers", "Los Angeles");
            Team team2 = new Team("NFL", "Cowboys", "Dallas");
            Team team3 = new Team("MLB", "Yankees", "New York");
            Team team4 = new Team("NFL", "Patriots", "New England");
            Team team5_badPrefix = new Team("SOCCER", "United", "Manchester");
            Team team6_outOfBounds = new Team("NBA", "Heat", "Miami");

            leagueRoster[0] = team1;
            log.AppendLine($"Added {team1.ToString()} | Error: {leagueRoster.ErrorCode}");
            leagueRoster[1] = team2;
            log.AppendLine($"Added {team2.ToString()} | Error: {leagueRoster.ErrorCode}");
            leagueRoster[2] = team3;
            log.AppendLine($"Added {team3.ToString()} | Error: {leagueRoster.ErrorCode}");

            leagueRoster[3] = team5_badPrefix;
            log.AppendLine($"Attempted to add {team5_badPrefix.ToString()} | Error: {leagueRoster.ErrorCode}");

            leagueRoster[4] = team4;
            log.AppendLine($"Added {team4.ToString()} | Error: {leagueRoster.ErrorCode}");

            leagueRoster[5] = team6_outOfBounds;
            log.AppendLine($"Attempted to add {team6_outOfBounds.ToString()} at index 5 | Error: {leagueRoster.ErrorCode}");

            label1.Text = log.ToString();

            StringBuilder roster = new StringBuilder();
            bool filterNBA = checkBoxFilter.Checked;

            roster.AppendLine(filterNBA ? "--- Displaying ONLY NBA Teams ---" : "--- Displaying All Valid Teams ---");

            for (int i = 0; i < leagueRoster.Length; i++)
            {
                Team currentTeam = leagueRoster[i];

                if (currentTeam != null && leagueRoster.ErrorCode == 0)
                {
                    if (!filterNBA || currentTeam.LeaguePrefix.Equals("NBA", StringComparison.OrdinalIgnoreCase))
                    {
                        roster.AppendLine($"[{i}] {currentTeam.ToString()}");
                    }
                }
                else if (currentTeam == null && leagueRoster.ErrorCode == 1)
                {
                    roster.AppendLine($"[{i}] Index read error (Index out of bounds)");
                }
            }

            label2.Text = roster.ToString();
        }
    }
    }
