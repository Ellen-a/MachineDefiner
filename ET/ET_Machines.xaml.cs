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
using System.Windows.Shapes;
using MachineDefiner.Model;

namespace MachineDefiner.ET
{
    /// <summary>
    /// Логика взаимодействия для ET_Machines.xaml
    /// </summary>
    public partial class ET_Machines : Window
    {
        public Machine Context;
        public bool IsOperationComplete;
        public ET_Machines(Machine context)
        {
            InitializeComponent();
            Context = context ?? new Machine();
            if (Context.Characteristic == null)
            {
                Context.Characteristic = new List<MachineCharactericticItem>();
            }
            mainGrid.DataContext = Context;

            mainDG.ItemsSource = null;
            mainDG.ItemsSource = Context.Characteristic;

        }

        private void load(object sender, RoutedEventArgs e)
        {
            // ввыбор только новых характеристик
            cb_characteristics.ItemsSource = MainWindow.rp.Characteristics;
        }

        private void cb_characteristics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var characteristic = cb_characteristics.SelectedItem as Characteristic;
            if (characteristic != null)
            {
                cb_value.ItemsSource = characteristic.ValueItemsList;

                ch_value.Visibility = Visibility.Collapsed;
                tb_value.Visibility = Visibility.Collapsed;
                cb_value.Visibility = Visibility.Collapsed;

                switch (characteristic.ValueType)
                {
                    case Characteristic.ItemType.ItBool:
                        {
                            ch_value.Visibility = Visibility.Visible;
                            ch_value.IsChecked = false;
                            if (characteristic.DefaultValue.ToUpper() == "ДА")
                            {
                                ch_value.IsChecked = true;
                            }
                            break;
                        }
                    case Characteristic.ItemType.ItInt:
                        {
                            tb_value.Visibility = Visibility.Visible;
                            tb_value.Text = characteristic.DefaultValue;
                            break;
                        }
                    case Characteristic.ItemType.ItList:
                        {
                            cb_value.Visibility  =Visibility.Visible;
                            cb_value.SelectedItem = characteristic.ValueItemsList.FirstOrDefault(s => s == characteristic.DefaultValue);
                            break;
                        }
                    case Characteristic.ItemType.ItString:
                        {
                            tb_value.Visibility = Visibility.Visible;
                            tb_value.Text = characteristic.DefaultValue;
                            break;
                        }
                }

                
                
            }

        }

        private void AddCharacteristic(object sender, RoutedEventArgs e)
        {
            string errorMessage = string.Empty;
            var currChar = cb_characteristics.SelectedItem as Characteristic;
            if (currChar != null)
            {
                switch (currChar.ValueType)
                {
                        case Characteristic.ItemType.ItBool:
                        {
                            currChar.Value = ch_value.IsChecked == null ? "Нет" : ch_value.IsChecked.Value?"Да":"Нет";
                            break;
                        }
                        case Characteristic.ItemType.ItString:
                        {
                            if (string.IsNullOrEmpty(tb_value.Text))
                            {
                                errorMessage = "Введите значение";
                            }
                            else
                            {
                                currChar.Value = tb_value.Text;
                            }
                            break;
                        }
                        case Characteristic.ItemType.ItInt:
                        {
                            decimal val;
                            if(Decimal.TryParse(tb_value.Text,out val))
                            {
                                currChar.Value = val.ToString();
                            }
                            else
                            {
                                errorMessage = "Введите числовое значение";
                            }
                            break;
                        }
                        case Characteristic.ItemType.ItList:
                        {
                              if (cb_value.SelectedItem != null)
                              {
                                  currChar.Value = cb_value.SelectedItem.ToString();
                              }
                              else
                              {
                                  errorMessage = "Выберите значение";
                              }
                            break;
                        }
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage, "Ошибка ввода", MessageBoxButton.OK,
                                           MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(currChar.Value))
                {
                    MessageBox.Show("Введите значение параметра", "Ошибка ввода", MessageBoxButton.OK,
                                            MessageBoxImage.Error);
                    return;
                }

                var editItem = Context.Characteristic.FirstOrDefault(s => s.Id == currChar.Id);
                if (editItem != null)
                {
                    editItem.Value = currChar.Value;
                }
                else
                {
                    Context.Characteristic.Add(new MachineCharactericticItem(){Id = currChar.Id,Name = currChar.Name,Value = currChar.Value});
                    
                }
                mainDG.ItemsSource = null;
                mainDG.ItemsSource = Context.Characteristic;
            }

        }

        private void DeleteCurrentCharacteristic(object sender, RoutedEventArgs e)
        {
            var deleteChar = mainDG.SelectedItem as MachineCharactericticItem;
            if (deleteChar == null) return;
            if (
                MessageBox.Show("Удалить текущую характеристику?", "Удаление записи", MessageBoxButton.OKCancel,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
            {

                Context.Characteristic.Remove(deleteChar);
                mainDG.ItemsSource = null;
                mainDG.ItemsSource = Context.Characteristic;
            }
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Context.Name))
            {
                MessageBox.Show("Введите название оборудования", "Ошибка ввода", MessageBoxButton.OK,
                                          MessageBoxImage.Error);
            }
            if (Context.Characteristic.Count == 0)
            {
                MessageBox.Show("Укажите характеристики оборудования", "Ошибка ввода", MessageBoxButton.OK,
                                          MessageBoxImage.Error);
            }
            IsOperationComplete = true;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsOperationComplete = false;
            this.Close();
        }
    }
}
