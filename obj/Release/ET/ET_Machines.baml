   M S B A M L   `   `   `  ����   MachineDefiner#    MachineDefiner.ET.ET_Machines   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � Title$0 *Работа с оборудованием��$	��450��$	��500��$	��450��$	��500��.��� -   $��mainGrid��$��5q� � ColumnDefinitions �� ��  � RowDefinitions �� $
��AUto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto ��� $��40 �.+��� $��0��$��0,10,0,0q�   TextTextBlock#��[  Название�� $��0��$��0,10,0,0q�$��1��  	InputText#��[ ����  �� Path$
 Name��� $��1��$��0,10,0,0q�#��[  Тип печати�� $��1��$��0,10,0,0q�$��1��#��[ ���� $ 	PrintType�&   System.Windows.Controls.DataGrid  -   $��mainDG��$��5q�$��2��$��2��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ Параметр��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� $
 Name�  $
 AUto $ Значение��	 �� $ Value��� $��0,10,0,0q�$��3��#��[  Параметр�� -   $��cb_characteristics��$��0,10,0,0q�
 �� SelectedValuePath$
 Id�� �� DisplayMemberPath$
 Name��$��3��$��1��  simpleCombobox#��[ �� $��0,10,0,0q�$��4��#��[  Значение�� $��0,10,0,0q� �� Orientation$ Vertical=�$��4��$��1��.+��� -   $��cb_value��$y�	Collapsed=�#��[ �� -   $��ch_value��$y�	Collapsed=�  SimpleCheckBox#��[ �� -   $��tb_value��$y�	Collapsed=�#��[ �� $ 
Horizontal=�$��1��$��5��$��Right=�.+��� -   $��5q�.���� $��/Images/plus.png���� -	   $��5q�.���� $��/Images/delete.png���� -
   $��5q�.���� $��/Images/save.png���� -   $��0��$��8��$	��100��$��5q�$
��Left=�$��Отмена��