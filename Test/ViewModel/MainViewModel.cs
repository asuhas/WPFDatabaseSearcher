using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Test.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }

    public class Person : MainViewModel
    {
        public string _name;
        private RelayCommand docommand;

        public string Name
        {

            get { return _name; }
            set { Set("Name", ref _name, value);
                RaisePropertyChanged("Name");
            }
        }

        public RelayCommand DOCommand { get { return docommand ?? new RelayCommand(DO); } }

        public Person()
        {
            docommand = new RelayCommand(DO);
        }

        public void DO()
        {
            Name = "Aish";
        }
    }


    public class DictionaryPoplatorViewModel : MainViewModel
    {
        IModel datasource;
       
        string _key1;
        double _key2;
        string _key3;
        private ObservableCollection<ModelDataStructure> _data;
        public RelayCommand GetDataCommand
        {
            get
            {
                return new RelayCommand(GetData, () =>
                {
                    if(Key1 != string.Empty && Key3?.Length > 2 && Key2 != 0)
                    {

                        GetDataCommand.RaiseCanExecuteChanged();

                        return true;
                    }
                    else
                    {
                        return false;
                    }


                });
            }
            private set{ }
        }

        private void GetData()
        {
            Data.Clear();
            // Bool controlling fancy spinny thing on
            // advantage of using view model is you can use tasks/threads so that you dont have to do WORK on the UI thread. You can show some
            // fancy spinny thing while the work is being performed
            Task.Factory.StartNew<IEnumerable<ModelDataStructure>>(() => {
                return datasource.GetData(_key1, _key2, _key3);
            })
            .ContinueWith(t=> {
                Data = new ObservableCollection<ModelDataStructure>(t.Result);
            },TaskScheduler.FromCurrentSynchronizationContext());
            // Bool controlling fancy spinny thing off

            // Uncomment this line , comment the Task and see your UI freeze when you click the button
            // Data = new ObservableCollection<ModelDataStructure>(datasource.GetData(_key1, _key2, _key3));
        }

        public string Key1
        {
            get { return _key1; }
            set { Set(ref _key1, value); }
        }

        public double Key2
        {
            get { return _key2; }
            set { Set(ref _key2, value); }
        }
        public string Key3
        {
            get { return _key3; }
            set { Set(ref _key3, value); }
        }
        public ObservableCollection<ModelDataStructure> Data { get { return _data; } set { Set(ref _data, value); } }


        public DictionaryPoplatorViewModel(IModel model)
        {
            datasource = model;
           
        }
    }
}