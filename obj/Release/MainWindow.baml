   M S B A M L   `   `   `  ����   MachineDefiner    MachineDefiner.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   1  +System.Windows.Controls.Ribbon.RibbonWindow   Name$  RibbonWindow�� � Icon$ 	image.ico�� � Title$O IПрограмма для определения оборудования�� � WindowStartupLocation$ CenterScreen=�$	��640��$	��480��.��� -    �Name$ 
LayoutRoot�� � RowDefinitions �� $
��Auto ��� $��* �.+�+  %System.Windows.Controls.Ribbon.Ribbon  -     Name$ Ribbon��   Title$  ��   ApplicationMenu :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  $y�	Collapsed=�.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��Главная��.@�0  *System.Windows.Controls.Ribbon.RibbonGroup  $��Действия��.@�1  +System.Windows.Controls.Ribbon.RibbonButton  -   	   LargeImageSource$	 Images/poligraf.png��
   Label$#
 Просмотр данных��  -   $	 Images/search.png��$3
 -Определить оборудование��  $��Справочники��.@�  .@�  -   $
 Станки��$	 Images/poligraf.png��  -   $"
 Характеристики��$	 Images/config.png��  -   $	 Images/save.png��$
 Сохранить��  $��Действия��.@�  -	   $
 Добавить��$	 Images/plus.png��  -
   $
 Изменить��$	 Images/edit.png��  -   $
 Удалить��$	 Images/delete.png��� -   $��dataGrid��$��1�� � ColumnDefinitions �� $	��230 ��� $��* �.+��� $��0��.���� $��5q� �� Orientation$ Vertical=�.+��� .��Название�� -   $��tb_Name���� -   $��filter_char��$ Vertical=��� $ 
Horizontal=�$��5q�.+��� .��Умный поиск�� -   $��ch_smartSearch��$��10,0,0,0q�$��Center=�$��Center=��� -   $��40,0,0,0q�$��30��$��30��.���� $��/Images/reset.png���� -   $��5,0,0,0q�$��30��$��30��.���� $��/Images/search.png��&   System.Windows.Controls.DataGrid  -   $��mainDGMachine��$��1��   AutoGenerateColumns .   �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     GroupHeaderStyle   ContainerStyle# [     Panel �� .R�>	  8System.Windows.Controls.Primitives.DataGridRowsPresenter	     Columns 0
  *System.Windows.Controls.DataGridTextColumn
  ,  &System.Windows.Controls.DataGridColumn   Header$/ )Название оборудования��   MinWidth$	 150Q�   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$
 Name�
  $ Тип печати��$ * $	 100Q� �� $ 	PrintType�4  .System.Windows.Controls.DataGridTemplateColumn  $ Общий балл��   CellTemplate �� .R���  �� TextAlignment$ Right=����� $ coefficientSumm�  -   $��mainDGProperties��$��1�� .  $y�	Collapsed=� 
  $ * $ Название�� �� $
 Name�
  $ Тип данных�� �� $ ValueTypeName�
  $ Порядок�� �� $ OrderNumber�
  $# Список значений�� �� $ 
ValueItems�  $ По умолчанию�� �� .R��� $ Right=����� $ DefaultValue�  $ Коэффициент�� �� .R��� $ Center=����� $ Coefficient�  $ Базовая�� �� .R��� $ Center=����� $ IsNecessaryUI�