using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        IDbCrud tm;

        public MainWindowViewModel(IDbCrud tm)
        {
            this.tm = tm;
            Cities = new ObservableCollection<CityModel>(tm.GetCities());
            Categories = new ObservableCollection<CategoryModel>(tm.GetCategories());
            Types = new ObservableCollection<TypeModel>(tm.GetTypes());
            InitContent();
            GetEvents(filterByCity.ID, filterByCity.ID);

        }

        private ObservableCollection<EventModel> events;
        public ObservableCollection<EventModel> Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



        public void GetEvents(int city, int category)
        {
            switch (category)
            {
                case 1:
                    Events = new ObservableCollection<EventModel>(tm.GetEventsCity(city));
                    break;
                default:
                    Events = new ObservableCollection<EventModel>(tm.GetEventsCity(city).Where(e => e.CategoryId == category));
                    break;
            }

        }

        public void GetEventsByType(int city, int category, int type)
        {
            Events = new ObservableCollection<EventModel>(tm.GetEventsCity(city));

            if (category > 1)
                Events = new ObservableCollection<EventModel>(Events.Where(e => e.CategoryId == category));
            if (type > 1)
                Events = new ObservableCollection<EventModel>(Events.Where(e => e.TypeId == type));

        }




        private void InitContent()
        {
            filterByType = Types[0];
            filterByCity = Cities[0];
            filterByCategory = Categories[0];
            OnPropertyChanged("FilterByCity");
            OnPropertyChanged("FilterByCategory");
            OnPropertyChanged("FilterByType");
        }



        #region Filters
        public ObservableCollection<CategoryModel> Categories { get; set; }
        public ObservableCollection<TypeModel> Types { get; set; }
        public ObservableCollection<CityModel> Cities { get; set; }

        private CityModel filterByCity;
        public CityModel FilterByCity
        {
            get { return filterByCity; }
            set
            {
                filterByCity = value;

                if (filterByCategory == null)
                {
                    filterByCategory = Categories[0];
                    OnPropertyChanged("FilterByCategory");
                }

                GetEvents(filterByCity.ID, filterByCategory.ID);

                OnPropertyChanged("FilterByCity");

                filterByType = Types[0];
                OnPropertyChanged("FilterByType");
            }
        }
        private CategoryModel filterByCategory;
        public CategoryModel FilterByCategory
        {
            get { return filterByCategory; }
            set
            {
                filterByCategory = value;


                GetEvents(filterByCity.ID, filterByCategory.ID);
                OnPropertyChanged("FilterByCategory");

                filterByType = Types[0];
                OnPropertyChanged("FilterByType");


            }
        }

        private TypeModel filterByType;
        public TypeModel FilterByType
        {
            get { return filterByType; }
            set
            {
                filterByType = value;
                GetEventsByType(filterByCity.ID, filterByCategory.ID, filterByType.ID);
                OnPropertyChanged("FilterByType");
            }
        }


        #endregion


    }


}



