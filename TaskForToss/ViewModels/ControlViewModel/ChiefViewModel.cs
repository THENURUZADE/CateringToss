using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskForToss.Command.Commands.Chiefs;
using TaskForToss.Enums;
using TaskForToss.Models;

namespace TaskForToss.ViewModels.ControlViewModel
{
    public class ChiefViewModel : BaseControlViewModel
    {
        public override string Header => "Şeflər";
        public ChiefViewModel()
        {
            selectedChief = new ChiefModel();
            currentChief = new ChiefModel();
            //commusionModel = new CommusionModel<T>();
            //CurrentChief.EffectiveDate = new  DateTime(Day, Month, Year);

        }

        private ChiefModel currentChief;
        public ChiefModel CurrentChief
        {
            get => currentChief;
            set
            {
                currentChief = value;
                OnPropertyChanged(nameof(CurrentChief));
            }
        }

        private ChiefModel selectedChief;
        public ChiefModel SelectedChief
        {
            get => selectedChief;
            set
            {
                selectedChief = value;
                OnPropertyChanged(nameof(SelectedChief));

                if (SelectedChief != null)
                {
                    ChiefModel model = new ChiefModel();
                    model.Name = SelectedChief.Name;
                    model.No = SelectedChief.No;
                    model.Phone = SelectedChief.Phone;
                    model.Month = SelectedChief.EffectiveDate.Month;
                    model.Day = SelectedChief.EffectiveDate.Day;
                    model.Year = SelectedChief.EffectiveDate.Year;
                    model.Email = SelectedChief.Email;
                    model.Id = SelectedChief.Id;

                    CurrentChief = model;

                    CurrentSituation = (int)Situation.SELECTED;
                }
                else
                {
                    CurrentChief = null;
                }
            }
        }
        public List<int> Months { get; } = new List<int>() { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12 };
        public List<int> Days { get; } = new List<int>() { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        public List<int> Years { get; } = new List<int>() { 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 };
        public List<ChiefModel> AllChiefs { get; set; } = new List<ChiefModel>();

        private ObservableCollection<ChiefModel> chiefs = new ObservableCollection<ChiefModel>();
        public ObservableCollection<ChiefModel> Chiefs
        {
            get => chiefs;
            set
            {
                chiefs = value;
                OnPropertyChanged(nameof(Chiefs));

            }
        }

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));

                List<ChiefModel> searchedLists = AllChiefs.Where(x => x.Name.Contains(SearchText) ||
                                                                 x.Email.Contains(SearchText)  ||
                                                                 x.Phone.Contains(SearchText)).ToList();
                Chiefs.Clear();
                foreach (var item in searchedLists)
                {
                    Chiefs.Add(item);
                }
            }
        }
        public SaveChiefCommand Save => new SaveChiefCommand(this);
        public RejectChiefCommand Reject => new RejectChiefCommand(this);
        public DeleteChiefCommand Delete => new DeleteChiefCommand(this);
    }
}
