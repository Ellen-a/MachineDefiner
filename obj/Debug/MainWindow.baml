   M S B A M L   `   `   `  ����  MachineDefiner    MachineDefiner.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        1  +System.Windows.Controls.Ribbon.RibbonWindow   Name$  RibbonWindow��5   	    � Icon$ 	image.ico��5   	    � Title$O IПрограмма для определения оборудования��6    � WindowStartupLocation$ CenterScreen=�5      $	��640��5   	   $	��480��6   .��5      � -   5         �Name$ 
LayoutRoot��5       � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  -   5          Name$ Ribbon��5         Title$  ��6!      ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�	Collapsed=�6(   5      .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $��Главная��6   .@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  $��Действия��6   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        	   LargeImageSource$	 Images/poligraf.png��5   5   
   Label$#
 Просмотр данных��6\   6v     5      -   5        $	 Images/search.png��5   3   $3
 -Определить оборудование��6X   6z   5      5        5      $��Справочники��6   .@�5        .@�5        -   5        $
 Станки��5   #   $	 Images/poligraf.png��62   6Y     5      -   5        $"
 Характеристики��5   #   $	 Images/config.png��6:   6_     5      -   5        $	 Images/save.png��5   5   $
 Сохранить��6X   6l   5        5       $��Действия��6   .@�5!        -	   5        $
 Добавить��5!   #   $	 Images/plus.png��64   6W     5"      -
   5        $
 Изменить��5"   #   $	 Images/edit.png��64   6W     5#      -   5        $
 Удалить��5#   #   $	 Images/delete.png��63   6X   5$      5%      5&      � 5'   
   -   5        $��dataGrid��5'      $��1��6    � ColumnDefinitions 5(      �� 5)      $	��230 �6#   �� 5*      $��* �6#   .+�5,      �� $��0��6   .��5-      �� $��5q�6    �� Orientation$ Vertical=�6(   .+�5.      �� .��6   Название6"   �� 5/      -   5        $��tb_Name��5/      6,   �� 51      -   5        $��filter_char��51   4   $ Vertical=�6   52      �� 54      $ 
Horizontal=�6   $��5q�66   .+�55      �� .��6   Умный поиск6)   �� 56      -   5        $��ch_smartSearch��56      $��10,0,0,0q�65   $��Center=�57      $��Center=�6<   �� 58      -   5        $��40,0,0,0q�58      $��30��6/   $��30��6;   .��59      �� $��/Images/reset.png��6    5:      �� 5;      -   5        $��5,0,0,0q�5;      $��30��6.   $��30��6:   .��5<      �� $��/Images/search.png��6    5=      5>      5?      5@      &   System.Windows.Controls.DataGrid  5A      -   5        $��mainDGMachine��5A   '   $��1��6      AutoGenerateColumns .   �� 
GroupStyle 5B      (  "System.Windows.Controls.GroupStyle  5C         GroupHeaderStyle   ContainerStyle# [  6!      Panel 5D      �� 5E      .R�5F   "   >	  8System.Windows.Controls.Primitives.DataGridRowsPresenter	  5G      5I         Columns 5K      0
  *System.Windows.Controls.DataGridTextColumn
  5L      ,  &System.Windows.Controls.DataGridColumn   Header$/ )Название оборудования��6)      MinWidth$	 150Q�6H      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   ��  �� Path$
 Name�
  5M      $ Тип печати��6)   $ * 6>   $	 100Q�6H    6W   �� $ 	PrintType�4  .System.Windows.Controls.DataGridTemplateColumn  5N      $ Общий балл��6.      CellTemplate 5O      �� 5P      .R�5Q   "   ��  �� TextAlignment$ Right=�6,   ��6B   �� $ coefficientSumm�5R      5T      5W        5X      -   5        $��mainDGProperties��5X   (   $��1��6    .  $y�	Collapsed=�6\    5Y      
  5Z      $ * 6)   $ Название��63    6E   �� $
 Name�
  5\      $ Тип данных��6)    6=   �� $ ValueTypeName�
  5]      $ Порядок��6)    6:   �� $ OrderNumber�
  5_      $# Список значений��6)    6B   �� $ 
ValueItems�  5a      $ По умолчанию��6-    5b      �� 5c      .R�5d   "   �� $ Right=�6,   ��6B   �� $ DefaultValue�5e      5g        5i      $ Коэффициент��6.    5j      �� 5k      .R�5l   "   �� $ Center=�6,   ��6C   �� $ Coefficient�5m      5o        5q      $ Базовая��6.    5r      �� 5s      .R�5t   "   �� $ Center=�6,   ��6C   �� $ IsNecessaryUI�5u      5w      5y      5z      5|      5}      