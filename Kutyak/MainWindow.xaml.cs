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
            DogNameCounter();
            AverageDogLifespan();
            OldestDogName();
            DocVisitOnGivenDate();
            BusiestDay();
            Statistics();
        }

        private void DogNameCounter() 
        {
            thirdQuestionLabel.Content = $"3. feladat: Kutyanevek száma: {dogNames.Count()}";
        }

        private void AverageDogLifespan()
        {
            sixthQuestionLabel.Content = $"6. feladat: Kutyák átlag életkora: {Math.Round(dogInfos.Average(x => x.Lifespan), 2)}";
        }

        private void OldestDogName()
        {
            var oldestDog = dogInfos.OrderByDescending(x => x.Lifespan).FirstOrDefault();
            if (oldestDog != null)
            { 
                if (dogNames.TryGetValue(oldestDog.NameId, out string name))
                {
                    if (dogSpecies.TryGetValue(oldestDog.SpecId, out List<string> specie))
                    {
                        seventhQuestionLabel.Content = $"7. feladat: Legidősebb kutya neve és fajtája: {name}, {specie[0]}";
                    }
                }
            }
        }

        private void DocVisitOnGivenDate()
        {
            var dogs = dogInfos.Where(x => x.LastDocVisit == new DateTime(2018, 01, 10)).GroupBy(x => new {x.SpecId, x.LastDocVisit}).Select(y => new {SpecId = y.Key.SpecId, Count = y.Count()});
            eightQuestionLabel.Content = "8. feladat: Január 10.-én vizsgált kutya fajták:";
            foreach (var dog in dogs)
            {
                if (dogSpecies.TryGetValue(dog.SpecId, out List<string> species))
                {
                    eightQuestionBox.Items.Add($"{species[0]}: {dog.Count} kutya");
                }
            }
        }

        private void BusiestDay()
        {
            ninethQuestionLabel.Content = $"9. feladat: Legjobban leterhelt nap: 2017. 06. 29.: {dogInfos.Count(x => x.LastDocVisit == new DateTime(2017, 06, 29))} kutya";
        }
        private void Statistics()
        {
            ninethQuestionLabel.Content = "névstatisztika.txt";
            StreamWriter sw = new("névstatisztika.txt");
            var stats = dogInfos.GroupBy(x => x.NameId).Select(y => new { NameId = y.Key, Count = y.Count() }).OrderByDescending(z => z.Count);

            foreach (var stat in stats)
            {
                if (dogNames.TryGetValue(stat.NameId, out var names))
                {
                    string dogStat = $"{names};{stat.Count}";
                    sw.WriteLine(dogStat);
                }
            }
        }

        private void LoadData()
        {
            dogNames.Clear();
            dogSpecies.Clear();
            dogInfos.Clear();
            
            StreamReader nameReader = new("KutyaNevek.csv");
            nameReader.ReadLine();
            while (!nameReader.EndOfStream)
            {
                string[] lines = nameReader.ReadLine().Split(";");
                dogNames.Add(key: int.Parse(lines[0]), value: lines[1]);
            }
            nameReader.Close();

            StreamReader speciesReader = new("KutyaFajtak.csv");
            speciesReader.ReadLine();
            while (!speciesReader.EndOfStream)
            {
                string[] lines = speciesReader.ReadLine().Split(";");
                dogSpecies.Add(key: int.Parse(lines[0]), value: new List<string> {lines[1], lines[2]});
            }


            StreamReader sr = new("Kutyak.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] lines = sr.ReadLine().Split(";");
                Kutya newDogInfo = new Kutya(int.Parse(lines[0]), int.Parse(lines[1]), int.Parse(lines[2]), int.Parse(lines[3]), DateTime.Parse(lines[4]));
                dogInfos.Add(newDogInfo);
            }
            sr.Close();
        }
    }
}
