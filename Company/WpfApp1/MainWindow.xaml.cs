//Вариант 18 -> Вариант 8
using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    public enum Company
    {
        Управление, 
        Разработка,
        Остальное
    }
    
    
    abstract public class Employee
    {
        private string c_name;
        private int c_salary;
        private double c_experience;
        private Company c_department;
        private string c_position;


        public Employee(string name, int salary, double experience, Company department, string position)
        {
            c_name = name;
            c_salary = salary;
            c_experience = experience;
            c_department = department;
            c_position = position;
        }

        public string Name
        {
            get
            {
                return c_name;
            }
            set
            {
                if (value != Name)
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        Name = value;
                    }
                    else if (value == null)
                    {
                        throw new ArgumentNullException($"{nameof(Name)} не может быть null", nameof(Name));
                    }
                    else
                    {
                        throw new ArgumentException($"{nameof(Name)} не может быть пустой или содержать только пробелы", nameof(Name));
                    }
                }
            }
        }
        public int Salary
        {
            get
            {
                return c_salary;
            }
            set
            {
               
            }
        }

        public double Experience
        {
            get
            {
                return c_experience;
            }
            set
            {

            }
        }
        public Company Department
        {
            get
            {
                return c_department;
            }
            set
            {

            }
        }
        public string Position
        {
            get
            {
                return c_position;
            }
            set
            {

            }
        }

    };

    public class Principal : Employee
    {
        public Principal(string name, int salary, double experience, string position) :
            base (name, salary, experience, Company.Управление, position)
        {

        }
    }
        
    public class Manager : Employee
    {
        public Manager(string name, int salary, double experience, string position) :
            base(name, salary, experience, Company.Управление, position)
        {

        }
    }

    public class Programmer : Employee
    {
        public Programmer(string name, int salary, double experience, string position) :
            base(name, salary, experience, Company.Разработка, position)
        {

        }
    }

    public class Cleaner : Employee
    {
        public Cleaner(string name, int salary, double experience, string position) :
            base(name, salary, experience, Company.Остальное, position)
        {

        }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

     

        List<Employee> Atmoslayerion = new List<Employee>();
        string[] Splitter = { " ", ";", "/",".",":"};

        public void PrintList(List <Employee> Ink, Company Department)
        {
            Tb1.Text = $"Люди, работающие в отделе {Department}: \n";
            for (int i = 0; i < Ink.Count; i++)
            {
                if (Ink[i].Department == Department)
                {
                    Tb1.Text += $"Имя: {Ink[i].Name}, Зарплата: {Ink[i].Salary}, Стаж: {Ink[i].Experience}, Должность: {Ink[i].Position} \n";
                }
            }
        }

        public void SalarySum(List<Employee> Ink, Company Department)
        {
            int salarysum = 0;
            int quantity = 0;
            double result = 0;

            for (int i = 0; i < Ink.Count; i++)
            {
                if (Ink[i].Department == Department)
                {
                    salarysum += Ink[i].Salary;
                    quantity++;
                }
            }
            result = salarysum / quantity;
            result = Math.Round(result, 3);
            Tb1.Text = $"Средняя зарплата в отделe {Department}: {result} \n";
        }

        public void ExperienceSum(List<Employee> Ink)
        {
            double experiencesum = 0;
            int quantity = 0;
            double result = 0;


            for (int i = 0; i < Ink.Count; i++)
            {
                experiencesum += Ink[i].Experience;
                quantity++;
            }
            result = experiencesum / quantity;
            result = Math.Round(result, 3);
            Tb1.Text = $"Средний опыт работы в компании: {result} \n";
        }


        public MainWindow()
        {
            InitializeComponent();

            Atmoslayerion.Add(new Principal("Игорь Смирнов", 100000, 30.5, "Директор"));
            Atmoslayerion.Add(new Manager("Сергей Светлов", 80500, 18.2, "Менджер"));
            Atmoslayerion.Add(new Programmer("Александр Семёнов", 70100, 15.2, "Программист"));
            Atmoslayerion.Add(new Cleaner("Пётр Иванов", 30500, 5, "Уборщик"));

        }

        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
           
            
            if (Cb2.SelectedIndex == -1)
            {
                Tb1.Text = "А что искать? Нужно выбрать необходимую информацию";
                
                return;
            }

            else
            {
                switch(Cb2.SelectedIndex)
                {
                    case 0:
                        switch (Cb1.SelectedIndex)
                        {
                            case -1:
                                
                                Tb1.Text = "А где искать? Нужно выбрать отдел";
                                break;


                            case 0:

                                PrintList(Atmoslayerion, Company.Управление);

                                break;
                            case 1:

                                PrintList(Atmoslayerion, Company.Разработка);

                                break;
                            case 2:

                                PrintList(Atmoslayerion, Company.Остальное);

                                break;
                        }
                        break;
                    case 1:
                        {
                            switch (Cb1.SelectedIndex)
                            {
                                case -1:

                                    Tb1.Text = "А где искать? Нужно выбрать отдел";
                                    break;
                                case 0:

                                   SalarySum(Atmoslayerion, Company.Управление);

                                    break;
                                case 1:

                                    SalarySum(Atmoslayerion, Company.Разработка);

                                    break;
                                case 2:

                                    SalarySum(Atmoslayerion, Company.Остальное);
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            ExperienceSum(Atmoslayerion);
                            break;
                        }
                }

            }
        }

        private void Bt2_Click(object sender, RoutedEventArgs e)
        {
            string[] text = Tb2.Text.Split(Splitter,System.StringSplitOptions.RemoveEmptyEntries);
            bool flag = false;

            try
            {
                string name = text[0];
                name += " ";
                name += text[1];
                int salary = int.Parse(text[2]);
                double experience = double.Parse(text[3]);
                string department = text[4];

                if (text[4] == "Директор")
                {
                    Atmoslayerion.Add(new Principal(name, salary, experience, department));
                    flag = true;

                }
                if (text[4] == "Программист")
                {
                    Atmoslayerion.Add(new Programmer(name, salary, experience, department));
                    flag = true;
                }
                if (text[4] == "Менеджер")
                {
                    Atmoslayerion.Add(new Manager(name, salary, experience, department));
                    flag = true;
                }
                if (text[4] == "Уборщик")
                {
                    Atmoslayerion.Add(new Cleaner(name, salary, experience, department));
                    flag = true;
                }

                if (flag == true)
                {
                    Tb2.Text = "Работник добавлен!";
                }
                else
                {
                    Tb2.Text = "Что-то пошло не так";
                }

            }
            catch 
            {
                Tb1.Text = "Ошибка во ведённых данных";
                Tb2.Text = "";
            }

        }

        private void Bt3_Click(object sender, RoutedEventArgs e)
        {
            string[] text = Tb2.Text.Split(Splitter,System.StringSplitOptions.RemoveEmptyEntries);
            bool flag = false;
            try
            {
                string name = text[0];
                name += " ";
                name += text[1];
                int salary = int.Parse(text[2]);
                double experience = double.Parse(text[3]);
                string department = text[4];

                for (int i=0; i < Atmoslayerion.Count; i++)
                {
                    if (name == Atmoslayerion[i].Name && salary == Atmoslayerion[i].Salary && experience == Atmoslayerion[i].Experience)
                    {
                        Atmoslayerion.Remove(Atmoslayerion[i]);
                        flag = true;
                    }
                
                }
                if (flag == true)
                {
                    Tb2.Text = "Работник удалён(";
                }
                else
                {
                    Tb2.Text = "Такого работника не нашли";
                }

            }
            catch (Exception ex)
            {
                Tb1.Text = "Ошибка во ведённых значениях";
                Tb2.Text = "";
            }
        }

        private void Bt4_Click(object sender, RoutedEventArgs e)
        {
            Tb1.Text = "Приветствуем в поисковике работников нашей компании. С помощью верхнего Combobox можно выбрать, отдел, для которого вы хотите найти нужную информацию. Выбрать необходимую информацию можно в нижнем Combobox. Обращаем внимание на то, что вычисление средней зарплаты проводится для выбранного отдела, вычисление среднего стажа проводится для всей компании, выбирать отдел для этой операции не требуется. Если вы желаете добавить сотрудника, впишите информацию о нём в левый TextBox по орбразцу: Имя, Фамилия, Зарплата, Опыт работы (в годах, если значение не целое, используете запятую), Должность (в нашей компании работают директора, менеджеры, программисты и уборщики). В качестве разделителей можно использовать пробел, двоеточие, точку с запятой, слэш. Запятую использовать не стоит. Более подробно формат списка можно посмотреть, если найти всех работников соответствующего отдела. Для удаления работника введите всю информацию в том же формате.  ";
        }
    }
}
