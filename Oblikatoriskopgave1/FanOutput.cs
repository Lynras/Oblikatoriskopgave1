using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Oblikatoriskopgave1
{
    public class FanOutput
    {
        public string _name;
        public double _temp;
        public double _humidity;
        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name is less that 2 characters");

                }
                else
                {
                    _name = value;
                }
            }
        }

        public double Temp
        {
            get { return _temp; }
            set
            {
                if (value >= 15 && value <= 25)
                {
                    _temp = value;
                }
                else
                {
                    throw new ArgumentException("Temp is less than 15 and higher than 25");
                }
            }
        }

        public int Humidity
        {
            get { return (int)_humidity; }
            set
            {
                if (value >= 30 && value <= 80)
                {
                    _humidity = value;
                }
                else
                {
                    throw new ArgumentException("Du er enten for tør eller for fugtig");
                }


            }
        }


        public FanOutput(int id, string name, double temp, int humidity)
        {
            Id = id;
            Name = name;
            Temp = temp;
            Humidity = humidity;

        }

        public FanOutput()
        {

        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Temp)}: {Temp}, {nameof(Humidity)}: {Humidity}";
        }
    }
}
