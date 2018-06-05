using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace SampleApp.Model
{
    public class Person:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        private string _firstname;
        private string _lastname;
        public string FirstName {
            get { return _firstname; }
            set
            {
                if (_firstname == value)
                {
                    return;
                }

                _firstname = value;
                OnPropertyChanged();

            }
        }

        public string LastName {
            get { return _lastname; }
            set
            {
                if (_lastname == value)
                {
                    return;
                }

                _lastname = value;
                OnPropertyChanged();

            }
        }

        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
