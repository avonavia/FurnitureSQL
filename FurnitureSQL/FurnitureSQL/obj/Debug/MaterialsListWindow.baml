   M S B A M L   `   `   `  ����G  CFurnitureSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FurnitureSQLFurnitureSQL  5   	   &     FurnitureSQL.MaterialsListWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FurnitureSQL     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Материалы��5	   	   $	��450��6   $	��800��6(   .��5
      � ���	#FFF1F5FB.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MaterialGrid��5         SelectionMode$ Extended=�6)      SelectionUnit$ FullRow=�6B      AutoGenerateColumns .     
IsReadOnly . $	��250��6�   $	��250��6�   $	��760��6�   $	��760��6�   $��13(�6�   $��Center=�6�   $��Center=�6�   $��	0,0,0,100q�6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Артикул��6@   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *Number+6@     5      $ Название��6>   	 6%   �� *Name+6>     5      $' !Единица измерения��6A   	 6%   �� *	Measure+6A     5      $ 
Длина��6@   	 6%   �� *Length+6@     5      $ Тип��6>   	 6%   �� *Type+6>     5      $ Цена��6>   	 6%   �� *Cost+6>     5      $ ГОСТ��6B   	 6%   �� *
Criteria+6B     5      $ Количество��6>   	 6%   �� *Quan+6>     5      $ Поставщик��6B   	 6%   �� *
Supplier+6B     5      $+ %Время доставки (мес.)��6E   	 6%   �� *DeliverTime+6E     5      $ Качество��6A   	 6%   �� *	Quality+6A     5      $ Статус��6@   	 6%   �� *Status+6@   5      �� 5   
   -   5        
 ��Name$
 
Add_button��5      $'��!Добавить материал��6%   $��Right=�6A   $��39��6]   $��Bottom=�6i   $	��200��6�   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	0,0,20,60q�6�   6  �� 5   
   -   5        $
 Redact_button��5      $1��+Редактировать материал��6(   $��Right=�6I   $��39��6e   $��Bottom=�6q   $	��200��6�   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	0,0,20,10q�6   6  �� 5   
   -   5         ��Name$ 
QualityBox��5      $��30��6'   $	��166��63   $	��166��6?   $��30��6N   $��Center=�6]   $��Bottom=�6z   $��
0,0,310,60q�6�   6�   �� 5   
   $3��-Сортировать по качеству:��6   $��Center=�63   $��33��6P   $��
0,0,310,90q�6\   $��Bottom=�6p   $	��170��6�   $��Proxima Nova)�6�   $
��Bold"�6�   �� 5!   
   -   5        $
 Back_button��5!      $��
Назад��6&   $
��Left=�66   $��39��6Q   $��Bottom=�6]   $	��100��6x   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	10,0,0,60q�6  �� 5"   
   -   5        $
 Exit_button��5"      $��
Выйти��6&   $
��Left=�66   $��39��6Q   $��Bottom=�6]   $	��100��6x   ���	#FF89C2EF���	#FF1B262C$��Proxima Nova)�6�   $��15(�6�   $
��Bold"�6�   $��	10,0,0,10q�6  5#      5$      