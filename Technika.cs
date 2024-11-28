using System;

namespace Practik_5
{
    public class Technika
    {
        private string _brand;
        private string _model;
        private string _color;

        public string Brand
        {
            get { return _brand; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _brand = value;
                }
                else
                {
                    throw new ArgumentException("Марка не может быть пустой.");
                }
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _model = value;
                }
                else
                {
                    throw new ArgumentException("Модель не может быть пустой.");
                }
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _color = value;
                }
                else
                {
                    throw new ArgumentException("Цвет не может быть пустым.");
                }
            }
        }

        public Technika(string brand = "None", string model = "None", string color = "None")
        {
            Brand = brand;
            Model = model;
            Color = color;
        }

        public virtual string GetInfo()
        {
            return $"Марка: {Brand}, Модель: {Model}, Цвет: {Color}";
        }

        public override string ToString()
        {
            return $"Марка: {Brand}, Модель: {Model}, Цвет: {Color} (Техника)";
        }
    }

    public class Television : Technika
    {
        private int _screenSize;

        public int ScreenSize
        {
            get { return _screenSize; }
            set
            {
                if (value >= 0)
                {
                    _screenSize = value;
                }
                else
                {
                    throw new ArgumentException("Размер экрана должен быть неотрицательным.");
                }
            }
        }

        public Television(string brand = "", string model = "", string color = "", int screenSize = 0)
            : base(brand, model, color)
        {
            ScreenSize = screenSize;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Размер экрана: {ScreenSize} дюймов";
        }

        public override string ToString()
        {
            return base.ToString() + $", Размер экрана: {ScreenSize} дюймов (Телевизор)";
        }

    }

    public class Radio : Technika
    {
        private int _numberOfStations;

        public int NumberOfStations
        {
            get { return _numberOfStations; }
            set
            {
                if (value >= 0)
                {
                    _numberOfStations = value;
                }
                else
                {
                    throw new ArgumentException("Количество станций должно быть неотрицательным.");
                }
            }
        }

        public Radio(string brand = "", string model = "", string color = "", int numberOfStations = 0)
            : base(brand, model, color)
        {
            NumberOfStations = numberOfStations;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Количество станций: {NumberOfStations}";
        }

        public override string ToString()
        {
            return base.ToString() + $", Количество станций: {NumberOfStations} (Радио)";
        }

    }
}
