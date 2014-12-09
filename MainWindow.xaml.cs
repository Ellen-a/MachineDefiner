using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MachineDefiner.ET;
using MachineDefiner.Model;

namespace MachineDefiner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private int tableType = 1;
        private List<Characteristic> finderCharacter;
       public static  Repository rp = new Repository();
        private void Define(object sender, RoutedEventArgs e)
        {

            ListCollectionView collection = new ListCollectionView(rp.Machines);
            collection.GroupDescriptions.Add(new PropertyGroupDescription("PrintType"));
            mainDGMachine.ItemsSource = collection;
            mainDGMachine.Items.Refresh();

            dataGrid.ColumnDefinitions[0].Width = new GridLength(250,GridUnitType.Pixel);
            filter_char.Children.Clear();

            if (rp == null) return;

            finderCharacter = rp.Characteristics.OrderBy(s => s.OrderNumber).ToList();

            foreach (var characteristic in finderCharacter)
            {
                switch (characteristic.ValueType)
                {
                        case Characteristic.ItemType.ItBool:
                        {
                            var cont = new StackPanel
                                {
                                    Orientation = Orientation.Horizontal,
                                    Margin = new Thickness(5)
                                };
                            var lb = new Label {Content = characteristic.Name};
                            var dataElem = new CheckBox
                                {
                                    Name = "name_" + characteristic.Id.ToString().Replace('-', '_'),
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    VerticalAlignment = VerticalAlignment.Center,
                                    Margin = new Thickness(15,0,0,0)
                                };
                            cont.Children.Add(lb);
                            cont.Children.Add(dataElem);
                            filter_char.Children.Add(cont);
                            break;
                        }
                        case Characteristic.ItemType.ItInt:
                        case Characteristic.ItemType.ItString:
                        {
                            var lb = new Label { Content = characteristic.Name };
                            var dataElem = new TextBox
                            {
                                Name = "name_" + characteristic.Id.ToString().Replace('-', '_'),
                                Margin = new Thickness(5)
                            };
                            filter_char.Children.Add(lb);
                            filter_char.Children.Add(dataElem);
                            break;
                        }
                        case Characteristic.ItemType.ItList:
                        {
                            var lb = new Label { Content = characteristic.Name };
                            var dataElem = new ComboBox
                            {
                                Name ="name_"+characteristic.Id.ToString().Replace('-','_'),
                                Margin = new Thickness(5),
                                ItemsSource = characteristic.ValueItemsList
                            };
                            filter_char.Children.Add(lb);
                            filter_char.Children.Add(dataElem);
                            break;
                        }
                }
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            dataGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
            mainDGMachine.Visibility = Visibility.Visible;
            rp.LoadCharacteristics();
            rp.LoadMathines();

            ColumnBilder();
            ListCollectionView collection = new ListCollectionView(rp.Machines);
            collection.GroupDescriptions.Add(new PropertyGroupDescription("PrintType"));
            mainDGMachine.ItemsSource = collection;
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            rp.SaveCharacteristics();
            rp.SaveMathines();
        }
        /// <summary>
        /// добавление отсутствующих характеристик 
        /// </summary>
        private void NormalizeMachine()
        {
            // перебор характеристик
            foreach (var characteristic in rp.Characteristics)
            {
                // перебор всего оборудования
                foreach (var machine    in rp.Machines)
                {
                    // найти характеристику
                    var mChar = machine.Characteristic.FirstOrDefault(s => s.Id == characteristic.Id);
                    if (mChar == null)
                    {
                        // добавление характеристики
                        machine.Characteristic.Add(new MachineCharactericticItem()
                            {
                                Id = characteristic.Id,
                                Name = characteristic.Name,
                                Value = characteristic.DefaultValue
                            });
                    }
                    else
                    {
                        mChar.Name = characteristic.Name;
                    }
                }    
            }
            
        }

        private void ColumnBilder()
        {
            NormalizeMachine();

            // удалить лишние столбцы
            int columnCount = mainDGMachine.Columns.Count-1;
            for (var i = 2; i < columnCount; i++)
            {
                mainDGMachine.Columns.RemoveAt(2);
            }
            // создать столбцы
            foreach (var t in rp.Characteristics)
            {
                var  tc = new DataGridTextColumn();
                tc.Header = t.Name;
                tc.Binding = new Binding(string.Format("CharacteristicValues[{0}]", t.Id));
                mainDGMachine.Columns.Add(tc);
            }
        }

        private void addItem(object sender, RoutedEventArgs e)
        {
            switch (tableType)
            {
                case 1:
                    {
                        var etM = new ET_Machines(new Machine());
                        etM.ShowDialog();
                        if (etM.IsOperationComplete)
                        {
                            rp.Machines.Add(etM.Context);
                            mainDGMachine.Items.Refresh();
                        }
                        break;
                    }
                case 2:
                    {
                        var etP = new ET_Properties(new Characteristic());
                        etP.ShowDialog();
                        if (etP.IsOperationComplete)
                        {
                            rp.Characteristics.Add(etP.Context);
                            mainDGProperties.Items.Refresh();
                        }
                        break;
                    }
            }
        }

        private void editItem(object sender, RoutedEventArgs e)
        {
            switch (tableType)
            {
                case 1:
                    {
                        var currItem = mainDGMachine.SelectedItem as Machine;
                        if (currItem != null)
                        {
                            var etP = new ET_Machines(currItem);
                            etP.ShowDialog();
                            mainDGMachine.Items.Refresh();
                        }
                        rp.SaveMathines();
                        break;
                    }
                case 2:
                    {
                        var currItem = mainDGProperties.SelectedItem as Characteristic;
                        if (currItem!=null)
                        {
                            var etP = new ET_Properties(currItem);
                            etP.ShowDialog();
                            mainDGProperties.Items.Refresh();
                            foreach (var oneMachine in rp.Machines )
                            {
                                var editItem = oneMachine.Characteristic.FirstOrDefault(s => s.Id == currItem.Id);
                                if (editItem != null)
                                {
                                    editItem.Name = currItem.Name;
                                }

                            }
                        }
                        rp.SaveCharacteristics();
                        break;
                    }
            }

        }

        private void deleteItem(object sender, RoutedEventArgs e)
        {
            switch (tableType)
            {
                case 1:
                    {
                        rp.SaveMathines();
                        break;
                    }
                case 2:
                    {
                        var currItem = mainDGProperties.SelectedItem as Characteristic;
                        if (currItem != null)
                        {
                            if (
                                MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.OKCancel,
                                                MessageBoxImage.Question) == MessageBoxResult.OK)
                            {
                                foreach (var machine in rp.Machines)
                                {
                                    var delItem = machine.Characteristic.FirstOrDefault(s => s.Id == currItem.Id);
                                    if (delItem != null)
                                    {
                                        machine.Characteristic.Remove(delItem);
                                    }
                                }
                                rp.Characteristics.Remove(currItem);
                                mainDGProperties.Items.Refresh();
                                rp.SaveMathines();
                                rp.SaveCharacteristics();
                            }
                        }
                        break;
                    }
            }
        }

        private void showMachines(object sender, RoutedEventArgs e)
        {
            tableType = 1;
            mainDGMachine.Visibility = Visibility.Visible;
            mainDGProperties.Visibility = Visibility.Collapsed;
            mainDGMachine.ItemsSource = rp.Machines;
        }

        private void showCharacterictics(object sender, RoutedEventArgs e)
        {
            tableType = 2;
            mainDGProperties.Visibility = Visibility.Visible;
            mainDGMachine.Visibility = Visibility.Collapsed;
            mainDGProperties.ItemsSource = rp.Characteristics;
        }

        private void changeTab(object sender, SelectionChangedEventArgs e)
        {
            mainDGMachine.Visibility = Visibility.Collapsed;
            mainDGProperties.Visibility = Visibility.Collapsed;
            dataGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Pixel);
            
        }

        private void findItems(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> filterParams = new Dictionary<string, string>();
            foreach (var oneElem in filter_char.Children)
            {
                if (oneElem is TextBox)
                {
                    var elem = oneElem as TextBox;
                    var id = elem.Name.Substring(5).Replace("_", "-");
                    filterParams.Add(id, elem.Text);
                }
                if (oneElem is StackPanel)
                {
                    foreach (var filterParam in (oneElem as StackPanel).Children)
                    {
                        if (filterParam is CheckBox)
                        {
                            var elem = filterParam as CheckBox;
                            var id = elem.Name.Substring(5).Replace("_", "-");
                            filterParams.Add(id, elem.IsChecked == null ? "False" : elem.IsChecked.Value.ToString());
                        }
                    }
                }
                if (oneElem is ComboBox)
                {
                    var elem = oneElem as ComboBox;
                    var id = elem.Name.Substring(5).Replace("_", "-");
                    if (elem.SelectedValue!=null)
                    filterParams.Add(id, elem.SelectedValue.ToString());
                }
            }
            // список значений фильтра
            var rezMachines = rp.Machines;
            filterParams = filterParams.Where(s => s.Value != "All" && !string.IsNullOrEmpty(s.Value)).ToDictionary(s=>s.Key,s=>s.Value);
            // если просто поиск
            if (!ch_smartSearch.IsChecked==true)
            {
                foreach (var filterParam in filterParams)
                {
                    var charact = rp.Characteristics.FirstOrDefault(s => s.Id.ToString() == filterParam.Key);
                    if (charact != null)
                    {
                        switch (charact.ValueType)
                        {
                            case Characteristic.ItemType.ItBool:
                                {
                                    var strValue = filterParam.Value.ToUpper() == "TRUE" ? "Да" : "Нет";
                                    rezMachines =
                                        rezMachines.Where(
                                            s => s.Characteristic.First(p => p.Id == charact.Id).Value == strValue)
                                                   .ToList();
                                    break;
                                }
                            case Characteristic.ItemType.ItString:
                                {
                                    var strValue = filterParam.Value;
                                    rezMachines =
                                        rezMachines.Where(
                                            s =>
                                            s.Characteristic.First(p => p.Id == charact.Id).Value.Contains(strValue))
                                                   .ToList();
                                    break;
                                }
                            case Characteristic.ItemType.ItInt:
                                {
                                    var strValue = filterParam.Value;
                                    rezMachines =
                                        rezMachines.Where(
                                            s => s.Characteristic.First(p => p.Id == charact.Id).Value == strValue)
                                                   .ToList();
                                    break;
                                }
                            case Characteristic.ItemType.ItList:
                                {
                                    var strValue = filterParam.Value;
                                    rezMachines =rezMachines.Where(s => (s.Characteristic.First(p => p.Id == charact.Id).Value == strValue) || (s.Characteristic.First(p => p.Id == charact.Id).Value == "All")).ToList();
                                    break;
                                }
                        }
                    }
                }
                
            }
                // если умный фильтр
            else
            {
                // сброс значений
                foreach (var rezMachine in rezMachines)
                {
                    rezMachine.coefficientSumm = 0;
                }
                foreach (var rezMachine in rezMachines)
                {
                    foreach (var filterParam in filterParams)
                    {
                        var charact = rp.Characteristics.FirstOrDefault(s => s.Id.ToString() == filterParam.Key);
                        if (charact != null)
                        {
                            switch (charact.ValueType)
                            {
                                case Characteristic.ItemType.ItBool:
                                    {
                                        var strValue = filterParam.Value.ToUpper() == "TRUE" ? "Да" : "Нет";
                                        //если значение совпадает
                                        if (rezMachine.Characteristic.First(s => s.Id == charact.Id).Value == strValue)
                                            rezMachine.coefficientSumm += charact.Coefficient;
                                        break;
                                    }
                                case Characteristic.ItemType.ItString:
                                    {
                                        var strValue = filterParam.Value;
                                        //если значение совпадает
                                        if (rezMachine.Characteristic.First(s => s.Id == charact.Id).Value.Contains(strValue))
                                            rezMachine.coefficientSumm += charact.Coefficient;
                                        break;
                                    }
                                case Characteristic.ItemType.ItInt:
                                    {
                                        decimal dc ;
                                        if (decimal.TryParse(filterParam.Value, out dc))
                                        {
                                            var currChar =
                                                rezMachine.Characteristic.First(s => s.Id == charact.Id).Value;
                                            decimal currVal;
                                            if (decimal.TryParse(currChar, out currVal))
                                            {
                                                if (currVal == dc)
                                                {
                                                    rezMachine.coefficientSumm += charact.Coefficient;
                                                }
                                                else
                                                {
                                                    decimal A = dc;
                                                    decimal B = currVal;
                                                    decimal C = charact.Coefficient;
                                                    double rez = 0;
                                                    decimal D = Math.Abs(B - A);

                                                    if (D < B)
                                                    {
                                                        rez = 1 - (double)D/(double)B;
                                                        rezMachine.coefficientSumm += Math.Round(rez * (double)C, 2);
                                                    }

                                                }
                                            }
                                        }
                                        break;
                                    }
                                case Characteristic.ItemType.ItList:
                                    {
                                        var strValue = filterParam.Value;
                                        //если значение совпадает
                                        if (rezMachine.Characteristic.First(s => s.Id == charact.Id).Value == strValue || rezMachine.Characteristic.First(s => s.Id == charact.Id).Value=="All")
                                            rezMachine.coefficientSumm += charact.Coefficient;
                                        break;
                                    }
                            }
                        }
                    } 
                }
                rezMachines = rezMachines.OrderByDescending(s => s.coefficientSumm).ToList();
            }
            if (!string.IsNullOrEmpty(tb_Name.Text))
                rezMachines = rezMachines.Where(s => s.Name.Contains(tb_Name.Text)).ToList();
            if (ch_smartSearch.IsChecked == true)
            {
                if (rezMachines.Count > 0 && rezMachines[0].coefficientSumm!=0)
                {
                    MessageBox.Show(string.Format("Самый оптимальный вариант {0}.",rezMachines[0].Name), "Поиск оборудования", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Невозможно определить записи", "Уточните поиск", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            ListCollectionView collection = new ListCollectionView(rezMachines);
            collection.GroupDescriptions.Add(new PropertyGroupDescription("PrintType"));
            mainDGMachine.ItemsSource = collection;

        }

        private void resetFilter(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
