using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kutyak
{
    public partial class MainWindow : Window
    {
        List<Kutya> dogInfos = new();
        Dictionary<int, string> dogNames = new();
        Dictionary<int, List<string>> dogSpecies = new();
        
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            dogNames.Clear();
            StreamReader nameSr = new("KutyaNevek.csv");
            while (!nameSr.EndOfStream)
            {
                string line = nameSr.ReadLine();
                dogNames.Add(int.Parse(line.Split(";")[0]), line.Split(";")[1]);
            }

            dogSpecies.Clear();
            StreamReader specSr = new("KutyaFajtak.csv");
            while (!specSr.EndOfStream)
            {
                string line = specSr.ReadLine();
                string[] lines = {$"{lines.Split(";")[1]}"};
                dogSpecies.Add(int.Parse(line.Split(";")[0]), line.Split(";")[1], line.Split(";")[2]);
            }





            dogInfos.Clear();
            StreamReader sr = new("Kutyak.csv");
            while (!sr.EndOfStream)
            {
                string[] lines = sr.ReadLine().Split(";");
                Kutya newDogInfo = new Kutya(int.Parse(lines[0]), int.Parse(lines[1]), int.Parse(lines[2]), int.Parse(lines[3]), int.Parse(lines[4]));
                dogInfos.Add(newDogInfo);
            }
            sr.Close();
        }
    }
}
