   M S B A M L   `   `   `  ����  MachineDefiner#    MachineDefiner.ET.ET_Machines   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � 
ResizeMode$  NoResize=�5   K    � WindowStartupLocation$ CenterScreen=�5   @    � Title$0 *Работа с оборудованием��5   	   $	��450��6(   $	��500��65   $	��450��6A   $	��500��6Q   .��5      � -   5        $��mainGrid��5      $��5q�6    � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5
   
   �� 5      $
��AUto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��0,10,0,0q�6!      TextTextBlock#��[  63   Название6d   �� 5   
   $��0��6   $��0,10,0,0q�6   $��1��61     	InputText#��[ 6\   ��6A   ��  �� Path$
 Name�6�   �� 5   
   $��1��6   $��0,10,0,0q�6!   #��[  63   Тип печати6f   �� 5   
   $��1��6   $��0,10,0,0q�6   $��1��61   #��[ 6a   ��6A   �� $ 	PrintType�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��mainDG��5      $��5q�6!   $��2��6,   $��2��69      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Параметр��6M   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6/   �� $
 Name�6a     5      $
 AUto 6%   $ Значение��6Q   	 62   �� $ Value�6e   5      �� 5   
   $��0,10,0,0q�6   $��3��6&   #��[  63   Параметр6d   �� 5!   
   -   5        $��cb_characteristics��5!   U   $��0,10,0,0q�6   
 �� SelectedValuePath$
 Id��6%    �� DisplayMemberPath$
 Name��6<   $��3��5"      $��1��6      simpleCombobox#��[ 60   6X   �� 5$   
   $��0,10,0,0q�6   $��4��6&   #��[  63   Значение6d   �� 5%   
   $��0,10,0,0q�6    �� Orientation$ Vertical=�6'   $��4��6>   $��1��6K   .+�5&      �� -   5        $��cb_value��5&   .   $y�	Collapsed=�6   #��[ 6>   �� 5'      -   5        $��ch_value��5'   .   $y�	Collapsed=�6     SimpleCheckBox#��[ 6>   �� 5(      -   5        $��tb_value��5(   .   $y�	Collapsed=�6   #��[ 6>   5)      �� 5+   
   $ 
Horizontal=�6   $��1��6.   $��5��6>   $��Right=�6K   .+�5,      �� -   5        $��5q�5,      .��5-      �� $��/Images/plus.png��6   64   5.      �� 5/      -	   5        $��5q�5/      .��50      �� $��/Images/delete.png��6   66   51      �� 52      -
   5        $��5q�52      .��53      �� $��/Images/save.png��6   64   54      55      �� 57   
   -   5        $��0��57      $��8��6!   $	��100��6.   $��5q�6:   $
��Left=�6E   $��Отмена��6`   6q   59      5:      